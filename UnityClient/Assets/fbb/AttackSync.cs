// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct AttackSync : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static AttackSync GetRootAsAttackSync(ByteBuffer _bb) { return GetRootAsAttackSync(_bb, new AttackSync()); }
  public static AttackSync GetRootAsAttackSync(ByteBuffer _bb, AttackSync obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AttackSync __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int SkillTid { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public uint ObjId { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public Vec3? Direction { get { int o = __p.__offset(8); return o != 0 ? (Vec3?)(new Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public Vec3? AtkPos { get { int o = __p.__offset(10); return o != 0 ? (Vec3?)(new Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static Offset<AttackSync> CreateAttackSync(FlatBufferBuilder builder,
      int skill_tid = 0,
      uint objId = 0,
      Vec3T direction = null,
      Vec3T atk_pos = null) {
    builder.StartTable(4);
    AttackSync.AddAtkPos(builder, Vec3.Pack(builder, atk_pos));
    AttackSync.AddDirection(builder, Vec3.Pack(builder, direction));
    AttackSync.AddObjId(builder, objId);
    AttackSync.AddSkillTid(builder, skill_tid);
    return AttackSync.EndAttackSync(builder);
  }

  public static void StartAttackSync(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddSkillTid(FlatBufferBuilder builder, int skillTid) { builder.AddInt(0, skillTid, 0); }
  public static void AddObjId(FlatBufferBuilder builder, uint objId) { builder.AddUint(1, objId, 0); }
  public static void AddDirection(FlatBufferBuilder builder, Offset<Vec3> directionOffset) { builder.AddStruct(2, directionOffset.Value, 0); }
  public static void AddAtkPos(FlatBufferBuilder builder, Offset<Vec3> atkPosOffset) { builder.AddStruct(3, atkPosOffset.Value, 0); }
  public static Offset<AttackSync> EndAttackSync(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AttackSync>(o);
  }
  public AttackSyncT UnPack() {
    var _o = new AttackSyncT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(AttackSyncT _o) {
    _o.SkillTid = this.SkillTid;
    _o.ObjId = this.ObjId;
    _o.Direction = this.Direction.HasValue ? this.Direction.Value.UnPack() : null;
    _o.AtkPos = this.AtkPos.HasValue ? this.AtkPos.Value.UnPack() : null;
  }
  public static Offset<AttackSync> Pack(FlatBufferBuilder builder, AttackSyncT _o) {
    if (_o == null) return default(Offset<AttackSync>);
    return CreateAttackSync(
      builder,
      _o.SkillTid,
      _o.ObjId,
      _o.Direction,
      _o.AtkPos);
  }
}

public class AttackSyncT
{
  [Newtonsoft.Json.JsonProperty("skill_tid")]
  public int SkillTid { get; set; }
  [Newtonsoft.Json.JsonProperty("objId")]
  public uint ObjId { get; set; }
  [Newtonsoft.Json.JsonProperty("direction")]
  public Vec3T Direction { get; set; }
  [Newtonsoft.Json.JsonProperty("atk_pos")]
  public Vec3T AtkPos { get; set; }

  public AttackSyncT() {
    this.SkillTid = 0;
    this.ObjId = 0;
    this.Direction = new Vec3T();
    this.AtkPos = new Vec3T();
  }
}

