using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.GlobalIPAssignmentHealth;

/// <summary>
/// Retrieve health check metrics for your Global IP assignments.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GlobalIPAssignmentHealthRetrieveParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[global_ip_id][in], filter[global_ip_assignment_id][in]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public GlobalIPAssignmentHealthRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentHealthRetrieveParams (
        GlobalIPAssignmentHealthRetrieveParams globalIPAssignmentHealthRetrieveParams
    ) : base(globalIPAssignmentHealthRetrieveParams)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentHealthRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentHealthRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static GlobalIPAssignmentHealthRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(GlobalIPAssignmentHealthRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/global_ip_assignment_health"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Consolidated filter parameter (deepObject style). Originally: filter[global_ip_id][in], filter[global_ip_assignment_id][in]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by exact Global IP Assignment ID
    /// </summary>
    public GlobalIPAssignmentID? GlobalIPAssignmentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIPAssignmentID>(
                "global_ip_assignment_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_assignment_id", value);
        }
    }

    /// <summary>
    /// Filter by exact Global IP ID
    /// </summary>
    public GlobalIPID? GlobalIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIPID>(
                "global_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.GlobalIPAssignmentID?.Validate();
        this.GlobalIPID?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by exact Global IP Assignment ID
/// </summary>
[JsonConverter(typeof(GlobalIPAssignmentIDConverter))]
public record class GlobalIPAssignmentID : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public GlobalIPAssignmentID (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public GlobalIPAssignmentID (In value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public GlobalIPAssignmentID (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="In"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickIn(out var value)) {
///     // `value` is of type `In`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickIn([NotNullWhen(true)] out In? value)
    {
        value =this.Value as In ;
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
///     (string value) =&gt; {...},
///     (In value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(System::Action<string> @string, System::Action<In> in_)
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case In value:
                in_(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPAssignmentID");

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
///     (string value) =&gt; {...},
///     (In value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<string, T> @string, System::Func<In, T> in_)
    {
        return this.Value switch
        {
            string value=>@string(value),
            In value=>in_(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPAssignmentID")
        } ;
    }

    public static implicit operator GlobalIPAssignmentID (
        string value
    )=> new(value) ;

    public static implicit operator GlobalIPAssignmentID (
        In value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPAssignmentID");
        }
        this.Switch((_) => {}, (in_) => in_.Validate());
    }

    public virtual bool Equals(GlobalIPAssignmentID? other)
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
        { string _=>0, In _=>1, _ =>-1 } ;
    }
}

sealed class GlobalIPAssignmentIDConverter : JsonConverter<GlobalIPAssignmentID>
{
    public override GlobalIPAssignmentID? Read(
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
            var deserialized = JsonSerializer.Deserialize<In>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

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
        GlobalIPAssignmentID value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<In, InFromRaw>))]
public sealed record class In : JsonModel
{
    /// <summary>
    /// Filter by Global IP Assignment ID(s) separated by commas
    /// </summary>
    public string? InValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("in", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.InValue; }

    public In ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public In (In in_) : base(in_)
    {  }
    #pragma warning restore CS8618

    public In (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    In (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InFromRaw.FromRawUnchecked"/>
    public static In FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InFromRaw : IFromRawJson<In>
{
    /// <inheritdoc/>
    public In FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>In.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by exact Global IP ID
/// </summary>
[JsonConverter(typeof(GlobalIPIDConverter))]
public record class GlobalIPID : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public GlobalIPID (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public GlobalIPID (GlobalIpidIn value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public GlobalIPID (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="string"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickString(out var value)) {
///     // `value` is of type `string`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickString([NotNullWhen(true)] out string? value)
    {
        value =this.Value as string ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="GlobalIpidIn"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickGlobalIpidIn(out var value)) {
///     // `value` is of type `GlobalIpidIn`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickGlobalIpidIn([NotNullWhen(true)] out GlobalIpidIn? value)
    {
        value =this.Value as GlobalIpidIn ;
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
///     (string value) =&gt; {...},
///     (GlobalIpidIn value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<GlobalIpidIn> globalIpidIn
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case GlobalIpidIn value:
                globalIpidIn(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPID");

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
///     (string value) =&gt; {...},
///     (GlobalIpidIn value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<GlobalIpidIn, T> globalIpidIn
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            GlobalIpidIn value=>globalIpidIn(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPID")
        } ;
    }

    public static implicit operator GlobalIPID (string value)=> new(value) ;

    public static implicit operator GlobalIPID (
        GlobalIpidIn value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of GlobalIPID");
        }
        this.Switch((_) => {}, (globalIpidIn) => globalIpidIn.Validate());
    }

    public virtual bool Equals(GlobalIPID? other)
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
        { string _=>0, GlobalIpidIn _=>1, _ =>-1 } ;
    }
}

sealed class GlobalIPIDConverter : JsonConverter<GlobalIPID>
{
    public override GlobalIPID? Read(
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
            var deserialized = JsonSerializer.Deserialize<GlobalIpidIn>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

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
        Utf8JsonWriter writer, GlobalIPID value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

/// <summary>
/// Filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GlobalIpidIn, GlobalIpidInFromRaw>))]
public sealed record class GlobalIpidIn : JsonModel
{
    /// <summary>
    /// Filter by Global IP ID(s) separated by commas
    /// </summary>
    public string? In {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "in"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("in", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.In; }

    public GlobalIpidIn ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIpidIn (GlobalIpidIn globalIpidIn) : base(globalIpidIn)
    {  }
    #pragma warning restore CS8618

    public GlobalIpidIn (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIpidIn (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIpidInFromRaw.FromRawUnchecked"/>
    public static GlobalIpidIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIpidInFromRaw : IFromRawJson<GlobalIpidIn>
{
    /// <inheritdoc/>
    public GlobalIpidIn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIpidIn.FromRawUnchecked(rawData);
}