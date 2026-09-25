using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberExtensionDeleteResponse, PhoneNumberExtensionDeleteResponseFromRaw>))]
public sealed record class PhoneNumberExtensionDeleteResponse : JsonModel
{
    public PortingPhoneNumberExtension? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingPhoneNumberExtension>(
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

    public PhoneNumberExtensionDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberExtensionDeleteResponse (
        PhoneNumberExtensionDeleteResponse phoneNumberExtensionDeleteResponse
    ) : base(phoneNumberExtensionDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberExtensionDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberExtensionDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberExtensionDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberExtensionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberExtensionDeleteResponseFromRaw : IFromRawJson<PhoneNumberExtensionDeleteResponse>
{
    /// <inheritdoc/>
    public PhoneNumberExtensionDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberExtensionDeleteResponse.FromRawUnchecked(rawData);
}