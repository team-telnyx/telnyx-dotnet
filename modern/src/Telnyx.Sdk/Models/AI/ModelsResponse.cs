using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI;

[JsonConverter(typeof(JsonModelConverter<ModelsResponse, ModelsResponseFromRaw>))]
public sealed record class ModelsResponse : JsonModel
{
    public required IReadOnlyList<ModelMetadata> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ModelMetadata>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ModelMetadata>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Object {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "object"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("object", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.Object;
    }

    public ModelsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ModelsResponse (ModelsResponse modelsResponse) : base(modelsResponse)
    {  }
    #pragma warning restore CS8618

    public ModelsResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ModelsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ModelsResponseFromRaw.FromRawUnchecked"/>
    public static ModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ModelsResponse (IReadOnlyList<ModelMetadata> data) : this()
    { this.Data = data; }
}

class ModelsResponseFromRaw : IFromRawJson<ModelsResponse>
{
    /// <inheritdoc/>
    public ModelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ModelsResponse.FromRawUnchecked(rawData);
}