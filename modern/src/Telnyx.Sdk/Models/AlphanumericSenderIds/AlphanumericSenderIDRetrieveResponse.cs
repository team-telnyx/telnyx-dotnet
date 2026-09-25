using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AlphanumericSenderIds;

[JsonConverter(typeof(JsonModelConverter<AlphanumericSenderIDRetrieveResponse, AlphanumericSenderIDRetrieveResponseFromRaw>))]
public sealed record class AlphanumericSenderIDRetrieveResponse : JsonModel
{
    public AlphanumericSenderID? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AlphanumericSenderID>(
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

    public AlphanumericSenderIDRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AlphanumericSenderIDRetrieveResponse (
        AlphanumericSenderIDRetrieveResponse alphanumericSenderIDRetrieveResponse
    ) : base(alphanumericSenderIDRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public AlphanumericSenderIDRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AlphanumericSenderIDRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AlphanumericSenderIDRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AlphanumericSenderIDRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AlphanumericSenderIDRetrieveResponseFromRaw : IFromRawJson<AlphanumericSenderIDRetrieveResponse>
{
    /// <inheritdoc/>
    public AlphanumericSenderIDRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AlphanumericSenderIDRetrieveResponse.FromRawUnchecked(rawData);
}