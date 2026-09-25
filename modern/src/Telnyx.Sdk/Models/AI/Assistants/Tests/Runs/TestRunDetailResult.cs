using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;

[JsonConverter(typeof(JsonModelConverter<TestRunDetailResult, TestRunDetailResultFromRaw>))]
public sealed record class TestRunDetailResult : JsonModel
{
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Represents the lifecycle of a test:   - 'pending': Test is waiting to be executed.
    ///   - 'starting': Test execution is initializing.   - 'running': Test is currently
    /// executing.   - 'passed': Test completed successfully.   - 'failed': Test
    /// executed but did not pass.   - 'error': An error occurred during test execution.
    /// </summary>
    public required ApiEnum<string, TestStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TestStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Status.Validate();
    }

    public TestRunDetailResult ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestRunDetailResult (TestRunDetailResult testRunDetailResult) : base(
        testRunDetailResult
    )
    {  }
    #pragma warning restore CS8618

    public TestRunDetailResult (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestRunDetailResult (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestRunDetailResultFromRaw.FromRawUnchecked"/>
    public static TestRunDetailResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TestRunDetailResultFromRaw : IFromRawJson<TestRunDetailResult>
{
    /// <inheritdoc/>
    public TestRunDetailResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestRunDetailResult.FromRawUnchecked(rawData);
}