using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections;

[JsonConverter(typeof(JsonModelConverter<CollectionEnvelope, CollectionEnvelopeFromRaw>))]
public sealed record class CollectionEnvelope : JsonModel
{
    public Collection? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Collection>(
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

    public CollectionEnvelope ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CollectionEnvelope (CollectionEnvelope collectionEnvelope) : base(
        collectionEnvelope
    )
    {  }
    #pragma warning restore CS8618

    public CollectionEnvelope (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CollectionEnvelope (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CollectionEnvelopeFromRaw.FromRawUnchecked"/>
    public static CollectionEnvelope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CollectionEnvelopeFromRaw : IFromRawJson<CollectionEnvelope>
{
    /// <inheritdoc/>
    public CollectionEnvelope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CollectionEnvelope.FromRawUnchecked(rawData);
}