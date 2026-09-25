using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests;

/// <summary>
/// Updates an existing assistant test configuration with new settings
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TestUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? TestID { get; init; }

    /// <summary>
    /// Updated description of the test's purpose and evaluation criteria.
    /// </summary>
    public string? Description {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("description", value);
        }
    }

    /// <summary>
    /// Updated target destination for test conversations.
    /// </summary>
    public string? Destination {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "destination"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("destination", value);
        }
    }

    /// <summary>
    /// Updated test scenario instructions and objectives.
    /// </summary>
    public string? Instructions {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "instructions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("instructions", value);
        }
    }

    /// <summary>
    /// Updated maximum test duration in seconds.
    /// </summary>
    public long? MaxDurationSeconds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "max_duration_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("max_duration_seconds", value);
        }
    }

    /// <summary>
    /// Updated name for the assistant test. Must be unique and descriptive.
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    /// <summary>
    /// Updated evaluation criteria for assessing assistant performance.
    /// </summary>
    public IReadOnlyList<TestUpdateParamsRubric>? Rubric {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<TestUpdateParamsRubric>>(
                "rubric"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<TestUpdateParamsRubric>?>(
                "rubric",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Updated communication channel for the test execution.
    /// </summary>
    public ApiEnum<string, TelnyxConversationChannel>? TelnyxConversationChannel {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, TelnyxConversationChannel>>(
                "telnyx_conversation_channel"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("telnyx_conversation_channel", value);
        }
    }

    /// <summary>
    /// Updated test suite assignment for better organization.
    /// </summary>
    public string? TestSuite {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "test_suite"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("test_suite", value);
        }
    }

    public TestUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestUpdateParams (TestUpdateParams testUpdateParams) : base(
        testUpdateParams
    )
    {
        this.TestID = testUpdateParams.TestID;

        this._rawBodyData = new(testUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public TestUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string testID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.TestID = testID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TestUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string testID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            testID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["TestID"] = JsonSerializer.SerializeToElement(this.TestID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TestUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.TestID?.Equals(other.TestID) ?? other.TestID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/ai/assistants/tests/{0}",
            this.TestID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(JsonModelConverter<TestUpdateParamsRubric, TestUpdateParamsRubricFromRaw>))]
public sealed record class TestUpdateParamsRubric : JsonModel
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

    public TestUpdateParamsRubric ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestUpdateParamsRubric (
        TestUpdateParamsRubric testUpdateParamsRubric
    ) : base(testUpdateParamsRubric)
    {  }
    #pragma warning restore CS8618

    public TestUpdateParamsRubric (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestUpdateParamsRubric (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestUpdateParamsRubricFromRaw.FromRawUnchecked"/>
    public static TestUpdateParamsRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TestUpdateParamsRubricFromRaw : IFromRawJson<TestUpdateParamsRubric>
{
    /// <inheritdoc/>
    public TestUpdateParamsRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestUpdateParamsRubric.FromRawUnchecked(rawData);
}