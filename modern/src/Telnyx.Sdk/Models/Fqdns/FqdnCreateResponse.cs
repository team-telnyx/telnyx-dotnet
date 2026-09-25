using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<FqdnCreateResponse, FqdnCreateResponseFromRaw>))]
public sealed record class FqdnCreateResponse : JsonModel
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

    public FqdnCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnCreateResponse (FqdnCreateResponse fqdnCreateResponse) : base(
        fqdnCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public FqdnCreateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnCreateResponseFromRaw.FromRawUnchecked"/>
    public static FqdnCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnCreateResponseFromRaw : IFromRawJson<FqdnCreateResponse>
{
    /// <inheritdoc/>
    public FqdnCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnCreateResponse.FromRawUnchecked(rawData);
}