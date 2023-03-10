// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct EnterWorldSync : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static EnterWorldSync GetRootAsEnterWorldSync(ByteBuffer _bb) { return GetRootAsEnterWorldSync(_bb, new EnterWorldSync()); }
  public static EnterWorldSync GetRootAsEnterWorldSync(ByteBuffer _bb, EnterWorldSync obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public EnterWorldSync __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint ObjId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public TransformInfo? Transform { get { int o = __p.__offset(6); return o != 0 ? (TransformInfo?)(new TransformInfo()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public StateSync? Stat { get { int o = __p.__offset(8); return o != 0 ? (StateSync?)(new StateSync()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }
  public ErrorCode ErrorCode { get { int o = __p.__offset(10); return o != 0 ? (ErrorCode)__p.bb.GetShort(o + __p.bb_pos) : ErrorCode.Success; } }

  public static Offset<EnterWorldSync> CreateEnterWorldSync(FlatBufferBuilder builder,
      uint obj_id = 0,
      TransformInfoT transform = null,
      Offset<StateSync> statOffset = default(Offset<StateSync>),
      ErrorCode error_code = ErrorCode.Success) {
    builder.StartTable(4);
    EnterWorldSync.AddStat(builder, statOffset);
    EnterWorldSync.AddTransform(builder, TransformInfo.Pack(builder, transform));
    EnterWorldSync.AddObjId(builder, obj_id);
    EnterWorldSync.AddErrorCode(builder, error_code);
    return EnterWorldSync.EndEnterWorldSync(builder);
  }

  public static void StartEnterWorldSync(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddObjId(FlatBufferBuilder builder, uint objId) { builder.AddUint(0, objId, 0); }
  public static void AddTransform(FlatBufferBuilder builder, Offset<TransformInfo> transformOffset) { builder.AddStruct(1, transformOffset.Value, 0); }
  public static void AddStat(FlatBufferBuilder builder, Offset<StateSync> statOffset) { builder.AddOffset(2, statOffset.Value, 0); }
  public static void AddErrorCode(FlatBufferBuilder builder, ErrorCode errorCode) { builder.AddShort(3, (short)errorCode, 0); }
  public static Offset<EnterWorldSync> EndEnterWorldSync(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<EnterWorldSync>(o);
  }
  public EnterWorldSyncT UnPack() {
    var _o = new EnterWorldSyncT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(EnterWorldSyncT _o) {
    _o.ObjId = this.ObjId;
    _o.Transform = this.Transform.HasValue ? this.Transform.Value.UnPack() : null;
    _o.Stat = this.Stat.HasValue ? this.Stat.Value.UnPack() : null;
    _o.ErrorCode = this.ErrorCode;
  }
  public static Offset<EnterWorldSync> Pack(FlatBufferBuilder builder, EnterWorldSyncT _o) {
    if (_o == null) return default(Offset<EnterWorldSync>);
    var _stat = _o.Stat == null ? default(Offset<StateSync>) : StateSync.Pack(builder, _o.Stat);
    return CreateEnterWorldSync(
      builder,
      _o.ObjId,
      _o.Transform,
      _stat,
      _o.ErrorCode);
  }
}

public class EnterWorldSyncT
{
  [Newtonsoft.Json.JsonProperty("obj_id")]
  public uint ObjId { get; set; }
  [Newtonsoft.Json.JsonProperty("transform")]
  public TransformInfoT Transform { get; set; }
  [Newtonsoft.Json.JsonProperty("stat")]
  public StateSyncT Stat { get; set; }
  [Newtonsoft.Json.JsonProperty("error_code")]
  public ErrorCode ErrorCode { get; set; }

  public EnterWorldSyncT() {
    this.ObjId = 0;
    this.Transform = new TransformInfoT();
    this.Stat = null;
    this.ErrorCode = ErrorCode.Success;
  }
}

