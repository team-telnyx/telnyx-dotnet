using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebSearch.Research;

[JsonConverter(typeof(JsonModelConverter<ResearchCreateResponse, ResearchCreateResponseFromRaw>))]
public sealed record class ResearchCreateResponse : JsonModel
{
    /// <summary>
    /// Synchronous research response (when `background` is false or unset).
    /// </summary>
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ResearchCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchCreateResponse (
        ResearchCreateResponse researchCreateResponse
    ) : base(researchCreateResponse)
    {  }
    #pragma warning restore CS8618

    public ResearchCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchCreateResponseFromRaw.FromRawUnchecked"/>
    public static ResearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ResearchCreateResponseFromRaw : IFromRawJson<ResearchCreateResponse>
{
    /// <inheritdoc/>
    public ResearchCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchCreateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Synchronous research response (when `background` is false or unset).
/// </summary>
[JsonConverter(typeof(DataConverter))]
public record class Data : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Data (ResearchResponseSync value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data (ResearchResponseAsync value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Data (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResearchResponseSync"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickResearchResponseSync(out var value)) {
///     // `value` is of type `ResearchResponseSync`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickResearchResponseSync(
        [NotNullWhen(true)] out ResearchResponseSync? value
    )
    {
        value =this.Value as ResearchResponseSync ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ResearchResponseAsync"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickResearchResponseAsync(out var value)) {
///     // `value` is of type `ResearchResponseAsync`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickResearchResponseAsync(
        [NotNullWhen(true)] out ResearchResponseAsync? value
    )
    {
        value =this.Value as ResearchResponseAsync ;
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
///     (ResearchResponseSync value) =&gt; {...},
///     (ResearchResponseAsync value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ResearchResponseSync> researchResponseSync,
        System::Action<ResearchResponseAsync> researchResponseAsync
    )
    {
        switch (this.Value)
        {
            case ResearchResponseSync value:
                researchResponseSync(value);
                break;
            case ResearchResponseAsync value:
                researchResponseAsync(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Data");

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
///     (ResearchResponseSync value) =&gt; {...},
///     (ResearchResponseAsync value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ResearchResponseSync, T> researchResponseSync,
        System::Func<ResearchResponseAsync, T> researchResponseAsync
    )
    {
        return this.Value switch
        {
            ResearchResponseSync value=>researchResponseSync(value),
            ResearchResponseAsync value=>researchResponseAsync(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Data")
        } ;
    }

    public static implicit operator Data (
        ResearchResponseSync value
    )=> new(value) ;

    public static implicit operator Data (
        ResearchResponseAsync value
    )=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Data");
        }
        this.Switch((researchResponseSync) => researchResponseSync.Validate(),
        (researchResponseAsync) => researchResponseAsync.Validate());
    }

    public virtual bool Equals(Data? other)
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
        { ResearchResponseSync _=>0, ResearchResponseAsync _=>1, _ =>-1 } ;
    }
}sealed class DataConverter : JsonConverter<Data>
{
    public override Data? Read(
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
            var deserialized = JsonSerializer.Deserialize<ResearchResponseAsync>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<ResearchResponseSync>(element, options);
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
        Utf8JsonWriter writer, Data value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Synchronous research response (when `background` is false or unset).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ResearchResponseSync, ResearchResponseSyncFromRaw>))]
public sealed record class ResearchResponseSync : JsonModel
{
    /// <summary>
    /// The synthesized research answer.
    /// </summary>
    public required string Answer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "answer"
            );
        }
        init { this._rawData.Set("answer", value); }
    }

    /// <summary>
    /// Sources cited in the answer.
    /// </summary>
    public IReadOnlyList<ResearchCitation>? Citations {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ResearchCitation>>(
                "citations"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ResearchCitation>?>(
                "citations",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Answer;
        foreach (var item in this.Citations ?? [])
        {
            item.Validate();
        }
    }

    public ResearchResponseSync ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchResponseSync (
        ResearchResponseSync researchResponseSync
    ) : base(researchResponseSync)
    {  }
    #pragma warning restore CS8618

    public ResearchResponseSync (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchResponseSync (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchResponseSyncFromRaw.FromRawUnchecked"/>
    public static ResearchResponseSync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ResearchResponseSync (string answer) : this()
    { this.Answer = answer; }
}class ResearchResponseSyncFromRaw : IFromRawJson<ResearchResponseSync>
{
    /// <inheritdoc/>
    public ResearchResponseSync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchResponseSync.FromRawUnchecked(rawData);
}/// <summary>
/// Asynchronous research response (when `background` is true).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ResearchResponseAsync, ResearchResponseAsyncFromRaw>))]
public sealed record class ResearchResponseAsync : JsonModel
{
    /// <summary>
    /// Current status of the research task.
    /// </summary>
    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Unique identifier for the research task. Use this to poll the status.
    /// </summary>
    public required string TaskID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "task_id"
            );
        }
        init { this._rawData.Set("task_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Status.Validate();
        _ = this.TaskID;
    }

    public ResearchResponseAsync ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ResearchResponseAsync (
        ResearchResponseAsync researchResponseAsync
    ) : base(researchResponseAsync)
    {  }
    #pragma warning restore CS8618

    public ResearchResponseAsync (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ResearchResponseAsync (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResearchResponseAsyncFromRaw.FromRawUnchecked"/>
    public static ResearchResponseAsync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResearchResponseAsyncFromRaw : IFromRawJson<ResearchResponseAsync>
{
    /// <inheritdoc/>
    public ResearchResponseAsync FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ResearchResponseAsync.FromRawUnchecked(rawData);
}/// <summary>
/// Current status of the research task.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Running, Completed, Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "running"=>Status.Running,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Running=>"running",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}