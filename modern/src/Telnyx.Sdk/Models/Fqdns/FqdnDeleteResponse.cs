using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<FqdnDeleteResponse, FqdnDeleteResponseFromRaw>))]
public sealed record class FqdnDeleteResponse : JsonModel
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

    public FqdnDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnDeleteResponse (FqdnDeleteResponse fqdnDeleteResponse) : base(
        fqdnDeleteResponse
    )
    {  }
    #pragma warning restore CS8618

    public FqdnDeleteResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FqdnDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnDeleteResponseFromRaw : IFromRawJson<FqdnDeleteResponse>
{
    /// <inheritdoc/>
    public FqdnDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnDeleteResponse.FromRawUnchecked(rawData);
}