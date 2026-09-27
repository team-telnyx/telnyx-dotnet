using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MeetingSessions.Artifacts;

[JsonConverter(typeof(JsonModelConverter<MeetingSessionArtifact, MeetingSessionArtifactFromRaw>))]
public sealed record class MeetingSessionArtifact : JsonModel
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

    public required Content? Content {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Content>(
                "content"
            );
        }
        init { this._rawData.Set("content", value); }
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

    public required string? FailureReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failure_reason"
            );
        }
        init { this._rawData.Set("failure_reason", value); }
    }

    public required ModelProvenance? ModelProvenance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ModelProvenance>(
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

    public required string SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required ApiEnum<string, MeetingSessionArtifactType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MeetingSessionArtifactType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Content?.Validate();
        _ = this.CreatedAt;
        _ = this.FailureReason;
        this.ModelProvenance?.Validate();
        _ = this.Prompt;
        _ = this.SessionID;
        this.Status.Validate();
        this.Type.Validate();
        _ = this.UpdatedAt;
    }

    public MeetingSessionArtifact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeetingSessionArtifact (
        MeetingSessionArtifact meetingSessionArtifact
    ) : base(meetingSessionArtifact)
    {  }
    #pragma warning restore CS8618

    public MeetingSessionArtifact (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MeetingSessionArtifact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MeetingSessionArtifactFromRaw.FromRawUnchecked"/>
    public static MeetingSessionArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MeetingSessionArtifactFromRaw : IFromRawJson<MeetingSessionArtifact>
{
    /// <inheritdoc/>
    public MeetingSessionArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MeetingSessionArtifact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Content, ContentFromRaw>))]
public sealed record class Content : JsonModel
{
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
}[JsonConverter(typeof(JsonModelConverter<ModelProvenance, ModelProvenanceFromRaw>))]
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
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Completed, Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MeetingSessionArtifactTypeConverter))]
public enum MeetingSessionArtifactType
{
    Summary, ActionItems, Decisions, Topics, OpenQuestions, Custom
}sealed class MeetingSessionArtifactTypeConverter : JsonConverter<MeetingSessionArtifactType>
{
    public override MeetingSessionArtifactType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summary"=>MeetingSessionArtifactType.Summary,
            "action_items"=>MeetingSessionArtifactType.ActionItems,
            "decisions"=>MeetingSessionArtifactType.Decisions,
            "topics"=>MeetingSessionArtifactType.Topics,
            "open_questions"=>MeetingSessionArtifactType.OpenQuestions,
            "custom"=>MeetingSessionArtifactType.Custom,
            _ =>(MeetingSessionArtifactType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MeetingSessionArtifactType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MeetingSessionArtifactType.Summary=>"summary",
            MeetingSessionArtifactType.ActionItems=>"action_items",
            MeetingSessionArtifactType.Decisions=>"decisions",
            MeetingSessionArtifactType.Topics=>"topics",
            MeetingSessionArtifactType.OpenQuestions=>"open_questions",
            MeetingSessionArtifactType.Custom=>"custom",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}