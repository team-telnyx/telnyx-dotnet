using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceListParticipantsPageResponse, ConferenceListParticipantsPageResponseFromRaw>))]
public sealed record class ConferenceListParticipantsPageResponse : JsonModel
{
    public IReadOnlyList<ConferenceListParticipantsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConferenceListParticipantsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ConferenceListParticipantsResponse>?>(
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

    public ConferenceListParticipantsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParticipantsPageResponse (
        ConferenceListParticipantsPageResponse conferenceListParticipantsPageResponse
    ) : base(conferenceListParticipantsPageResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceListParticipantsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParticipantsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceListParticipantsPageResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceListParticipantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceListParticipantsPageResponseFromRaw : IFromRawJson<ConferenceListParticipantsPageResponse>
{
    /// <inheritdoc/>
    public ConferenceListParticipantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceListParticipantsPageResponse.FromRawUnchecked(rawData);
}