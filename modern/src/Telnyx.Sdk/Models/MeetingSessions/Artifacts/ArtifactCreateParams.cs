using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MeetingSessions.Artifacts;

/// <summary>
/// Requests asynchronous generation of one artifact: `summary`, `action_items`,
/// `decisions`, `topics`, `open_questions`, or `custom`. Each request produces one
/// artifact. `custom` is answered from a `prompt` you supply, which is required for
/// `custom` and rejected on the five named types. Generation requires transcript
/// content and configured inference and currently reads at most the first 10,000
/// segments, so exceptionally long transcripts may produce incomplete artifacts
/// or fail model limits. **Not idempotent, and every call is billed**: each request
/// is a separate inference run, so a retry or a duplicate POST produces a second
/// artifact and a second charge. Guard the call rather than relying on the service
/// to collapse it. The automatic `summarize_on_end` attempt is billed on the same basis.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ArtifactCreateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? ID { get; init; }

    /// <summary>
    /// One of two shapes: a named type on its own, or `custom` with the prompt it answers.
    /// </summary>
    public required Body Body {
        get {
            return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public ArtifactCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ArtifactCreateParams (
        ArtifactCreateParams artifactCreateParams
    ) : base(artifactCreateParams)
    {
        this.ID = artifactCreateParams.ID;

        this.RawBodyData = artifactCreateParams.RawBodyData;
    }
    #pragma warning restore CS8618

    public ArtifactCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ArtifactCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ArtifactCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ArtifactCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/meeting_sessions/{0}/artifacts",
            this.ID)
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

/// <summary>
/// One of two shapes: a named type on its own, or `custom` with the prompt it answers.
/// </summary>
[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Body (NamedArtifact value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (CustomArtifact value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="NamedArtifact"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickNamedArtifact(out var value)) {
///     // `value` is of type `NamedArtifact`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickNamedArtifact(
        [NotNullWhen(true)] out NamedArtifact? value
    )
    {
        value =this.Value as NamedArtifact ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CustomArtifact"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCustomArtifact(out var value)) {
///     // `value` is of type `CustomArtifact`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCustomArtifact(
        [NotNullWhen(true)] out CustomArtifact? value
    )
    {
        value =this.Value as CustomArtifact ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (NamedArtifact value) =&gt; {...},
///     (CustomArtifact value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<NamedArtifact> namedArtifact,
        System::Action<CustomArtifact> customArtifact
    )
    {
        switch (this.Value)
        {
            case NamedArtifact value:
                namedArtifact(value);
                break;
            case CustomArtifact value:
                customArtifact(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Body");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (NamedArtifact value) =&gt; {...},
///     (CustomArtifact value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<NamedArtifact, T> namedArtifact,
        System::Func<CustomArtifact, T> customArtifact
    )
    {
        return this.Value switch
        {
            NamedArtifact value=>namedArtifact(value),
            CustomArtifact value=>customArtifact(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Body")
        } ;
    }

    public static implicit operator Body (NamedArtifact value)=> new(value) ;

    public static implicit operator Body (CustomArtifact value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch((namedArtifact) => namedArtifact.Validate(),
        (customArtifact) => customArtifact.Validate());
    }

    public virtual bool Equals(Body? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { NamedArtifact _=>0, CustomArtifact _=>1, _ =>-1 } ;
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(
            ref reader,
            options
        );
        try
        {
            var deserialized = JsonSerializer.Deserialize<CustomArtifact>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<NamedArtifact>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer, Body value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<NamedArtifact, NamedArtifactFromRaw>))]
public sealed record class NamedArtifact : JsonModel
{
    /// <summary>
    /// What to generate from the transcript. `custom` is answered from a `prompt`
    /// you supply; the five named types need none.
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Type.Validate(); }

    public NamedArtifact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamedArtifact (NamedArtifact namedArtifact) : base(namedArtifact)
    {  }
    #pragma warning restore CS8618

    public NamedArtifact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NamedArtifact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NamedArtifactFromRaw.FromRawUnchecked"/>
    public static NamedArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NamedArtifact (
        ApiEnum<string, global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type> type
    ) : this()
    { this.Type = type; }
}

class NamedArtifactFromRaw : IFromRawJson<NamedArtifact>
{
    /// <inheritdoc/>
    public NamedArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NamedArtifact.FromRawUnchecked(rawData);
}

/// <summary>
/// What to generate from the transcript. `custom` is answered from a `prompt` you
/// supply; the five named types need none.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Summary, ActionItems, Decisions, Topics, OpenQuestions
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type>
{
    public override global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "summary"=>global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Summary,
            "action_items"=>global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.ActionItems,
            "decisions"=>global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Decisions,
            "topics"=>global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Topics,
            "open_questions"=>global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.OpenQuestions,
            _ =>(global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Summary=>"summary",
            global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.ActionItems=>"action_items",
            global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Decisions=>"decisions",
            global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.Topics=>"topics",
            global::Telnyx.Sdk.Models.MeetingSessions.Artifacts.Type.OpenQuestions=>"open_questions",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CustomArtifact, CustomArtifactFromRaw>))]
public sealed record class CustomArtifact : JsonModel
{
    /// <summary>
    /// An open-ended request answered from the transcript. Required when `type`
    /// is `custom`, and rejected with 400 on any named type. Trimmed before storage
    /// and echoed back in artifact responses and the `artifact.completed` webhook.
    /// </summary>
    public required string Prompt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "prompt"
            );
        }
        init { this._rawData.Set("prompt", value); }
    }

    /// <summary>
    /// Answered from the `prompt` below rather than a fixed question.
    /// </summary>
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Prompt;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("custom")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public CustomArtifact ()
    { this.Type = JsonSerializer.SerializeToElement("custom"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomArtifact (CustomArtifact customArtifact) : base(customArtifact)
    {  }
    #pragma warning restore CS8618

    public CustomArtifact (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("custom");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomArtifact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomArtifactFromRaw.FromRawUnchecked"/>
    public static CustomArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public CustomArtifact (string prompt) : this()
    { this.Prompt = prompt; }
}

class CustomArtifactFromRaw : IFromRawJson<CustomArtifact>
{
    /// <inheritdoc/>
    public CustomArtifact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomArtifact.FromRawUnchecked(rawData);
}