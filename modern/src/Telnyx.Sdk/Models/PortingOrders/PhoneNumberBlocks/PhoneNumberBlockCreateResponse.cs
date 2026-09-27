using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberBlockCreateResponse, PhoneNumberBlockCreateResponseFromRaw>))]
public sealed record class PhoneNumberBlockCreateResponse : JsonModel
{
    public PortingPhoneNumberBlock? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingPhoneNumberBlock>(
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

    public PhoneNumberBlockCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBlockCreateResponse (
        PhoneNumberBlockCreateResponse phoneNumberBlockCreateResponse
    ) : base(phoneNumberBlockCreateResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberBlockCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBlockCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberBlockCreateResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberBlockCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberBlockCreateResponseFromRaw : IFromRawJson<PhoneNumberBlockCreateResponse>
{
    /// <inheritdoc/>
    public PhoneNumberBlockCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberBlockCreateResponse.FromRawUnchecked(rawData);
}