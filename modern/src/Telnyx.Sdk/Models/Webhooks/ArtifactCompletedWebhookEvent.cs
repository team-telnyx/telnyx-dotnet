using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<ArtifactCompletedWebhookEvent, ArtifactCompletedWebhookEventFromRaw>))]
public sealed record class ArtifactCompletedWebhookEvent : JsonModel
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
    /// Completed artifact, including its generated content.
    /// </summary>
    public required ArtifactCompletedWebhookEventData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ArtifactCompletedWebhookEventData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Event type.
    /// </summary>
    public required ApiEnum<string, Event> Event {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Event>>(
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

    public ArtifactCompletedWebhookEvent ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactCompletedWebhookEvent (
        ArtifactCompletedWebhookEvent artifactCompletedWebhookEvent
    ) : base(artifactCompletedWebhookEvent)
    {  }
    #pragma warning restore CS8618

    public ArtifactCompletedWebhookEvent (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactCompletedWebhookEvent (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactCompletedWebhookEventFromRaw.FromRawUnchecked"/>
    public static ArtifactCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ArtifactCompletedWebhookEventFromRaw : IFromRawJson<ArtifactCompletedWebhookEvent>
{
    /// <inheritdoc/>
    public ArtifactCompletedWebhookEvent FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArtifactCompletedWebhookEvent.FromRawUnchecked(rawData);
}

/// <summary>
/// Completed artifact, including its generated content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ArtifactCompletedWebhookEventData, ArtifactCompletedWebhookEventDataFromRaw>))]
public sealed record class ArtifactCompletedWebhookEventData : JsonModel
{
    /// <summary>
    /// Id of the completed artifact.
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
    /// Generated artifact content.
    /// </summary>
    public required Content Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Content>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
    }

    /// <summary>
    /// Model that generated the artifact.
    /// </summary>
    public required ModelProvenance ModelProvenance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ModelProvenance>(
                "model_provenance"
            );
        }
        init { this._rawData.Set("model_provenance", value); }
    }

    /// <summary>
    /// The prompt that produced this artifact, or null for a named type. Non-null
    /// only when `type` is `custom`; the five named types always return `null`.
    /// </summary>
    public required string? Prompt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "prompt"
            );
        }
        init { this._rawData.Set("prompt", value); }
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
    /// Type of the completed artifact.
    /// </summary>
    public required ApiEnum<string, ArtifactCompletedWebhookEventDataType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ArtifactCompletedWebhookEventDataType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ArtifactID;
        this.Content.Validate();
        this.ModelProvenance.Validate();
        _ = this.Prompt;
        _ = this.SessionID;
        this.Type.Validate();
    }

    public ArtifactCompletedWebhookEventData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactCompletedWebhookEventData (
        ArtifactCompletedWebhookEventData artifactCompletedWebhookEventData
    ) : base(artifactCompletedWebhookEventData)
    {  }
    #pragma warning restore CS8618

    public ArtifactCompletedWebhookEventData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactCompletedWebhookEventData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ArtifactCompletedWebhookEventDataFromRaw.FromRawUnchecked"/>
    public static ArtifactCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ArtifactCompletedWebhookEventDataFromRaw : IFromRawJson<ArtifactCompletedWebhookEventData>
{
    /// <inheritdoc/>
    public ArtifactCompletedWebhookEventData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ArtifactCompletedWebhookEventData.FromRawUnchecked(rawData);
}/// <summary>
/// Generated artifact content.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
{
    /// <summary>
    /// Generated artifact text.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Text; }

    public Content ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Content (Content content) : base(content)
    {  }
    #pragma warning restore CS8618

    public Content (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Content (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContentFromRaw.FromRawUnchecked"/>
    public static Content FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Content (string text) : this()
    { this.Text = text; }
}class ContentFromRaw : IFromRawJson<Content>
{
    /// <inheritdoc/>
    public Content FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Content.FromRawUnchecked(rawData);
}/// <summary>
/// Model that generated the artifact.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ModelProvenance, ModelProvenanceFromRaw>))]
public sealed record class ModelProvenance : JsonModel
{
    public required string Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "model"
            );
        }
        init { this._rawData.Set("model", value); }
    }

    public required string Provider {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Model;
        _ = this.Provider;
    }

    public ModelProvenance ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelProvenance (ModelProvenance modelProvenance) : base(
        modelProvenance
    )
    {  }
    #pragma warning restore CS8618

    public ModelProvenance (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelProvenance (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ModelProvenanceFromRaw.FromRawUnchecked"/>
    public static ModelProvenance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ModelProvenanceFromRaw : IFromRawJson<ModelProvenance>
{
    /// <inheritdoc/>
    public ModelProvenance FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ModelProvenance.FromRawUnchecked(rawData);
}/// <summary>
/// Type of the completed artifact.
/// </summary>
[JsonConverter(typeof(ArtifactCompletedWebhookEventDataTypeConverter))]
public enum ArtifactCompletedWebhookEventDataType
{
    Summary, ActionItems, Decisions, Topics, OpenQuestions, Custom
}sealed class ArtifactCompletedWebhookEventDataTypeConverter : JsonConverter<ArtifactCompletedWebhookEventDataType>
{
    public override ArtifactCompletedWebhookEventDataType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summary"=>ArtifactCompletedWebhookEventDataType.Summary,
            "action_items"=>ArtifactCompletedWebhookEventDataType.ActionItems,
            "decisions"=>ArtifactCompletedWebhookEventDataType.Decisions,
            "topics"=>ArtifactCompletedWebhookEventDataType.Topics,
            "open_questions"=>ArtifactCompletedWebhookEventDataType.OpenQuestions,
            "custom"=>ArtifactCompletedWebhookEventDataType.Custom,
            _ =>(ArtifactCompletedWebhookEventDataType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ArtifactCompletedWebhookEventDataType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ArtifactCompletedWebhookEventDataType.Summary=>"summary",
            ArtifactCompletedWebhookEventDataType.ActionItems=>"action_items",
            ArtifactCompletedWebhookEventDataType.Decisions=>"decisions",
            ArtifactCompletedWebhookEventDataType.Topics=>"topics",
            ArtifactCompletedWebhookEventDataType.OpenQuestions=>"open_questions",
            ArtifactCompletedWebhookEventDataType.Custom=>"custom",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Event type.
/// </summary>
[JsonConverter(typeof(EventConverter))]
public enum Event
{
    ArtifactCompleted
}sealed class EventConverter : JsonConverter<Event>
{
    public override Event Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "artifact.completed"=>Event.ArtifactCompleted, _ =>(Event)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Event value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Event.ArtifactCompleted=>"artifact.completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}