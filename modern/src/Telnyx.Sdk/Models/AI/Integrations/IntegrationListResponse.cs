using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Integrations;

[JsonConverter(typeof(JsonModelConverter<IntegrationListResponse, IntegrationListResponseFromRaw>))]
public sealed record class IntegrationListResponse : JsonModel
{
    public required IReadOnlyList<Integration> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Integration>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Integration>>(
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

    public IntegrationListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationListResponse (
        IntegrationListResponse integrationListResponse
    ) : base(integrationListResponse)
    {  }
    #pragma warning restore CS8618

    public IntegrationListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationListResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public IntegrationListResponse (IReadOnlyList<Integration> data) : this()
    { this.Data = data; }
}

class IntegrationListResponseFromRaw : IFromRawJson<IntegrationListResponse>
{
    /// <inheritdoc/>
    public IntegrationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntegrationListResponse.FromRawUnchecked(rawData);
}