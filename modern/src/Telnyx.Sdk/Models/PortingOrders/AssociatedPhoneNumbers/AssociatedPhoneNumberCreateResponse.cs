using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<AssociatedPhoneNumberCreateResponse, AssociatedPhoneNumberCreateResponseFromRaw>))]
public sealed record class AssociatedPhoneNumberCreateResponse : JsonModel
{
    public PortingAssociatedPhoneNumber? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingAssociatedPhoneNumber>(
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

    public AssociatedPhoneNumberCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedPhoneNumberCreateResponse (
        AssociatedPhoneNumberCreateResponse associatedPhoneNumberCreateResponse
    ) : base(associatedPhoneNumberCreateResponse)
    {  }
    #pragma warning restore CS8618

    public AssociatedPhoneNumberCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssociatedPhoneNumberCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssociatedPhoneNumberCreateResponseFromRaw.FromRawUnchecked"/>
    public static AssociatedPhoneNumberCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssociatedPhoneNumberCreateResponseFromRaw : IFromRawJson<AssociatedPhoneNumberCreateResponse>
{
    /// <inheritdoc/>
    public AssociatedPhoneNumberCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssociatedPhoneNumberCreateResponse.FromRawUnchecked(rawData);
}