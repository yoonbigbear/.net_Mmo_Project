// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct TradeUpdateSync : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static TradeUpdateSync GetRootAsTradeUpdateSync(ByteBuffer _bb) { return GetRootAsTradeUpdateSync(_bb, new TradeUpdateSync()); }
  public static TradeUpdateSync GetRootAsTradeUpdateSync(ByteBuffer _bb, TradeUpdateSync obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public TradeUpdateSync __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public uint TradeId { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUint(o + __p.bb_pos) : (uint)0; } }
  public TradeInfo? Tradeinfo { get { int o = __p.__offset(6); return o != 0 ? (TradeInfo?)(new TradeInfo()).__assign(__p.__indirect(o + __p.bb_pos), __p.bb) : null; } }

  public static Offset<TradeUpdateSync> CreateTradeUpdateSync(FlatBufferBuilder builder,
      uint trade_id = 0,
      Offset<TradeInfo> tradeinfoOffset = default(Offset<TradeInfo>)) {
    builder.StartTable(2);
    TradeUpdateSync.AddTradeinfo(builder, tradeinfoOffset);
    TradeUpdateSync.AddTradeId(builder, trade_id);
    return TradeUpdateSync.EndTradeUpdateSync(builder);
  }

  public static void StartTradeUpdateSync(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddTradeId(FlatBufferBuilder builder, uint tradeId) { builder.AddUint(0, tradeId, 0); }
  public static void AddTradeinfo(FlatBufferBuilder builder, Offset<TradeInfo> tradeinfoOffset) { builder.AddOffset(1, tradeinfoOffset.Value, 0); }
  public static Offset<TradeUpdateSync> EndTradeUpdateSync(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TradeUpdateSync>(o);
  }
  public TradeUpdateSyncT UnPack() {
    var _o = new TradeUpdateSyncT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(TradeUpdateSyncT _o) {
    _o.TradeId = this.TradeId;
    _o.Tradeinfo = this.Tradeinfo.HasValue ? this.Tradeinfo.Value.UnPack() : null;
  }
  public static Offset<TradeUpdateSync> Pack(FlatBufferBuilder builder, TradeUpdateSyncT _o) {
    if (_o == null) return default(Offset<TradeUpdateSync>);
    var _tradeinfo = _o.Tradeinfo == null ? default(Offset<TradeInfo>) : TradeInfo.Pack(builder, _o.Tradeinfo);
    return CreateTradeUpdateSync(
      builder,
      _o.TradeId,
      _tradeinfo);
  }
}

public class TradeUpdateSyncT
{
  [Newtonsoft.Json.JsonProperty("trade_id")]
  public uint TradeId { get; set; }
  [Newtonsoft.Json.JsonProperty("tradeinfo")]
  public TradeInfoT Tradeinfo { get; set; }

  public TradeUpdateSyncT() {
    this.TradeId = 0;
    this.Tradeinfo = null;
  }
}
