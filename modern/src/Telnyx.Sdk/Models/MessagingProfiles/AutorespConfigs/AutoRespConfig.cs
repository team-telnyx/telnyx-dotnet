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

[JsonConverter(typeof(JsonModelConverter<AutoRespConfig, AutoRespConfigFromRaw>))]
public sealed record class AutoRespConfig : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawData.Set("country_code", value); }
    }

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
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

    public required ApiEnum<string, AutoRespConfigOp> Op {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AutoRespConfigOp>>(
                "op"
            );
        }
        init { this._rawData.Set("op", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
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
        _ = this.ID;
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.Keywords;
        this.Op.Validate();
        _ = this.UpdatedAt;
        _ = this.RespText;
    }

    public AutoRespConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRespConfig (AutoRespConfig autoRespConfig) : base(autoRespConfig)
    {  }
    #pragma warning restore CS8618

    public AutoRespConfig (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRespConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRespConfigFromRaw.FromRawUnchecked"/>
    public static AutoRespConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutoRespConfigFromRaw : IFromRawJson<AutoRespConfig>
{
    /// <inheritdoc/>
    public AutoRespConfig FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRespConfig.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AutoRespConfigOpConverter))]
public enum AutoRespConfigOp
{
    Start, Stop, Info
}sealed class AutoRespConfigOpConverter : JsonConverter<AutoRespConfigOp>
{
    public override AutoRespConfigOp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "start"=>AutoRespConfigOp.Start,
            "stop"=>AutoRespConfigOp.Stop,
            "info"=>AutoRespConfigOp.Info,
            _ =>(AutoRespConfigOp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutoRespConfigOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AutoRespConfigOp.Start=>"start",
            AutoRespConfigOp.Stop=>"stop",
            AutoRespConfigOp.Info=>"info",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}