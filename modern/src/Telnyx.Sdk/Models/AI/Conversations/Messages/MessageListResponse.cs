using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Conversations.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageListResponse, MessageListResponseFromRaw>))]
public sealed record class MessageListResponse : JsonModel
{
    /// <summary>
    /// The role of the message sender.
    /// </summary>
    public required ApiEnum<string, Role> Role {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Role>>(
                "role"
            );
        }
        init { this._rawData.Set("role", value); }
    }

    /// <summary>
    /// The message content. Can be null for tool calls.
    /// </summary>
    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <summary>
    /// The datetime the message was created on the conversation. This does not necesarily
    /// correspond to the time the message was sent. The best field to use to determine
    /// the time the end user experienced the message is `sent_at`.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public Generic::IReadOnlyDictionary<string, Metadata>? Metadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, Metadata>>(
                "metadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, Metadata>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The datetime the message was sent to the end user.
    /// </summary>
    public System::DateTimeOffset? SentAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sent_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sent_at", value);
        }
    }

    /// <summary>
    /// Optional tool calls made by the assistant.
    /// </summary>
    public Generic::IReadOnlyList<ToolCall>? ToolCalls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ToolCall>>(
                "tool_calls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ToolCall>?>(
                "tool_calls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Role.Validate();
        _ = this.Text;
        _ = this.CreatedAt;
        if (this.Metadata != null)
        {
            foreach (var item in this.Metadata.Values)
            {
                item.Validate();
            }
        }
        _ = this.SentAt;
        foreach (var item in this.ToolCalls ?? [])
        {
            item.Validate();
        }
    }

    public MessageListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageListResponse (MessageListResponse messageListResponse) : base(
        messageListResponse
    )
    {  }
    #pragma warning restore CS8618

    public MessageListResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageListResponseFromRaw.FromRawUnchecked"/>
    public static MessageListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageListResponseFromRaw : IFromRawJson<MessageListResponse>
{
    /// <inheritdoc/>
    public MessageListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The role of the message sender.
/// </summary>
[JsonConverter(typeof(RoleConverter))]
public enum Role
{
    User, Assistant, Tool
}sealed class RoleConverter : JsonConverter<Role>
{
    public override Role Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user"=>Role.User,
            "assistant"=>Role.Assistant,
            "tool"=>Role.Tool,
            _ =>(Role)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Role value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Role.User=>"user",
            Role.Assistant=>"assistant",
            Role.Tool=>"tool",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(MetadataConverter))]
public record class Metadata : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Metadata (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (long value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Metadata (
        Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Metadata (JsonElement element)
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
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLong(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="bool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBool(out var value)) {
///     // `value` is of type `bool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value =this.Value as bool? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>UnnamedSchemaWithArrayParent1</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickConversationMetadataListValue(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent1&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickConversationMetadataListValue(
        [NotNullWhen(true)] out Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1> ;
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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent1&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<bool> @bool,
        System::Action<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1>> conversationMetadataListValue
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            case Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1> value:
                conversationMetadataListValue(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Metadata");

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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;UnnamedSchemaWithArrayParent1&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<bool, T> @bool,
        System::Func<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1>, T> conversationMetadataListValue
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            long value=>@long(value),
            bool value=>@bool(value),
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1> value=>conversationMetadataListValue(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Metadata")
        } ;
    }

    public static implicit operator Metadata (string value)=> new(value) ;

    public static implicit operator Metadata (long value)=> new(value) ;

    public static implicit operator Metadata (bool value)=> new(value) ;

    public static implicit operator Metadata (
        Generic::List<UnnamedSchemaWithArrayParent1> value
    )=> new((Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Metadata");
        }
        this.Switch((_) => {},
        (_) => {},
        (_) => {},
        (conversationMetadataListValue) => {foreach (var item in conversationMetadataListValue)
        {
            item.Validate();
        }});
    }

    public virtual bool Equals(Metadata? other)
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
            string _=>0,
            long _=>1,
            bool _=>2,
            Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1> _=>3,
            _ =>-1
        } ;
    }
}sealed class MetadataConverter : JsonConverter<Metadata>
{
    public override Metadata? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<UnnamedSchemaWithArrayParent1>>(element, options);
            if (deserialized != null) {
                foreach (var item in deserialized)
                {
                    item.Validate();
                }
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
        Utf8JsonWriter writer, Metadata value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(UnnamedSchemaWithArrayParent1Converter))]
public record class UnnamedSchemaWithArrayParent1 : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public UnnamedSchemaWithArrayParent1 (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent1 (
        long value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent1 (
        bool value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public UnnamedSchemaWithArrayParent1 (JsonElement element)
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
/// type <see cref="long"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickLong(out var value)) {
///     // `value` is of type `long`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickLong([NotNullWhen(true)] out long? value)
    {
        value =this.Value as long? ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="bool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBool(out var value)) {
///     // `value` is of type `bool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBool([NotNullWhen(true)] out bool? value)
    {
        value =this.Value as bool? ;
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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<long> @long,
        System::Action<bool> @bool
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case long value:
                @long(value);
                break;
            case bool value:
                @bool(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent1");

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
///     (long value) =&gt; {...},
///     (bool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<long, T> @long,
        System::Func<bool, T> @bool
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            long value=>@long(value),
            bool value=>@bool(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent1")
        } ;
    }

    public static implicit operator UnnamedSchemaWithArrayParent1 (
        string value
    )=> new(value) ;

    public static implicit operator UnnamedSchemaWithArrayParent1 (
        long value
    )=> new(value) ;

    public static implicit operator UnnamedSchemaWithArrayParent1 (
        bool value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of UnnamedSchemaWithArrayParent1");
        }
    }

    public virtual bool Equals(UnnamedSchemaWithArrayParent1? other)
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
        { string _=>0, long _=>1, bool _=>2, _ =>-1 } ;
    }
}sealed class UnnamedSchemaWithArrayParent1Converter : JsonConverter<UnnamedSchemaWithArrayParent1>
{
    public override UnnamedSchemaWithArrayParent1? Read(
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
            return new(JsonSerializer.Deserialize<long>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        try
        {
            return new(JsonSerializer.Deserialize<bool>(element, options), element);
        }
        catch (System::Exception e)when( e is JsonException || e is TelnyxInvalidDataException )
        {
            // ignore
        }

        return new(element);
    }

    public override void Write(
        Utf8JsonWriter writer,
        UnnamedSchemaWithArrayParent1 value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<ToolCall, ToolCallFromRaw>))]
public sealed record class ToolCall : JsonModel
{
    /// <summary>
    /// Unique identifier for the tool call.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required Function Function {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Function>(
                "function"
            );
        }
        init { this._rawData.Set("function", value); }
    }

    /// <summary>
    /// Type of the tool call.
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Function.Validate();
        this.Type.Validate();
    }

    public ToolCall ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolCall (ToolCall toolCall) : base(toolCall)
    {  }
    #pragma warning restore CS8618

    public ToolCall (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolCall (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolCallFromRaw.FromRawUnchecked"/>
    public static ToolCall FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ToolCallFromRaw : IFromRawJson<ToolCall>
{
    /// <inheritdoc/>
    public ToolCall FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolCall.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Function, FunctionFromRaw>))]
public sealed record class Function : JsonModel
{
    /// <summary>
    /// JSON-formatted arguments to pass to the function.
    /// </summary>
    public required string Arguments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "arguments"
            );
        }
        init { this._rawData.Set("arguments", value); }
    }

    /// <summary>
    /// Name of the function to call.
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
        _ = this.Arguments;
        _ = this.Name;
    }

    public Function ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Function (Function function) : base(function)
    {  }
    #pragma warning restore CS8618

    public Function (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Function (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FunctionFromRaw.FromRawUnchecked"/>
    public static Function FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FunctionFromRaw : IFromRawJson<Function>
{
    /// <inheritdoc/>
    public Function FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Function.FromRawUnchecked(rawData);
}/// <summary>
/// Type of the tool call.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Function
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type>
{
    public override global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "function"=>global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type.Function,
            _ =>(global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.AI.Conversations.Messages.Type.Function=>"function",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}