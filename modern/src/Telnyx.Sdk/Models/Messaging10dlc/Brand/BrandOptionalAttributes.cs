using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

[JsonConverter(typeof(JsonModelConverter<BrandOptionalAttributes, BrandOptionalAttributesFromRaw>))]
public sealed record class BrandOptionalAttributes : JsonModel
{
    /// <summary>
    /// The tax exempt status of the brand
    /// </summary>
    public string? TaxExemptStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "taxExemptStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("taxExemptStatus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.TaxExemptStatus; }

    public BrandOptionalAttributes ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandOptionalAttributes (
        BrandOptionalAttributes brandOptionalAttributes
    ) : base(brandOptionalAttributes)
    {  }
    #pragma warning restore CS8618

    public BrandOptionalAttributes (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandOptionalAttributes (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandOptionalAttributesFromRaw.FromRawUnchecked"/>
    public static BrandOptionalAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandOptionalAttributesFromRaw : IFromRawJson<BrandOptionalAttributes>
{
    /// <inheritdoc/>
    public BrandOptionalAttributes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandOptionalAttributes.FromRawUnchecked(rawData);
}