using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Brands;

[JsonConverter(typeof(JsonModelConverter<EinBrandIdentifier, EinBrandIdentifierFromRaw>))]
public sealed record class EinBrandIdentifier : JsonModel
{
    public JsonElement IdentifierType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "identifier_type"
            );
        }
        init { this._rawData.Set("identifier_type", value); }
    }

    /// <summary>
    /// Nine digits, optionally formatted as NN-NNNNNNN.
    /// </summary>
    public required string ValueValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.IdentifierType, JsonSerializer.SerializeToElement("EIN")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.ValueValue;
    }

    public EinBrandIdentifier ()
    { this.IdentifierType = JsonSerializer.SerializeToElement("EIN"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EinBrandIdentifier (EinBrandIdentifier einBrandIdentifier) : base(
        einBrandIdentifier
    )
    {  }
    #pragma warning restore CS8618

    public EinBrandIdentifier (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.IdentifierType = JsonSerializer.SerializeToElement("EIN");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EinBrandIdentifier (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EinBrandIdentifierFromRaw.FromRawUnchecked"/>
    public static EinBrandIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EinBrandIdentifier (string valueValue) : this()
    { this.ValueValue = valueValue; }
}

class EinBrandIdentifierFromRaw : IFromRawJson<EinBrandIdentifier>
{
    /// <inheritdoc/>
    public EinBrandIdentifier FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EinBrandIdentifier.FromRawUnchecked(rawData);
}