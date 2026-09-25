using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberRetrieveResponse, MobilePhoneNumberRetrieveResponseFromRaw>))]
public sealed record class MobilePhoneNumberRetrieveResponse : JsonModel
{
    public MobilePhoneNumber? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumber>(
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

    public MobilePhoneNumberRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberRetrieveResponse (
        MobilePhoneNumberRetrieveResponse mobilePhoneNumberRetrieveResponse
    ) : base(mobilePhoneNumberRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobilePhoneNumberRetrieveResponseFromRaw : IFromRawJson<MobilePhoneNumberRetrieveResponse>
{
    /// <inheritdoc/>
    public MobilePhoneNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberRetrieveResponse.FromRawUnchecked(rawData);
}