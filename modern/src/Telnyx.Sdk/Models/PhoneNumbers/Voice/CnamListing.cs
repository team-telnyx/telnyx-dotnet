using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

/// <summary>
/// The CNAM listing settings for a phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CnamListing, CnamListingFromRaw>))]
public sealed record class CnamListing : JsonModel
{
    /// <summary>
    /// The CNAM listing details for this number. Must be alphanumeric characters
    /// or spaces with a maximum length of 15. Requires cnam_listing_enabled to also
    /// be set to true.
    /// </summary>
    public string? CnamListingDetails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cnam_listing_details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cnam_listing_details", value);
        }
    }

    /// <summary>
    /// Enables CNAM listings for this number. Requires cnam_listing_details to also
    /// be set.
    /// </summary>
    public bool? CnamListingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "cnam_listing_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cnam_listing_enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CnamListingDetails;
        _ = this.CnamListingEnabled;
    }

    public CnamListing ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CnamListing (CnamListing cnamListing) : base(cnamListing)
    {  }
    #pragma warning restore CS8618

    public CnamListing (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CnamListing (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CnamListingFromRaw.FromRawUnchecked"/>
    public static CnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CnamListingFromRaw : IFromRawJson<CnamListing>
{
    /// <inheritdoc/>
    public CnamListing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CnamListing.FromRawUnchecked(rawData);
}