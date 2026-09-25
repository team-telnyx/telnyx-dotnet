using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rooms.Sessions.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionsParticipantsRequest, ActionsParticipantsRequestFromRaw>))]
public sealed record class ActionsParticipantsRequest : JsonModel
{
    /// <summary>
    /// List of participant id to exclude from the action.
    /// </summary>
    public Generic::IReadOnlyList<string>? Exclude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "exclude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "exclude",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Either a list of participant id to perform the action on, or the keyword
    /// "all" to perform the action on all participant.
    /// </summary>
    public ActionsParticipantsRequestParticipants? Participants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionsParticipantsRequestParticipants>(
                "participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("participants", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Exclude;
        this.Participants?.Validate();
    }

    public ActionsParticipantsRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionsParticipantsRequest (
        ActionsParticipantsRequest actionsParticipantsRequest
    ) : base(actionsParticipantsRequest)
    {  }
    #pragma warning restore CS8618

    public ActionsParticipantsRequest (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionsParticipantsRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionsParticipantsRequestFromRaw.FromRawUnchecked"/>
    public static ActionsParticipantsRequest FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionsParticipantsRequestFromRaw : IFromRawJson<ActionsParticipantsRequest>
{
    /// <inheritdoc/>
    public ActionsParticipantsRequest FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionsParticipantsRequest.FromRawUnchecked(rawData);
}

/// <summary>
/// Either a list of participant id to perform the action on, or the keyword "all"
/// to perform the action on all participant.
/// </summary>
[JsonConverter(typeof(ActionsParticipantsRequestParticipantsConverter))]
public record class ActionsParticipantsRequestParticipants : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ActionsParticipantsRequestParticipants (
        ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionsParticipantsRequestParticipants (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ActionsParticipantsRequestParticipants (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of ActionsParticipantsRequestParticipantsAllParticipants>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAll(out var value)) {
///     // `value` is of type `ApiEnum&lt;string, ActionsParticipantsRequestParticipantsAllParticipants&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAll(
        [NotNullWhen(true)] out ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants>? value
    )
    {
        value =this.Value as ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>string</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickStrings(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;string&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickStrings(
        [NotNullWhen(true)] out Generic::IReadOnlyList<string>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<string> ;
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
///     (ApiEnum&lt;string, ActionsParticipantsRequestParticipantsAllParticipants&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants>> all,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> value:
                all(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ActionsParticipantsRequestParticipants");

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
///     (ApiEnum&lt;string, ActionsParticipantsRequestParticipantsAllParticipants&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants>, T> all,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> value=>all(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ActionsParticipantsRequestParticipants")
        } ;
    }

    public static implicit operator ActionsParticipantsRequestParticipants (
        ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> value
    )=> new(value) ;

    public static implicit operator ActionsParticipantsRequestParticipants (
        ActionsParticipantsRequestParticipantsAllParticipants value
    )=> new(value) ;

    public static implicit operator ActionsParticipantsRequestParticipants (
        Generic::List<string> value
    )=> new((Generic::IReadOnlyList<string>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of ActionsParticipantsRequestParticipants");
        }
        this.Switch((all) => all.Validate(), (_) => {});
    }

    public virtual bool Equals(ActionsParticipantsRequestParticipants? other)
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
            ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants> _=>0,
            Generic::IReadOnlyList<string> _=>1,
            _ =>-1
        } ;
    }
}sealed class ActionsParticipantsRequestParticipantsConverter : JsonConverter<ActionsParticipantsRequestParticipants>
{
    public override ActionsParticipantsRequestParticipants? Read(
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
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActionsParticipantsRequestParticipantsAllParticipants>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<string>>(element, options);
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
        ActionsParticipantsRequestParticipants value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(ActionsParticipantsRequestParticipantsAllParticipantsConverter))]
public enum ActionsParticipantsRequestParticipantsAllParticipants
{
    All
}sealed class ActionsParticipantsRequestParticipantsAllParticipantsConverter : JsonConverter<ActionsParticipantsRequestParticipantsAllParticipants>
{
    public override ActionsParticipantsRequestParticipantsAllParticipants Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all"=>ActionsParticipantsRequestParticipantsAllParticipants.All,
            _ =>(ActionsParticipantsRequestParticipantsAllParticipants)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionsParticipantsRequestParticipantsAllParticipants value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionsParticipantsRequestParticipantsAllParticipants.All=>"all",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}