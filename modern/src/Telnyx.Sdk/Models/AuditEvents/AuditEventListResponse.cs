using System = System;
using System.Collections.Frozen;
using Generic = System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AuditEvents;

[JsonConverter(typeof(JsonModelConverter<AuditEventListResponse, AuditEventListResponseFromRaw>))]
public sealed record class AuditEventListResponse : JsonModel
{
    /// <summary>
    /// Unique identifier for the audit log entry.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// An alternate identifier for a resource which may be considered unique enough
    /// to identify the resource but is not the primary identifier for the resource.
    /// For example, this field could be used to store the phone number value for
    /// a phone number when the primary database identifier is a separate distinct value.
    /// </summary>
    public string? AlternateResourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "alternate_resource_id"
            );
        }
        init { this._rawData.Set("alternate_resource_id", value); }
    }

    /// <summary>
    /// Indicates if the change was made by Telnyx on your behalf, the organization
    /// owner, a member of your organization, or in the case of managed accounts,
    /// the account manager.
    /// </summary>
    public ApiEnum<string, ChangeMadeBy>? ChangeMadeBy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ChangeMadeBy>>(
                "change_made_by"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("change_made_by", value);
        }
    }

    /// <summary>
    /// The type of change that occurred.
    /// </summary>
    public string? ChangeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "change_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("change_type", value);
        }
    }

    /// <summary>
    /// Details of the changes made to the resource.
    /// </summary>
    public Generic::IReadOnlyList<Change>? Changes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Change>>(
                "changes"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Change>?>(
                "changes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the change occurred.
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

    /// <summary>
    /// Unique identifier for the organization that owns the resource.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
        }
    }

    /// <summary>
    /// The type of the resource being audited.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Unique identifier for the resource that was changed.
    /// </summary>
    public string? ResourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resource_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resource_id", value);
        }
    }

    /// <summary>
    /// Unique identifier for the user who made the change.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AlternateResourceID;
        this.ChangeMadeBy?.Validate();
        _ = this.ChangeType;
        foreach (var item in this.Changes ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.OrganizationID;
        _ = this.RecordType;
        _ = this.ResourceID;
        _ = this.UserID;
    }

    public AuditEventListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuditEventListResponse (
        AuditEventListResponse auditEventListResponse
    ) : base(auditEventListResponse)
    {  }
    #pragma warning restore CS8618

    public AuditEventListResponse (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuditEventListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuditEventListResponseFromRaw.FromRawUnchecked"/>
    public static AuditEventListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuditEventListResponseFromRaw : IFromRawJson<AuditEventListResponse>
{
    /// <inheritdoc/>
    public AuditEventListResponse FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuditEventListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Indicates if the change was made by Telnyx on your behalf, the organization owner,
/// a member of your organization, or in the case of managed accounts, the account manager.
/// </summary>
[JsonConverter(typeof(ChangeMadeByConverter))]
public enum ChangeMadeBy
{
    Telnyx, AccountManager, AccountOwner, OrganizationMember
}sealed class ChangeMadeByConverter : JsonConverter<ChangeMadeBy>
{
    public override ChangeMadeBy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "telnyx"=>ChangeMadeBy.Telnyx,
            "account_manager"=>ChangeMadeBy.AccountManager,
            "account_owner"=>ChangeMadeBy.AccountOwner,
            "organization_member"=>ChangeMadeBy.OrganizationMember,
            _ =>(ChangeMadeBy)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ChangeMadeBy value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ChangeMadeBy.Telnyx=>"telnyx",
            ChangeMadeBy.AccountManager=>"account_manager",
            ChangeMadeBy.AccountOwner=>"account_owner",
            ChangeMadeBy.OrganizationMember=>"organization_member",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Details of the changes made to a resource.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Change, ChangeFromRaw>))]
public sealed record class Change : JsonModel
{
    /// <summary>
    /// The name of the field that was changed. May use the dot notation to indicate
    /// nested fields.
    /// </summary>
    public string? Field {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field", value);
        }
    }

    /// <summary>
    /// The previous value of the field. Can be any JSON type.
    /// </summary>
    public From? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// The new value of the field. Can be any JSON type.
    /// </summary>
    public To? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Field;
        this.From?.Validate();
        this.To?.Validate();
    }

    public Change ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Change (Change change) : base(change)
    {  }
    #pragma warning restore CS8618

    public Change (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Change (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChangeFromRaw.FromRawUnchecked"/>
    public static Change FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ChangeFromRaw : IFromRawJson<Change>
{
    /// <inheritdoc/>
    public Change FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Change.FromRawUnchecked(rawData);
}/// <summary>
/// The previous value of the field. Can be any JSON type.
/// </summary>
[JsonConverter(typeof(FromConverter))]
public record class From : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public From (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public From (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public From (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public From (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public From (
        Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)));
        this._element = element;
    }

    public From (JsonElement element)
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
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
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
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickChangesObject(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickChangesObject(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>Generic::Dictionary&lt;string, JsonElement&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> ;
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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> changesObject,
        System::Action<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>> jsonElements
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                changesObject(value);
                break;
            case Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of From");

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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> changesObject,
        System::Func<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>, T> jsonElements
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            double value=>@double(value),
            bool value=>@bool(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>changesObject(value),
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value=>jsonElements(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of From")
        } ;
    }

    public static implicit operator From (string value)=> new(value) ;

    public static implicit operator From (double value)=> new(value) ;

    public static implicit operator From (bool value)=> new(value) ;

    public static implicit operator From (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator From (
        Generic::List<Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of From");
        }
    }

    public virtual bool Equals(From? other)
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
            double _=>1,
            bool _=>2,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>3,
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> _=>4,
            _ =>-1
        } ;
    }
}sealed class FromConverter : JsonConverter<From?>
{
    public override From? Read(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>>(element, options);
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
        Utf8JsonWriter writer, From? value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}/// <summary>
/// The new value of the field. Can be any JSON type.
/// </summary>
[JsonConverter(typeof(ToConverter))]
public record class To : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public To (string value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (double value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (bool value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public To (
        Generic::IReadOnlyDictionary<string, JsonElement> value,
        JsonElement? element = null
    )
    {
        this.Value = FrozenDictionary.ToFrozenDictionary(value);
        this._element = element;
    }

    public To (
        Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)));
        this._element = element;
    }

    public To (JsonElement element)
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
/// type <see cref="double"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickDouble(out var value)) {
///     // `value` is of type `double`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickDouble([NotNullWhen(true)] out double? value)
    {
        value =this.Value as double? ;
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
/// type <see cref="Generic::Dictionary{Key, Value}"/> with a <c>Key</c> of <c>string</c> and a <c>Value</c> of <c>JsonElement</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickChangesObject(out var value)) {
///     // `value` is of type `Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickChangesObject(
        [NotNullWhen(true)] out Generic::IReadOnlyDictionary<string, JsonElement>? value
    )
    {
        value =this.Value as Generic::IReadOnlyDictionary<string, JsonElement> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>Generic::Dictionary&lt;string, JsonElement&gt;</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickJsonElements(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickJsonElements(
        [NotNullWhen(true)] out Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> ;
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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<string> @string,
        System::Action<double> @double,
        System::Action<bool> @bool,
        System::Action<Generic::IReadOnlyDictionary<string, JsonElement>> changesObject,
        System::Action<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>> jsonElements
    )
    {
        switch (this.Value)
        {
            case string value:
                @string(value);
                break;
            case double value:
                @double(value);
                break;
            case bool value:
                @bool(value);
                break;
            case Generic::IReadOnlyDictionary<string, JsonElement> value:
                changesObject(value);
                break;
            case Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of To");

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
///     (double value) =&gt; {...},
///     (bool value) =&gt; {...},
///     (Generic::IReadOnlyDictionary&lt;string, JsonElement&gt; value) =&gt; {...},
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<string, T> @string,
        System::Func<double, T> @double,
        System::Func<bool, T> @bool,
        System::Func<Generic::IReadOnlyDictionary<string, JsonElement>, T> changesObject,
        System::Func<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>, T> jsonElements
    )
    {
        return this.Value switch
        {
            string value=>@string(value),
            double value=>@double(value),
            bool value=>@bool(value),
            Generic::IReadOnlyDictionary<string, JsonElement> value=>changesObject(value),
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value=>jsonElements(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of To")
        } ;
    }

    public static implicit operator To (string value)=> new(value) ;

    public static implicit operator To (double value)=> new(value) ;

    public static implicit operator To (bool value)=> new(value) ;

    public static implicit operator To (
        Generic::Dictionary<string, JsonElement> value
    )=> new((Generic::IReadOnlyDictionary<string, JsonElement>)value) ;

    public static implicit operator To (
        Generic::List<Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of To");
        }
    }

    public virtual bool Equals(To? other)
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
            double _=>1,
            bool _=>2,
            Generic::IReadOnlyDictionary<string, JsonElement> _=>3,
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> _=>4,
            _ =>-1
        } ;
    }
}sealed class ToConverter : JsonConverter<To?>
{
    public override To? Read(
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
            return new(JsonSerializer.Deserialize<double>(element, options), element);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyDictionary<string, JsonElement>>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>>(element, options);
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
        Utf8JsonWriter writer, To? value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value?.Json, options); }
}