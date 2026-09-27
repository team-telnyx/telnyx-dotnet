using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberUpdateResponse, PhoneNumberUpdateResponseFromRaw>))]
public sealed record class PhoneNumberUpdateResponse : JsonModel
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

    public PhoneNumberUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberUpdateResponse (
        PhoneNumberUpdateResponse phoneNumberUpdateResponse
    ) : base(phoneNumberUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberUpdateResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberUpdateResponseFromRaw : IFromRawJson<PhoneNumberUpdateResponse>
{
    /// <inheritdoc/>
    public PhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberUpdateResponse.FromRawUnchecked(rawData);
}