using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Rooms.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionRetrieveParticipantsPageResponse, SessionRetrieveParticipantsPageResponseFromRaw>))]
public sealed record class SessionRetrieveParticipantsPageResponse : JsonModel
{
    public IReadOnlyList<RoomParticipant>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RoomParticipant>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RoomParticipant>?>(
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

    public SessionRetrieveParticipantsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionRetrieveParticipantsPageResponse (
        SessionRetrieveParticipantsPageResponse sessionRetrieveParticipantsPageResponse
    ) : base(sessionRetrieveParticipantsPageResponse)
    {  }
    #pragma warning restore CS8618

    public SessionRetrieveParticipantsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionRetrieveParticipantsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionRetrieveParticipantsPageResponseFromRaw.FromRawUnchecked"/>
    public static SessionRetrieveParticipantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionRetrieveParticipantsPageResponseFromRaw : IFromRawJson<SessionRetrieveParticipantsPageResponse>
{
    /// <inheritdoc/>
    public SessionRetrieveParticipantsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionRetrieveParticipantsPageResponse.FromRawUnchecked(rawData);
}