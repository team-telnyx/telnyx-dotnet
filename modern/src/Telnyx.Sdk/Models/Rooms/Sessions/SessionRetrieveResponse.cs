using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Sessions;

[JsonConverter(typeof(JsonModelConverter<SessionRetrieveResponse, SessionRetrieveResponseFromRaw>))]
public sealed record class SessionRetrieveResponse : JsonModel
{
    public RoomSession? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RoomSession>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public SessionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionRetrieveResponse (
        SessionRetrieveResponse sessionRetrieveResponse
    ) : base(sessionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SessionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SessionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionRetrieveResponseFromRaw : IFromRawJson<SessionRetrieveResponse>
{
    /// <inheritdoc/>
    public SessionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionRetrieveResponse.FromRawUnchecked(rawData);
}