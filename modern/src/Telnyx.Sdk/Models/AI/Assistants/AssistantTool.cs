using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Chat = Telnyx.Sdk.Models.AI.OpenAI.Chat;
using Telnyx.Sdk.Models.AI.Tools;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// The handoff tool allows the assistant to hand off control of the conversation
/// to another AI assistant. By default, this will happen transparently to the end user.
/// </summary>
[JsonConverter(typeof(AssistantToolConverter))]
public record class AssistantTool : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public bool? Shared {
        get {
            return Match<bool?>(function: ( x )=>x.Shared,
            inferenceEmbeddingWebhookToolParams: ( x )=>x.Shared,
            clientSide: ( x )=>x.Shared,
            retrieval: ( x )=>x.Shared,
            handoff: ( x )=>x.Shared,
            hangup: ( x )=>x.Shared,
            transfer: ( x )=>x.Shared,
            invite: ( x )=>x.Shared,
            refer: ( x )=>x.Shared,
            sendDtmf: ( x )=>x.Shared,
            sendMessage: ( x )=>x.Shared,
            skipTurn: ( x )=>x.Shared,
            pay: ( x )=>x.Shared,
            updateDynamicVariables: ( x )=>x.Shared);
        }
    }

    public AssistantTool (Function value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (
        InferenceEmbeddingWebhookToolParams value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (ClientSideTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (RetrievalTool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Handoff value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Hangup value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Transfer value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Invite value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Refer value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (SendDtmf value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (SendMessage value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (SkipTurn value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (Pay value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (
        UpdateDynamicVariables value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public AssistantTool (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Function"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickFunction(out var value)) {
///     // `value` is of type `Function`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickFunction([NotNullWhen(true)] out Function? value)
    {
        value =this.Value as Function ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="InferenceEmbeddingWebhookToolParams"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInferenceEmbeddingWebhookToolParams(out var value)) {
///     // `value` is of type `InferenceEmbeddingWebhookToolParams`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInferenceEmbeddingWebhookToolParams(
        [NotNullWhen(true)] out InferenceEmbeddingWebhookToolParams? value
    )
    {
        value =this.Value as InferenceEmbeddingWebhookToolParams ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ClientSideTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickClientSide(out var value)) {
///     // `value` is of type `ClientSideTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickClientSide([NotNullWhen(true)] out ClientSideTool? value)
    {
        value =this.Value as ClientSideTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="RetrievalTool"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRetrieval(out var value)) {
///     // `value` is of type `RetrievalTool`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRetrieval([NotNullWhen(true)] out RetrievalTool? value)
    {
        value =this.Value as RetrievalTool ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Handoff"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHandoff(out var value)) {
///     // `value` is of type `Handoff`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHandoff([NotNullWhen(true)] out Handoff? value)
    {
        value =this.Value as Handoff ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Hangup"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickHangup(out var value)) {
///     // `value` is of type `Hangup`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickHangup([NotNullWhen(true)] out Hangup? value)
    {
        value =this.Value as Hangup ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Transfer"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickTransfer(out var value)) {
///     // `value` is of type `Transfer`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickTransfer([NotNullWhen(true)] out Transfer? value)
    {
        value =this.Value as Transfer ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Invite"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickInvite(out var value)) {
///     // `value` is of type `Invite`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickInvite([NotNullWhen(true)] out Invite? value)
    {
        value =this.Value as Invite ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Refer"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickRefer(out var value)) {
///     // `value` is of type `Refer`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickRefer([NotNullWhen(true)] out Refer? value)
    {
        value =this.Value as Refer ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SendDtmf"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSendDtmf(out var value)) {
///     // `value` is of type `SendDtmf`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSendDtmf([NotNullWhen(true)] out SendDtmf? value)
    {
        value =this.Value as SendDtmf ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SendMessage"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSendMessage(out var value)) {
///     // `value` is of type `SendMessage`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSendMessage([NotNullWhen(true)] out SendMessage? value)
    {
        value =this.Value as SendMessage ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="SkipTurn"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSkipTurn(out var value)) {
///     // `value` is of type `SkipTurn`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSkipTurn([NotNullWhen(true)] out SkipTurn? value)
    {
        value =this.Value as SkipTurn ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Pay"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPay(out var value)) {
///     // `value` is of type `Pay`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPay([NotNullWhen(true)] out Pay? value)
    {
        value =this.Value as Pay ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="UpdateDynamicVariables"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickUpdateDynamicVariables(out var value)) {
///     // `value` is of type `UpdateDynamicVariables`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickUpdateDynamicVariables(
        [NotNullWhen(true)] out UpdateDynamicVariables? value
    )
    {
        value =this.Value as UpdateDynamicVariables ;
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
///     (Function value) =&gt; {...},
///     (InferenceEmbeddingWebhookToolParams value) =&gt; {...},
///     (ClientSideTool value) =&gt; {...},
///     (RetrievalTool value) =&gt; {...},
///     (Handoff value) =&gt; {...},
///     (Hangup value) =&gt; {...},
///     (Transfer value) =&gt; {...},
///     (Invite value) =&gt; {...},
///     (Refer value) =&gt; {...},
///     (SendDtmf value) =&gt; {...},
///     (SendMessage value) =&gt; {...},
///     (SkipTurn value) =&gt; {...},
///     (Pay value) =&gt; {...},
///     (UpdateDynamicVariables value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Function> function,
        System::Action<InferenceEmbeddingWebhookToolParams> inferenceEmbeddingWebhookToolParams,
        System::Action<ClientSideTool> clientSide,
        System::Action<RetrievalTool> retrieval,
        System::Action<Handoff> handoff,
        System::Action<Hangup> hangup,
        System::Action<Transfer> transfer,
        System::Action<Invite> invite,
        System::Action<Refer> refer,
        System::Action<SendDtmf> sendDtmf,
        System::Action<SendMessage> sendMessage,
        System::Action<SkipTurn> skipTurn,
        System::Action<Pay> pay,
        System::Action<UpdateDynamicVariables> updateDynamicVariables
    )
    {
        switch (this.Value)
        {
            case Function value:
                function(value);
                break;
            case InferenceEmbeddingWebhookToolParams value:
                inferenceEmbeddingWebhookToolParams(value);
                break;
            case ClientSideTool value:
                clientSide(value);
                break;
            case RetrievalTool value:
                retrieval(value);
                break;
            case Handoff value:
                handoff(value);
                break;
            case Hangup value:
                hangup(value);
                break;
            case Transfer value:
                transfer(value);
                break;
            case Invite value:
                invite(value);
                break;
            case Refer value:
                refer(value);
                break;
            case SendDtmf value:
                sendDtmf(value);
                break;
            case SendMessage value:
                sendMessage(value);
                break;
            case SkipTurn value:
                skipTurn(value);
                break;
            case Pay value:
                pay(value);
                break;
            case UpdateDynamicVariables value:
                updateDynamicVariables(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of AssistantTool");

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
///     (Function value) =&gt; {...},
///     (InferenceEmbeddingWebhookToolParams value) =&gt; {...},
///     (ClientSideTool value) =&gt; {...},
///     (RetrievalTool value) =&gt; {...},
///     (Handoff value) =&gt; {...},
///     (Hangup value) =&gt; {...},
///     (Transfer value) =&gt; {...},
///     (Invite value) =&gt; {...},
///     (Refer value) =&gt; {...},
///     (SendDtmf value) =&gt; {...},
///     (SendMessage value) =&gt; {...},
///     (SkipTurn value) =&gt; {...},
///     (Pay value) =&gt; {...},
///     (UpdateDynamicVariables value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Function, T> function,
        System::Func<InferenceEmbeddingWebhookToolParams, T> inferenceEmbeddingWebhookToolParams,
        System::Func<ClientSideTool, T> clientSide,
        System::Func<RetrievalTool, T> retrieval,
        System::Func<Handoff, T> handoff,
        System::Func<Hangup, T> hangup,
        System::Func<Transfer, T> transfer,
        System::Func<Invite, T> invite,
        System::Func<Refer, T> refer,
        System::Func<SendDtmf, T> sendDtmf,
        System::Func<SendMessage, T> sendMessage,
        System::Func<SkipTurn, T> skipTurn,
        System::Func<Pay, T> pay,
        System::Func<UpdateDynamicVariables, T> updateDynamicVariables
    )
    {
        return this.Value switch
        {
            Function value=>function(value),
            InferenceEmbeddingWebhookToolParams value=>inferenceEmbeddingWebhookToolParams(value),
            ClientSideTool value=>clientSide(value),
            RetrievalTool value=>retrieval(value),
            Handoff value=>handoff(value),
            Hangup value=>hangup(value),
            Transfer value=>transfer(value),
            Invite value=>invite(value),
            Refer value=>refer(value),
            SendDtmf value=>sendDtmf(value),
            SendMessage value=>sendMessage(value),
            SkipTurn value=>skipTurn(value),
            Pay value=>pay(value),
            UpdateDynamicVariables value=>updateDynamicVariables(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of AssistantTool")
        } ;
    }

    public static implicit operator AssistantTool (
        Function value
    )=> new(value) ;

    public static implicit operator AssistantTool (
        InferenceEmbeddingWebhookToolParams value
    )=> new(value) ;

    public static implicit operator AssistantTool (
        ClientSideTool value
    )=> new(value) ;

    public static implicit operator AssistantTool (
        RetrievalTool value
    )=> new(value) ;

    public static implicit operator AssistantTool (Handoff value)=> new(value) ;

    public static implicit operator AssistantTool (Hangup value)=> new(value) ;

    public static implicit operator AssistantTool (
        Transfer value
    )=> new(value) ;

    public static implicit operator AssistantTool (Invite value)=> new(value) ;

    public static implicit operator AssistantTool (Refer value)=> new(value) ;

    public static implicit operator AssistantTool (
        SendDtmf value
    )=> new(value) ;

    public static implicit operator AssistantTool (
        SendMessage value
    )=> new(value) ;

    public static implicit operator AssistantTool (
        SkipTurn value
    )=> new(value) ;

    public static implicit operator AssistantTool (Pay value)=> new(value) ;

    public static implicit operator AssistantTool (
        UpdateDynamicVariables value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of AssistantTool");
        }
        this.Switch((function) => function.Validate(),
        (inferenceEmbeddingWebhookToolParams) => inferenceEmbeddingWebhookToolParams.Validate(),
        (clientSide) => clientSide.Validate(),
        (retrieval) => retrieval.Validate(),
        (handoff) => handoff.Validate(),
        (hangup) => hangup.Validate(),
        (transfer) => transfer.Validate(),
        (invite) => invite.Validate(),
        (refer) => refer.Validate(),
        (sendDtmf) => sendDtmf.Validate(),
        (sendMessage) => sendMessage.Validate(),
        (skipTurn) => skipTurn.Validate(),
        (pay) => pay.Validate(),
        (updateDynamicVariables) => updateDynamicVariables.Validate());
    }

    public virtual bool Equals(AssistantTool? other)
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
            Function _=>0,
            InferenceEmbeddingWebhookToolParams _=>1,
            ClientSideTool _=>2,
            RetrievalTool _=>3,
            Handoff _=>4,
            Hangup _=>5,
            Transfer _=>6,
            Invite _=>7,
            Refer _=>8,
            SendDtmf _=>9,
            SendMessage _=>10,
            SkipTurn _=>11,
            Pay _=>12,
            UpdateDynamicVariables _=>13,
            _ =>-1
        } ;
    }
}

sealed class AssistantToolConverter : JsonConverter<AssistantTool>
{
    public override AssistantTool? Read(
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
            case "function":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Function>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<InferenceEmbeddingWebhookToolParams>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "client_side_tool":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<ClientSideTool>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<RetrievalTool>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "handoff":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Handoff>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Hangup>(element, options);
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
                    var deserialized = JsonSerializer.Deserialize<Transfer>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "invite":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Invite>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "refer":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Refer>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "send_dtmf":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SendDtmf>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "send_message":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SendMessage>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "skip_turn":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<SkipTurn>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "pay":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Pay>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "update_dynamic_variables":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<UpdateDynamicVariables>(element, options);
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
                { return new AssistantTool(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssistantTool value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<Function, FunctionFromRaw>))]
public sealed record class Function : JsonModel
{
    public required Chat::FunctionDefinition FunctionValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Chat::FunctionDefinition>(
                "function"
            );
        }
        init { this._rawData.Set("function", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.FunctionValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("function")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Function ()
    { this.Type = JsonSerializer.SerializeToElement("function"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Function (Function function) : base(function)
    {  }
    #pragma warning restore CS8618

    public Function (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("function");
    }

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

    [SetsRequiredMembers]
    public Function (Chat::FunctionDefinition functionValue) : this()
    { this.FunctionValue = functionValue; }
}class FunctionFromRaw : IFromRawJson<Function>
{
    /// <inheritdoc/>
    public Function FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Function.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ClientSideTool, ClientSideToolFromRaw>))]
public sealed record class ClientSideTool : JsonModel
{
    public required ClientSideToolClientSideTool ClientSideToolValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ClientSideToolClientSideTool>(
                "client_side_tool"
            );
        }
        init { this._rawData.Set("client_side_tool", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ClientSideToolValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("client_side_tool")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public ClientSideTool ()
    { this.Type = JsonSerializer.SerializeToElement("client_side_tool"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClientSideTool (ClientSideTool clientSideTool) : base(clientSideTool)
    {  }
    #pragma warning restore CS8618

    public ClientSideTool (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("client_side_tool");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClientSideTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClientSideToolFromRaw.FromRawUnchecked"/>
    public static ClientSideTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ClientSideTool (
        ClientSideToolClientSideTool clientSideToolValue
    ) : this()
    { this.ClientSideToolValue = clientSideToolValue; }
}class ClientSideToolFromRaw : IFromRawJson<ClientSideTool>
{
    /// <inheritdoc/>
    public ClientSideTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClientSideTool.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ClientSideToolClientSideTool, ClientSideToolClientSideToolFromRaw>))]
public sealed record class ClientSideToolClientSideTool : JsonModel
{
    /// <summary>
    /// The description of the tool.
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// The name of the tool.
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

    /// <summary>
    /// The parameters the tool accepts, described as a JSON Schema object. See the
    /// [JSON Schema reference](https://json-schema.org/understanding-json-schema)
    /// for documentation about the format
    /// </summary>
    public required Parameters Parameters {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Parameters>(
                "parameters"
            );
        }
        init { this._rawData.Set("parameters", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
        this.Parameters.Validate();
    }

    public ClientSideToolClientSideTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ClientSideToolClientSideTool (
        ClientSideToolClientSideTool clientSideToolClientSideTool
    ) : base(clientSideToolClientSideTool)
    {  }
    #pragma warning restore CS8618

    public ClientSideToolClientSideTool (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ClientSideToolClientSideTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ClientSideToolClientSideToolFromRaw.FromRawUnchecked"/>
    public static ClientSideToolClientSideTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ClientSideToolClientSideToolFromRaw : IFromRawJson<ClientSideToolClientSideTool>
{
    /// <inheritdoc/>
    public ClientSideToolClientSideTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ClientSideToolClientSideTool.FromRawUnchecked(rawData);
}/// <summary>
/// The parameters the tool accepts, described as a JSON Schema object. See the [JSON
/// Schema reference](https://json-schema.org/understanding-json-schema) for documentation
/// about the format
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Parameters, ParametersFromRaw>))]
public sealed record class Parameters : JsonModel
{
    /// <summary>
    /// The properties of the parameters.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Properties {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "properties"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "properties",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The required properties of the parameters.
    /// </summary>
    public Generic::IReadOnlyList<string>? Required {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "required"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "required",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, global::Telnyx.Sdk.Models.AI.Assistants.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.AI.Assistants.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Properties;
        _ = this.Required;
        this.Type?.Validate();
    }

    public Parameters ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Parameters (Parameters parameters) : base(parameters)
    {  }
    #pragma warning restore CS8618

    public Parameters (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Parameters (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParametersFromRaw.FromRawUnchecked"/>
    public static Parameters FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ParametersFromRaw : IFromRawJson<Parameters>
{
    /// <inheritdoc/>
    public Parameters FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Parameters.FromRawUnchecked(rawData);
}[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Object
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.AI.Assistants.Type>
{
    public override global::Telnyx.Sdk.Models.AI.Assistants.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "object"=>global::Telnyx.Sdk.Models.AI.Assistants.Type.Object,
            _ =>(global::Telnyx.Sdk.Models.AI.Assistants.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.AI.Assistants.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.AI.Assistants.Type.Object=>"object",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The handoff tool allows the assistant to hand off control of the conversation
/// to another AI assistant. By default, this will happen transparently to the end user.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Handoff, HandoffFromRaw>))]
public sealed record class Handoff : JsonModel
{
    public required HandoffHandoff HandoffValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<HandoffHandoff>(
                "handoff"
            );
        }
        init { this._rawData.Set("handoff", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.HandoffValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("handoff")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Handoff ()
    { this.Type = JsonSerializer.SerializeToElement("handoff"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Handoff (Handoff handoff) : base(handoff)
    {  }
    #pragma warning restore CS8618

    public Handoff (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("handoff");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Handoff (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HandoffFromRaw.FromRawUnchecked"/>
    public static Handoff FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Handoff (HandoffHandoff handoffValue) : this()
    { this.HandoffValue = handoffValue; }
}class HandoffFromRaw : IFromRawJson<Handoff>
{
    /// <inheritdoc/>
    public Handoff FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Handoff.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<HandoffHandoff, HandoffHandoffFromRaw>))]
public sealed record class HandoffHandoff : JsonModel
{
    /// <summary>
    /// List of possible assistants that can receive a handoff.
    /// </summary>
    public required Generic::IReadOnlyList<AIAssistant> AIAssistants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AIAssistant>>(
                "ai_assistants"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AIAssistant>>(
                "ai_assistants",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// With the unified voice mode all assistants share the same voice, making the
    /// handoff transparent to the user. With the distinct voice mode all assistants
    /// retain their voice configuration, providing the experience of a conference
    /// call with a team of assistants.
    /// </summary>
    public ApiEnum<string, VoiceMode>? VoiceMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoiceMode>>(
                "voice_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.AIAssistants)
        {
            item.Validate();
        }
        this.VoiceMode?.Validate();
    }

    public HandoffHandoff ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HandoffHandoff (HandoffHandoff handoffHandoff) : base(handoffHandoff)
    {  }
    #pragma warning restore CS8618

    public HandoffHandoff (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HandoffHandoff (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HandoffHandoffFromRaw.FromRawUnchecked"/>
    public static HandoffHandoff FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public HandoffHandoff (
        Generic::IReadOnlyList<AIAssistant> aiAssistants
    ) : this()
    { this.AIAssistants = aiAssistants; }
}class HandoffHandoffFromRaw : IFromRawJson<HandoffHandoff>
{
    /// <inheritdoc/>
    public HandoffHandoff FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HandoffHandoff.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<AIAssistant, AIAssistantFromRaw>))]
public sealed record class AIAssistant : JsonModel
{
    /// <summary>
    /// The ID of the assistant to hand off to.
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

    /// <summary>
    /// Helpful name for giving context on when to handoff to the assistant.
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
        _ = this.ID;
        _ = this.Name;
    }

    public AIAssistant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AIAssistant (AIAssistant aiAssistant) : base(aiAssistant)
    {  }
    #pragma warning restore CS8618

    public AIAssistant (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AIAssistant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AIAssistantFromRaw.FromRawUnchecked"/>
    public static AIAssistant FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AIAssistantFromRaw : IFromRawJson<AIAssistant>
{
    /// <inheritdoc/>
    public AIAssistant FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AIAssistant.FromRawUnchecked(rawData);
}/// <summary>
/// With the unified voice mode all assistants share the same voice, making the handoff
/// transparent to the user. With the distinct voice mode all assistants retain their
/// voice configuration, providing the experience of a conference call with a team
/// of assistants.
/// </summary>
[JsonConverter(typeof(VoiceModeConverter))]
public enum VoiceMode
{
    Unified, Distinct
}sealed class VoiceModeConverter : JsonConverter<VoiceMode>
{
    public override VoiceMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "unified"=>VoiceMode.Unified,
            "distinct"=>VoiceMode.Distinct,
            _ =>(VoiceMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, VoiceMode value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoiceMode.Unified=>"unified",
            VoiceMode.Distinct=>"distinct",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Hangup, HangupFromRaw>))]
public sealed record class Hangup : JsonModel
{
    public required HangupToolParams HangupValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<HangupToolParams>(
                "hangup"
            );
        }
        init { this._rawData.Set("hangup", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.HangupValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("hangup")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Hangup ()
    { this.Type = JsonSerializer.SerializeToElement("hangup"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Hangup (Hangup hangup) : base(hangup)
    {  }
    #pragma warning restore CS8618

    public Hangup (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("hangup");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Hangup (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HangupFromRaw.FromRawUnchecked"/>
    public static Hangup FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Hangup (HangupToolParams hangupValue) : this()
    { this.HangupValue = hangupValue; }
}class HangupFromRaw : IFromRawJson<Hangup>
{
    /// <inheritdoc/>
    public Hangup FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Hangup.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Transfer, TransferFromRaw>))]
public sealed record class Transfer : JsonModel
{
    public required TransferTransfer TransferValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TransferTransfer>(
                "transfer"
            );
        }
        init { this._rawData.Set("transfer", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.TransferValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("transfer")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Transfer ()
    { this.Type = JsonSerializer.SerializeToElement("transfer"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Transfer (Transfer transfer) : base(transfer)
    {  }
    #pragma warning restore CS8618

    public Transfer (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("transfer");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Transfer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransferFromRaw.FromRawUnchecked"/>
    public static Transfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Transfer (TransferTransfer transferValue) : this()
    { this.TransferValue = transferValue; }
}class TransferFromRaw : IFromRawJson<Transfer>
{
    /// <inheritdoc/>
    public Transfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Transfer.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<TransferTransfer, TransferTransferFromRaw>))]
public sealed record class TransferTransfer : JsonModel
{
    /// <summary>
    /// Number or SIP URI placing the call.
    /// </summary>
    public required string From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The different possible targets of the transfer. The assistant will be able
    /// to choose one of the targets to transfer the call to. This can also be a
    /// dynamic variable string like `{{ targets }}` where `targets` is returned by
    /// the dynamic variables webhook and resolves to an array of target objects
    /// at runtime.
    /// </summary>
    public required Targets Targets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Targets>(
                "targets"
            );
        }
        init { this._rawData.Set("targets", value); }
    }

    /// <summary>
    /// Custom headers to be added to the SIP INVITE for the transfer command.
    /// </summary>
    public Generic::IReadOnlyList<CustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomHeader>>(
                "custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomHeader>?>(
                "custom_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// A description of the transfer tool. By default, Telnyx generates this automatically
    /// based on the configured targets. Typically only set when importing an assistant
    /// from another provider that allowed a custom description; in that case the
    /// provided value is preserved. Most users should leave this empty and let Telnyx
    /// manage it.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// The number the inbound call was received on, forwarded so an unverified non-Telnyx
    /// `from` can be used as the caller id -- typically to transfer out as the original
    /// caller by pairing `from: "{{telnyx_end_user_target}}"` with `diversion: "{{telnyx_agent_target}}"`.
    /// The caller id is only accepted while that number is still on an active inbound
    /// call to this `diversion` number, and the `diversion` number must be one you
    /// own or have verified.
    /// </summary>
    public string? Diversion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "diversion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("diversion", value);
        }
    }

    /// <summary>
    /// Configuration for voicemail detection (AMD - Answering Machine Detection)
    /// on the transferred call. Allows the assistant to detect when a voicemail system
    /// answers the transferred call and take appropriate action.
    /// </summary>
    public VoicemailDetection? VoicemailDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoicemailDetection>(
                "voicemail_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voicemail_detection", value);
        }
    }

    /// <summary>
    /// Optional delay in milliseconds before playing the warm message audio when
    /// the transferred call is answered. When set, the audio_url is not included
    /// in the dial command; instead, playback starts after the specified delay.
    /// When not set, existing behavior (audio_url in dial) is preserved.
    /// </summary>
    public long? WarmMessageDelayMs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "warm_message_delay_ms"
            );
        }
        init { this._rawData.Set("warm_message_delay_ms", value); }
    }

    /// <summary>
    /// Requires the transfer destination to accept the call before the caller is
    /// bridged. When enabled, the assistant speaks privately with the destination
    /// after they answer — delivering the warm transfer message and asking whether
    /// they take the call — while the caller keeps hearing ringback. The assistant
    /// then finalizes the transfer with the built-in `complete_transfer` tool: an
    /// accept bridges the calls, a decline hangs up the destination and returns the
    /// assistant to the caller with the reason the destination gave. Requires either
    /// `warm_transfer_instructions` or a `message` on every target, otherwise the
    /// assistant fails to save. Only available for calls started with `ai_assistant_start`;
    /// single-caller conversations only (a conference or additional invited participants
    /// fall back to a regular warm transfer).
    /// </summary>
    public WarmTransferAcceptance? WarmTransferAcceptance {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WarmTransferAcceptance>(
                "warm_transfer_acceptance"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("warm_transfer_acceptance", value);
        }
    }

    /// <summary>
    /// Natural language instructions for your agent for how to provide context for
    /// the transfer recipient.
    /// </summary>
    public string? WarmTransferInstructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "warm_transfer_instructions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("warm_transfer_instructions", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        this.Targets.Validate();
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        _ = this.Description;
        _ = this.Diversion;
        this.VoicemailDetection?.Validate();
        _ = this.WarmMessageDelayMs;
        this.WarmTransferAcceptance?.Validate();
        _ = this.WarmTransferInstructions;
    }

    public TransferTransfer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferTransfer (TransferTransfer transferTransfer) : base(
        transferTransfer
    )
    {  }
    #pragma warning restore CS8618

    public TransferTransfer (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferTransfer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransferTransferFromRaw.FromRawUnchecked"/>
    public static TransferTransfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TransferTransferFromRaw : IFromRawJson<TransferTransfer>
{
    /// <inheritdoc/>
    public TransferTransfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TransferTransfer.FromRawUnchecked(rawData);
}/// <summary>
/// The different possible targets of the transfer. The assistant will be able to
/// choose one of the targets to transfer the call to. This can also be a dynamic
/// variable string like `{{ targets }}` where `targets` is returned by the dynamic
/// variables webhook and resolves to an array of target objects at runtime.
/// </summary>
[JsonConverter(typeof(TargetsConverter))]
public record class Targets : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Targets (
        Generic::IReadOnlyList<TargetObject> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Targets (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Targets (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>TargetObject</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;TargetObject&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<TargetObject>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<TargetObject> ;
        return value != null ;
    }

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
///     (Generic::IReadOnlyList&lt;TargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<TargetObject>> targetsList,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<TargetObject> value:
                targetsList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Targets");

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
///     (Generic::IReadOnlyList&lt;TargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<TargetObject>, T> targetsList,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<TargetObject> value=>targetsList(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Targets")
        } ;
    }

    public static implicit operator Targets (
        Generic::List<TargetObject> value
    )=> new((Generic::IReadOnlyList<TargetObject>)value) ;

    public static implicit operator Targets (string value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Targets");
        }
        this.Switch((targetsList) => {foreach (var item in targetsList)
        {
            item.Validate();
        }},
        (_) => {});
    }

    public virtual bool Equals(Targets? other)
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
        { Generic::IReadOnlyList<TargetObject> _=>0, string _=>1, _ =>-1 } ;
    }
}sealed class TargetsConverter : JsonConverter<Targets>
{
    public override Targets? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<TargetObject>>(element, options);
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
        Utf8JsonWriter writer, Targets value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<TargetObject, TargetObjectFromRaw>))]
public sealed record class TargetObject : JsonModel
{
    /// <summary>
    /// The destination number or SIP URI of the call.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// DTMF digits to send automatically after the transfer destination answers.
    /// Useful for reaching an extension behind an IVR (e.g. `"200"` to dial extension
    /// 200 once the called party picks up). Allowed characters: `0-9`, `A-D`, `w`
    /// (0.5s pause), `W` (1s pause), `*`, `#`. Maximum 64 characters. When omitted,
    /// no automatic DTMF is sent.
    /// </summary>
    public string? Extension {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extension"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extension", value);
        }
    }

    /// <summary>
    /// The warm transfer message to deliver to this specific target. When set, it
    /// takes precedence over the message the assistant composes from `warm_transfer_instructions`.
    /// </summary>
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

    /// <summary>
    /// The name of the target.
    /// </summary>
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

    /// <summary>
    /// SIP Authentication password used for SIP challenges. Applies when `to` is
    /// a SIP URI.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_auth_password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_auth_password", value);
        }
    }

    /// <summary>
    /// SIP Authentication username used for SIP challenges. Applies when `to` is
    /// a SIP URI.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_auth_username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_auth_username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.To;
        _ = this.Extension;
        _ = this.Message;
        _ = this.Name;
        _ = this.SipAuthPassword;
        _ = this.SipAuthUsername;
    }

    public TargetObject ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TargetObject (TargetObject targetObject) : base(targetObject)
    {  }
    #pragma warning restore CS8618

    public TargetObject (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TargetObject (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TargetObjectFromRaw.FromRawUnchecked"/>
    public static TargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TargetObject (string to) : this()
    { this.To = to; }
}class TargetObjectFromRaw : IFromRawJson<TargetObject>
{
    /// <inheritdoc/>
    public TargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TargetObject.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<CustomHeader, CustomHeaderFromRaw>))]
public sealed record class CustomHeader : JsonModel
{
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

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `{{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public CustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CustomHeader (CustomHeader customHeader) : base(customHeader)
    {  }
    #pragma warning restore CS8618

    public CustomHeader (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomHeaderFromRaw.FromRawUnchecked"/>
    public static CustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CustomHeaderFromRaw : IFromRawJson<CustomHeader>
{
    /// <inheritdoc/>
    public CustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomHeader.FromRawUnchecked(rawData);
}/// <summary>
/// Configuration for voicemail detection (AMD - Answering Machine Detection) on
/// the transferred call. Allows the assistant to detect when a voicemail system
/// answers the transferred call and take appropriate action.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoicemailDetection, VoicemailDetectionFromRaw>))]
public sealed record class VoicemailDetection : JsonModel
{
    /// <summary>
    /// Advanced AMD detection configuration parameters. All values are optional -
    /// Telnyx will use defaults if not specified.
    /// </summary>
    public DetectionConfig? DetectionConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DetectionConfig>(
                "detection_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detection_config", value);
        }
    }

    /// <summary>
    /// The AMD detection mode to use. 'premium' enables premium answering machine
    /// detection. 'disabled' turns off AMD detection.
    /// </summary>
    public ApiEnum<string, DetectionMode>? DetectionMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DetectionMode>>(
                "detection_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detection_mode", value);
        }
    }

    /// <summary>
    /// Action to take when voicemail is detected on the transferred call.
    /// </summary>
    public OnVoicemailDetected? OnVoicemailDetected {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OnVoicemailDetected>(
                "on_voicemail_detected"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_voicemail_detected", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DetectionConfig?.Validate();
        this.DetectionMode?.Validate();
        this.OnVoicemailDetected?.Validate();
    }

    public VoicemailDetection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailDetection (VoicemailDetection voicemailDetection) : base(
        voicemailDetection
    )
    {  }
    #pragma warning restore CS8618

    public VoicemailDetection (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailDetection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailDetectionFromRaw.FromRawUnchecked"/>
    public static VoicemailDetection FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoicemailDetectionFromRaw : IFromRawJson<VoicemailDetection>
{
    /// <inheritdoc/>
    public VoicemailDetection FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailDetection.FromRawUnchecked(rawData);
}/// <summary>
/// Advanced AMD detection configuration parameters. All values are optional - Telnyx
/// will use defaults if not specified.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DetectionConfig, DetectionConfigFromRaw>))]
public sealed record class DetectionConfig : JsonModel
{
    /// <summary>
    /// Duration of silence after greeting detection before finalizing the result.
    /// </summary>
    public long? AfterGreetingSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "after_greeting_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("after_greeting_silence_millis", value);
        }
    }

    /// <summary>
    /// Maximum silence duration between words during greeting.
    /// </summary>
    public long? BetweenWordsSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "between_words_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("between_words_silence_millis", value);
        }
    }

    /// <summary>
    /// Expected duration of greeting speech.
    /// </summary>
    public long? GreetingDurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "greeting_duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_duration_millis", value);
        }
    }

    /// <summary>
    /// Duration of silence after the greeting to wait before considering the greeting complete.
    /// </summary>
    public long? GreetingSilenceDurationMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "greeting_silence_duration_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_silence_duration_millis", value);
        }
    }

    /// <summary>
    /// Maximum time to spend analyzing the greeting.
    /// </summary>
    public long? GreetingTotalAnalysisTimeMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "greeting_total_analysis_time_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("greeting_total_analysis_time_millis", value);
        }
    }

    /// <summary>
    /// Maximum silence duration at the start of the call before speech.
    /// </summary>
    public long? InitialSilenceMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "initial_silence_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("initial_silence_millis", value);
        }
    }

    /// <summary>
    /// Maximum number of words expected in a human greeting.
    /// </summary>
    public long? MaximumNumberOfWords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "maximum_number_of_words"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maximum_number_of_words", value);
        }
    }

    /// <summary>
    /// Maximum duration of a single word.
    /// </summary>
    public long? MaximumWordLengthMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "maximum_word_length_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maximum_word_length_millis", value);
        }
    }

    /// <summary>
    /// Minimum duration for audio to be considered a word.
    /// </summary>
    public long? MinWordLengthMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "min_word_length_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("min_word_length_millis", value);
        }
    }

    /// <summary>
    /// Audio level threshold for silence detection.
    /// </summary>
    public long? SilenceThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "silence_threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("silence_threshold", value);
        }
    }

    /// <summary>
    /// Total time allowed for AMD analysis.
    /// </summary>
    public long? TotalAnalysisTimeMillis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_analysis_time_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_analysis_time_millis", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AfterGreetingSilenceMillis;
        _ = this.BetweenWordsSilenceMillis;
        _ = this.GreetingDurationMillis;
        _ = this.GreetingSilenceDurationMillis;
        _ = this.GreetingTotalAnalysisTimeMillis;
        _ = this.InitialSilenceMillis;
        _ = this.MaximumNumberOfWords;
        _ = this.MaximumWordLengthMillis;
        _ = this.MinWordLengthMillis;
        _ = this.SilenceThreshold;
        _ = this.TotalAnalysisTimeMillis;
    }

    public DetectionConfig ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetectionConfig (DetectionConfig detectionConfig) : base(
        detectionConfig
    )
    {  }
    #pragma warning restore CS8618

    public DetectionConfig (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetectionConfig (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DetectionConfigFromRaw.FromRawUnchecked"/>
    public static DetectionConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DetectionConfigFromRaw : IFromRawJson<DetectionConfig>
{
    /// <inheritdoc/>
    public DetectionConfig FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DetectionConfig.FromRawUnchecked(rawData);
}/// <summary>
/// The AMD detection mode to use. 'premium' enables premium answering machine detection.
/// 'disabled' turns off AMD detection.
/// </summary>
[JsonConverter(typeof(DetectionModeConverter))]
public enum DetectionMode
{
    Disabled, Premium
}sealed class DetectionModeConverter : JsonConverter<DetectionMode>
{
    public override DetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>DetectionMode.Disabled,
            "premium"=>DetectionMode.Premium,
            _ =>(DetectionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DetectionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DetectionMode.Disabled=>"disabled",
            DetectionMode.Premium=>"premium",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Action to take when voicemail is detected on the transferred call.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OnVoicemailDetected, OnVoicemailDetectedFromRaw>))]
public sealed record class OnVoicemailDetected : JsonModel
{
    /// <summary>
    /// The action to take when voicemail is detected. 'stop_transfer' hangs up immediately.
    /// 'leave_message_and_stop_transfer' leaves a message then hangs up.
    /// </summary>
    public ApiEnum<string, Action>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Action>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <summary>
    /// Configuration for the voicemail message to leave. Only applicable when action
    /// is 'leave_message_and_stop_transfer'.
    /// </summary>
    public VoicemailMessage? VoicemailMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VoicemailMessage>(
                "voicemail_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voicemail_message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        this.VoicemailMessage?.Validate();
    }

    public OnVoicemailDetected ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OnVoicemailDetected (OnVoicemailDetected onVoicemailDetected) : base(
        onVoicemailDetected
    )
    {  }
    #pragma warning restore CS8618

    public OnVoicemailDetected (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OnVoicemailDetected (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OnVoicemailDetectedFromRaw.FromRawUnchecked"/>
    public static OnVoicemailDetected FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OnVoicemailDetectedFromRaw : IFromRawJson<OnVoicemailDetected>
{
    /// <inheritdoc/>
    public OnVoicemailDetected FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OnVoicemailDetected.FromRawUnchecked(rawData);
}/// <summary>
/// The action to take when voicemail is detected. 'stop_transfer' hangs up immediately.
/// 'leave_message_and_stop_transfer' leaves a message then hangs up.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    StopTransfer, LeaveMessageAndStopTransfer
}sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stop_transfer"=>Action.StopTransfer,
            "leave_message_and_stop_transfer"=>Action.LeaveMessageAndStopTransfer,
            _ =>(Action)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Action value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Action.StopTransfer=>"stop_transfer",
            Action.LeaveMessageAndStopTransfer=>"leave_message_and_stop_transfer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Configuration for the voicemail message to leave. Only applicable when action
/// is 'leave_message_and_stop_transfer'.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoicemailMessage, VoicemailMessageFromRaw>))]
public sealed record class VoicemailMessage : JsonModel
{
    /// <summary>
    /// The specific message to leave as voicemail (converted to speech). Only applicable
    /// when type is 'message'.
    /// </summary>
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

    /// <summary>
    /// The type of voicemail message. Use 'message' to leave a specific TTS message,
    /// or 'warm_transfer_instructions' to play the warm transfer audio.
    /// </summary>
    public ApiEnum<string, VoicemailMessageType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, VoicemailMessageType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type?.Validate();
    }

    public VoicemailMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoicemailMessage (VoicemailMessage voicemailMessage) : base(
        voicemailMessage
    )
    {  }
    #pragma warning restore CS8618

    public VoicemailMessage (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoicemailMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoicemailMessageFromRaw.FromRawUnchecked"/>
    public static VoicemailMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoicemailMessageFromRaw : IFromRawJson<VoicemailMessage>
{
    /// <inheritdoc/>
    public VoicemailMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoicemailMessage.FromRawUnchecked(rawData);
}/// <summary>
/// The type of voicemail message. Use 'message' to leave a specific TTS message,
/// or 'warm_transfer_instructions' to play the warm transfer audio.
/// </summary>
[JsonConverter(typeof(VoicemailMessageTypeConverter))]
public enum VoicemailMessageType
{
    Message, WarmTransferInstructions
}sealed class VoicemailMessageTypeConverter : JsonConverter<VoicemailMessageType>
{
    public override VoicemailMessageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "message"=>VoicemailMessageType.Message,
            "warm_transfer_instructions"=>VoicemailMessageType.WarmTransferInstructions,
            _ =>(VoicemailMessageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        VoicemailMessageType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            VoicemailMessageType.Message=>"message",
            VoicemailMessageType.WarmTransferInstructions=>"warm_transfer_instructions",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Requires the transfer destination to accept the call before the caller is bridged.
/// When enabled, the assistant speaks privately with the destination after they
/// answer — delivering the warm transfer message and asking whether they take the
/// call — while the caller keeps hearing ringback. The assistant then finalizes the
/// transfer with the built-in `complete_transfer` tool: an accept bridges the calls,
/// a decline hangs up the destination and returns the assistant to the caller with
/// the reason the destination gave. Requires either `warm_transfer_instructions`
/// or a `message` on every target, otherwise the assistant fails to save. Only available
/// for calls started with `ai_assistant_start`; single-caller conversations only
/// (a conference or additional invited participants fall back to a regular warm transfer).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WarmTransferAcceptance, WarmTransferAcceptanceFromRaw>))]
public sealed record class WarmTransferAcceptance : JsonModel
{
    /// <summary>
    /// Whether the destination must accept the transfer before the calls are bridged.
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Controls whether the private exchange between the assistant and the transfer
    /// destination is kept out of the conversation. With `private` (default) the
    /// exchange never reaches the conversation history, AI conversations, webhooks
    /// or insights, and the transfer tool result is rewritten with the outcome only.
    /// With `shared` the exchange stays in the conversation like any other messages.
    /// </summary>
    public ApiEnum<string, EndUserTargetContextMode>? EndUserTargetContextMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EndUserTargetContextMode>>(
                "end_user_target_context_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_user_target_context_mode", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enabled;
        this.EndUserTargetContextMode?.Validate();
    }

    public WarmTransferAcceptance ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WarmTransferAcceptance (
        WarmTransferAcceptance warmTransferAcceptance
    ) : base(warmTransferAcceptance)
    {  }
    #pragma warning restore CS8618

    public WarmTransferAcceptance (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WarmTransferAcceptance (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WarmTransferAcceptanceFromRaw.FromRawUnchecked"/>
    public static WarmTransferAcceptance FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WarmTransferAcceptanceFromRaw : IFromRawJson<WarmTransferAcceptance>
{
    /// <inheritdoc/>
    public WarmTransferAcceptance FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WarmTransferAcceptance.FromRawUnchecked(rawData);
}/// <summary>
/// Controls whether the private exchange between the assistant and the transfer destination
/// is kept out of the conversation. With `private` (default) the exchange never
/// reaches the conversation history, AI conversations, webhooks or insights, and
/// the transfer tool result is rewritten with the outcome only. With `shared` the
/// exchange stays in the conversation like any other messages.
/// </summary>
[JsonConverter(typeof(EndUserTargetContextModeConverter))]
public enum EndUserTargetContextMode
{
    Private, Shared
}sealed class EndUserTargetContextModeConverter : JsonConverter<EndUserTargetContextMode>
{
    public override EndUserTargetContextMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "private"=>EndUserTargetContextMode.Private,
            "shared"=>EndUserTargetContextMode.Shared,
            _ =>(EndUserTargetContextMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EndUserTargetContextMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EndUserTargetContextMode.Private=>"private",
            EndUserTargetContextMode.Shared=>"shared",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Invite, InviteFromRaw>))]
public sealed record class Invite : JsonModel
{
    public required InviteInvite InviteValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InviteInvite>(
                "invite"
            );
        }
        init { this._rawData.Set("invite", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InviteValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("invite")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Invite ()
    { this.Type = JsonSerializer.SerializeToElement("invite"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Invite (Invite invite) : base(invite)
    {  }
    #pragma warning restore CS8618

    public Invite (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("invite");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Invite (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteFromRaw.FromRawUnchecked"/>
    public static Invite FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Invite (InviteInvite inviteValue) : this()
    { this.InviteValue = inviteValue; }
}class InviteFromRaw : IFromRawJson<Invite>
{
    /// <inheritdoc/>
    public Invite FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Invite.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<InviteInvite, InviteInviteFromRaw>))]
public sealed record class InviteInvite : JsonModel
{
    /// <summary>
    /// Number or SIP URI placing the call.
    /// </summary>
    public required string From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// Custom headers to be added to the SIP INVITE for the invite command.
    /// </summary>
    public Generic::IReadOnlyList<InviteInviteCustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<InviteInviteCustomHeader>>(
                "custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<InviteInviteCustomHeader>?>(
                "custom_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The different possible targets of the invite. The assistant will be able
    /// to choose one of the targets to invite to the call. This can also be a dynamic
    /// variable string like `{{ targets }}` where `targets` is returned by the dynamic
    /// variables webhook and resolves to an array of target objects at runtime.
    /// If omitted or null, the invite tool can still be configured and targets may
    /// be supplied dynamically at runtime.
    /// </summary>
    public InviteInviteTargets? Targets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InviteInviteTargets>(
                "targets"
            );
        }
        init { this._rawData.Set("targets", value); }
    }

    /// <summary>
    /// Configuration for voicemail detection (AMD - Answering Machine Detection)
    /// on the invited call.
    /// </summary>
    public InviteInviteVoicemailDetection? VoicemailDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InviteInviteVoicemailDetection>(
                "voicemail_detection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voicemail_detection", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        this.Targets?.Validate();
        this.VoicemailDetection?.Validate();
    }

    public InviteInvite ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteInvite (InviteInvite inviteInvite) : base(inviteInvite)
    {  }
    #pragma warning restore CS8618

    public InviteInvite (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteInvite (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteInviteFromRaw.FromRawUnchecked"/>
    public static InviteInvite FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InviteInvite (string from) : this()
    { this.From = from; }
}class InviteInviteFromRaw : IFromRawJson<InviteInvite>
{
    /// <inheritdoc/>
    public InviteInvite FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InviteInvite.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<InviteInviteCustomHeader, InviteInviteCustomHeaderFromRaw>))]
public sealed record class InviteInviteCustomHeader : JsonModel
{
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

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `{{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public InviteInviteCustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteInviteCustomHeader (
        InviteInviteCustomHeader inviteInviteCustomHeader
    ) : base(inviteInviteCustomHeader)
    {  }
    #pragma warning restore CS8618

    public InviteInviteCustomHeader (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteInviteCustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteInviteCustomHeaderFromRaw.FromRawUnchecked"/>
    public static InviteInviteCustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InviteInviteCustomHeaderFromRaw : IFromRawJson<InviteInviteCustomHeader>
{
    /// <inheritdoc/>
    public InviteInviteCustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InviteInviteCustomHeader.FromRawUnchecked(rawData);
}/// <summary>
/// The different possible targets of the invite. The assistant will be able to choose
/// one of the targets to invite to the call. This can also be a dynamic variable
/// string like `{{ targets }}` where `targets` is returned by the dynamic variables
/// webhook and resolves to an array of target objects at runtime. If omitted or null,
/// the invite tool can still be configured and targets may be supplied dynamically
/// at runtime.
/// </summary>
[JsonConverter(typeof(InviteInviteTargetsConverter))]
public record class InviteInviteTargets : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public InviteInviteTargets (
        Generic::IReadOnlyList<InviteInviteTargetsTargetObject> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public InviteInviteTargets (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public InviteInviteTargets (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>InviteInviteTargetsTargetObject</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;InviteInviteTargetsTargetObject&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<InviteInviteTargetsTargetObject>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<InviteInviteTargetsTargetObject> ;
        return value != null ;
    }

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
///     (Generic::IReadOnlyList&lt;InviteInviteTargetsTargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<InviteInviteTargetsTargetObject>> targetsList,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<InviteInviteTargetsTargetObject> value:
                targetsList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of InviteInviteTargets");

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
///     (Generic::IReadOnlyList&lt;InviteInviteTargetsTargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<InviteInviteTargetsTargetObject>, T> targetsList,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<InviteInviteTargetsTargetObject> value=>targetsList(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of InviteInviteTargets")
        } ;
    }

    public static implicit operator InviteInviteTargets (
        Generic::List<InviteInviteTargetsTargetObject> value
    )=> new((Generic::IReadOnlyList<InviteInviteTargetsTargetObject>)value) ;

    public static implicit operator InviteInviteTargets (
        string value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of InviteInviteTargets");
        }
        this.Switch((targetsList) => {foreach (var item in targetsList)
        {
            item.Validate();
        }},
        (_) => {});
    }

    public virtual bool Equals(InviteInviteTargets? other)
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
            Generic::IReadOnlyList<InviteInviteTargetsTargetObject> _=>0,
            string _=>1,
            _ =>-1
        } ;
    }
}sealed class InviteInviteTargetsConverter : JsonConverter<InviteInviteTargets?>
{
    public override InviteInviteTargets? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<InviteInviteTargetsTargetObject>>(element, options);
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
        InviteInviteTargets? value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<InviteInviteTargetsTargetObject, InviteInviteTargetsTargetObjectFromRaw>))]
public sealed record class InviteInviteTargetsTargetObject : JsonModel
{
    /// <summary>
    /// The destination number or SIP URI of the call.
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// The name of the target.
    /// </summary>
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
        _ = this.To;
        _ = this.Name;
    }

    public InviteInviteTargetsTargetObject ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteInviteTargetsTargetObject (
        InviteInviteTargetsTargetObject inviteInviteTargetsTargetObject
    ) : base(inviteInviteTargetsTargetObject)
    {  }
    #pragma warning restore CS8618

    public InviteInviteTargetsTargetObject (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteInviteTargetsTargetObject (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteInviteTargetsTargetObjectFromRaw.FromRawUnchecked"/>
    public static InviteInviteTargetsTargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InviteInviteTargetsTargetObject (string to) : this()
    { this.To = to; }
}class InviteInviteTargetsTargetObjectFromRaw : IFromRawJson<InviteInviteTargetsTargetObject>
{
    /// <inheritdoc/>
    public InviteInviteTargetsTargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InviteInviteTargetsTargetObject.FromRawUnchecked(rawData);
}/// <summary>
/// Configuration for voicemail detection (AMD - Answering Machine Detection) on
/// the invited call.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InviteInviteVoicemailDetection, InviteInviteVoicemailDetectionFromRaw>))]
public sealed record class InviteInviteVoicemailDetection : JsonModel
{
    /// <summary>
    /// The AMD detection mode to use. 'premium' enables premium answering machine
    /// detection. 'disabled' turns off AMD detection.
    /// </summary>
    public ApiEnum<string, InviteInviteVoicemailDetectionDetectionMode>? DetectionMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InviteInviteVoicemailDetectionDetectionMode>>(
                "detection_mode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detection_mode", value);
        }
    }

    /// <summary>
    /// Action to take when voicemail is detected on the invited call.
    /// </summary>
    public InviteInviteVoicemailDetectionOnVoicemailDetected? OnVoicemailDetected {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InviteInviteVoicemailDetectionOnVoicemailDetected>(
                "on_voicemail_detected"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_voicemail_detected", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.DetectionMode?.Validate();
        this.OnVoicemailDetected?.Validate();
    }

    public InviteInviteVoicemailDetection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteInviteVoicemailDetection (
        InviteInviteVoicemailDetection inviteInviteVoicemailDetection
    ) : base(inviteInviteVoicemailDetection)
    {  }
    #pragma warning restore CS8618

    public InviteInviteVoicemailDetection (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteInviteVoicemailDetection (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteInviteVoicemailDetectionFromRaw.FromRawUnchecked"/>
    public static InviteInviteVoicemailDetection FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InviteInviteVoicemailDetectionFromRaw : IFromRawJson<InviteInviteVoicemailDetection>
{
    /// <inheritdoc/>
    public InviteInviteVoicemailDetection FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InviteInviteVoicemailDetection.FromRawUnchecked(rawData);
}/// <summary>
/// The AMD detection mode to use. 'premium' enables premium answering machine detection.
/// 'disabled' turns off AMD detection.
/// </summary>
[JsonConverter(typeof(InviteInviteVoicemailDetectionDetectionModeConverter))]
public enum InviteInviteVoicemailDetectionDetectionMode
{
    Disabled, Premium
}sealed class InviteInviteVoicemailDetectionDetectionModeConverter : JsonConverter<InviteInviteVoicemailDetectionDetectionMode>
{
    public override InviteInviteVoicemailDetectionDetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>InviteInviteVoicemailDetectionDetectionMode.Disabled,
            "premium"=>InviteInviteVoicemailDetectionDetectionMode.Premium,
            _ =>(InviteInviteVoicemailDetectionDetectionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InviteInviteVoicemailDetectionDetectionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InviteInviteVoicemailDetectionDetectionMode.Disabled=>"disabled",
            InviteInviteVoicemailDetectionDetectionMode.Premium=>"premium",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Action to take when voicemail is detected on the invited call.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InviteInviteVoicemailDetectionOnVoicemailDetected, InviteInviteVoicemailDetectionOnVoicemailDetectedFromRaw>))]
public sealed record class InviteInviteVoicemailDetectionOnVoicemailDetected : JsonModel
{
    /// <summary>
    /// The action to take when voicemail is detected.
    /// </summary>
    public ApiEnum<string, InviteInviteVoicemailDetectionOnVoicemailDetectedAction>? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, InviteInviteVoicemailDetectionOnVoicemailDetectedAction>>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Action?.Validate(); }

    public InviteInviteVoicemailDetectionOnVoicemailDetected ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InviteInviteVoicemailDetectionOnVoicemailDetected (
        InviteInviteVoicemailDetectionOnVoicemailDetected inviteInviteVoicemailDetectionOnVoicemailDetected
    ) : base(inviteInviteVoicemailDetectionOnVoicemailDetected)
    {  }
    #pragma warning restore CS8618

    public InviteInviteVoicemailDetectionOnVoicemailDetected (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InviteInviteVoicemailDetectionOnVoicemailDetected (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InviteInviteVoicemailDetectionOnVoicemailDetectedFromRaw.FromRawUnchecked"/>
    public static InviteInviteVoicemailDetectionOnVoicemailDetected FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InviteInviteVoicemailDetectionOnVoicemailDetectedFromRaw : IFromRawJson<InviteInviteVoicemailDetectionOnVoicemailDetected>
{
    /// <inheritdoc/>
    public InviteInviteVoicemailDetectionOnVoicemailDetected FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InviteInviteVoicemailDetectionOnVoicemailDetected.FromRawUnchecked(rawData);
}/// <summary>
/// The action to take when voicemail is detected.
/// </summary>
[JsonConverter(typeof(InviteInviteVoicemailDetectionOnVoicemailDetectedActionConverter))]
public enum InviteInviteVoicemailDetectionOnVoicemailDetectedAction
{
    StopInvite
}sealed class InviteInviteVoicemailDetectionOnVoicemailDetectedActionConverter : JsonConverter<InviteInviteVoicemailDetectionOnVoicemailDetectedAction>
{
    public override InviteInviteVoicemailDetectionOnVoicemailDetectedAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "stop_invite"=>InviteInviteVoicemailDetectionOnVoicemailDetectedAction.StopInvite,
            _ =>(InviteInviteVoicemailDetectionOnVoicemailDetectedAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        InviteInviteVoicemailDetectionOnVoicemailDetectedAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InviteInviteVoicemailDetectionOnVoicemailDetectedAction.StopInvite=>"stop_invite",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Refer, ReferFromRaw>))]
public sealed record class Refer : JsonModel
{
    public required ReferRefer ReferValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ReferRefer>(
                "refer"
            );
        }
        init { this._rawData.Set("refer", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ReferValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("refer")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Refer ()
    { this.Type = JsonSerializer.SerializeToElement("refer"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Refer (Refer refer) : base(refer)
    {  }
    #pragma warning restore CS8618

    public Refer (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("refer");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Refer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferFromRaw.FromRawUnchecked"/>
    public static Refer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Refer (ReferRefer referValue) : this()
    { this.ReferValue = referValue; }
}class ReferFromRaw : IFromRawJson<Refer>
{
    /// <inheritdoc/>
    public Refer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Refer.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ReferRefer, ReferReferFromRaw>))]
public sealed record class ReferRefer : JsonModel
{
    /// <summary>
    /// The different possible targets of the SIP refer. The assistant will be able
    /// to choose one of the targets to refer the call to.
    /// </summary>
    public required Generic::IReadOnlyList<Target> Targets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Target>>(
                "targets"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Target>>(
                "targets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Custom headers to be added to the SIP REFER.
    /// </summary>
    public Generic::IReadOnlyList<ReferReferCustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ReferReferCustomHeader>>(
                "custom_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ReferReferCustomHeader>?>(
                "custom_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// SIP headers to be added to the SIP REFER. Currently only User-to-User and
    /// Diversion headers are supported.
    /// </summary>
    public Generic::IReadOnlyList<SipHeader>? SipHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SipHeader>>(
                "sip_headers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SipHeader>?>(
                "sip_headers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Targets)
        {
            item.Validate();
        }
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.SipHeaders ?? [])
        {
            item.Validate();
        }
    }

    public ReferRefer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferRefer (ReferRefer referRefer) : base(referRefer)
    {  }
    #pragma warning restore CS8618

    public ReferRefer (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferRefer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferReferFromRaw.FromRawUnchecked"/>
    public static ReferRefer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ReferRefer (Generic::IReadOnlyList<Target> targets) : this()
    { this.Targets = targets; }
}class ReferReferFromRaw : IFromRawJson<ReferRefer>
{
    /// <inheritdoc/>
    public ReferRefer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReferRefer.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Target, TargetFromRaw>))]
public sealed record class Target : JsonModel
{
    /// <summary>
    /// The name of the target.
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

    /// <summary>
    /// The SIP URI to which the call will be referred.
    /// </summary>
    public required string SipAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "sip_address"
            );
        }
        init { this._rawData.Set("sip_address", value); }
    }

    /// <summary>
    /// SIP Authentication password used for SIP challenges.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_auth_password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_auth_password", value);
        }
    }

    /// <summary>
    /// SIP Authentication username used for SIP challenges.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_auth_username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_auth_username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.SipAddress;
        _ = this.SipAuthPassword;
        _ = this.SipAuthUsername;
    }

    public Target ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Target (Target target) : base(target)
    {  }
    #pragma warning restore CS8618

    public Target (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Target (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TargetFromRaw.FromRawUnchecked"/>
    public static Target FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TargetFromRaw : IFromRawJson<Target>
{
    /// <inheritdoc/>
    public Target FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Target.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ReferReferCustomHeader, ReferReferCustomHeaderFromRaw>))]
public sealed record class ReferReferCustomHeader : JsonModel
{
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

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `{{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public ReferReferCustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReferReferCustomHeader (
        ReferReferCustomHeader referReferCustomHeader
    ) : base(referReferCustomHeader)
    {  }
    #pragma warning restore CS8618

    public ReferReferCustomHeader (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReferReferCustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReferReferCustomHeaderFromRaw.FromRawUnchecked"/>
    public static ReferReferCustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ReferReferCustomHeaderFromRaw : IFromRawJson<ReferReferCustomHeader>
{
    /// <inheritdoc/>
    public ReferReferCustomHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReferReferCustomHeader.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SipHeader, SipHeaderFromRaw>))]
public sealed record class SipHeader : JsonModel
{
    public ApiEnum<string, Name>? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Name>>(
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

    /// <summary>
    /// The value of the header. Note that we support mustache templating for the
    /// value. For example you can use `{{#integration_secret}}test-secret{{/integration_secret}}`
    /// to pass the value of the integration secret.
    /// </summary>
    public string? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Name?.Validate();
        _ = this.Value;
    }

    public SipHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SipHeader (SipHeader sipHeader) : base(sipHeader)
    {  }
    #pragma warning restore CS8618

    public SipHeader (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SipHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SipHeaderFromRaw.FromRawUnchecked"/>
    public static SipHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SipHeaderFromRaw : IFromRawJson<SipHeader>
{
    /// <inheritdoc/>
    public SipHeader FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SipHeader.FromRawUnchecked(rawData);
}[JsonConverter(typeof(NameConverter))]
public enum Name
{
    UserToUser, Diversion
}sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "User-to-User"=>Name.UserToUser,
            "Diversion"=>Name.Diversion,
            _ =>(Name)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Name value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Name.UserToUser=>"User-to-User",
            Name.Diversion=>"Diversion",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<SendDtmf, SendDtmfFromRaw>))]
public sealed record class SendDtmf : JsonModel
{
    public required Generic::IReadOnlyDictionary<string, JsonElement> SendDtmfValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "send_dtmf"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "send_dtmf",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SendDtmfValue;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("send_dtmf")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public SendDtmf ()
    { this.Type = JsonSerializer.SerializeToElement("send_dtmf"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendDtmf (SendDtmf sendDtmf) : base(sendDtmf)
    {  }
    #pragma warning restore CS8618

    public SendDtmf (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send_dtmf");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SendDtmf (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SendDtmfFromRaw.FromRawUnchecked"/>
    public static SendDtmf FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SendDtmfFromRaw : IFromRawJson<SendDtmf>
{
    /// <inheritdoc/>
    public SendDtmf FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SendDtmf.FromRawUnchecked(rawData);
}/// <summary>
/// The send_message tool allows the assistant to send SMS or MMS messages to the
/// end user. The 'to' and 'from' addresses are automatically determined from the
/// conversation context, and the message text is generated by the assistant unless
/// a message_template is provided for runtime variable substitution.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SendMessage, SendMessageFromRaw>))]
public sealed record class SendMessage : JsonModel
{
    public required SendMessageSendMessage SendMessageValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SendMessageSendMessage>(
                "send_message"
            );
        }
        init { this._rawData.Set("send_message", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SendMessageValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("send_message")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public SendMessage ()
    { this.Type = JsonSerializer.SerializeToElement("send_message"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendMessage (SendMessage sendMessage) : base(sendMessage)
    {  }
    #pragma warning restore CS8618

    public SendMessage (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("send_message");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SendMessageFromRaw.FromRawUnchecked"/>
    public static SendMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SendMessage (SendMessageSendMessage sendMessageValue) : this()
    { this.SendMessageValue = sendMessageValue; }
}class SendMessageFromRaw : IFromRawJson<SendMessage>
{
    /// <inheritdoc/>
    public SendMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SendMessage.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SendMessageSendMessage, SendMessageSendMessageFromRaw>))]
public sealed record class SendMessageSendMessage : JsonModel
{
    /// <summary>
    /// Optional message template with dynamic variable support using mustache syntax
    /// (e.g., {{variable_name}}). When set, the assistant will use this template
    /// for the SMS body instead of generating one. Dynamic variables like {{telnyx_end_user_target}},
    /// {{telnyx_agent_target}}, and custom webhook-provided variables will be resolved
    /// at runtime.
    /// </summary>
    public string? MessageTemplate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_template"
            );
        }
        init { this._rawData.Set("message_template", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.MessageTemplate; }

    public SendMessageSendMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendMessageSendMessage (
        SendMessageSendMessage sendMessageSendMessage
    ) : base(sendMessageSendMessage)
    {  }
    #pragma warning restore CS8618

    public SendMessageSendMessage (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SendMessageSendMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SendMessageSendMessageFromRaw.FromRawUnchecked"/>
    public static SendMessageSendMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SendMessageSendMessageFromRaw : IFromRawJson<SendMessageSendMessage>
{
    /// <inheritdoc/>
    public SendMessageSendMessage FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SendMessageSendMessage.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SkipTurn, SkipTurnFromRaw>))]
public sealed record class SkipTurn : JsonModel
{
    public required SkipTurnSkipTurn SkipTurnValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SkipTurnSkipTurn>(
                "skip_turn"
            );
        }
        init { this._rawData.Set("skip_turn", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.SkipTurnValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("skip_turn")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public SkipTurn ()
    { this.Type = JsonSerializer.SerializeToElement("skip_turn"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkipTurn (SkipTurn skipTurn) : base(skipTurn)
    {  }
    #pragma warning restore CS8618

    public SkipTurn (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("skip_turn");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SkipTurn (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SkipTurnFromRaw.FromRawUnchecked"/>
    public static SkipTurn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SkipTurn (SkipTurnSkipTurn skipTurnValue) : this()
    { this.SkipTurnValue = skipTurnValue; }
}class SkipTurnFromRaw : IFromRawJson<SkipTurn>
{
    /// <inheritdoc/>
    public SkipTurn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SkipTurn.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<SkipTurnSkipTurn, SkipTurnSkipTurnFromRaw>))]
public sealed record class SkipTurnSkipTurn : JsonModel
{
    /// <summary>
    /// The description of the function that will be passed to the assistant.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Description; }

    public SkipTurnSkipTurn ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SkipTurnSkipTurn (SkipTurnSkipTurn skipTurnSkipTurn) : base(
        skipTurnSkipTurn
    )
    {  }
    #pragma warning restore CS8618

    public SkipTurnSkipTurn (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SkipTurnSkipTurn (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SkipTurnSkipTurnFromRaw.FromRawUnchecked"/>
    public static SkipTurnSkipTurn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SkipTurnSkipTurnFromRaw : IFromRawJson<SkipTurnSkipTurn>
{
    /// <inheritdoc/>
    public SkipTurnSkipTurn FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SkipTurnSkipTurn.FromRawUnchecked(rawData);
}/// <summary>
/// (BETA) The pay tool allows the assistant to collect card payments from the caller
/// via DTMF during the conversation. Recording is automatically paused while the
/// pay tool is active and resumes when the payment flow completes. The connector_name
/// must reference a pay connector configured in the Telnyx API.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Pay, PayFromRaw>))]
public sealed record class Pay : JsonModel
{
    public required PayToolParams PayValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PayToolParams>(
                "pay"
            );
        }
        init { this._rawData.Set("pay", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PayValue.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("pay")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        _ = this.Shared;
    }

    public Pay ()
    { this.Type = JsonSerializer.SerializeToElement("pay"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Pay (Pay pay) : base(pay)
    {  }
    #pragma warning restore CS8618

    public Pay (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("pay");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Pay (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayFromRaw.FromRawUnchecked"/>
    public static Pay FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Pay (PayToolParams payValue) : this()
    { this.PayValue = payValue; }
}class PayFromRaw : IFromRawJson<Pay>
{
    /// <inheritdoc/>
    public Pay FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Pay.FromRawUnchecked(rawData);
}/// <summary>
/// The update_dynamic_variables tool lets the assistant write values into the conversation's
/// dynamic-variables context during the call. Updated variables are available to
/// later `{{variable}}` interpolation (prompts, speak nodes, message templates) and
/// to flow edge conditions. Declare each variable the assistant is allowed to set
/// under `updatable_variables`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UpdateDynamicVariables, UpdateDynamicVariablesFromRaw>))]
public sealed record class UpdateDynamicVariables : JsonModel
{
    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Configuration for an update_dynamic_variables tool.
    /// </summary>
    public required UpdateDynamicVariablesToolParams UpdateDynamicVariablesValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<UpdateDynamicVariablesToolParams>(
                "update_dynamic_variables"
            );
        }
        init { this._rawData.Set("update_dynamic_variables", value); }
    }

    /// <summary>
    /// Whether this tool comes from the shared Tools Library. Responses merge shared
    /// tools into `tools` with `shared: true`; inline tools carry `shared: false`.
    /// Read-only: set by the server, not accepted in requests. When updating an assistant,
    /// omit `shared: true` tools from the request `tools` array and manage them
    /// through `tool_ids` instead — re-sending their definitions creates an inline
    /// duplicate (rejected with error code 10015 when the type allows only one instance
    /// per assistant).
    /// </summary>
    public bool? Shared {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "shared"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("shared", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("update_dynamic_variables")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
        this.UpdateDynamicVariablesValue.Validate();
        _ = this.Shared;
    }

    public UpdateDynamicVariables ()
    {
        this.Type = JsonSerializer.SerializeToElement("update_dynamic_variables");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateDynamicVariables (
        UpdateDynamicVariables updateDynamicVariables
    ) : base(updateDynamicVariables)
    {  }
    #pragma warning restore CS8618

    public UpdateDynamicVariables (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("update_dynamic_variables");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateDynamicVariables (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateDynamicVariablesFromRaw.FromRawUnchecked"/>
    public static UpdateDynamicVariables FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public UpdateDynamicVariables (
        UpdateDynamicVariablesToolParams updateDynamicVariablesValue
    ) : this()
    { this.UpdateDynamicVariablesValue = updateDynamicVariablesValue; }
}class UpdateDynamicVariablesFromRaw : IFromRawJson<UpdateDynamicVariables>
{
    /// <inheritdoc/>
    public UpdateDynamicVariables FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateDynamicVariables.FromRawUnchecked(rawData);
}