using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests;

/// <summary>
/// Paginated list of assistant tests with metadata.
///
/// <para>Returns a subset of tests based on pagination parameters along with metadata
/// for implementing pagination controls in the UI.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TestListPageResponse, TestListPageResponseFromRaw>))]
public sealed record class TestListPageResponse : JsonModel
{
    /// <summary>
    /// Array of assistant test objects for the current page.
    /// </summary>
    public required IReadOnlyList<AssistantTest> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AssistantTest>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AssistantTest>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Pagination metadata including total counts and current page info.
    /// </summary>
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

    public TestListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestListPageResponse (
        TestListPageResponse testListPageResponse
    ) : base(testListPageResponse)
    {  }
    #pragma warning restore CS8618

    public TestListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestListPageResponseFromRaw.FromRawUnchecked"/>
    public static TestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TestListPageResponseFromRaw : IFromRawJson<TestListPageResponse>
{
    /// <inheritdoc/>
    public TestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestListPageResponse.FromRawUnchecked(rawData);
}