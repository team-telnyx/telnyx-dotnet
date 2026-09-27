using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

/// <summary>
/// Paginated list of test runs with metadata.
///
/// <para>Returns test run execution results with pagination support for handling
/// large numbers of test executions.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PaginatedTestRunList, PaginatedTestRunListFromRaw>))]
public sealed record class PaginatedTestRunList : JsonModel
{
    /// <summary>
    /// Array of test run objects for the current page.
    /// </summary>
    public required IReadOnlyList<TestRunResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TestRunResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<TestRunResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including total counts and current page info.
    /// </summary>
    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
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

    public PaginatedTestRunList ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PaginatedTestRunList (
        PaginatedTestRunList paginatedTestRunList
    ) : base(paginatedTestRunList)
    {  }
    #pragma warning restore CS8618

    public PaginatedTestRunList (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PaginatedTestRunList (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PaginatedTestRunListFromRaw.FromRawUnchecked"/>
    public static PaginatedTestRunList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PaginatedTestRunListFromRaw : IFromRawJson<PaginatedTestRunList>
{
    /// <inheritdoc/>
    public PaginatedTestRunList FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PaginatedTestRunList.FromRawUnchecked(rawData);
}