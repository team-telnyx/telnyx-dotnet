using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;
using Telnyx.Sdk.Models.PhoneNumbers.Actions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

[JsonConverter(typeof(JsonModelConverter<VoiceListPageResponse, VoiceListPageResponseFromRaw>))]
public sealed record class VoiceListPageResponse : JsonModel
{
    public IReadOnlyList<PhoneNumberWithVoiceSettings>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PhoneNumberWithVoiceSettings>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PhoneNumberWithVoiceSettings>?>(
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

    public VoiceListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceListPageResponse (
        VoiceListPageResponse voiceListPageResponse
    ) : base(voiceListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceListPageResponseFromRaw.FromRawUnchecked"/>
    public static VoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceListPageResponseFromRaw : IFromRawJson<VoiceListPageResponse>
{
    /// <inheritdoc/>
    public VoiceListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceListPageResponse.FromRawUnchecked(rawData);
}