
using Google.FlatBuffers;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static UnityEditor.Experimental.GraphView.GraphView;

public partial class Player
{
	public void Attack(int skillTid, Vector3 dir)
	{
		transform.LookAt(mover.Position + dir, Vector3.up);
		AttackAni();
		Attack_Req(skillTid, dir);

	}

	public void Attack_Req(int skillTid, Vector3 dir)
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(128);
		AttackReqT req = new();

		Assert.IsTrue(TableData.Instance.SkillTable.HasKey(skillTid));

		req.SkillTid = skillTid;
		req.Direction = dir.ToVec3T();

		fbb.Finish(AttackReq.Pack(fbb, req).Value);

		network?.Send((short)PacketId.AttackReq, fbb.Offset, fbb.SizedByteArray());

		inAnimation = true;
	}

	public void Hit_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		HitSyncT sync = HitSync.GetRootAsHitSync(bb).UnPack();

		Assert.IsTrue(TableData.Instance.SkillTable.HasKey(sync.SkillTid));

		var table = TableData.Instance.SkillTable[sync.SkillTid];
		int i = 0;
		int size = sync.TargetObjIds.Count;


		for (; i < size; i++)
		{
			if (!Neighbors.ContainsKey(sync.TargetObjIds[i]))
			{
				continue;
			}

			var obj = sync.TargetObjIds[i];
			var damage = sync.Damages[i];
			var position = sync.Positions[i];

			var fieldObj = Neighbors[obj];
			if (fieldObj)
			{
				DebugExtension.DebugPoint(position.ToUnityVector(), Color.blue, 1, 1, true);
			}
		}
	}
	public void Attack_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		AttackRespT resp = AttackResp.GetRootAsAttackResp(bb).UnPack();

		if (resp.ErrorCode != ErrorCode.Success)
		{
			Debug.Log($"attack failed. StopAnimation");
			inAnimation = false;
			return;
		}
		mover.TransformSync(0, 
			resp.AtkPos.ToUnityVector(), 
			resp.AtkPos.ToUnityVector(), 
			resp.Direction.ToUnityVector());
	}

	public void Attack_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		AttackSyncT sync = AttackSync.GetRootAsAttackSync(bb).UnPack();

		DebugSector(sync.SkillTid, sync.Direction.ToUnityVector(), sync.AtkPos.ToUnityVector());

		if (Neighbors.ContainsKey(sync.ObjId))
		{
			Neighbors[sync.ObjId].transform.LookAt(sync.Direction.ToUnityVector(), Vector3.up);
		}
	}

}
