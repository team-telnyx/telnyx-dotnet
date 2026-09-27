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
/// Creates a comprehensive test configuration for evaluating AI assistant performance
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class TestCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The target destination for the test conversation. Format depends on the channel:
    /// phone number for SMS/voice, webhook URL for web chat, etc.
    /// </summary>
    public required string Destination {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "destination"
            );
        }
        init { this._rawBodyData.Set("destination", value); }
    }

    /// <summary>
    /// Detailed instructions that define the test scenario and what the assistant
    /// should accomplish. This guides the test execution and evaluation.
    /// </summary>
    public required string Instructions {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "instructions"
            );
        }
        init { this._rawBodyData.Set("instructions", value); }
    }

    /// <summary>
    /// A descriptive name for the assistant test. This will be used to identify the
    /// test in the UI and reports.
    /// </summary>
    public required string Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// Evaluation criteria used to assess the assistant's performance. Each rubric
    /// item contains a name and specific criteria for evaluation.
    /// </summary>
    public required IReadOnlyList<Rubric> Rubric {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Rubric>>(
                "rubric"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<Rubric>>(
                "rubric",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Optional detailed description of what this test evaluates and its purpose.
    /// Helps team members understand the test's objectives.
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
    /// Maximum duration in seconds that the test conversation should run before timing
    /// out. If not specified, uses system default timeout.
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
    /// The communication channel through which the test will be conducted. Determines
    /// how the assistant will receive and respond to test messages.
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
    /// Optional test suite name to group related tests together. Useful for organizing
    /// tests by feature, team, or release cycle.
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

    public string? IdempotencyKey {
        get {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>(
                "Idempotency-Key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawHeaderData.Set("Idempotency-Key", value);
        }
    }

    public TestCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestCreateParams (TestCreateParams testCreateParams) : base(
        testCreateParams
    )
    { this._rawBodyData = new(testCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public TestCreateParams (
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
    TestCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static TestCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(TestCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/ai/assistants/tests"
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

[JsonConverter(typeof(JsonModelConverter<Rubric, RubricFromRaw>))]
public sealed record class Rubric : JsonModel
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

    public Rubric ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Rubric (Rubric rubric) : base(rubric)
    {  }
    #pragma warning restore CS8618

    public Rubric (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Rubric (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RubricFromRaw.FromRawUnchecked"/>
    public static Rubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RubricFromRaw : IFromRawJson<Rubric>
{
    /// <inheritdoc/>
    public Rubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Rubric.FromRawUnchecked(rawData);
}