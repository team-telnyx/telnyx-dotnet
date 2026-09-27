using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.References;

[JsonConverter(typeof(JsonModelConverter<ReferenceUpdateResponse, ReferenceUpdateResponseFromRaw>))]
public sealed record class ReferenceUpdateResponse : JsonModel
{
    /// <summary>
    /// A reference (business or financial) on a DIR, in the customer-facing shape.
    /// No internal identifiers are exposed.
    /// </summary>
    public required Reference Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Reference>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ReferenceUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferenceUpdateResponse (
        ReferenceUpdateResponse referenceUpdateResponse
    ) : base(referenceUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ReferenceUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferenceUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferenceUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ReferenceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ReferenceUpdateResponse (Reference data) : this()
    { this.Data = data; }
}

class ReferenceUpdateResponseFromRaw : IFromRawJson<ReferenceUpdateResponse>
{
    /// <inheritdoc/>
    public ReferenceUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReferenceUpdateResponse.FromRawUnchecked(rawData);
}