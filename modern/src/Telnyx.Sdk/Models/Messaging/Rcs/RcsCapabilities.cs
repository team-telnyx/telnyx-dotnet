using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging.Rcs;

[JsonConverter(typeof(JsonModelConverter<RcsCapabilities, RcsCapabilitiesFromRaw>))]
public sealed record class RcsCapabilities : JsonModel
{
    /// <summary>
    /// RCS agent ID
    /// </summary>
    public string? AgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_id", value);
        }
    }

    /// <summary>
    /// RCS agent name
    /// </summary>
    public string? AgentName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_name", value);
        }
    }

    /// <summary>
    /// List of RCS capabilities
    /// </summary>
    public IReadOnlyList<string>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        _ = this.AgentName;
        _ = this.Features;
        _ = this.PhoneNumber;
        this.RecordType?.Validate();
    }

    public RcsCapabilities ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsCapabilities (RcsCapabilities rcsCapabilities) : base(
        rcsCapabilities
    )
    {  }
    #pragma warning restore CS8618

    public RcsCapabilities (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsCapabilities (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsCapabilitiesFromRaw.FromRawUnchecked"/>
    public static RcsCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsCapabilitiesFromRaw : IFromRawJson<RcsCapabilities>
{
    /// <inheritdoc/>
    public RcsCapabilities FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsCapabilities.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    RcsCapabilities
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rcs.capabilities"=>RecordType.RcsCapabilities, _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.RcsCapabilities=>"rcs.capabilities",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}