using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.Rooms.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionList1PageResponse, SessionList1PageResponseFromRaw>))]
public sealed record class SessionList1PageResponse : JsonModel
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

    public SessionList1PageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionList1PageResponse (
        SessionList1PageResponse sessionList1PageResponse
    ) : base(sessionList1PageResponse)
    {  }
    #pragma warning restore CS8618

    public SessionList1PageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionList1PageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionList1PageResponseFromRaw.FromRawUnchecked"/>
    public static SessionList1PageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionList1PageResponseFromRaw : IFromRawJson<SessionList1PageResponse>
{
    /// <inheritdoc/>
    public SessionList1PageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionList1PageResponse.FromRawUnchecked(rawData);
}