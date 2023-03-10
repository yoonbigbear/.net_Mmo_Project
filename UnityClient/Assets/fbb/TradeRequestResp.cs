// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct TradeRequestResp : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_22_9_29(); }
  public static TradeRequestResp GetRootAsTradeRequestResp(ByteBuffer _bb) { return GetRootAsTradeRequestResp(_bb, new TradeRequestResp()); }
  public static TradeRequestResp GetRootAsTradeRequestResp(ByteBuffer _bb, TradeRequestResp obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public TradeRequestResp __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ErrorCode ErrorCode { get { int o = __p.__offset(4); return o != 0 ? (ErrorCode)__p.bb.GetShort(o + __p.bb_pos) : ErrorCode.Success; } }

  public static Offset<TradeRequestResp> CreateTradeRequestResp(FlatBufferBuilder builder,
      ErrorCode error_code = ErrorCode.Success) {
    builder.StartTable(1);
    TradeRequestResp.AddErrorCode(builder, error_code);
    return TradeRequestResp.EndTradeRequestResp(builder);
  }

  public static void StartTradeRequestResp(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddErrorCode(FlatBufferBuilder builder, ErrorCode errorCode) { builder.AddShort(0, (short)errorCode, 0); }
  public static Offset<TradeRequestResp> EndTradeRequestResp(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TradeRequestResp>(o);
  }
  public TradeRequestRespT UnPack() {
    var _o = new TradeRequestRespT();
    this.UnPackTo(_o);
    return _o;
  }
  public void UnPackTo(TradeRequestRespT _o) {
    _o.ErrorCode = this.ErrorCode;
  }
  public static Offset<TradeRequestResp> Pack(FlatBufferBuilder builder, TradeRequestRespT _o) {
    if (_o == null) return default(Offset<TradeRequestResp>);
    return CreateTradeRequestResp(
      builder,
      _o.ErrorCode);
  }
}

public class TradeRequestRespT
{
  [Newtonsoft.Json.JsonProperty("error_code")]
  public ErrorCode ErrorCode { get; set; }

  public TradeRequestRespT() {
    this.ErrorCode = ErrorCode.Success;
  }
}

