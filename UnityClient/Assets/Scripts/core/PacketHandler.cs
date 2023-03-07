
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public struct Packet
{
	public short id;
	public int bodySize;
	public byte[] body;
}

public partial class PacketHandler // main
{
	public Dictionary<PacketId, UnityEvent<ArraySegment<byte>>> packetFunc = new();

	public Queue<Packet> msgQueue;

	public void Start(Queue<Packet> queue)
	{
		packetFunc = new();
		this.msgQueue = queue;
	}

	public void RegisterRespond(PacketId protocol, UnityAction<ArraySegment<byte>> response)
	{
		if (!packetFunc.ContainsKey(protocol))
			packetFunc.Add(protocol, new());

		packetFunc[protocol].AddListener(response);
	}

	public void Update()
	{
		while (msgQueue.Count > 0)
		{
			if (msgQueue.TryDequeue(out var packet))
			{
				if (packetFunc.ContainsKey((PacketId)packet.id))
				{
					packetFunc[(PacketId)packet.id].Invoke(packet.body);
				}
				else
				{
					Debug.Log($"callback failure ID {packet.id}");
				}
			}
		}
	}
}
