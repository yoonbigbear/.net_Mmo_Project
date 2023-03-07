
using Google.FlatBuffers;
using System;

public partial class Player
{
	public void CreateCharacter_Req()
	{
		FlatBufferBuilder fbb = new FlatBufferBuilder(128);
		CreateCharacterReqT req = new();
		req.Name = $"char_{network.AccountId}";
		req.ClassId = 10000;
		fbb.Finish(CreateCharacterReq.Pack(fbb, req).Value);

		network.Send((short)PacketId.CreateCharacterReq, fbb.Offset, fbb.SizedByteArray());
	}


	public void CreateCharacter_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		CreateCharacterRespT resp = CreateCharacterResp.GetRootAsCreateCharacterResp(bb).UnPack();
		network.CharacterId = resp.Character.DbId;
		WorldId = resp.Character.WorldId;
		StateUpdate(resp.Keys, resp.Values);
		
		EnterWorld_Req(TableData.Instance.WorldTable[0].id);
	}
}
