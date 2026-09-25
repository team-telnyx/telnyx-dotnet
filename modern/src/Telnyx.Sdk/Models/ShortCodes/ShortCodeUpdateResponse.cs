using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ShortCodes;

[JsonConverter(typeof(JsonModelConverter<ShortCodeUpdateResponse, ShortCodeUpdateResponseFromRaw>))]
public sealed record class ShortCodeUpdateResponse : JsonModel
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

    public ShortCodeUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ShortCodeUpdateResponse (
        ShortCodeUpdateResponse shortCodeUpdateResponse
    ) : base(shortCodeUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ShortCodeUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ShortCodeUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ShortCodeUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ShortCodeUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ShortCodeUpdateResponseFromRaw : IFromRawJson<ShortCodeUpdateResponse>
{
    /// <inheritdoc/>
    public ShortCodeUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ShortCodeUpdateResponse.FromRawUnchecked(rawData);
}