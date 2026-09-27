using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Rooms.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionList0PageResponse, SessionList0PageResponseFromRaw>))]
public sealed record class SessionList0PageResponse : JsonModel
{
    public IReadOnlyList<RoomSession>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RoomSession>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RoomSession>?>(
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

    public SessionList0PageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList0PageResponse (
        SessionList0PageResponse sessionList0PageResponse
    ) : base(sessionList0PageResponse)
    {  }
    #pragma warning restore CS8618

    public SessionList0PageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList0PageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList0PageResponseFromRaw.FromRawUnchecked"/>
    public static SessionList0PageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList0PageResponseFromRaw : IFromRawJson<SessionList0PageResponse>
{
    /// <inheritdoc/>
    public SessionList0PageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList0PageResponse.FromRawUnchecked(rawData);
}