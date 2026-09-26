using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rooms.Sessions.Actions;

/// <summary>
/// Unmutes the selected participants in the specified room session. Apply the action
/// to a list of participant IDs or to `all`, with optional participant IDs excluded
/// from the action.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionUnmuteParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public Generic::IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? RoomSessionID { get; init; }

    /// <summary>
    /// List of participant id to exclude from the action.
    /// </summary>
    public Generic::IReadOnlyList<string>? Exclude {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "exclude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "exclude",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Either a list of participant id to perform the action on, or the keyword
    /// "all" to perform the action on all participant.
    /// </summary>
    public ActionUnmuteParamsParticipants? Participants {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ActionUnmuteParamsParticipants>(
                "participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("participants", value);
        }
    }

    public ActionUnmuteParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionUnmuteParams (ActionUnmuteParams actionUnmuteParams) : base(
        actionUnmuteParams
    )
    {
        this.RoomSessionID = actionUnmuteParams.RoomSessionID;

        this._rawBodyData = new(actionUnmuteParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionUnmuteParams (
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionUnmuteParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string roomSessionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RoomSessionID = roomSessionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionUnmuteParams FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawQueryData,
        Generic::IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string roomSessionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            roomSessionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Generic::Dictionary<string, JsonElement>(

    )
    {
        ["RoomSessionID"] = JsonSerializer.SerializeToElement(this.RoomSessionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionUnmuteParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RoomSessionID?.Equals(other.RoomSessionID) ?? other.RoomSessionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/room_sessions/{0}/actions/unmute",
            EncodePathSegment(this.RoomSessionID))
        )
        {
            Query = this.QueryString(options, new())
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(request, options, new());
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
/// Either a list of participant id to perform the action on, or the keyword "all"
/// to perform the action on all participant.
/// </summary>
[JsonConverter(typeof(ActionUnmuteParamsParticipantsConverter))]
public record class ActionUnmuteParamsParticipants : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public ActionUnmuteParamsParticipants (
        ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> value,
        JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public ActionUnmuteParamsParticipants (
        Generic::IReadOnlyList<string> value, JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public ActionUnmuteParamsParticipants (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApiEnum{TRaw, TEnum}"/> with a <c>TRaw</c> of <c>string</c> and a <c>TEnum</c> of ActionUnmuteParamsParticipantsAllParticipants>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickAll(out var value)) {
///     // `value` is of type `ApiEnum&lt;string, ActionUnmuteParamsParticipantsAllParticipants&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickAll(
        [NotNullWhen(true)] out ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants>? value
    )
    {
        value =this.Value as ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> ;
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
///     (ApiEnum&lt;string, ActionUnmuteParamsParticipantsAllParticipants&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants>> all,
        System::Action<Generic::IReadOnlyList<string>> strings
    )
    {
        switch (this.Value)
        {
            case ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> value:
                all(value);
                break;
            case Generic::IReadOnlyList<string> value:
                strings(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of ActionUnmuteParamsParticipants");

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
///     (ApiEnum&lt;string, ActionUnmuteParamsParticipantsAllParticipants&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;string&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants>, T> all,
        System::Func<Generic::IReadOnlyList<string>, T> strings
    )
    {
        return this.Value switch
        {
            ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> value=>all(value),
            Generic::IReadOnlyList<string> value=>strings(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of ActionUnmuteParamsParticipants")
        } ;
    }

    public static implicit operator ActionUnmuteParamsParticipants (
        ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> value
    )=> new(value) ;

    public static implicit operator ActionUnmuteParamsParticipants (
        ActionUnmuteParamsParticipantsAllParticipants value
    )=> new(value) ;

    public static implicit operator ActionUnmuteParamsParticipants (
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
            throw new TelnyxInvalidDataException("Data did not match any variant of ActionUnmuteParamsParticipants");
        }
        this.Switch((all) => all.Validate(), (_) => {});
    }

    public virtual bool Equals(ActionUnmuteParamsParticipants? other)
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
            ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants> _=>0,
            Generic::IReadOnlyList<string> _=>1,
            _ =>-1
        } ;
    }
}

sealed class ActionUnmuteParamsParticipantsConverter : JsonConverter<ActionUnmuteParamsParticipants>
{
    public override ActionUnmuteParamsParticipants? Read(
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
            var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ActionUnmuteParamsParticipantsAllParticipants>>(element, options);
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
        ActionUnmuteParamsParticipants value,
        JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(ActionUnmuteParamsParticipantsAllParticipantsConverter))]
public enum ActionUnmuteParamsParticipantsAllParticipants
{
    All
}

sealed class ActionUnmuteParamsParticipantsAllParticipantsConverter : JsonConverter<ActionUnmuteParamsParticipantsAllParticipants>
{
    public override ActionUnmuteParamsParticipantsAllParticipants Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all"=>ActionUnmuteParamsParticipantsAllParticipants.All,
            _ =>(ActionUnmuteParamsParticipantsAllParticipants)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionUnmuteParamsParticipantsAllParticipants value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionUnmuteParamsParticipantsAllParticipants.All=>"all",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}