using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages.Actions;

/// <summary>
/// Email address accepted by inbox message actions, as a string or an object with
/// `email` and optional `name`.
/// </summary>
[JsonConverter(typeof(InboxActionEmailAddressInputConverter))]
public record class InboxActionEmailAddressInput : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public InboxActionEmailAddressInput (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InboxActionEmailAddressInput (
        InboxActionEmailAddressInputInboxRecipientAddress value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public InboxActionEmailAddressInput (JsonElement element)
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
/// type <see cref="InboxActionEmailAddressInputInboxRecipientAddress"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRecipientAddress(out var value)) {
///     // `value` is of type `InboxActionEmailAddressInputInboxRecipientAddress`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRecipientAddress(
        [NotNullWhen(true)] out InboxActionEmailAddressInputInboxRecipientAddress? value
    )
    {
        value =this.Value as InboxActionEmailAddressInputInboxRecipientAddress ;
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
///     (InboxActionEmailAddressInputInboxRecipientAddress value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<InboxActionEmailAddressInputInboxRecipientAddress> recipientAddress
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case InboxActionEmailAddressInputInboxRecipientAddress value:
                recipientAddress(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of InboxActionEmailAddressInput");

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
///     (InboxActionEmailAddressInputInboxRecipientAddress value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<InboxActionEmailAddressInputInboxRecipientAddress, T> recipientAddress
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            InboxActionEmailAddressInputInboxRecipientAddress value=>recipientAddress(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of InboxActionEmailAddressInput")
        } ;
    }

    public static implicit operator InboxActionEmailAddressInput (
        string value
    )=> new(value) ;

    public static implicit operator InboxActionEmailAddressInput (
        InboxActionEmailAddressInputInboxRecipientAddress value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of InboxActionEmailAddressInput");
        }
        this.Switch((_) => {},
        (recipientAddress) => recipientAddress.Validate());
    }

    public virtual bool Equals(InboxActionEmailAddressInput? other)
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
            InboxActionEmailAddressInputInboxRecipientAddress _=>1,
            _ =>-1
        } ;
    }
}

sealed class InboxActionEmailAddressInputConverter : JsonConverter<InboxActionEmailAddressInput>
{
    public override InboxActionEmailAddressInput? Read(
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
            var deserialized = JsonSerializer.Deserialize<InboxActionEmailAddressInputInboxRecipientAddress>(element, options);
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
        InboxActionEmailAddressInput value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<InboxActionEmailAddressInputInboxRecipientAddress, InboxActionEmailAddressInputInboxRecipientAddressFromRaw>))]
public sealed record class InboxActionEmailAddressInputInboxRecipientAddress : JsonModel
{
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        _ = this.Name;
    }

    public InboxActionEmailAddressInputInboxRecipientAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboxActionEmailAddressInputInboxRecipientAddress (
        InboxActionEmailAddressInputInboxRecipientAddress inboxActionEmailAddressInputInboxRecipientAddress
    ) : base(inboxActionEmailAddressInputInboxRecipientAddress)
    {  }
    #pragma warning restore CS8618

    public InboxActionEmailAddressInputInboxRecipientAddress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboxActionEmailAddressInputInboxRecipientAddress (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboxActionEmailAddressInputInboxRecipientAddressFromRaw.FromRawUnchecked"/>
    public static InboxActionEmailAddressInputInboxRecipientAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InboxActionEmailAddressInputInboxRecipientAddress (
        string email
    ) : this()
    { this.Email = email; }
}class InboxActionEmailAddressInputInboxRecipientAddressFromRaw : IFromRawJson<InboxActionEmailAddressInputInboxRecipientAddress>
{
    /// <inheritdoc/>
    public InboxActionEmailAddressInputInboxRecipientAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboxActionEmailAddressInputInboxRecipientAddress.FromRawUnchecked(rawData);
}