using Google.FlatBuffers;
using System.Security.Cryptography;
using System;
using UnityEngine;

public partial class Player
{
	public void MoveSync(int speed, Vector3 EndPos, bool sendPacket)
	{
		mover.MoveSync(speed, EndPos);
		if (sendPacket)
			Transform_Req();
	}

	public void LookAt(Vector3 Position)
	{
		mover.Dir = Vector3.Normalize(Position - mover.Position);
	}

	public Vec3T CurPos() => mover.Position.ToVec3T();
	public Vec3T EndPos() => mover.EndPos.ToVec3T();
	public Vec3T Dir() => mover.Dir.ToVec3T();
	public TransformInfoT TransformInfo()
	{
		TransformInfoT info = new();
		info.CurPos = CurPos();
		info.EndPos = EndPos();
		info.Dir = Dir();
		info.Speed = mover.Speed;
		return info;
	}
	public void Transform_Req()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(128);
		TransformReqT req = new();

		req.Transform = TransformInfo();

		fbb.Finish(TransformReq.Pack(fbb, req).Value);

		network?.Send((short)PacketId.TransformReq, fbb.Offset, fbb.SizedByteArray());
	}
	protected void Transform_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		TransformSyncT sync = TransformSync.GetRootAsTransformSync(bb).UnPack();

		if (Neighbors.ContainsKey(sync.ObjId))
		{
			var obj = Neighbors[sync.ObjId];
			if (sync.ObjId != ObjId && sync.ObjId == obj.ObjId)
			{
				var transform = sync.Transform;

				obj.mover.Position = transform.CurPos.ToUnityVector();
				obj.mover.Dir = transform.Dir.ToUnityVector();
				obj.mover.MoveSync(transform.Speed,
					transform.EndPos.ToUnityVector());
				return;
			}
		}
	}
	protected void Transform_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		TransformRespT resp = TransformResp.GetRootAsTransformResp(bb).UnPack();

		if (resp.ErrorCode != 0)
		{
			Debug.Log($"[R] Transform Resp Err");
			return;
		}
	}
}
