using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.OutboundVoiceProfiles;

[JsonConverter(typeof(JsonModelConverter<OutboundVoiceProfileListPageResponse, OutboundVoiceProfileListPageResponseFromRaw>))]
public sealed record class OutboundVoiceProfileListPageResponse : JsonModel
{
    public IReadOnlyList<OutboundVoiceProfile>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OutboundVoiceProfile>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OutboundVoiceProfile>?>(
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

    public OutboundVoiceProfileListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OutboundVoiceProfileListPageResponse (
        OutboundVoiceProfileListPageResponse outboundVoiceProfileListPageResponse
    ) : base(outboundVoiceProfileListPageResponse)
    {  }
    #pragma warning restore CS8618

    public OutboundVoiceProfileListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OutboundVoiceProfileListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OutboundVoiceProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static OutboundVoiceProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OutboundVoiceProfileListPageResponseFromRaw : IFromRawJson<OutboundVoiceProfileListPageResponse>
{
    /// <inheritdoc/>
    public OutboundVoiceProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OutboundVoiceProfileListPageResponse.FromRawUnchecked(rawData);
}