using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Recordings;

[JsonConverter(typeof(JsonModelConverter<RecordingListPageResponse, RecordingListPageResponseFromRaw>))]
public sealed record class RecordingListPageResponse : JsonModel
{
    public IReadOnlyList<RecordingResponseData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RecordingResponseData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RecordingResponseData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public RecordingListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecordingListPageResponse (
        RecordingListPageResponse recordingListPageResponse
    ) : base(recordingListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RecordingListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecordingListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecordingListPageResponseFromRaw.FromRawUnchecked"/>
    public static RecordingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecordingListPageResponseFromRaw : IFromRawJson<RecordingListPageResponse>
{
    /// <inheritdoc/>
    public RecordingListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecordingListPageResponse.FromRawUnchecked(rawData);
}