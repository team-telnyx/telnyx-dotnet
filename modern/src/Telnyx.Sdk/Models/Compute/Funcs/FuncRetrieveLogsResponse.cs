using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(FuncRetrieveLogsResponseConverter))]
public record class FuncRetrieveLogsResponse : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public LogsMeta? Meta {
        get {
            return Match<LogsMeta?>(runtime: ( x )=>x.Meta,
            invocation: ( x )=>x.Meta);
        }
    }

    public FuncRetrieveLogsResponse (
        FuncRuntimeLogsResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FuncRetrieveLogsResponse (
        FuncInvocationLogsResponse value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public FuncRetrieveLogsResponse (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FuncRuntimeLogsResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRuntime(out var value)) {
///     // `value` is of type `FuncRuntimeLogsResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRuntime(
        [NotNullWhen(true)] out FuncRuntimeLogsResponse? value
    )
    {
        value =this.Value as FuncRuntimeLogsResponse ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="FuncInvocationLogsResponse"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInvocation(out var value)) {
///     // `value` is of type `FuncInvocationLogsResponse`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInvocation(
        [NotNullWhen(true)] out FuncInvocationLogsResponse? value
    )
    {
        value =this.Value as FuncInvocationLogsResponse ;
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
///     (FuncRuntimeLogsResponse value) =&gt; {...},
///     (FuncInvocationLogsResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<FuncRuntimeLogsResponse> runtime,
        System::Action<FuncInvocationLogsResponse> invocation
    )
    {
        switch (this.Value)
        {
            case FuncRuntimeLogsResponse value:
                runtime(value);
                break;
            case FuncInvocationLogsResponse value:
                invocation(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of FuncRetrieveLogsResponse");

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
///     (FuncRuntimeLogsResponse value) =&gt; {...},
///     (FuncInvocationLogsResponse value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<FuncRuntimeLogsResponse, T> runtime,
        System::Func<FuncInvocationLogsResponse, T> invocation
    )
    {
        return this.Value switch
        {
            FuncRuntimeLogsResponse value=>runtime(value),
            FuncInvocationLogsResponse value=>invocation(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of FuncRetrieveLogsResponse")
        } ;
    }

    public static implicit operator FuncRetrieveLogsResponse (
        FuncRuntimeLogsResponse value
    )=> new(value) ;

    public static implicit operator FuncRetrieveLogsResponse (
        FuncInvocationLogsResponse value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of FuncRetrieveLogsResponse");
        }
        this.Switch((runtime) => runtime.Validate(),
        (invocation) => invocation.Validate());
    }

    public virtual bool Equals(FuncRetrieveLogsResponse? other)
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
        {
            FuncRuntimeLogsResponse _=>0,
            FuncInvocationLogsResponse _=>1,
            _ =>-1
        } ;
    }
}

sealed class FuncRetrieveLogsResponseConverter : JsonConverter<FuncRetrieveLogsResponse>
{
    public override FuncRetrieveLogsResponse? Read(
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
            var deserialized = JsonSerializer.Deserialize<FuncRuntimeLogsResponse>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<FuncInvocationLogsResponse>(element, options);
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
        Utf8JsonWriter writer,
        FuncRetrieveLogsResponse value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<FuncRuntimeLogsResponse, FuncRuntimeLogsResponseFromRaw>))]
public sealed record class FuncRuntimeLogsResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public LogsMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LogsMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public FuncRuntimeLogsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRuntimeLogsResponse (
        FuncRuntimeLogsResponse funcRuntimeLogsResponse
    ) : base(funcRuntimeLogsResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRuntimeLogsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRuntimeLogsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRuntimeLogsResponseFromRaw.FromRawUnchecked"/>
    public static FuncRuntimeLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FuncRuntimeLogsResponseFromRaw : IFromRawJson<FuncRuntimeLogsResponse>
{
    /// <inheritdoc/>
    public FuncRuntimeLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRuntimeLogsResponse.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? Level {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "level"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("level", value);
        }
    }

    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public System::DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Level;
        _ = this.Message;
        this.RecordType?.Validate();
        _ = this.Timestamp;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    ComputeFuncRuntimeLog
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "compute_func_runtime_log"=>RecordType.ComputeFuncRuntimeLog,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.ComputeFuncRuntimeLog=>"compute_func_runtime_log",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<FuncInvocationLogsResponse, FuncInvocationLogsResponseFromRaw>))]
public sealed record class FuncInvocationLogsResponse : JsonModel
{
    public IReadOnlyList<FuncInvocationLogsResponseData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FuncInvocationLogsResponseData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FuncInvocationLogsResponseData>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public LogsMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LogsMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public FuncInvocationLogsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncInvocationLogsResponse (
        FuncInvocationLogsResponse funcInvocationLogsResponse
    ) : base(funcInvocationLogsResponse)
    {  }
    #pragma warning restore CS8618

    public FuncInvocationLogsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncInvocationLogsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncInvocationLogsResponseFromRaw.FromRawUnchecked"/>
    public static FuncInvocationLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FuncInvocationLogsResponseFromRaw : IFromRawJson<FuncInvocationLogsResponse>
{
    /// <inheritdoc/>
    public FuncInvocationLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncInvocationLogsResponse.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<FuncInvocationLogsResponseData, FuncInvocationLogsResponseDataFromRaw>))]
public sealed record class FuncInvocationLogsResponseData : JsonModel
{
    public double? DurationMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "duration_ms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("duration_ms", value);
        }
    }

    public string? Method {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("method", value);
        }
    }

    public string? Path {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "path"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    public ApiEnum<string, FuncInvocationLogsResponseDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FuncInvocationLogsResponseDataRecordType>>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    public long? RequestSizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "request_size_bytes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("request_size_bytes", value);
        }
    }

    public long? ResponseSizeBytes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "response_size_bytes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("response_size_bytes", value);
        }
    }

    public long? StatusCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "status_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status_code", value);
        }
    }

    public System::DateTimeOffset? Timestamp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "timestamp"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("timestamp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DurationMs;
        _ = this.Method;
        _ = this.Path;
        this.RecordType?.Validate();
        _ = this.Region;
        _ = this.RequestSizeBytes;
        _ = this.ResponseSizeBytes;
        _ = this.StatusCode;
        _ = this.Timestamp;
    }

    public FuncInvocationLogsResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncInvocationLogsResponseData (
        FuncInvocationLogsResponseData funcInvocationLogsResponseData
    ) : base(funcInvocationLogsResponseData)
    {  }
    #pragma warning restore CS8618

    public FuncInvocationLogsResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncInvocationLogsResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncInvocationLogsResponseDataFromRaw.FromRawUnchecked"/>
    public static FuncInvocationLogsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FuncInvocationLogsResponseDataFromRaw : IFromRawJson<FuncInvocationLogsResponseData>
{
    /// <inheritdoc/>
    public FuncInvocationLogsResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncInvocationLogsResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(FuncInvocationLogsResponseDataRecordTypeConverter))]
public enum FuncInvocationLogsResponseDataRecordType
{
    ComputeFuncInvocationLog
}sealed class FuncInvocationLogsResponseDataRecordTypeConverter : JsonConverter<FuncInvocationLogsResponseDataRecordType>
{
    public override FuncInvocationLogsResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "compute_func_invocation_log"=>FuncInvocationLogsResponseDataRecordType.ComputeFuncInvocationLog,
            _ =>(FuncInvocationLogsResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FuncInvocationLogsResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FuncInvocationLogsResponseDataRecordType.ComputeFuncInvocationLog=>"compute_func_invocation_log",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}