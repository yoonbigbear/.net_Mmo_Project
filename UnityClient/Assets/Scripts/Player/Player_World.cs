
using Google.FlatBuffers;
using System.Security.Cryptography;
using System;
using UnityEngine;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine.Tilemaps;

public partial class Player
{
	public void EnterServer_Req()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(64);
		EnterServerReqT req = new();
		req.AcctId = network.AccountId;
		fbb.Finish(EnterServerReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.EnterServerReq, fbb.Offset, fbb.SizedByteArray());
	}

	public void EnterLobby_Req()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(64);
		EnterLobbyReqT req = new();
		fbb.Finish(EnterLobbyReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.EnterLobbyReq, fbb.Offset, fbb.SizedByteArray());
	}

	public void EnterWorld_Req(uint worldId)
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(64);
		EnterWorldReqT req = new();
		req.WorldId = worldId;
		fbb.Finish(EnterWorldReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.EnterWorldReq, fbb.Offset, fbb.SizedByteArray());
	}

	public void MoveScene_Req(uint worldId)
	{
		if (worldId == WorldId)
			return;

		FlatBufferBuilder fbb = new FlatBufferBuilder(64);
		MoveSceneReqT req = new();
		req.WorldId = WorldId;
		fbb.Finish(MoveSceneReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.MoveSceneReq, fbb.Offset, fbb.SizedByteArray());
	}

	public void MovePortal_Req(uint portalId)
	{
		Debug.Assert(TableData.Instance.PortalTable.HasKey(portalId));

		var table = TableData.Instance.PortalTable[portalId];

		FlatBufferBuilder fbb = new FlatBufferBuilder(64);
		MovePortalReqT req = new();
		req.PortalId = portalId;
		fbb.Finish(MovePortalReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.MovePortalReq, fbb.Offset, fbb.SizedByteArray());
	}

	protected void EnterLobby_Resp(ArraySegment<byte> data)
	{
		Debug.Log($" EnterLobby Resp {ObjId}");

		ByteBuffer bb = new ByteBuffer(data.Array);
		EnterLobbyRespT resp = EnterLobbyResp.GetRootAsEnterLobbyResp(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		try
		{
			resp.CharList.ForEach(ch => {

			});


			//var charInfo = nfy.CharList.First();

			//FlatBufferBuilder fbb = new FlatBufferBuilder(256);
			//EnterReqT req = new();
			//req.WorldId = charInfo.WorldId;
			//fbb.Finish(EnterReq.Pack(fbb, req).Value);

			//Packet packet = new();
			//packet.id = (short)PacketId.EnterReq;
			//packet.dataSize = fbb.Offset;
			//packet.data = fbb.SizedByteArray();

			//Send(packet);

		}
		finally
		{
			CreateCharacter_Req();

			//if (nfy.CharList.Count == 0)
			//	CreateCharacter_Req();
		};
	}
	protected void EnterWorld_Resp(ArraySegment<byte> data)
	{
		Debug.Log($"[R] Enter_Resp {ObjId}");

		ByteBuffer bb = new ByteBuffer(data.Array);
		EnterWorldRespT resp = EnterWorldResp.GetRootAsEnterWorldResp(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		ObjId = resp.ObjId;
		var transform = resp.Transform;
		mover.TransformSync(transform.Speed,
				transform.CurPos.ToUnityVector(),
				transform.EndPos.ToUnityVector(),
				transform.Dir.ToUnityVector());

		var objectBaseTable = TableData.Instance.ObjectBaseTable;
		int tid = 0;
		string resourceName;

		int i = 0;
		int count = resp.OtherObjIds.Count;
		for (; i < count; ++i)
		{
			GameObject gameObject;
			switch(resp.ObjectTypes[i])
			{
				case ObjectType.Player:
					{
						var newObject = Instantiate(Resources.Load<FieldObject>("FieldObject"));
						if (newObject)
						{
							newObject.ObjId = resp.OtherObjIds[i];
							var otherTransform = resp.OtherTransforms[i];
							var stat = resp.OtherStats[i];
							newObject.mover.TransformSync(otherTransform.Speed,
							otherTransform.CurPos.ToUnityVector(),
							otherTransform.EndPos.ToUnityVector(),
							otherTransform.Dir.ToUnityVector());
							newObject.StateUpdate(stat.Keys, stat.Values);
							Neighbors.Add(newObject.ObjId, newObject);
						}
					}
					break;
				case ObjectType.NonPlayer:
					{
						if (!objectBaseTable.HasKey(resp.ObjectTids[i]))
						{
							Debug.LogError($"No matching object table id {resp.ObjectTids[i]}");
							continue;
						}
						resourceName = objectBaseTable[resp.ObjectTids[i]].resource;
						var newObject = Instantiate(Resources.Load<Monster>(resourceName));
						if (newObject)
						{
							newObject.ObjId = resp.OtherObjIds[i];
							var otherTransform = resp.OtherTransforms[i];
							var stat = resp.OtherStats[i];
							newObject.mover.TransformSync(otherTransform.Speed,
							otherTransform.CurPos.ToUnityVector(),
							otherTransform.EndPos.ToUnityVector(),
							otherTransform.Dir.ToUnityVector());
							newObject.StateUpdate(stat.Keys, stat.Values);
							Neighbors.Add(newObject.ObjId, newObject);
						}
					}
					break;
			}
			
		}

		//test
		//Move();
	}
	protected void EnterWorld_Sync(ArraySegment<byte> data)
	{
		Debug.Log($"[R] Enter_Sync {ObjId}");

		ByteBuffer bb = new ByteBuffer(data.Array);
		EnterWorldSyncT resp = EnterWorldSync.GetRootAsEnterWorldSync(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		if (ObjId != resp.ObjId)
		{
			var newObject = Instantiate(Resources.Load<FieldObject>("FieldObject"));
			if (newObject)
			{
				newObject.ObjId = resp.ObjId;
				var otherTransform = resp.Transform;
				var stat = resp.Stat;
				newObject.mover.TransformSync(otherTransform.Speed,
				otherTransform.CurPos.ToUnityVector(),
				otherTransform.EndPos.ToUnityVector(),
				otherTransform.Dir.ToUnityVector());
				newObject.StateUpdate(stat.Keys, stat.Values);
				Neighbors.Add(newObject.ObjId, newObject);
			}
		}
	}
	protected void LeaveWorld_Sync(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		EnterWorldSyncT resp = EnterWorldSync.GetRootAsEnterWorldSync(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		Neighbors.Remove(resp.ObjId, out var obj);
		Destroy(obj.gameObject, 2);
		return;
	}

	protected void MoveScene_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		MoveSceneRespT resp = MoveSceneResp.GetRootAsMoveSceneResp(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		Debug.Assert(TableData.Instance.WorldTable.HasKey(resp.WorldId));

		var tableData = TableData.Instance.WorldTable[resp.WorldId];

		//move scene
		MoveScene(resp.WorldId);

		EnterWorld_Req(resp.WorldId);

	}
	protected void MovePortal_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		MovePortalRespT resp = MovePortalResp.GetRootAsMovePortalResp(bb).UnPack();

		if (resp.ErrorCode != 0)
			return;

		Debug.Assert(TableData.Instance.WorldTable.HasKey(resp.WorldId));

		var tableData = TableData.Instance.WorldTable[resp.WorldId];

		//move scene
		MoveScene(resp.WorldId);

		EnterWorld_Req(resp.WorldId);


	}

	protected void MoveScene(uint sceneId)
	{
		Neighbors.Clear();

		SceneManager.LoadScene(sceneId);
	}
}
