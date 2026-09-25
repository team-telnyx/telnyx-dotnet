using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<NumberOrderPhoneNumberUpdateRequirementsResponse, NumberOrderPhoneNumberUpdateRequirementsResponseFromRaw>))]
public sealed record class NumberOrderPhoneNumberUpdateRequirementsResponse : JsonModel
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

    public NumberOrderPhoneNumberUpdateRequirementsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberOrderPhoneNumberUpdateRequirementsResponse (
        NumberOrderPhoneNumberUpdateRequirementsResponse numberOrderPhoneNumberUpdateRequirementsResponse
    ) : base(numberOrderPhoneNumberUpdateRequirementsResponse)
    {  }
    #pragma warning restore CS8618

    public NumberOrderPhoneNumberUpdateRequirementsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberOrderPhoneNumberUpdateRequirementsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberOrderPhoneNumberUpdateRequirementsResponseFromRaw.FromRawUnchecked"/>
    public static NumberOrderPhoneNumberUpdateRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberOrderPhoneNumberUpdateRequirementsResponseFromRaw : IFromRawJson<NumberOrderPhoneNumberUpdateRequirementsResponse>
{
    /// <inheritdoc/>
    public NumberOrderPhoneNumberUpdateRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberOrderPhoneNumberUpdateRequirementsResponse.FromRawUnchecked(rawData);
}