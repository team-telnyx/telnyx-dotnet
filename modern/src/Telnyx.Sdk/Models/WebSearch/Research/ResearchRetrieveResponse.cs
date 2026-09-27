using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebSearch.Research;

[JsonConverter(typeof(JsonModelConverter<ResearchRetrieveResponse, ResearchRetrieveResponseFromRaw>))]
public sealed record class ResearchRetrieveResponse : JsonModel
{
    public ResearchRetrieveResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ResearchRetrieveResponseData>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ResearchRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchRetrieveResponse (
        ResearchRetrieveResponse researchRetrieveResponse
    ) : base(researchRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ResearchRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ResearchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ResearchRetrieveResponseFromRaw : IFromRawJson<ResearchRetrieveResponse>
{
    /// <inheritdoc/>
    public ResearchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ResearchRetrieveResponseData, ResearchRetrieveResponseDataFromRaw>))]
public sealed record class ResearchRetrieveResponseData : JsonModel
{
    /// <summary>
    /// Current status of the research task.
    /// </summary>
    public required ApiEnum<string, ResearchRetrieveResponseDataStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ResearchRetrieveResponseDataStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// The research task identifier.
    /// </summary>
    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "task_id"
            );
        }
        init { this._rawData.Set("task_id", value); }
    }

    /// <summary>
    /// The synthesized research answer (present when status is `completed`).
    /// </summary>
    public string? Answer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "answer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("answer", value);
        }
    }

    /// <summary>
    /// Sources cited in the answer (present when status is `completed`).
    /// </summary>
    public IReadOnlyList<ResearchCitation>? Citations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ResearchCitation>>(
                "citations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ResearchCitation>?>(
                "citations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Always present in poll responses; `null` unless the task failed.
    /// </summary>
    public string? Error {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error"
            );
        }
        init { this._rawData.Set("error", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.TaskID;
        _ = this.Answer;
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
        _ = this.Error;
    }

    public ResearchRetrieveResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchRetrieveResponseData (
        ResearchRetrieveResponseData researchRetrieveResponseData
    ) : base(researchRetrieveResponseData)
    {  }
    #pragma warning restore CS8618

    public ResearchRetrieveResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchRetrieveResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchRetrieveResponseDataFromRaw.FromRawUnchecked"/>
    public static ResearchRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResearchRetrieveResponseDataFromRaw : IFromRawJson<ResearchRetrieveResponseData>
{
    /// <inheritdoc/>
    public ResearchRetrieveResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchRetrieveResponseData.FromRawUnchecked(rawData);
}/// <summary>
/// Current status of the research task.
/// </summary>
[JsonConverter(typeof(ResearchRetrieveResponseDataStatusConverter))]
public enum ResearchRetrieveResponseDataStatus
{
    Pending, Running, Completed, Failed
}sealed class ResearchRetrieveResponseDataStatusConverter : JsonConverter<ResearchRetrieveResponseDataStatus>
{
    public override ResearchRetrieveResponseDataStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>ResearchRetrieveResponseDataStatus.Pending,
            "running"=>ResearchRetrieveResponseDataStatus.Running,
            "completed"=>ResearchRetrieveResponseDataStatus.Completed,
            "failed"=>ResearchRetrieveResponseDataStatus.Failed,
            _ =>(ResearchRetrieveResponseDataStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ResearchRetrieveResponseDataStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ResearchRetrieveResponseDataStatus.Pending=>"pending",
            ResearchRetrieveResponseDataStatus.Running=>"running",
            ResearchRetrieveResponseDataStatus.Completed=>"completed",
            ResearchRetrieveResponseDataStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}