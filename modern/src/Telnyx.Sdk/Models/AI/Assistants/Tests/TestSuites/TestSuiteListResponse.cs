using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites;

/// <summary>
/// Response containing all available test suite names.
///
/// <para>Returns a list of distinct test suite names that can be used for filtering
/// and organizing tests.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TestSuiteListResponse, TestSuiteListResponseFromRaw>))]
public sealed record class TestSuiteListResponse : JsonModel
{
    /// <summary>
    /// Array of unique test suite names available to the user.
    /// </summary>
    public required IReadOnlyList<string> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Data; }

    public TestSuiteListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestSuiteListResponse (
        TestSuiteListResponse testSuiteListResponse
    ) : base(testSuiteListResponse)
    {  }
    #pragma warning restore CS8618

    public TestSuiteListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestSuiteListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestSuiteListResponseFromRaw.FromRawUnchecked"/>
    public static TestSuiteListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TestSuiteListResponse (IReadOnlyList<string> data) : this()
    { this.Data = data; }
}

class TestSuiteListResponseFromRaw : IFromRawJson<TestSuiteListResponse>
{
    /// <inheritdoc/>
    public TestSuiteListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestSuiteListResponse.FromRawUnchecked(rawData);
}