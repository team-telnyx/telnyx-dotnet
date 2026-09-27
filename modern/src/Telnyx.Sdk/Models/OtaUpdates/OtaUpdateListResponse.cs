using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OtaUpdates;

/// <summary>
/// This object represents an Over the Air (OTA) update request. It allows tracking
/// the current status of a operation that apply settings in a particular SIM card. &lt;br/&gt;&lt;br/&gt;
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OtaUpdateListResponse, OtaUpdateListResponseFromRaw>))]
public sealed record class OtaUpdateListResponse : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// The identification UUID of the related SIM card resource.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    public ApiEnum<string, OtaUpdateListResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OtaUpdateListResponseStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Represents the type of the operation requested. This will relate directly
    /// to the source of the request.
    /// </summary>
    public ApiEnum<string, OtaUpdateListResponseType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, OtaUpdateListResponseType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.SimCardID;
        this.Status?.Validate();
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public OtaUpdateListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OtaUpdateListResponse (
        OtaUpdateListResponse otaUpdateListResponse
    ) : base(otaUpdateListResponse)
    {  }
    #pragma warning restore CS8618

    public OtaUpdateListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OtaUpdateListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OtaUpdateListResponseFromRaw.FromRawUnchecked"/>
    public static OtaUpdateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OtaUpdateListResponseFromRaw : IFromRawJson<OtaUpdateListResponse>
{
    /// <inheritdoc/>
    public OtaUpdateListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OtaUpdateListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(OtaUpdateListResponseStatusConverter))]
public enum OtaUpdateListResponseStatus
{
    InProgress, Completed, Failed
}sealed class OtaUpdateListResponseStatusConverter : JsonConverter<OtaUpdateListResponseStatus>
{
    public override OtaUpdateListResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>OtaUpdateListResponseStatus.InProgress,
            "completed"=>OtaUpdateListResponseStatus.Completed,
            "failed"=>OtaUpdateListResponseStatus.Failed,
            _ =>(OtaUpdateListResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OtaUpdateListResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OtaUpdateListResponseStatus.InProgress=>"in-progress",
            OtaUpdateListResponseStatus.Completed=>"completed",
            OtaUpdateListResponseStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the type of the operation requested. This will relate directly to
/// the source of the request.
/// </summary>
[JsonConverter(typeof(OtaUpdateListResponseTypeConverter))]
public enum OtaUpdateListResponseType
{
    SimCardNetworkPreferences
}sealed class OtaUpdateListResponseTypeConverter : JsonConverter<OtaUpdateListResponseType>
{
    public override OtaUpdateListResponseType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sim_card_network_preferences"=>OtaUpdateListResponseType.SimCardNetworkPreferences,
            _ =>(OtaUpdateListResponseType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        OtaUpdateListResponseType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            OtaUpdateListResponseType.SimCardNetworkPreferences=>"sim_card_network_preferences",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}