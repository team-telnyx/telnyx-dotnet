using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberBlockDeleteResponse, PhoneNumberBlockDeleteResponseFromRaw>))]
public sealed record class PhoneNumberBlockDeleteResponse : JsonModel
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

    public PhoneNumberBlockDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBlockDeleteResponse (
        PhoneNumberBlockDeleteResponse phoneNumberBlockDeleteResponse
    ) : base(phoneNumberBlockDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberBlockDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBlockDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberBlockDeleteResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberBlockDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberBlockDeleteResponseFromRaw : IFromRawJson<PhoneNumberBlockDeleteResponse>
{
    /// <inheritdoc/>
    public PhoneNumberBlockDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberBlockDeleteResponse.FromRawUnchecked(rawData);
}