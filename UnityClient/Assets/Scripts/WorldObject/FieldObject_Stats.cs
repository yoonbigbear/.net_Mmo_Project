using Google.FlatBuffers;
using System;
using System.Collections.Generic;

public partial class FieldObject
{
	public long[] Stats64 { get; set; } = new long[(int)SyncVar64.End];

	public bool IsDead { get; set; } = false;

	public void StateUpdate(List<int> keys, List<long> values)
	{
		int i = 0;
		int size = keys.Count;
		for (; i < size; ++i)
			Stats64[keys[i]] = values[i];
	}
	protected void ChangeState_Resp(ArraySegment<byte> data)
	{
		ByteBuffer bb = new ByteBuffer(data.Array);
		ChangeStateRespT resp = ChangeStateResp.GetRootAsChangeStateResp(bb).UnPack();

		try
		{
			//Do nothing
		}
		finally
		{

		};
	}
}