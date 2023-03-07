// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct MovePortalReq : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static MovePortalReq GetRootAsMovePortalReq(ByteBuffer _bb) { return GetRootAsMovePortalReq(_bb, new MovePortalReq()); }
  public static MovePortalReq GetRootAsMovePortalReq(ByteBuffer _bb, MovePortalReq obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public MovePortalReq __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint PortalId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }

  public static Offset<MovePortalReq> CreateMovePortalReq(FlatBufferBuilder builder,
      uint portal_id = 0) {
    builder.StartTable(1);
    MovePortalReq.AddPortalId(builder, portal_id);
    return MovePortalReq.EndMovePortalReq(builder);
  }

  public static void StartMovePortalReq(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddPortalId(FlatBufferBuilder builder, uint portalId) { builder.AddUint(0, portalId, 0); }
  public static Offset<MovePortalReq> EndMovePortalReq(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<MovePortalReq>(o);
  }
  public MovePortalReqT UnPack() {
    var _o = new MovePortalReqT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(MovePortalReqT _o) {
    _o.PortalId = this.PortalId;
  }
  public static Offset<MovePortalReq> Pack(FlatBufferBuilder builder, MovePortalReqT _o) {
    if (_o == null) return default(Offset<MovePortalReq>);
    return CreateMovePortalReq(
      builder,
      _o.PortalId);
  }
}

public class MovePortalReqT
{
  [Newtonsoft.Json.JsonProperty("portal_id")]
  public uint PortalId { get; set; }

  public MovePortalReqT() {
    this.PortalId = 0;
  }
}

