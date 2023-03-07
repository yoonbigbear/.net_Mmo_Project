// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct RemoveItemReq : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static RemoveItemReq GetRootAsRemoveItemReq(ByteBuffer _bb) { return GetRootAsRemoveItemReq(_bb, new RemoveItemReq()); }
  public static RemoveItemReq GetRootAsRemoveItemReq(ByteBuffer _bb, RemoveItemReq obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public RemoveItemReq __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint Ids(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(__p.__vector(o) + j * 4) : (uint)0; }
  public int IdsLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<uint> GetIdsBytes() { return __p.__vector_as_span<uint>(4, 4); }
#else
  public ArraySegment<byte>? GetIdsBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public uint[] GetIdsArray() { return __p.__vector_as_array<uint>(4); }
  public ulong DbIds(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.GetUlong(__p.__vector(o) + j * 8) : (ulong)0; }
  public int DbIdsLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<ulong> GetDbIdsBytes() { return __p.__vector_as_span<ulong>(6, 8); }
#else
  public ArraySegment<byte>? GetDbIdsBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public ulong[] GetDbIdsArray() { return __p.__vector_as_array<ulong>(6); }
  public int Values(int j) { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(__p.__vector(o) + j * 4) : (int)0; }
  public int ValuesLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<int> GetValuesBytes() { return __p.__vector_as_span<int>(8, 4); }
#else
  public ArraySegment<byte>? GetValuesBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public int[] GetValuesArray() { return __p.__vector_as_array<int>(8); }

  public static Offset<RemoveItemReq> CreateRemoveItemReq(FlatBufferBuilder builder,
      VectorOffset idsOffset = default(VectorOffset),
      VectorOffset db_idsOffset = default(VectorOffset),
      VectorOffset valuesOffset = default(VectorOffset)) {
    builder.StartTable(3);
    RemoveItemReq.AddValues(builder, valuesOffset);
    RemoveItemReq.AddDbIds(builder, db_idsOffset);
    RemoveItemReq.AddIds(builder, idsOffset);
    return RemoveItemReq.EndRemoveItemReq(builder);
  }

  public static void StartRemoveItemReq(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddIds(FlatBufferBuilder builder, VectorOffset idsOffset) { builder.AddOffset(0, idsOffset.Value, 0); }
  public static VectorOffset CreateIdsVector(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddUint(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateIdsVectorBlock(FlatBufferBuilder builder, uint[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateIdsVectorBlock(FlatBufferBuilder builder, ArraySegment<uint> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateIdsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<uint>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartIdsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddDbIds(FlatBufferBuilder builder, VectorOffset dbIdsOffset) { builder.AddOffset(1, dbIdsOffset.Value, 0); }
  public static VectorOffset CreateDbIdsVector(FlatBufferBuilder builder, ulong[] data) { builder.StartVector(8, data.Length, 8); for (int i = data.Length - 1; i >= 0; i--) builder.AddUlong(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDbIdsVectorBlock(FlatBufferBuilder builder, ulong[] data) { builder.StartVector(8, data.Length, 8); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDbIdsVectorBlock(FlatBufferBuilder builder, ArraySegment<ulong> data) { builder.StartVector(8, data.Count, 8); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDbIdsVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<ulong>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDbIdsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(8, numElems, 8); }
  public static void AddValues(FlatBufferBuilder builder, VectorOffset valuesOffset) { builder.AddOffset(2, valuesOffset.Value, 0); }
  public static VectorOffset CreateValuesVector(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddInt(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateValuesVectorBlock(FlatBufferBuilder builder, int[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateValuesVectorBlock(FlatBufferBuilder builder, ArraySegment<int> data) { builder.StartVector(4, data.Count, 4); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateValuesVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<int>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartValuesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<RemoveItemReq> EndRemoveItemReq(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<RemoveItemReq>(o);
  }
  public RemoveItemReqT UnPack() {
    var _o = new RemoveItemReqT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(RemoveItemReqT _o) {
    _o.Ids = new List<uint>();
    for (var _j = 0; _j < this.IdsLength; ++_j) {_o.Ids.Add(this.Ids(_j));}
    _o.DbIds = new List<ulong>();
    for (var _j = 0; _j < this.DbIdsLength; ++_j) {_o.DbIds.Add(this.DbIds(_j));}
    _o.Values = new List<int>();
    for (var _j = 0; _j < this.ValuesLength; ++_j) {_o.Values.Add(this.Values(_j));}
  }
  public static Offset<RemoveItemReq> Pack(FlatBufferBuilder builder, RemoveItemReqT _o) {
    if (_o == null) return default(Offset<RemoveItemReq>);
    var _ids = default(VectorOffset);
    if (_o.Ids != null) {
      var __ids = _o.Ids.ToArray();
      _ids = CreateIdsVector(builder, __ids);
    }
    var _db_ids = default(VectorOffset);
    if (_o.DbIds != null) {
      var __db_ids = _o.DbIds.ToArray();
      _db_ids = CreateDbIdsVector(builder, __db_ids);
    }
    var _values = default(VectorOffset);
    if (_o.Values != null) {
      var __values = _o.Values.ToArray();
      _values = CreateValuesVector(builder, __values);
    }
    return CreateRemoveItemReq(
      builder,
      _ids,
      _db_ids,
      _values);
  }
}

public class RemoveItemReqT
{
  [Newtonsoft.Json.JsonProperty("ids")]
  public List<uint> Ids { get; set; }
  [Newtonsoft.Json.JsonProperty("db_ids")]
  public List<ulong> DbIds { get; set; }
  [Newtonsoft.Json.JsonProperty("values")]
  public List<int> Values { get; set; }

  public RemoveItemReqT() {
    this.Ids = null;
    this.DbIds = null;
    this.Values = null;
  }
}
