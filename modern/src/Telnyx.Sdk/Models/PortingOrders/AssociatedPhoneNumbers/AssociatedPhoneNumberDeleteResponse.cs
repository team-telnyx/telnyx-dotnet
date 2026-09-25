using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<AssociatedPhoneNumberDeleteResponse, AssociatedPhoneNumberDeleteResponseFromRaw>))]
public sealed record class AssociatedPhoneNumberDeleteResponse : JsonModel
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

    public AssociatedPhoneNumberDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedPhoneNumberDeleteResponse (
        AssociatedPhoneNumberDeleteResponse associatedPhoneNumberDeleteResponse
    ) : base(associatedPhoneNumberDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public AssociatedPhoneNumberDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssociatedPhoneNumberDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssociatedPhoneNumberDeleteResponseFromRaw.FromRawUnchecked"/>
    public static AssociatedPhoneNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssociatedPhoneNumberDeleteResponseFromRaw : IFromRawJson<AssociatedPhoneNumberDeleteResponse>
{
    /// <inheritdoc/>
    public AssociatedPhoneNumberDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssociatedPhoneNumberDeleteResponse.FromRawUnchecked(rawData);
}