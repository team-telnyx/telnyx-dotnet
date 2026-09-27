using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ArtifactFailedWebhookEvent, ArtifactFailedWebhookEventFromRaw>))]
public sealed record class ArtifactFailedWebhookEvent : JsonModel
{
    /// <summary>
    /// Unique event id; deduplicate deliveries on it.
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
    /// Failed artifact reference and reason.
    /// </summary>
    public required ArtifactFailedWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ArtifactFailedWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type.
    /// </summary>
    public required ApiEnum<string, ArtifactFailedWebhookEventEvent> Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ArtifactFailedWebhookEventEvent>>(
                "event"
            );
        }
        init { this._rawData.Set("event", value); }
    }

    /// <summary>
    /// When the event occurred.
    /// </summary>
    public required System::DateTimeOffset OccurredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "occurred_at"
            );
        }
        init { this._rawData.Set("occurred_at", value); }
    }

    /// <summary>
    /// Envelope version.
    /// </summary>
    public required string Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "version"
            );
        }
        init { this._rawData.Set("version", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Data.Validate();
        this.Event.Validate();
        _ = this.OccurredAt;
        _ = this.Version;
    }

    public ArtifactFailedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactFailedWebhookEvent (
        ArtifactFailedWebhookEvent artifactFailedWebhookEvent
    ) : base(artifactFailedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ArtifactFailedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactFailedWebhookEvent (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactFailedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ArtifactFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ArtifactFailedWebhookEventFromRaw : IFromRawJson<ArtifactFailedWebhookEvent>
{
    /// <inheritdoc/>
    public ArtifactFailedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArtifactFailedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Failed artifact reference and reason.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ArtifactFailedWebhookEventData, ArtifactFailedWebhookEventDataFromRaw>))]
public sealed record class ArtifactFailedWebhookEventData : JsonModel
{
    /// <summary>
    /// Id of the failed artifact.
    /// </summary>
    public required string ArtifactID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "artifact_id"
            );
        }
        init { this._rawData.Set("artifact_id", value); }
    }

    /// <summary>
    /// The meeting session this event belongs to.
    /// </summary>
    public required string SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <summary>
    /// Type of the failed artifact.
    /// </summary>
    public required ApiEnum<string, ArtifactFailedWebhookEventDataType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ArtifactFailedWebhookEventDataType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArtifactID;
        _ = this.SessionID;
        this.Type.Validate();
    }

    public ArtifactFailedWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactFailedWebhookEventData (
        ArtifactFailedWebhookEventData artifactFailedWebhookEventData
    ) : base(artifactFailedWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public ArtifactFailedWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactFailedWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactFailedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static ArtifactFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ArtifactFailedWebhookEventDataFromRaw : IFromRawJson<ArtifactFailedWebhookEventData>
{
    /// <inheritdoc/>
    public ArtifactFailedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArtifactFailedWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// Type of the failed artifact.
/// </summary>
[JsonConverter(typeof(ArtifactFailedWebhookEventDataTypeConverter))]
public enum ArtifactFailedWebhookEventDataType
{
    Summary, ActionItems, Decisions, Topics, OpenQuestions, Custom
}sealed class ArtifactFailedWebhookEventDataTypeConverter : JsonConverter<ArtifactFailedWebhookEventDataType>
{
    public override ArtifactFailedWebhookEventDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summary"=>ArtifactFailedWebhookEventDataType.Summary,
            "action_items"=>ArtifactFailedWebhookEventDataType.ActionItems,
            "decisions"=>ArtifactFailedWebhookEventDataType.Decisions,
            "topics"=>ArtifactFailedWebhookEventDataType.Topics,
            "open_questions"=>ArtifactFailedWebhookEventDataType.OpenQuestions,
            "custom"=>ArtifactFailedWebhookEventDataType.Custom,
            _ =>(ArtifactFailedWebhookEventDataType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ArtifactFailedWebhookEventDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ArtifactFailedWebhookEventDataType.Summary=>"summary",
            ArtifactFailedWebhookEventDataType.ActionItems=>"action_items",
            ArtifactFailedWebhookEventDataType.Decisions=>"decisions",
            ArtifactFailedWebhookEventDataType.Topics=>"topics",
            ArtifactFailedWebhookEventDataType.OpenQuestions=>"open_questions",
            ArtifactFailedWebhookEventDataType.Custom=>"custom",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Event type.
/// </summary>
[JsonConverter(typeof(ArtifactFailedWebhookEventEventConverter))]
public enum ArtifactFailedWebhookEventEvent
{
    ArtifactFailed
}sealed class ArtifactFailedWebhookEventEventConverter : JsonConverter<ArtifactFailedWebhookEventEvent>
{
    public override ArtifactFailedWebhookEventEvent Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "artifact.failed"=>ArtifactFailedWebhookEventEvent.ArtifactFailed,
            _ =>(ArtifactFailedWebhookEventEvent)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ArtifactFailedWebhookEventEvent value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ArtifactFailedWebhookEventEvent.ArtifactFailed=>"artifact.failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}