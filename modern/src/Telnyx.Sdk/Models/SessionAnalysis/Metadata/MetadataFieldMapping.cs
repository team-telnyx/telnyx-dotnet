using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis.Metadata;

[JsonConverter(typeof(JsonModelConverter<MetadataFieldMapping, MetadataFieldMappingFromRaw>))]
public sealed record class MetadataFieldMapping : JsonModel
{
    public required string LocalField {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "local_field"
            );
        }
        init { this._rawData.Set("local_field", value); }
    }

    public required string ParentField {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "parent_field"
            );
        }
        init { this._rawData.Set("parent_field", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LocalField;
        _ = this.ParentField;
    }

    public MetadataFieldMapping ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MetadataFieldMapping (
        MetadataFieldMapping metadataFieldMapping
    ) : base(metadataFieldMapping)
    {  }
    #pragma warning restore CS8618

    public MetadataFieldMapping (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MetadataFieldMapping (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetadataFieldMappingFromRaw.FromRawUnchecked"/>
    public static MetadataFieldMapping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MetadataFieldMappingFromRaw : IFromRawJson<MetadataFieldMapping>
{
    /// <inheritdoc/>
    public MetadataFieldMapping FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MetadataFieldMapping.FromRawUnchecked(rawData);
}