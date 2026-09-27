using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

[JsonConverter(typeof(JsonModelConverter<AutoRespConfigCreate, AutoRespConfigCreateFromRaw>))]
public sealed record class AutoRespConfigCreate : JsonModel
{
    public required string CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    public required IReadOnlyList<string> Keywords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "keywords"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "keywords",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, AutoRespConfigCreateOp> Op {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutoRespConfigCreateOp>>(
                "op"
            );
        }
        init { this._rawData.Set("op", value); }
    }

    public string? RespText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resp_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resp_text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CountryCode;
        _ = this.Keywords;
        this.Op.Validate();
        _ = this.RespText;
    }

    public AutoRespConfigCreate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRespConfigCreate (
        AutoRespConfigCreate autoRespConfigCreate
    ) : base(autoRespConfigCreate)
    {  }
    #pragma warning restore CS8618

    public AutoRespConfigCreate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRespConfigCreate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRespConfigCreateFromRaw.FromRawUnchecked"/>
    public static AutoRespConfigCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutoRespConfigCreateFromRaw : IFromRawJson<AutoRespConfigCreate>
{
    /// <inheritdoc/>
    public AutoRespConfigCreate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRespConfigCreate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutoRespConfigCreateOpConverter))]
public enum AutoRespConfigCreateOp
{
    Start, Stop, Info
}sealed class AutoRespConfigCreateOpConverter : JsonConverter<AutoRespConfigCreateOp>
{
    public override AutoRespConfigCreateOp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "start"=>AutoRespConfigCreateOp.Start,
            "stop"=>AutoRespConfigCreateOp.Stop,
            "info"=>AutoRespConfigCreateOp.Info,
            _ =>(AutoRespConfigCreateOp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoRespConfigCreateOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AutoRespConfigCreateOp.Start=>"start",
            AutoRespConfigCreateOp.Stop=>"stop",
            AutoRespConfigCreateOp.Info=>"info",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}