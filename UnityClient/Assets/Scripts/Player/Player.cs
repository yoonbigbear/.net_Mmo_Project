using Google.FlatBuffers;
using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public partial class Player : FieldObject
{
	[SerializeField] bool Online = true;
	
	protected NetworkSession network;
	protected PacketHandler packetHandler = new();
	public Dictionary<uint, FieldObject> Neighbors = new Dictionary<uint, FieldObject>();

	const float _heartbeatRate = 3000;
	float _heartbeatTime = 0;

	const double _time_sync_interval = 10000;
	double _next_time_sync = 0;

	void Start()
	{
		TableData.Instance.Start();

		DontDestroyOnLoad(gameObject);

		Initialize();

		if (Online)
			CreateCharacter();

		packetHandler.RegisterRespond(PacketId.CreateCharacterResp, CreateCharacter_Resp);
		packetHandler.RegisterRespond(PacketId.EnterLobbyResp, EnterLobby_Resp);
		packetHandler.RegisterRespond(PacketId.EnterWorldResp, EnterWorld_Resp);
		packetHandler.RegisterRespond(PacketId.EnterWorldSync, EnterWorld_Sync);
		packetHandler.RegisterRespond(PacketId.LeaveWorldSync, LeaveWorld_Sync);
		packetHandler.RegisterRespond(PacketId.MoveSceneResp, MoveScene_Resp);
		packetHandler.RegisterRespond(PacketId.MovePortalResp, MovePortal_Resp);

		packetHandler.RegisterRespond(PacketId.TransformResp, Transform_Resp);
		packetHandler.RegisterRespond(PacketId.TransformSync, Transform_Sync);

		packetHandler.RegisterRespond(PacketId.HitSync, Hit_Sync);
		packetHandler.RegisterRespond(PacketId.AttackResp, Attack_Resp);
		packetHandler.RegisterRespond(PacketId.AttackSync, Attack_Sync);
		packetHandler.RegisterRespond(PacketId.ChangeStateResp, ChangeState_Resp);
		packetHandler.RegisterRespond(PacketId.AddItemResp, AddItem_Resp);
		packetHandler.RegisterRespond(PacketId.StateSync, Stats_Sync);
		packetHandler.RegisterRespond(PacketId.DeadSync, Dead_Sync);
		packetHandler.RegisterRespond(PacketId.ChangedStatsNty, ChangedStats_Nty);
		packetHandler.RegisterRespond(PacketId.TimeSync, Time_Sync);
	}

	void CreateCharacter()
	{
		var accountInfo = Connector.CreateAccount(DateTime.Now.ToString());
		if (!accountInfo.HasValue)
			return;

		var serverList = Connector.FetchServerList();
		if (!serverList.HasValue)
			return;

		network = new(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000));
		network.AccountId = accountInfo.Value.acctId;
		packetHandler.Start(network.msgQueue);

		EnterServer_Req();
	}

	private new void Update()
	{
		base.Update();

		if (Online)
			packetHandler.Update();

		foreach (var e in Neighbors)
		{
		}
	}

	void Time_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		TimeSyncT sync = TimeSync.GetRootAsTimeSync(bb).UnPack();

		Timer.RecvRtt();
		Timer.UnixServeTime = sync.ServerTime;
		_next_time_sync = Timer.UnixServeTime + _time_sync_interval;
	}

	//Send heartbeat to server
	void SendHeartBeat()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(1);
		HeartbeatT req = new();
		fbb.Finish(Heartbeat.Pack(fbb, req).Value);

		network?.Send((short)PacketId.Heartbeat, fbb.Offset, fbb.SizedByteArray());
	}

	void TimeSyncSend()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(1);
		TimeSyncT req = new();
		fbb.Finish(TimeSync.Pack(fbb, req).Value);
		Timer.SendRtt();
		network?.Send((short)PacketId.TimeSync, fbb.Offset, fbb.SizedByteArray());
	}
}
