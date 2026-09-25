using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrieveResponse, PhoneNumberRetrieveResponseFromRaw>))]
public sealed record class PhoneNumberRetrieveResponse : JsonModel
{
    public NumbersPhoneNumberDetailed? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumbersPhoneNumberDetailed>(
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

    public PhoneNumberRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrieveResponse (
        PhoneNumberRetrieveResponse phoneNumberRetrieveResponse
    ) : base(phoneNumberRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberRetrieveResponseFromRaw : IFromRawJson<PhoneNumberRetrieveResponse>
{
    /// <inheritdoc/>
    public PhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrieveResponse.FromRawUnchecked(rawData);
}