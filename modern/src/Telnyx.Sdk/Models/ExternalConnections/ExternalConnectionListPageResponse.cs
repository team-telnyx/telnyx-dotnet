using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionListPageResponse, ExternalConnectionListPageResponseFromRaw>))]
public sealed record class ExternalConnectionListPageResponse : JsonModel
{
    public IReadOnlyList<ExternalConnection>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ExternalConnection>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ExternalConnection>?>(
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

    public ExternalConnectionListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionListPageResponse (
        ExternalConnectionListPageResponse externalConnectionListPageResponse
    ) : base(externalConnectionListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionListPageResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionListPageResponseFromRaw : IFromRawJson<ExternalConnectionListPageResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionListPageResponse.FromRawUnchecked(rawData);
}