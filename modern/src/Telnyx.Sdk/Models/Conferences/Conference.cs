using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<Conference, ConferenceFromRaw>))]
public sealed record class Conference : JsonModel
{
    /// <summary>
    /// Uniquely identifies the conference
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the conference was created
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the conference will expire
    /// </summary>
    public required string ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "expires_at"
            );
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// Name of the conference
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Identifies the connection associated with the conference
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// Reason why the conference ended
    /// </summary>
    public ApiEnum<string, EndReason>? EndReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EndReason>>(
                "end_reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_reason", value);
        }
    }

    /// <summary>
    /// IDs related to who ended the conference. It is expected for them to all be
    /// there or all be null
    /// </summary>
    public EndedBy? EndedBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EndedBy>(
                "ended_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ended_by", value);
        }
    }

    /// <summary>
    /// Region where the conference is hosted
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// Status of the conference
    /// </summary>
    public ApiEnum<string, ConferenceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceStatus>>(
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
    /// ISO 8601 formatted date of when the conference was last updated
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
        _ = this.ExpiresAt;
        _ = this.Name;
        this.RecordType.Validate();
        _ = this.ConnectionID;
        this.EndReason?.Validate();
        this.EndedBy?.Validate();
        _ = this.Region;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public Conference ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Conference (Conference conference) : base(conference)
    {  }
    #pragma warning restore CS8618

    public Conference (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Conference (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceFromRaw.FromRawUnchecked"/>
    public static Conference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceFromRaw : IFromRawJson<Conference>
{
    /// <inheritdoc/>
    public Conference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Conference.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    Conference
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "conference"=>RecordType.Conference, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.Conference=>"conference",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Reason why the conference ended
/// </summary>
[JsonConverter(typeof(EndReasonConverter))]
public enum EndReason
{
    AllLeft, EndedViaApi, HostLeft, TimeExceeded
}sealed class EndReasonConverter : JsonConverter<EndReason>
{
    public override EndReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all_left"=>EndReason.AllLeft,
            "ended_via_api"=>EndReason.EndedViaApi,
            "host_left"=>EndReason.HostLeft,
            "time_exceeded"=>EndReason.TimeExceeded,
            _ =>(EndReason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, EndReason value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EndReason.AllLeft=>"all_left",
            EndReason.EndedViaApi=>"ended_via_api",
            EndReason.HostLeft=>"host_left",
            EndReason.TimeExceeded=>"time_exceeded",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// IDs related to who ended the conference. It is expected for them to all be there
/// or all be null
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EndedBy, EndedByFromRaw>))]
public sealed record class EndedBy : JsonModel
{
    /// <summary>
    /// Call Control ID which ended the conference
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// Call Session ID which ended the conference
    /// </summary>
    public string? CallSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_session_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlID;
        _ = this.CallSessionID;
    }

    public EndedBy ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EndedBy (EndedBy endedBy) : base(endedBy)
    {  }
    #pragma warning restore CS8618

    public EndedBy (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EndedBy (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EndedByFromRaw.FromRawUnchecked"/>
    public static EndedBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EndedByFromRaw : IFromRawJson<EndedBy>
{
    /// <inheritdoc/>
    public EndedBy FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EndedBy.FromRawUnchecked(rawData);
}/// <summary>
/// Status of the conference
/// </summary>
[JsonConverter(typeof(ConferenceStatusConverter))]
public enum ConferenceStatus
{
    Init, InProgress, Completed
}sealed class ConferenceStatusConverter : JsonConverter<ConferenceStatus>
{
    public override ConferenceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "init"=>ConferenceStatus.Init,
            "in_progress"=>ConferenceStatus.InProgress,
            "completed"=>ConferenceStatus.Completed,
            _ =>(ConferenceStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceStatus.Init=>"init",
            ConferenceStatus.InProgress=>"in_progress",
            ConferenceStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}