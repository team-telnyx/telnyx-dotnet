using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadListPageResponse, UploadListPageResponseFromRaw>))]
public sealed record class UploadListPageResponse : JsonModel
{
    public IReadOnlyList<Upload>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Upload>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Upload>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ExternalVoiceIntegrationsPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalVoiceIntegrationsPaginationMeta>(
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

    public UploadListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadListPageResponse (
        UploadListPageResponse uploadListPageResponse
    ) : base(uploadListPageResponse)
    {  }
    #pragma warning restore CS8618

    public UploadListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadListPageResponseFromRaw.FromRawUnchecked"/>
    public static UploadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadListPageResponseFromRaw : IFromRawJson<UploadListPageResponse>
{
    /// <inheritdoc/>
    public UploadListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadListPageResponse.FromRawUnchecked(rawData);
}