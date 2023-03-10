// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct Heartbeat : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static Heartbeat GetRootAsHeartbeat(ByteBuffer _bb) { return GetRootAsHeartbeat(_bb, new Heartbeat()); }
  public static Heartbeat GetRootAsHeartbeat(ByteBuffer _bb, Heartbeat obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Heartbeat __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }


  public static void StartHeartbeat(FlatBufferBuilder builder) { builder.StartTable(0); }
  public static Offset<Heartbeat> EndHeartbeat(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<Heartbeat>(o);
  }
  public HeartbeatT UnPack() {
    var _o = new HeartbeatT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(HeartbeatT _o) {
  }
  public static Offset<Heartbeat> Pack(FlatBufferBuilder builder, HeartbeatT _o) {
    if (_o == null) return default(Offset<Heartbeat>);
    StartHeartbeat(builder);
    return EndHeartbeat(builder);
  }
}

public class HeartbeatT
{

  public HeartbeatT() {
  }
}

