using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ShortCodes;

[JsonConverter(typeof(JsonModelConverter<ShortCodeRetrieveResponse, ShortCodeRetrieveResponseFromRaw>))]
public sealed record class ShortCodeRetrieveResponse : JsonModel
{
    public ShortCode? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ShortCode>(
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

    public ShortCodeRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShortCodeRetrieveResponse (
        ShortCodeRetrieveResponse shortCodeRetrieveResponse
    ) : base(shortCodeRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ShortCodeRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortCodeRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ShortCodeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ShortCodeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ShortCodeRetrieveResponseFromRaw : IFromRawJson<ShortCodeRetrieveResponse>
{
    /// <inheritdoc/>
    public ShortCodeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ShortCodeRetrieveResponse.FromRawUnchecked(rawData);
}