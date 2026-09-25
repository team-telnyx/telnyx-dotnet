using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<FqdnUpdateResponse, FqdnUpdateResponseFromRaw>))]
public sealed record class FqdnUpdateResponse : JsonModel
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

    public FqdnUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnUpdateResponse (FqdnUpdateResponse fqdnUpdateResponse) : base(
        fqdnUpdateResponse
    )
    {  }
    #pragma warning restore CS8618

    public FqdnUpdateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FqdnUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnUpdateResponseFromRaw : IFromRawJson<FqdnUpdateResponse>
{
    /// <inheritdoc/>
    public FqdnUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnUpdateResponse.FromRawUnchecked(rawData);
}