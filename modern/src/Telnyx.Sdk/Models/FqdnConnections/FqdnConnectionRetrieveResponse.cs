using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections;

[JsonConverter(typeof(JsonModelConverter<FqdnConnectionRetrieveResponse, FqdnConnectionRetrieveResponseFromRaw>))]
public sealed record class FqdnConnectionRetrieveResponse : JsonModel
{
    public FqdnConnection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FqdnConnection>(
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

    public FqdnConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnConnectionRetrieveResponse (
        FqdnConnectionRetrieveResponse fqdnConnectionRetrieveResponse
    ) : base(fqdnConnectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnConnectionRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FqdnConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnConnectionRetrieveResponseFromRaw : IFromRawJson<FqdnConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public FqdnConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnConnectionRetrieveResponse.FromRawUnchecked(rawData);
}