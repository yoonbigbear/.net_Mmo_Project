// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct EnterServerReq : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static EnterServerReq GetRootAsEnterServerReq(ByteBuffer _bb) { return GetRootAsEnterServerReq(_bb, new EnterServerReq()); }
  public static EnterServerReq GetRootAsEnterServerReq(ByteBuffer _bb, EnterServerReq obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public EnterServerReq __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int AcctId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<EnterServerReq> CreateEnterServerReq(FlatBufferBuilder builder,
      int acct_id = 0) {
    builder.StartTable(1);
    EnterServerReq.AddAcctId(builder, acct_id);
    return EnterServerReq.EndEnterServerReq(builder);
  }

  public static void StartEnterServerReq(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddAcctId(FlatBufferBuilder builder, int acctId) { builder.AddInt(0, acctId, 0); }
  public static Offset<EnterServerReq> EndEnterServerReq(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<EnterServerReq>(o);
  }
  public EnterServerReqT UnPack() {
    var _o = new EnterServerReqT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(EnterServerReqT _o) {
    _o.AcctId = this.AcctId;
  }
  public static Offset<EnterServerReq> Pack(FlatBufferBuilder builder, EnterServerReqT _o) {
    if (_o == null) return default(Offset<EnterServerReq>);
    return CreateEnterServerReq(
      builder,
      _o.AcctId);
  }
}

public class EnterServerReqT
{
  [Newtonsoft.Json.JsonProperty("acct_id")]
  public int AcctId { get; set; }

  public EnterServerReqT() {
    this.AcctId = 0;
  }
}
