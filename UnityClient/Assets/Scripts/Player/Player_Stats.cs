using Google.FlatBuffers;
using System.Collections.Generic;
using System;
using UnityEngine.TextCore.Text;

public partial class Player
{
	public void ChangeState_Req(List<int> keys, List<long> values)
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(128);
		ChangeStateReqT req = new();

		req.Key = new();
		req.Value = new();

		req.Key.Add((int)SyncVar64.MaxHp);
		req.Value.Add(30);
		req.Key.Add((int)SyncVar64.Gold);
		req.Value.Add(30000);

		fbb.Finish(ChangeStateReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.ChangeStateReq, fbb.Offset, fbb.SizedByteArray());
	}

	//recv changed state packet
	protected void Stats_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		StateSyncT sync = StateSync.GetRootAsStateSync(bb).UnPack();

		var objId = sync.ObjId;

		if (Neighbors.ContainsKey(objId))
		{
			Neighbors[objId].StateUpdate(sync.Keys, sync.Values);
		}
		else
		{
			if (objId == this.ObjId)
			{
				StateUpdate(sync.Keys, sync.Values);
			}
		}
	}
	protected void ChangedStats_Nty(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		ChangedStatsNtyT sync = ChangedStatsNty.GetRootAsChangedStatsNty(bb).UnPack();

		var objId = sync.ObjId;

		if (Neighbors.ContainsKey(objId))
		{
			Neighbors[objId].StateUpdate(sync.Keys, sync.Values);
		}
		else
		{
			if (objId == this.ObjId)
			{
				StateUpdate(sync.Keys, sync.Values);
			}
		}
	}
	protected void Dead_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		DeadSyncT sync = DeadSync.GetRootAsDeadSync(bb).UnPack();

		var objId = sync.ObjId;

		if (Neighbors.ContainsKey(objId))
		{
			Neighbors[objId].IsDead = true;
			Neighbors[objId].DeathAni();
		}
	}
}
