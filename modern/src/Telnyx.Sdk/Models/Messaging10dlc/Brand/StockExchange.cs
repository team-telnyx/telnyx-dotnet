using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// (Required for public company) stock exchange.
/// </summary>
[JsonConverter(typeof(StockExchangeConverter))]
public enum StockExchange
{
    None,
    Nasdaq,
    Nyse,
    Amex,
    Amx,
    Asx,
    B3,
    Bme,
    Bse,
    Fra,
    Icex,
    Jpx,
    Jse,
    Krx,
    Lon,
    Nse,
    Omx,
    Sehk,
    Sse,
    Sto,
    Swx,
    Szse,
    Tsx,
    Twse,
    Vse
}

sealed class StockExchangeConverter : JsonConverter<StockExchange>
{
    public override StockExchange Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NONE"=>StockExchange.None,
            "NASDAQ"=>StockExchange.Nasdaq,
            "NYSE"=>StockExchange.Nyse,
            "AMEX"=>StockExchange.Amex,
            "AMX"=>StockExchange.Amx,
            "ASX"=>StockExchange.Asx,
            "B3"=>StockExchange.B3,
            "BME"=>StockExchange.Bme,
            "BSE"=>StockExchange.Bse,
            "FRA"=>StockExchange.Fra,
            "ICEX"=>StockExchange.Icex,
            "JPX"=>StockExchange.Jpx,
            "JSE"=>StockExchange.Jse,
            "KRX"=>StockExchange.Krx,
            "LON"=>StockExchange.Lon,
            "NSE"=>StockExchange.Nse,
            "OMX"=>StockExchange.Omx,
            "SEHK"=>StockExchange.Sehk,
            "SSE"=>StockExchange.Sse,
            "STO"=>StockExchange.Sto,
            "SWX"=>StockExchange.Swx,
            "SZSE"=>StockExchange.Szse,
            "TSX"=>StockExchange.Tsx,
            "TWSE"=>StockExchange.Twse,
            "VSE"=>StockExchange.Vse,
            _ =>(StockExchange)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        StockExchange value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            StockExchange.None=>"NONE",
            StockExchange.Nasdaq=>"NASDAQ",
            StockExchange.Nyse=>"NYSE",
            StockExchange.Amex=>"AMEX",
            StockExchange.Amx=>"AMX",
            StockExchange.Asx=>"ASX",
            StockExchange.B3=>"B3",
            StockExchange.Bme=>"BME",
            StockExchange.Bse=>"BSE",
            StockExchange.Fra=>"FRA",
            StockExchange.Icex=>"ICEX",
            StockExchange.Jpx=>"JPX",
            StockExchange.Jse=>"JSE",
            StockExchange.Krx=>"KRX",
            StockExchange.Lon=>"LON",
            StockExchange.Nse=>"NSE",
            StockExchange.Omx=>"OMX",
            StockExchange.Sehk=>"SEHK",
            StockExchange.Sse=>"SSE",
            StockExchange.Sto=>"STO",
            StockExchange.Swx=>"SWX",
            StockExchange.Szse=>"SZSE",
            StockExchange.Tsx=>"TSX",
            StockExchange.Twse=>"TWSE",
            StockExchange.Vse=>"VSE",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}