using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Assistant configuration including choice of LLM, custom instructions, and tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Assistant, AssistantFromRaw>))]
public sealed record class Assistant : JsonModel
{
    /// <summary>
    /// The system instructions that the voice assistant uses during the gather command
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
    /// The model to be used by the voice assistant.
    /// </summary>
    public string? Model {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "model"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("model", value);
        }
    }

    /// <summary>
    /// This is necessary only if the model selected is from OpenAI. You would pass
    /// the `identifier` for an integration secret [/v2/integration_secrets](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// that refers to your OpenAI API Key. Warning: Free plans are unlikely to work
    /// with this integration.
    /// </summary>
    public string? OpenAIApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "openai_api_key_ref"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("openai_api_key_ref", value);
        }
    }

    /// <summary>
    /// The tools that the voice assistant can use.
    /// </summary>
    public IReadOnlyList<Tool>? Tools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Tool>>(
                "tools"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Tool>?>(
                "tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Instructions;
        _ = this.Model;
        _ = this.OpenAIApiKeyRef;
        foreach (var item in this.Tools ?? [])
        {
            item.Validate();
        }
    }

    public Assistant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Assistant (Assistant assistant) : base(assistant)
    {  }
    #pragma warning restore CS8618

    public Assistant (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Assistant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AssistantFromRaw.FromRawUnchecked"/>
    public static Assistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AssistantFromRaw : IFromRawJson<Assistant>
{
    /// <inheritdoc/>
    public Assistant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Assistant.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ToolConverter))]
public record class Tool : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Tool (BookAppointmentTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (CheckAvailabilityTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (WebhookTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (HangupTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (TransferTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (CallControlRetrievalTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Tool (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="BookAppointmentTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickBookAppointment(out var value)) {
///     // `value` is of type `BookAppointmentTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickBookAppointment(
        [NotNullWhen(true)] out BookAppointmentTool? value
    )
    {
        value =this.Value as BookAppointmentTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CheckAvailabilityTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCheckAvailability(out var value)) {
///     // `value` is of type `CheckAvailabilityTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCheckAvailability(
        [NotNullWhen(true)] out CheckAvailabilityTool? value
    )
    {
        value =this.Value as CheckAvailabilityTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WebhookTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWebhook(out var value)) {
///     // `value` is of type `WebhookTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWebhook([NotNullWhen(true)] out WebhookTool? value)
    {
        value =this.Value as WebhookTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="HangupTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHangup(out var value)) {
///     // `value` is of type `HangupTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHangup([NotNullWhen(true)] out HangupTool? value)
    {
        value =this.Value as HangupTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="TransferTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTransfer(out var value)) {
///     // `value` is of type `TransferTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTransfer([NotNullWhen(true)] out TransferTool? value)
    {
        value =this.Value as TransferTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="CallControlRetrievalTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickCallControlRetrieval(out var value)) {
///     // `value` is of type `CallControlRetrievalTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickCallControlRetrieval(
        [NotNullWhen(true)] out CallControlRetrievalTool? value
    )
    {
        value =this.Value as CallControlRetrievalTool ;
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
///     (BookAppointmentTool value) =&gt; {...},
///     (CheckAvailabilityTool value) =&gt; {...},
///     (WebhookTool value) =&gt; {...},
///     (HangupTool value) =&gt; {...},
///     (TransferTool value) =&gt; {...},
///     (CallControlRetrievalTool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<BookAppointmentTool> bookAppointment,
        System::Action<CheckAvailabilityTool> checkAvailability,
        System::Action<WebhookTool> webhook,
        System::Action<HangupTool> hangup,
        System::Action<TransferTool> transfer,
        System::Action<CallControlRetrievalTool> callControlRetrieval
    )
    {
        switch (this.Value)
        {
            case BookAppointmentTool value:
                bookAppointment(value);
                break;
            case CheckAvailabilityTool value:
                checkAvailability(value);
                break;
            case WebhookTool value:
                webhook(value);
                break;
            case HangupTool value:
                hangup(value);
                break;
            case TransferTool value:
                transfer(value);
                break;
            case CallControlRetrievalTool value:
                callControlRetrieval(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Tool");

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
///     (BookAppointmentTool value) =&gt; {...},
///     (CheckAvailabilityTool value) =&gt; {...},
///     (WebhookTool value) =&gt; {...},
///     (HangupTool value) =&gt; {...},
///     (TransferTool value) =&gt; {...},
///     (CallControlRetrievalTool value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<BookAppointmentTool, T> bookAppointment,
        System::Func<CheckAvailabilityTool, T> checkAvailability,
        System::Func<WebhookTool, T> webhook,
        System::Func<HangupTool, T> hangup,
        System::Func<TransferTool, T> transfer,
        System::Func<CallControlRetrievalTool, T> callControlRetrieval
    )
    {
        return this.Value switch
        {
            BookAppointmentTool value=>bookAppointment(value),
            CheckAvailabilityTool value=>checkAvailability(value),
            WebhookTool value=>webhook(value),
            HangupTool value=>hangup(value),
            TransferTool value=>transfer(value),
            CallControlRetrievalTool value=>callControlRetrieval(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Tool")
        } ;
    }

    public static implicit operator Tool (
        BookAppointmentTool value
    )=> new(value) ;

    public static implicit operator Tool (
        CheckAvailabilityTool value
    )=> new(value) ;

    public static implicit operator Tool (WebhookTool value)=> new(value) ;

    public static implicit operator Tool (HangupTool value)=> new(value) ;

    public static implicit operator Tool (TransferTool value)=> new(value) ;

    public static implicit operator Tool (
        CallControlRetrievalTool value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Tool");
        }
        this.Switch((bookAppointment) => bookAppointment.Validate(),
        (checkAvailability) => checkAvailability.Validate(),
        (webhook) => webhook.Validate(),
        (hangup) => hangup.Validate(),
        (transfer) => transfer.Validate(),
        (callControlRetrieval) => callControlRetrieval.Validate());
    }

    public virtual bool Equals(Tool? other)
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
            BookAppointmentTool _=>0,
            CheckAvailabilityTool _=>1,
            WebhookTool _=>2,
            HangupTool _=>3,
            TransferTool _=>4,
            CallControlRetrievalTool _=>5,
            _ =>-1
        } ;
    }
}sealed class ToolConverter : JsonConverter<Tool>
{
    public override Tool? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "book_appointment":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<BookAppointmentTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "check_availability":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CheckAvailabilityTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "webhook":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<WebhookTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "hangup":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<HangupTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "transfer":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<TransferTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "retrieval":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<CallControlRetrievalTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new Tool(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Tool value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}