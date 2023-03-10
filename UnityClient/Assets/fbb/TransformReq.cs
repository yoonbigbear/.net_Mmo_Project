// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct TransformReq : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static TransformReq GetRootAsTransformReq(ByteBuffer _bb) { return GetRootAsTransformReq(_bb, new TransformReq()); }
  public static TransformReq GetRootAsTransformReq(ByteBuffer _bb, TransformReq obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public TransformReq __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public TransformInfo? Transform { get { int o = __p.__offset(4); return o != 0 ? (TransformInfo?)(new TransformInfo()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartTransformReq(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddTransform(FlatBufferBuilder builder, Offset<TransformInfo> transformOffset) { builder.AddStruct(0, transformOffset.Value, 0); }
  public static Offset<TransformReq> EndTransformReq(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TransformReq>(o);
  }
  public TransformReqT UnPack() {
    var _o = new TransformReqT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(TransformReqT _o) {
    _o.Transform = this.Transform.HasValue ? this.Transform.Value.UnPack() : null;
  }
  public static Offset<TransformReq> Pack(FlatBufferBuilder builder, TransformReqT _o) {
    if (_o == null) return default(Offset<TransformReq>);
    StartTransformReq(builder);
    AddTransform(builder, TransformInfo.Pack(builder, _o.Transform));
    return EndTransformReq(builder);
  }
}

public class TransformReqT
{
  [Newtonsoft.Json.JsonProperty("transform")]
  public TransformInfoT Transform { get; set; }

  public TransformReqT() {
    this.Transform = new TransformInfoT();
  }
}

