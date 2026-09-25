using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Conversations.Insights;

[JsonConverter(typeof(JsonModelConverter<InsightTemplate, InsightTemplateFromRaw>))]
public sealed record class InsightTemplate : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    public ApiEnum<string, InsightType>? InsightType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InsightType>>(
                "insight_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("insight_type", value);
        }
    }

    /// <summary>
    /// If specified, the output will follow the JSON schema.
    /// </summary>
    public InsightTemplateJsonSchema? JsonSchema {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InsightTemplateJsonSchema>(
                "json_schema"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("json_schema", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public string? Webhook {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Instructions;
        this.InsightType?.Validate();
        this.JsonSchema?.Validate();
        _ = this.Name;
        _ = this.Webhook;
    }

    public InsightTemplate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InsightTemplate (InsightTemplate insightTemplate) : base(
        insightTemplate
    )
    {  }
    #pragma warning restore CS8618

    public InsightTemplate (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InsightTemplate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InsightTemplateFromRaw.FromRawUnchecked"/>
    public static InsightTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InsightTemplateFromRaw : IFromRawJson<InsightTemplate>
{
    /// <inheritdoc/>
    public InsightTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InsightTemplate.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InsightTypeConverter))]
public enum InsightType
{
    Custom, Default
}sealed class InsightTypeConverter : JsonConverter<InsightType>
{
    public override InsightType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom"=>InsightType.Custom,
            "default"=>InsightType.Default,
            _ =>(InsightType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, InsightType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InsightType.Custom=>"custom",
            InsightType.Default=>"default",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// If specified, the output will follow the JSON schema.
/// </summary>
[JsonConverter(typeof(InsightTemplateJsonSchemaConverter))]
public record class InsightTemplateJsonSchema : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public InsightTemplateJsonSchema (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InsightTemplateJsonSchema (
        IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public InsightTemplateJsonSchema (JsonElement element)
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
/// type <see cref="Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickObject(out var value)) {
///     // `value` is of type `IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickObject(
        [NotNullWhen(true)] out IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as IReadOnlyDictionary<string, JsonElement> ;
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
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<IReadOnlyDictionary<string, JsonElement>> jsonSchemaObject
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case IReadOnlyDictionary<string, JsonElement> value:
                jsonSchemaObject(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of InsightTemplateJsonSchema");

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
///     (IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<IReadOnlyDictionary<string, JsonElement>, T> jsonSchemaObject
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            IReadOnlyDictionary<string, JsonElement> value=>jsonSchemaObject(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of InsightTemplateJsonSchema")
        } ;
    }

    public static implicit operator InsightTemplateJsonSchema (
        string value
    )=> new(value) ;

    public static implicit operator InsightTemplateJsonSchema (
        Dictionary<string, JsonElement> value
    )=> new((IReadOnlyDictionary<string, JsonElement>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of InsightTemplateJsonSchema");
        }
    }

    public virtual bool Equals(InsightTemplateJsonSchema? other)
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
        { string _=>0, IReadOnlyDictionary<string, JsonElement> _=>1, _ =>-1 } ;
    }
}sealed class InsightTemplateJsonSchemaConverter : JsonConverter<InsightTemplateJsonSchema>
{
    public override InsightTemplateJsonSchema? Read(
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
            var deserialized = JsonSerializer.Deserialize<string>(element, options);
            if (deserialized != null) {

                return new(deserialized, element);
            }
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<IReadOnlyDictionary<string, JsonElement>>(element, options);
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
        InsightTemplateJsonSchema value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}