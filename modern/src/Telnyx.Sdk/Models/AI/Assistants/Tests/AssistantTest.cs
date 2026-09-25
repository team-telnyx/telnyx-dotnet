using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests;

/// <summary>
/// Response model containing complete assistant test information.
///
/// <para>Returns all test configuration details including evaluation criteria, scheduling,
/// and metadata. Used when retrieving individual tests or after creating/updating tests.</para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AssistantTest, AssistantTestFromRaw>))]
public sealed record class AssistantTest : JsonModel
{
    /// <summary>
    /// Timestamp when the test was created.
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
    /// Human-readable name of the test.
    /// </summary>
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
    /// Evaluation criteria used to assess test performance.
    /// </summary>
    public required IReadOnlyList<AssistantTestRubric> Rubric {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AssistantTestRubric>>(
                "rubric"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AssistantTestRubric>>(
                "rubric",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Communication channel used for test execution.
    /// </summary>
    public required ApiEnum<string, TelnyxConversationChannel> TelnyxConversationChannel {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TelnyxConversationChannel>>(
                "telnyx_conversation_channel"
            );
        }
        init { this._rawData.Set("telnyx_conversation_channel", value); }
    }

    /// <summary>
    /// Unique identifier for the assistant test.
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
    /// Detailed description of the test's purpose and scope.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Target destination for test conversations.
    /// </summary>
    public string? Destination {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "destination"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("destination", value);
        }
    }

    /// <summary>
    /// Detailed test scenario instructions and objectives.
    /// </summary>
    public string? Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "instructions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("instructions", value);
        }
    }

    /// <summary>
    /// Maximum allowed duration for test execution in seconds.
    /// </summary>
    public long? MaxDurationSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_duration_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_duration_seconds", value);
        }
    }

    /// <summary>
    /// Test suite grouping for organizational purposes.
    /// </summary>
    public string? TestSuite {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "test_suite"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("test_suite", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Name;
        foreach (var item in this.Rubric)
        {
            item.Validate();
        }
        this.TelnyxConversationChannel.Validate();
        _ = this.TestID;
        _ = this.Description;
        _ = this.Destination;
        _ = this.Instructions;
        _ = this.MaxDurationSeconds;
        _ = this.TestSuite;
    }

    public AssistantTest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantTest (AssistantTest assistantTest) : base(assistantTest)
    {  }
    #pragma warning restore CS8618

    public AssistantTest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantTest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantTestFromRaw.FromRawUnchecked"/>
    public static AssistantTest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantTestFromRaw : IFromRawJson<AssistantTest>
{
    /// <inheritdoc/>
    public AssistantTest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantTest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<AssistantTestRubric, AssistantTestRubricFromRaw>))]
public sealed record class AssistantTestRubric : JsonModel
{
    /// <summary>
    /// Specific guidance on how to assess the assistant’s performance for this rubric item.
    /// </summary>
    public required string Criteria {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "criteria"
            );
        }
        init { this._rawData.Set("criteria", value); }
    }

    /// <summary>
    /// Label for the evaluation criterion, e.g., Empathy, Accuracy, Clarity.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Criteria;
        _ = this.Name;
    }

    public AssistantTestRubric ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssistantTestRubric (AssistantTestRubric assistantTestRubric) : base(
        assistantTestRubric
    )
    {  }
    #pragma warning restore CS8618

    public AssistantTestRubric (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AssistantTestRubric (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantTestRubricFromRaw.FromRawUnchecked"/>
    public static AssistantTestRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AssistantTestRubricFromRaw : IFromRawJson<AssistantTestRubric>
{
    /// <inheritdoc/>
    public AssistantTestRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AssistantTestRubric.FromRawUnchecked(rawData);
}