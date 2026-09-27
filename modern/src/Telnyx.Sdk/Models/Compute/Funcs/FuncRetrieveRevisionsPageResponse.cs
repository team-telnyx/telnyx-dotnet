using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveRevisionsPageResponse, FuncRetrieveRevisionsPageResponseFromRaw>))]
public sealed record class FuncRetrieveRevisionsPageResponse : JsonModel
{
    public IReadOnlyList<FuncRetrieveRevisionsResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FuncRetrieveRevisionsResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FuncRetrieveRevisionsResponse>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public FunctionsObservabilityPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FunctionsObservabilityPaginationMeta>(
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

    public FuncRetrieveRevisionsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveRevisionsPageResponse (
        FuncRetrieveRevisionsPageResponse funcRetrieveRevisionsPageResponse
    ) : base(funcRetrieveRevisionsPageResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveRevisionsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveRevisionsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveRevisionsPageResponseFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveRevisionsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncRetrieveRevisionsPageResponseFromRaw : IFromRawJson<FuncRetrieveRevisionsPageResponse>
{
    /// <inheritdoc/>
    public FuncRetrieveRevisionsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveRevisionsPageResponse.FromRawUnchecked(rawData);
}