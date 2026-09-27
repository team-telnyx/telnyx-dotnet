using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Connections;

[JsonConverter(typeof(JsonModelConverter<ConnectionRetrieveCountResponse, ConnectionRetrieveCountResponseFromRaw>))]
public sealed record class ConnectionRetrieveCountResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ConnectionRetrieveCountResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionRetrieveCountResponse (
        ConnectionRetrieveCountResponse connectionRetrieveCountResponse
    ) : base(connectionRetrieveCountResponse)
    {  }
    #pragma warning restore CS8618

    public ConnectionRetrieveCountResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionRetrieveCountResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionRetrieveCountResponseFromRaw.FromRawUnchecked"/>
    public static ConnectionRetrieveCountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConnectionRetrieveCountResponse (Data data) : this()
    { this.Data = data; }
}

class ConnectionRetrieveCountResponseFromRaw : IFromRawJson<ConnectionRetrieveCountResponse>
{
    /// <inheritdoc/>
    public ConnectionRetrieveCountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionRetrieveCountResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Counts of the authenticated user's connections, grouped by connection type.
    /// Forward-only connections are excluded.
    /// </summary>
    public required Counts Counts {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Counts>(
                "counts"
            );
        }
        init { this._rawData.Set("counts", value); }
    }

    /// <summary>
    /// Connection limits that apply to the user. Contains a single global_limit when
    /// a global connection limit applies, or per-type limits (standard_limit, texml_limit
    /// and uac_limit) when the user has per-type connection count capabilities.
    /// </summary>
    public required Limits Limits {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Limits>(
                "limits"
            );
        }
        init { this._rawData.Set("limits", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Counts.Validate();
        this.Limits.Validate();
        _ = this.RecordType;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Counts of the authenticated user's connections, grouped by connection type. Forward-only
/// connections are excluded.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Counts, CountsFromRaw>))]
public sealed record class Counts : JsonModel
{
    /// <summary>
    /// Number of Call Control applications.
    /// </summary>
    public required long CallControlApplications {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "call_control_applications"
            );
        }
        init { this._rawData.Set("call_control_applications", value); }
    }

    /// <summary>
    /// Number of credential connections.
    /// </summary>
    public required long CredentialConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "credential_connections"
            );
        }
        init { this._rawData.Set("credential_connections", value); }
    }

    /// <summary>
    /// Number of external connections.
    /// </summary>
    public required long ExternalConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "external_connections"
            );
        }
        init { this._rawData.Set("external_connections", value); }
    }

    /// <summary>
    /// Number of Fax applications.
    /// </summary>
    public required long FaxConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "fax_connections"
            );
        }
        init { this._rawData.Set("fax_connections", value); }
    }

    /// <summary>
    /// Number of FQDN connections.
    /// </summary>
    public required long FqdnConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "fqdn_connections"
            );
        }
        init { this._rawData.Set("fqdn_connections", value); }
    }

    /// <summary>
    /// Number of IP connections.
    /// </summary>
    public required long IPConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "ip_connections"
            );
        }
        init { this._rawData.Set("ip_connections", value); }
    }

    /// <summary>
    /// Number of Microsoft Teams SBC (direct routing) connections.
    /// </summary>
    public required long MicrosoftTeamsSbcConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "microsoft_teams_sbc_connections"
            );
        }
        init { this._rawData.Set("microsoft_teams_sbc_connections", value); }
    }

    /// <summary>
    /// Number of mobile voice (IMS) connections.
    /// </summary>
    public required long MobileVoiceConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "mobile_voice_connections"
            );
        }
        init { this._rawData.Set("mobile_voice_connections", value); }
    }

    /// <summary>
    /// Number of Microsoft Operator Connect connections.
    /// </summary>
    public required long OperatorConnectConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "operator_connect_connections"
            );
        }
        init { this._rawData.Set("operator_connect_connections", value); }
    }

    /// <summary>
    /// Number of TeXML applications.
    /// </summary>
    public required long TexmlApplications {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "texml_applications"
            );
        }
        init { this._rawData.Set("texml_applications", value); }
    }

    /// <summary>
    /// Number of third-party provider connections.
    /// </summary>
    public required long ThirdPartyProviderConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "third_party_provider_connections"
            );
        }
        init { this._rawData.Set("third_party_provider_connections", value); }
    }

    /// <summary>
    /// Number of UAC connections.
    /// </summary>
    public required long UacConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "uac_connections"
            );
        }
        init { this._rawData.Set("uac_connections", value); }
    }

    /// <summary>
    /// Number of Zoom SBC connections.
    /// </summary>
    public required long ZoomSbcConnections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "zoom_sbc_connections"
            );
        }
        init { this._rawData.Set("zoom_sbc_connections", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallControlApplications;
        _ = this.CredentialConnections;
        _ = this.ExternalConnections;
        _ = this.FaxConnections;
        _ = this.FqdnConnections;
        _ = this.IPConnections;
        _ = this.MicrosoftTeamsSbcConnections;
        _ = this.MobileVoiceConnections;
        _ = this.OperatorConnectConnections;
        _ = this.TexmlApplications;
        _ = this.ThirdPartyProviderConnections;
        _ = this.UacConnections;
        _ = this.ZoomSbcConnections;
    }

    public Counts ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Counts (Counts counts) : base(counts)
    {  }
    #pragma warning restore CS8618

    public Counts (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Counts (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CountsFromRaw.FromRawUnchecked"/>
    public static Counts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CountsFromRaw : IFromRawJson<Counts>
{
    /// <inheritdoc/>
    public Counts FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Counts.FromRawUnchecked(rawData);
}/// <summary>
/// Connection limits that apply to the user. Contains a single global_limit when
/// a global connection limit applies, or per-type limits (standard_limit, texml_limit
/// and uac_limit) when the user has per-type connection count capabilities.
/// </summary>
[JsonConverter(typeof(LimitsConverter))]
public record class Limits : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Limits (GlobalConnectionLimit value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Limits (PerTypeConnectionLimits value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Limits (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="GlobalConnectionLimit"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickGlobalConnectionLimit(out var value)) {
///     // `value` is of type `GlobalConnectionLimit`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickGlobalConnectionLimit(
        [NotNullWhen(true)] out GlobalConnectionLimit? value
    )
    {
        value =this.Value as GlobalConnectionLimit ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="PerTypeConnectionLimits"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickPerTypeConnection(out var value)) {
///     // `value` is of type `PerTypeConnectionLimits`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickPerTypeConnection(
        [NotNullWhen(true)] out PerTypeConnectionLimits? value
    )
    {
        value =this.Value as PerTypeConnectionLimits ;
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
///     (GlobalConnectionLimit value) =&gt; {...},
///     (PerTypeConnectionLimits value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<GlobalConnectionLimit> globalConnectionLimit,
        System::Action<PerTypeConnectionLimits> perTypeConnection
    )
    {
        switch (this.Value)
        {
            case GlobalConnectionLimit value:
                globalConnectionLimit(value);
                break;
            case PerTypeConnectionLimits value:
                perTypeConnection(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Limits");

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
///     (GlobalConnectionLimit value) =&gt; {...},
///     (PerTypeConnectionLimits value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<GlobalConnectionLimit, T> globalConnectionLimit,
        System::Func<PerTypeConnectionLimits, T> perTypeConnection
    )
    {
        return this.Value switch
        {
            GlobalConnectionLimit value=>globalConnectionLimit(value),
            PerTypeConnectionLimits value=>perTypeConnection(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Limits")
        } ;
    }

    public static implicit operator Limits (
        GlobalConnectionLimit value
    )=> new(value) ;

    public static implicit operator Limits (
        PerTypeConnectionLimits value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Limits");
        }
        this.Switch((globalConnectionLimit) => globalConnectionLimit.Validate(),
        (perTypeConnection) => perTypeConnection.Validate());
    }

    public virtual bool Equals(Limits? other)
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
        { GlobalConnectionLimit _=>0, PerTypeConnectionLimits _=>1, _ =>-1 } ;
    }
}sealed class LimitsConverter : JsonConverter<Limits>
{
    public override Limits? Read(
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
            var deserialized = JsonSerializer.Deserialize<PerTypeConnectionLimits>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<GlobalConnectionLimit>(element, options);
            if (deserialized != null) {
                deserialized.Validate();
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
        Utf8JsonWriter writer, Limits value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<GlobalConnectionLimit, GlobalConnectionLimitFromRaw>))]
public sealed record class GlobalConnectionLimit : JsonModel
{
    /// <summary>
    /// Maximum total number of connections allowed, when a global limit applies.
    /// </summary>
    public required long GlobalLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "global_limit"
            );
        }
        init { this._rawData.Set("global_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.GlobalLimit; }

    public GlobalConnectionLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalConnectionLimit (
        GlobalConnectionLimit globalConnectionLimit
    ) : base(globalConnectionLimit)
    {  }
    #pragma warning restore CS8618

    public GlobalConnectionLimit (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalConnectionLimit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalConnectionLimitFromRaw.FromRawUnchecked"/>
    public static GlobalConnectionLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public GlobalConnectionLimit (long globalLimit) : this()
    { this.GlobalLimit = globalLimit; }
}class GlobalConnectionLimitFromRaw : IFromRawJson<GlobalConnectionLimit>
{
    /// <inheritdoc/>
    public GlobalConnectionLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalConnectionLimit.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<PerTypeConnectionLimits, PerTypeConnectionLimitsFromRaw>))]
public sealed record class PerTypeConnectionLimits : JsonModel
{
    /// <summary>
    /// Maximum number of standard connections allowed, when per-type limits apply.
    /// </summary>
    public required long StandardLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "standard_limit"
            );
        }
        init { this._rawData.Set("standard_limit", value); }
    }

    /// <summary>
    /// Maximum number of TeXML applications allowed, when per-type limits apply.
    /// </summary>
    public required long TexmlLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "texml_limit"
            );
        }
        init { this._rawData.Set("texml_limit", value); }
    }

    /// <summary>
    /// Maximum number of UAC connections allowed, when per-type limits apply.
    /// </summary>
    public required long UacLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "uac_limit"
            );
        }
        init { this._rawData.Set("uac_limit", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.StandardLimit;
        _ = this.TexmlLimit;
        _ = this.UacLimit;
    }

    public PerTypeConnectionLimits ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PerTypeConnectionLimits (
        PerTypeConnectionLimits perTypeConnectionLimits
    ) : base(perTypeConnectionLimits)
    {  }
    #pragma warning restore CS8618

    public PerTypeConnectionLimits (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PerTypeConnectionLimits (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PerTypeConnectionLimitsFromRaw.FromRawUnchecked"/>
    public static PerTypeConnectionLimits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PerTypeConnectionLimitsFromRaw : IFromRawJson<PerTypeConnectionLimits>
{
    /// <inheritdoc/>
    public PerTypeConnectionLimits FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PerTypeConnectionLimits.FromRawUnchecked(rawData);
}