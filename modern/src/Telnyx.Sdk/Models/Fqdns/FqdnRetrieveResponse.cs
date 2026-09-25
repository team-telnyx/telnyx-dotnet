using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<FqdnRetrieveResponse, FqdnRetrieveResponseFromRaw>))]
public sealed record class FqdnRetrieveResponse : JsonModel
{
    public Fqdn? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Fqdn>(
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

    public FqdnRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnRetrieveResponse (
        FqdnRetrieveResponse fqdnRetrieveResponse
    ) : base(fqdnRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FqdnRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnRetrieveResponseFromRaw : IFromRawJson<FqdnRetrieveResponse>
{
    /// <inheritdoc/>
    public FqdnRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnRetrieveResponse.FromRawUnchecked(rawData);
}