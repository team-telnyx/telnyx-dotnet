using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberExtensionCreateResponse, PhoneNumberExtensionCreateResponseFromRaw>))]
public sealed record class PhoneNumberExtensionCreateResponse : JsonModel
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

    public PhoneNumberExtensionCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberExtensionCreateResponse (
        PhoneNumberExtensionCreateResponse phoneNumberExtensionCreateResponse
    ) : base(phoneNumberExtensionCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberExtensionCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberExtensionCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberExtensionCreateResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberExtensionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberExtensionCreateResponseFromRaw : IFromRawJson<PhoneNumberExtensionCreateResponse>
{
    /// <inheritdoc/>
    public PhoneNumberExtensionCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberExtensionCreateResponse.FromRawUnchecked(rawData);
}