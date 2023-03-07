// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct AttackReq : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static AttackReq GetRootAsAttackReq(ByteBuffer _bb) { return GetRootAsAttackReq(_bb, new AttackReq()); }
  public static AttackReq GetRootAsAttackReq(ByteBuffer _bb, AttackReq obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AttackReq __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int SkillTid { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public uint TargetObjId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public Vec3? Direction { get { int o = __p.__offset(8); return o != 0 ? (Vec3?)(new Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static Offset<AttackReq> CreateAttackReq(FlatBufferBuilder builder,
      int skill_tid = 0,
      uint target_obj_id = 0,
      Vec3T direction = null) {
    builder.StartTable(3);
    AttackReq.AddDirection(builder, Vec3.Pack(builder, direction));
    AttackReq.AddTargetObjId(builder, target_obj_id);
    AttackReq.AddSkillTid(builder, skill_tid);
    return AttackReq.EndAttackReq(builder);
  }

  public static void StartAttackReq(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddSkillTid(FlatBufferBuilder builder, int skillTid) { builder.AddInt(0, skillTid, 0); }
  public static void AddTargetObjId(FlatBufferBuilder builder, uint targetObjId) { builder.AddUint(1, targetObjId, 0); }
  public static void AddDirection(FlatBufferBuilder builder, Offset<Vec3> directionOffset) { builder.AddStruct(2, directionOffset.Value, 0); }
  public static Offset<AttackReq> EndAttackReq(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AttackReq>(o);
  }
  public AttackReqT UnPack() {
    var _o = new AttackReqT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(AttackReqT _o) {
    _o.SkillTid = this.SkillTid;
    _o.TargetObjId = this.TargetObjId;
    _o.Direction = this.Direction.HasValue ? this.Direction.Value.UnPack() : null;
  }
  public static Offset<AttackReq> Pack(FlatBufferBuilder builder, AttackReqT _o) {
    if (_o == null) return default(Offset<AttackReq>);
    return CreateAttackReq(
      builder,
      _o.SkillTid,
      _o.TargetObjId,
      _o.Direction);
  }
}

public class AttackReqT
{
  [Newtonsoft.Json.JsonProperty("skill_tid")]
  public int SkillTid { get; set; }
  [Newtonsoft.Json.JsonProperty("target_obj_id")]
  public uint TargetObjId { get; set; }
  [Newtonsoft.Json.JsonProperty("direction")]
  public Vec3T Direction { get; set; }

  public AttackReqT() {
    this.SkillTid = 0;
    this.TargetObjId = 0;
    this.Direction = new Vec3T();
  }
}
