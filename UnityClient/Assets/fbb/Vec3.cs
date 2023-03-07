// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct Vec3 : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p = new Struct(_i, _bb); }
  public Vec3 __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public float X { get { return __p.bb.GetFloat(__p.bb_pos + 0); } }
  public float Y { get { return __p.bb.GetFloat(__p.bb_pos + 4); } }
  public float Z { get { return __p.bb.GetFloat(__p.bb_pos + 8); } }

  public static Offset<Vec3> CreateVec3(FlatBufferBuilder builder, float X, float Y, float Z) {
    builder.Prep(4, 12);
    builder.PutFloat(Z);
    builder.PutFloat(Y);
    builder.PutFloat(X);
    return new Offset<Vec3>(builder.Offset);
  }
  public Vec3T UnPack() {
    var _o = new Vec3T();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(Vec3T _o) {
    _o.X = this.X;
    _o.Y = this.Y;
    _o.Z = this.Z;
  }
  public static Offset<Vec3> Pack(FlatBufferBuilder builder, Vec3T _o) {
    if (_o == null) return default(Offset<Vec3>);
    return CreateVec3(
      builder,
      _o.X,
      _o.Y,
      _o.Z);
  }
}

public class Vec3T
{
  [Newtonsoft.Json.JsonProperty("x")]
  public float X { get; set; }
  [Newtonsoft.Json.JsonProperty("y")]
  public float Y { get; set; }
  [Newtonsoft.Json.JsonProperty("z")]
  public float Z { get; set; }

  public Vec3T() {
    this.X = 0.0f;
    this.Y = 0.0f;
    this.Z = 0.0f;
  }
}

