using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<NumberOrderPhoneNumberRetrieveResponse, NumberOrderPhoneNumberRetrieveResponseFromRaw>))]
public sealed record class NumberOrderPhoneNumberRetrieveResponse : JsonModel
{
    public NumberOrderPhoneNumber? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<NumberOrderPhoneNumber>(
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

    public NumberOrderPhoneNumberRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderPhoneNumberRetrieveResponse (
        NumberOrderPhoneNumberRetrieveResponse numberOrderPhoneNumberRetrieveResponse
    ) : base(numberOrderPhoneNumberRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderPhoneNumberRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderPhoneNumberRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderPhoneNumberRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderPhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderPhoneNumberRetrieveResponseFromRaw : IFromRawJson<NumberOrderPhoneNumberRetrieveResponse>
{
    /// <inheritdoc/>
    public NumberOrderPhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderPhoneNumberRetrieveResponse.FromRawUnchecked(rawData);
}