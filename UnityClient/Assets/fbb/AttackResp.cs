// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct AttackResp : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static AttackResp GetRootAsAttackResp(ByteBuffer _bb) { return GetRootAsAttackResp(_bb, new AttackResp()); }
  public static AttackResp GetRootAsAttackResp(ByteBuffer _bb, AttackResp obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public AttackResp __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int SkillTid { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public Vec3? AtkPos { get { int o = __p.__offset(6); return o != 0 ? (Vec3?)(new Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public Vec3? Direction { get { int o = __p.__offset(8); return o != 0 ? (Vec3?)(new Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public ErrorCode ErrorCode { get { int o = __p.__offset(10); return o != 0 ? (ErrorCode)__p.bb.GetShort(o + __p.bb_pos) : ErrorCode.Success; } }

  public static Offset<AttackResp> CreateAttackResp(FlatBufferBuilder builder,
      int skill_tid = 0,
      Vec3T atk_pos = null,
      Vec3T direction = null,
      ErrorCode error_code = ErrorCode.Success) {
    builder.StartTable(4);
    AttackResp.AddDirection(builder, Vec3.Pack(builder, direction));
    AttackResp.AddAtkPos(builder, Vec3.Pack(builder, atk_pos));
    AttackResp.AddSkillTid(builder, skill_tid);
    AttackResp.AddErrorCode(builder, error_code);
    return AttackResp.EndAttackResp(builder);
  }

  public static void StartAttackResp(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddSkillTid(FlatBufferBuilder builder, int skillTid) { builder.AddInt(0, skillTid, 0); }
  public static void AddAtkPos(FlatBufferBuilder builder, Offset<Vec3> atkPosOffset) { builder.AddStruct(1, atkPosOffset.Value, 0); }
  public static void AddDirection(FlatBufferBuilder builder, Offset<Vec3> directionOffset) { builder.AddStruct(2, directionOffset.Value, 0); }
  public static void AddErrorCode(FlatBufferBuilder builder, ErrorCode errorCode) { builder.AddShort(3, (short)errorCode, 0); }
  public static Offset<AttackResp> EndAttackResp(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<AttackResp>(o);
  }
  public AttackRespT UnPack() {
    var _o = new AttackRespT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(AttackRespT _o) {
    _o.SkillTid = this.SkillTid;
    _o.AtkPos = this.AtkPos.HasValue ? this.AtkPos.Value.UnPack() : null;
    _o.Direction = this.Direction.HasValue ? this.Direction.Value.UnPack() : null;
    _o.ErrorCode = this.ErrorCode;
  }
  public static Offset<AttackResp> Pack(FlatBufferBuilder builder, AttackRespT _o) {
    if (_o == null) return default(Offset<AttackResp>);
    return CreateAttackResp(
      builder,
      _o.SkillTid,
      _o.AtkPos,
      _o.Direction,
      _o.ErrorCode);
  }
}

public class AttackRespT
{
  [Newtonsoft.Json.JsonProperty("skill_tid")]
  public int SkillTid { get; set; }
  [Newtonsoft.Json.JsonProperty("atk_pos")]
  public Vec3T AtkPos { get; set; }
  [Newtonsoft.Json.JsonProperty("direction")]
  public Vec3T Direction { get; set; }
  [Newtonsoft.Json.JsonProperty("error_code")]
  public ErrorCode ErrorCode { get; set; }

  public AttackRespT() {
    this.SkillTid = 0;
    this.AtkPos = new Vec3T();
    this.Direction = new Vec3T();
    this.ErrorCode = ErrorCode.Success;
  }
}

