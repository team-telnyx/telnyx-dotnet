using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;

/// <summary>
/// Response model containing test run execution details and results.
///
/// <para>Provides comprehensive information about a test execution including status,
/// timing, logs, and detailed evaluation results.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<TestRunResponse, TestRunResponseFromRaw>))]
public sealed record class TestRunResponse : JsonModel
{
    /// <summary>
    /// Timestamp when the test run was created and queued.
    /// </summary>
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Unique identifier for this specific test run execution.
    /// </summary>
    public required string RunID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "run_id"
            );
        }
        init { this._rawData.Set("run_id", value); }
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

    /// <summary>
    /// Identifier of the assistant test that was executed.
    /// </summary>
    public required string TestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "test_id"
            );
        }
        init { this._rawData.Set("test_id", value); }
    }

    /// <summary>
    /// How this test run was initiated (manual, scheduled, or API).
    /// </summary>
    public required string TriggeredBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "triggered_by"
            );
        }
        init { this._rawData.Set("triggered_by", value); }
    }

    /// <summary>
    /// Timestamp when the test run finished execution.
    /// </summary>
    public DateTimeOffset? CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "completed_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("completed_at", value);
        }
    }

    /// <summary>
    /// Identifier of the conversation created during test execution.
    /// </summary>
    public string? ConversationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_id", value);
        }
    }

    /// <summary>
    /// Identifier for conversation analysis and insights data.
    /// </summary>
    public string? ConversationInsightsID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conversation_insights_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conversation_insights_id", value);
        }
    }

    /// <summary>
    /// Detailed evaluation results for each rubric criteria. Name is name of the
    /// criteria from the rubric and status is the result of the evaluation. This
    /// list will have a result for every criteria in the rubric section.
    /// </summary>
    public IReadOnlyList<TestRunDetailResult>? DetailStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TestRunDetailResult>>(
                "detail_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TestRunDetailResult>?>(
                "detail_status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Detailed execution logs and debug information.
    /// </summary>
    public string? Logs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logs", value);
        }
    }

    /// <summary>
    /// Identifier linking this run to a test suite execution batch.
    /// </summary>
    public string? TestSuiteRunID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "test_suite_run_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("test_suite_run_id", value);
        }
    }

    /// <summary>
    /// Timestamp of the last update to this test run.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.RunID;
        this.Status.Validate();
        _ = this.TestID;
        _ = this.TriggeredBy;
        _ = this.CompletedAt;
        _ = this.ConversationID;
        _ = this.ConversationInsightsID;
        foreach (var item in this.DetailStatus ?? [])
        {
            item.Validate();
        }
        _ = this.Logs;
        _ = this.TestSuiteRunID;
        _ = this.UpdatedAt;
    }

    public TestRunResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestRunResponse (TestRunResponse testRunResponse) : base(
        testRunResponse
    )
    {  }
    #pragma warning restore CS8618

    public TestRunResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestRunResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestRunResponseFromRaw.FromRawUnchecked"/>
    public static TestRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TestRunResponseFromRaw : IFromRawJson<TestRunResponse>
{
    /// <inheritdoc/>
    public TestRunResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestRunResponse.FromRawUnchecked(rawData);
}