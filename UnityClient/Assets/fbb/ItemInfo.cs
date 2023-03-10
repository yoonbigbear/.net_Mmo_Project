// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct ItemInfo : IFlatbufferObject
{
  private Struct __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public void __init(int _i, ByteBuffer _bb) { __p = new Struct(_i, _bb); }
  public ItemInfo __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Count { get { return __p.bb.GetInt(__p.bb_pos + 0); } }
  public uint TId { get { return __p.bb.GetUint(__p.bb_pos + 4); } }
  public ulong DbId { get { return __p.bb.GetUlong(__p.bb_pos + 8); } }

  public static Offset<ItemInfo> CreateItemInfo(FlatBufferBuilder builder, int Count, uint TId, ulong DbId) {
    builder.Prep(8, 16);
    builder.PutUlong(DbId);
    builder.PutUint(TId);
    builder.PutInt(Count);
    return new Offset<ItemInfo>(builder.Offset);
  }
  public ItemInfoT UnPack() {
    var _o = new ItemInfoT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(ItemInfoT _o) {
    _o.Count = this.Count;
    _o.TId = this.TId;
    _o.DbId = this.DbId;
  }
  public static Offset<ItemInfo> Pack(FlatBufferBuilder builder, ItemInfoT _o) {
    if (_o == null) return default(Offset<ItemInfo>);
    return CreateItemInfo(
      builder,
      _o.Count,
      _o.TId,
      _o.DbId);
  }
}

public class ItemInfoT
{
  [Newtonsoft.Json.JsonProperty("count")]
  public int Count { get; set; }
  [Newtonsoft.Json.JsonProperty("t_id")]
  public uint TId { get; set; }
  [Newtonsoft.Json.JsonProperty("db_id")]
  public ulong DbId { get; set; }

  public ItemInfoT() {
    this.Count = 0;
    this.TId = 0;
    this.DbId = 0;
  }
}

