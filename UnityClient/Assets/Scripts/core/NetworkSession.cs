using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System;
using UnityEngine;
using System.Drawing;

public class NetworkSession 
{
	protected Socket socket;
	protected IPEndPoint ipEndPoint;
	protected SocketAsyncEventArgs recvArgs = new SocketAsyncEventArgs();

	public Queue<Packet> msgQueue = new();

	public int AccountId { get; set; }
	public ulong CharacterId { get; set; }

	public NetworkSession(IPEndPoint iPEndPoint)
	{
		this.ipEndPoint = iPEndPoint;

		recvArgs.Completed += OnRecv;

		//should change
		byte[] bb = new byte[ushort.MaxValue];
		recvArgs.SetBuffer(bb);


		socket = new Socket(
		addressFamily: AddressFamily.InterNetwork,
		socketType: SocketType.Stream,
		protocolType: ProtocolType.Tcp);
		socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.NoDelay, true);
		socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, false);

		Connect();
	}

	~NetworkSession()
	{
		Disconnect();
	}

	void Connect()
	{
		//소켓 연결
		socket.ConnectAsync(ipEndPoint).ContinueWith((task) =>
		{
			if (task.IsCompletedSuccessfully)
			{
				Debug.Log("connected");
			}
			else
			{
				Debug.LogError("connected failure");
			}
		}).Wait();

		socket.ReceiveAsync(recvArgs);
	}

	public void Send(short id, int size, ArraySegment<byte> buf)
	{
		byte[] data = new byte[sizeof(short) + sizeof(int) + size];

		int offset = 0;
		Buffer.BlockCopy(BitConverter.GetBytes(id),
			0, data, offset, sizeof(short));
		offset += sizeof(short);
		Buffer.BlockCopy(BitConverter.GetBytes(size),
			0, data, offset, sizeof(int));
		offset += sizeof(int);
		Buffer.BlockCopy(buf.Array,
			0, data, offset, size);

		socket.Send(data);
	}


	private void OnRecv(object sender, SocketAsyncEventArgs e)
	{
		if (e.BytesTransferred != 0)
		{
			int splitSize = sizeof(short);
			int offset = 0;

			while (true)
			{
				if (offset >= e.BytesTransferred)
					break;

				Packet packet = new();
				packet.id = BitConverter.ToInt16(e.MemoryBuffer.Span.Slice(offset, splitSize));
				offset += splitSize;
				packet.bodySize = BitConverter.ToInt32(e.MemoryBuffer.Span.Slice(offset, sizeof(int)));
				offset += sizeof(int);
				packet.body = e.MemoryBuffer.Span.Slice(offset, packet.bodySize).ToArray();
				offset += packet.bodySize;

				msgQueue.Enqueue(packet);
			}

			socket.ReceiveAsync(recvArgs);
		}
		else
		{
			Debug.Log("disconnected");
		}
	}

	public void Disconnect()
	{
		try
		{
			socket.Shutdown(SocketShutdown.Both);
		}
		finally
		{
			socket.Close();
		}
	}
}