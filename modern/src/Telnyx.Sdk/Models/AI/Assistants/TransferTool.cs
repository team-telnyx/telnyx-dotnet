using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<TransferTool, TransferToolFromRaw>))]
public sealed record class TransferTool : JsonModel
{
    public required TransferToolTransfer Transfer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TransferToolTransfer>(
                "transfer"
            );
        }
        init { this._rawData.Set("transfer", value); }
    }

    public required ApiEnum<string, TransferToolType> Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TransferToolType>>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Transfer.Validate();
        this.Type.Validate();
    }

    public TransferTool ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferTool (TransferTool transferTool) : base(transferTool)
    {  }
    #pragma warning restore CS8618

    public TransferTool (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferTool (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransferToolFromRaw.FromRawUnchecked"/>
    public static TransferTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TransferToolFromRaw : IFromRawJson<TransferTool>
{
    /// <inheritdoc/>
    public TransferTool FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TransferTool.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<TransferToolTransfer, TransferToolTransferFromRaw>))]
public sealed record class TransferToolTransfer : JsonModel
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
    public required TransferToolTransferTargets Targets {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TransferToolTransferTargets>(
                "targets"
            );
        }
        init { this._rawData.Set("targets", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        this.Targets.Validate();
    }

    public TransferToolTransfer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferToolTransfer (
        TransferToolTransfer transferToolTransfer
    ) : base(transferToolTransfer)
    {  }
    #pragma warning restore CS8618

    public TransferToolTransfer (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferToolTransfer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransferToolTransferFromRaw.FromRawUnchecked"/>
    public static TransferToolTransfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TransferToolTransferFromRaw : IFromRawJson<TransferToolTransfer>
{
    /// <inheritdoc/>
    public TransferToolTransfer FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TransferToolTransfer.FromRawUnchecked(rawData);
}/// <summary>
/// The different possible targets of the transfer. The assistant will be able to
/// choose one of the targets to transfer the call to. This can also be a dynamic
/// variable string like `{{ targets }}` where `targets` is returned by the dynamic
/// variables webhook and resolves to an array of target objects at runtime.
/// </summary>
[JsonConverter(typeof(TransferToolTransferTargetsConverter))]
public record class TransferToolTransferTargets : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public TransferToolTransferTargets (
        Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public TransferToolTransferTargets (
        string value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public TransferToolTransferTargets (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>TransferToolTransferTargetsTargetObject</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickList(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;TransferToolTransferTargetsTargetObject&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickList(
        [NotNullWhen(true)] out Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject> ;
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
///     (Generic::IReadOnlyList&lt;TransferToolTransferTargetsTargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject>> targetsList,
        System::Action<string> @string
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject> value:
                targetsList(value);
                break;
            case string value:
                @string(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of TransferToolTransferTargets");

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
///     (Generic::IReadOnlyList&lt;TransferToolTransferTargetsTargetObject&gt; value) =&gt; {...},
///     (string value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject>, T> targetsList,
        System::Func<string, T> @string
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject> value=>targetsList(value),
            string value=>@string(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of TransferToolTransferTargets")
        } ;
    }

    public static implicit operator TransferToolTransferTargets (
        Generic::List<TransferToolTransferTargetsTargetObject> value
    )=> new((Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject>)value) ;

    public static implicit operator TransferToolTransferTargets (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of TransferToolTransferTargets");
        }
        this.Switch((targetsList) => {foreach (var item in targetsList)
        {
            item.Validate();
        }},
        (_) => {});
    }

    public virtual bool Equals(TransferToolTransferTargets? other)
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
            Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject> _=>0,
            string _=>1,
            _ =>-1
        } ;
    }
}sealed class TransferToolTransferTargetsConverter : JsonConverter<TransferToolTransferTargets>
{
    public override TransferToolTransferTargets? Read(
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<TransferToolTransferTargetsTargetObject>>(element, options);
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
        TransferToolTransferTargets value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<TransferToolTransferTargetsTargetObject, TransferToolTransferTargetsTargetObjectFromRaw>))]
public sealed record class TransferToolTransferTargetsTargetObject : JsonModel
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

    public TransferToolTransferTargetsTargetObject ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TransferToolTransferTargetsTargetObject (
        TransferToolTransferTargetsTargetObject transferToolTransferTargetsTargetObject
    ) : base(transferToolTransferTargetsTargetObject)
    {  }
    #pragma warning restore CS8618

    public TransferToolTransferTargetsTargetObject (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TransferToolTransferTargetsTargetObject (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TransferToolTransferTargetsTargetObjectFromRaw.FromRawUnchecked"/>
    public static TransferToolTransferTargetsTargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TransferToolTransferTargetsTargetObject (string to) : this()
    { this.To = to; }
}class TransferToolTransferTargetsTargetObjectFromRaw : IFromRawJson<TransferToolTransferTargetsTargetObject>
{
    /// <inheritdoc/>
    public TransferToolTransferTargetsTargetObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TransferToolTransferTargetsTargetObject.FromRawUnchecked(rawData);
}[JsonConverter(typeof(TransferToolTypeConverter))]
public enum TransferToolType
{
    Transfer
}sealed class TransferToolTypeConverter : JsonConverter<TransferToolType>
{
    public override TransferToolType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "transfer"=>TransferToolType.Transfer, _ =>(TransferToolType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TransferToolType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TransferToolType.Transfer=>"transfer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}