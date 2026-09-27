using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RecordingTranscriptions;

[JsonConverter(typeof(JsonModelConverter<RecordingTranscriptionListPageResponse, RecordingTranscriptionListPageResponseFromRaw>))]
public sealed record class RecordingTranscriptionListPageResponse : JsonModel
{
    public IReadOnlyList<RecordingTranscription>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecordingTranscription>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RecordingTranscription>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public RecordingTranscriptionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingTranscriptionListPageResponse (
        RecordingTranscriptionListPageResponse recordingTranscriptionListPageResponse
    ) : base(recordingTranscriptionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RecordingTranscriptionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingTranscriptionListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingTranscriptionListPageResponseFromRaw.FromRawUnchecked"/>
    public static RecordingTranscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingTranscriptionListPageResponseFromRaw : IFromRawJson<RecordingTranscriptionListPageResponse>
{
    /// <inheritdoc/>
    public RecordingTranscriptionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingTranscriptionListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public Cursor? Cursors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cursor>(
                "cursors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cursors", value);
        }
    }

    /// <summary>
    /// Path to next page.
    /// </summary>
    public string? Next {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next", value);
        }
    }

    /// <summary>
    /// Path to previous page.
    /// </summary>
    public string? Previous {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("previous", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cursors?.Validate();
        _ = this.Next;
        _ = this.Previous;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}