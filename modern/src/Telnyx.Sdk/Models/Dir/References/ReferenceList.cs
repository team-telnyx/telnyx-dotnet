using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.References;

[JsonConverter(typeof(JsonModelConverter<ReferenceList, ReferenceListFromRaw>))]
public sealed record class ReferenceList : JsonModel
{
    public required IReadOnlyList<Reference> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Reference>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Reference>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ReferenceList ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferenceList (ReferenceList referenceList) : base(referenceList)
    {  }
    #pragma warning restore CS8618

    public ReferenceList (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferenceList (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferenceListFromRaw.FromRawUnchecked"/>
    public static ReferenceList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ReferenceList (IReadOnlyList<Reference> data) : this()
    { this.Data = data; }
}

class ReferenceListFromRaw : IFromRawJson<ReferenceList>
{
    /// <inheritdoc/>
    public ReferenceList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReferenceList.FromRawUnchecked(rawData);
}