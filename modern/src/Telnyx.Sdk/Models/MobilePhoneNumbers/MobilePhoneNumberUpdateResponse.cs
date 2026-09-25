using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<MobilePhoneNumberUpdateResponse, MobilePhoneNumberUpdateResponseFromRaw>))]
public sealed record class MobilePhoneNumberUpdateResponse : JsonModel
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

    public MobilePhoneNumberUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePhoneNumberUpdateResponse (
        MobilePhoneNumberUpdateResponse mobilePhoneNumberUpdateResponse
    ) : base(mobilePhoneNumberUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MobilePhoneNumberUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePhoneNumberUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePhoneNumberUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MobilePhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobilePhoneNumberUpdateResponseFromRaw : IFromRawJson<MobilePhoneNumberUpdateResponse>
{
    /// <inheritdoc/>
    public MobilePhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePhoneNumberUpdateResponse.FromRawUnchecked(rawData);
}