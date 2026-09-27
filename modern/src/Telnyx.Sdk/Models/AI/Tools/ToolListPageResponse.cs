using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolListPageResponse, ToolListPageResponseFromRaw>))]
public sealed record class ToolListPageResponse : JsonModel
{
    public required IReadOnlyList<SharedToolResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<SharedToolResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<SharedToolResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public ToolListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolListPageResponse (
        ToolListPageResponse toolListPageResponse
    ) : base(toolListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ToolListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolListPageResponseFromRaw.FromRawUnchecked"/>
    public static ToolListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ToolListPageResponseFromRaw : IFromRawJson<ToolListPageResponse>
{
    /// <inheritdoc/>
    public ToolListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolListPageResponse.FromRawUnchecked(rawData);
}