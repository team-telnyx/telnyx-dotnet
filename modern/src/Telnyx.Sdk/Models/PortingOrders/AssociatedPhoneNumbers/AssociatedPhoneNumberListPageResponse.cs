using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<AssociatedPhoneNumberListPageResponse, AssociatedPhoneNumberListPageResponseFromRaw>))]
public sealed record class AssociatedPhoneNumberListPageResponse : JsonModel
{
    public IReadOnlyList<PortingAssociatedPhoneNumber>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingAssociatedPhoneNumber>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingAssociatedPhoneNumber>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public AssociatedPhoneNumberListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedPhoneNumberListPageResponse (
        AssociatedPhoneNumberListPageResponse associatedPhoneNumberListPageResponse
    ) : base(associatedPhoneNumberListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AssociatedPhoneNumberListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssociatedPhoneNumberListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssociatedPhoneNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static AssociatedPhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssociatedPhoneNumberListPageResponseFromRaw : IFromRawJson<AssociatedPhoneNumberListPageResponse>
{
    /// <inheritdoc/>
    public AssociatedPhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssociatedPhoneNumberListPageResponse.FromRawUnchecked(rawData);
}