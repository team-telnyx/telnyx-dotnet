using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

/// <summary>
/// Initiate an outbound TeXML call. Telnyx will request TeXML from the XML Request
/// URL configured for the connection in the Mission Control Portal.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallCallsParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? AccountSid { get; init; }

    public required Body Body {
        get {
            return WrappedJsonSerializer.GetNotNullClass<Body>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public CallCallsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallCallsParams (CallCallsParams callCallsParams) : base(
        callCallsParams
    )
    {
        this.AccountSid = callCallsParams.AccountSid;

        this.RawBodyData = callCallsParams.RawBodyData;
    }
    #pragma warning restore CS8618

    public CallCallsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallCallsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string accountSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.AccountSid = accountSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallCallsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string accountSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            accountSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallCallsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountSid?.Equals(other.AccountSid) ?? other.AccountSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls",
            EncodePathSegment(this.AccountSid))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
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
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
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

[JsonConverter(typeof(BodyConverter))]
public record class Body : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string? Url {
        get {
            return Match<string?>(withUrl: ( x )=>x.Url,
            withTeXml: ( x )=>x.Url,
            applicationDefault: ( x )=>x.Url);
        }
    }

    public string? ApplicationSid {
        get {
            return Match<string?>(withUrl: ( x )=>x.ApplicationSid,
            withTeXml: ( x )=>x.ApplicationSid,
            applicationDefault: ( x )=>x.ApplicationSid);
        }
    }

    public bool? AsyncAmd {
        get {
            return Match<bool?>(withUrl: ( x )=>x.AsyncAmd,
            withTeXml: ( x )=>x.AsyncAmd,
            applicationDefault: ( x )=>x.AsyncAmd);
        }
    }

    public string? AsyncAmdStatusCallback {
        get {
            return Match<string?>(withUrl: ( x )=>x.AsyncAmdStatusCallback,
            withTeXml: ( x )=>x.AsyncAmdStatusCallback,
            applicationDefault: ( x )=>x.AsyncAmdStatusCallback);
        }
    }

    public string? CallerID {
        get {
            return Match<string?>(withUrl: ( x )=>x.CallerID,
            withTeXml: ( x )=>x.CallerID,
            applicationDefault: ( x )=>x.CallerID);
        }
    }

    public bool? CancelPlaybackOnDetectMessageEnd {
        get {
            return Match<bool?>(withUrl: ( x )=>x.CancelPlaybackOnDetectMessageEnd,
            withTeXml: ( x )=>x.CancelPlaybackOnDetectMessageEnd,
            applicationDefault: ( x )=>x.CancelPlaybackOnDetectMessageEnd);
        }
    }

    public bool? CancelPlaybackOnMachineDetection {
        get {
            return Match<bool?>(withUrl: ( x )=>x.CancelPlaybackOnMachineDetection,
            withTeXml: ( x )=>x.CancelPlaybackOnMachineDetection,
            applicationDefault: ( x )=>x.CancelPlaybackOnMachineDetection);
        }
    }

    public string? DeepfakeDetectionCallbackUrl {
        get {
            return Match<string?>(withUrl: ( x )=>x.DeepfakeDetectionCallbackUrl,
            withTeXml: ( x )=>x.DeepfakeDetectionCallbackUrl,
            applicationDefault: ( x )=>x.DeepfakeDetectionCallbackUrl);
        }
    }

    public string? FallbackUrl {
        get {
            return Match<string?>(withUrl: ( x )=>x.FallbackUrl,
            withTeXml: ( x )=>x.FallbackUrl,
            applicationDefault: ( x )=>x.FallbackUrl);
        }
    }

    public string? From {
        get {
            return Match<string?>(withUrl: ( x )=>x.From,
            withTeXml: ( x )=>x.From,
            applicationDefault: ( x )=>x.From);
        }
    }

    public int? MachineDetectionBeepMaxFrequency {
        get {
            return Match<int?>(withUrl: ( x )=>x.MachineDetectionBeepMaxFrequency,
            withTeXml: ( x )=>x.MachineDetectionBeepMaxFrequency,
            applicationDefault: ( x )=>x.MachineDetectionBeepMaxFrequency);
        }
    }

    public int? MachineDetectionBeepMinFrequency {
        get {
            return Match<int?>(withUrl: ( x )=>x.MachineDetectionBeepMinFrequency,
            withTeXml: ( x )=>x.MachineDetectionBeepMinFrequency,
            applicationDefault: ( x )=>x.MachineDetectionBeepMinFrequency);
        }
    }

    public int? MachineDetectionBeepMinToneDuration {
        get {
            return Match<int?>(withUrl: ( x )=>x.MachineDetectionBeepMinToneDuration,
            withTeXml: ( x )=>x.MachineDetectionBeepMinToneDuration,
            applicationDefault: ( x )=>x.MachineDetectionBeepMinToneDuration);
        }
    }

    public bool? MachineDetectionBeepSpectralConfirmation {
        get {
            return Match<bool?>(withUrl: ( x )=>x.MachineDetectionBeepSpectralConfirmation,
            withTeXml: ( x )=>x.MachineDetectionBeepSpectralConfirmation,
            applicationDefault: ( x )=>x.MachineDetectionBeepSpectralConfirmation);
        }
    }

    public double? MachineDetectionBeepSpectralMinPurity {
        get {
            return Match<double?>(withUrl: ( x )=>x.MachineDetectionBeepSpectralMinPurity,
            withTeXml: ( x )=>x.MachineDetectionBeepSpectralMinPurity,
            applicationDefault: ( x )=>x.MachineDetectionBeepSpectralMinPurity);
        }
    }

    public bool? MachineDetectionBeepSpectralRejectFaxCng {
        get {
            return Match<bool?>(withUrl: ( x )=>x.MachineDetectionBeepSpectralRejectFaxCng,
            withTeXml: ( x )=>x.MachineDetectionBeepSpectralRejectFaxCng,
            applicationDefault: ( x )=>x.MachineDetectionBeepSpectralRejectFaxCng);
        }
    }

    public int? MachineDetectionBeepSpectralWindow {
        get {
            return Match<int?>(withUrl: ( x )=>x.MachineDetectionBeepSpectralWindow,
            withTeXml: ( x )=>x.MachineDetectionBeepSpectralWindow,
            applicationDefault: ( x )=>x.MachineDetectionBeepSpectralWindow);
        }
    }

    public long? MachineDetectionPromptEndTimeout {
        get {
            return Match<long?>(withUrl: ( x )=>x.MachineDetectionPromptEndTimeout,
            withTeXml: ( x )=>x.MachineDetectionPromptEndTimeout,
            applicationDefault: ( x )=>x.MachineDetectionPromptEndTimeout);
        }
    }

    public long? MachineDetectionSilenceTimeout {
        get {
            return Match<long?>(withUrl: ( x )=>x.MachineDetectionSilenceTimeout,
            withTeXml: ( x )=>x.MachineDetectionSilenceTimeout,
            applicationDefault: ( x )=>x.MachineDetectionSilenceTimeout);
        }
    }

    public long? MachineDetectionSpeechEndThreshold {
        get {
            return Match<long?>(withUrl: ( x )=>x.MachineDetectionSpeechEndThreshold,
            withTeXml: ( x )=>x.MachineDetectionSpeechEndThreshold,
            applicationDefault: ( x )=>x.MachineDetectionSpeechEndThreshold);
        }
    }

    public long? MachineDetectionSpeechThreshold {
        get {
            return Match<long?>(withUrl: ( x )=>x.MachineDetectionSpeechThreshold,
            withTeXml: ( x )=>x.MachineDetectionSpeechThreshold,
            applicationDefault: ( x )=>x.MachineDetectionSpeechThreshold);
        }
    }

    public long? MachineDetectionTimeout {
        get {
            return Match<long?>(withUrl: ( x )=>x.MachineDetectionTimeout,
            withTeXml: ( x )=>x.MachineDetectionTimeout,
            applicationDefault: ( x )=>x.MachineDetectionTimeout);
        }
    }

    public string? PreferredCodecs {
        get {
            return Match<string?>(withUrl: ( x )=>x.PreferredCodecs,
            withTeXml: ( x )=>x.PreferredCodecs,
            applicationDefault: ( x )=>x.PreferredCodecs);
        }
    }

    public bool? Record {
        get {
            return Match<bool?>(withUrl: ( x )=>x.Record,
            withTeXml: ( x )=>x.Record,
            applicationDefault: ( x )=>x.Record);
        }
    }

    public string? RecordingStatusCallback {
        get {
            return Match<string?>(withUrl: ( x )=>x.RecordingStatusCallback,
            withTeXml: ( x )=>x.RecordingStatusCallback,
            applicationDefault: ( x )=>x.RecordingStatusCallback);
        }
    }

    public string? RecordingStatusCallbackEvent {
        get {
            return Match<string?>(withUrl: ( x )=>x.RecordingStatusCallbackEvent,
            withTeXml: ( x )=>x.RecordingStatusCallbackEvent,
            applicationDefault: ( x )=>x.RecordingStatusCallbackEvent);
        }
    }

    public long? RecordingTimeout {
        get {
            return Match<long?>(withUrl: ( x )=>x.RecordingTimeout,
            withTeXml: ( x )=>x.RecordingTimeout,
            applicationDefault: ( x )=>x.RecordingTimeout);
        }
    }

    public bool? SendRecordingUrl {
        get {
            return Match<bool?>(withUrl: ( x )=>x.SendRecordingUrl,
            withTeXml: ( x )=>x.SendRecordingUrl,
            applicationDefault: ( x )=>x.SendRecordingUrl);
        }
    }

    public string? SipAuthPassword {
        get {
            return Match<string?>(withUrl: ( x )=>x.SipAuthPassword,
            withTeXml: ( x )=>x.SipAuthPassword,
            applicationDefault: ( x )=>x.SipAuthPassword);
        }
    }

    public string? SipAuthUsername {
        get {
            return Match<string?>(withUrl: ( x )=>x.SipAuthUsername,
            withTeXml: ( x )=>x.SipAuthUsername,
            applicationDefault: ( x )=>x.SipAuthUsername);
        }
    }

    public string? StatusCallback {
        get {
            return Match<string?>(withUrl: ( x )=>x.StatusCallback,
            withTeXml: ( x )=>x.StatusCallback,
            applicationDefault: ( x )=>x.StatusCallback);
        }
    }

    public string? StatusCallbackEvent {
        get {
            return Match<string?>(withUrl: ( x )=>x.StatusCallbackEvent,
            withTeXml: ( x )=>x.StatusCallbackEvent,
            applicationDefault: ( x )=>x.StatusCallbackEvent);
        }
    }

    public string? SuperviseCallSid {
        get {
            return Match<string?>(withUrl: ( x )=>x.SuperviseCallSid,
            withTeXml: ( x )=>x.SuperviseCallSid,
            applicationDefault: ( x )=>x.SuperviseCallSid);
        }
    }

    public string? Texml {
        get {
            return Match<string?>(withUrl: ( x )=>x.Texml,
            withTeXml: ( x )=>x.Texml,
            applicationDefault: ( x )=>x.Texml);
        }
    }

    public long? TimeLimit {
        get {
            return Match<long?>(withUrl: ( x )=>x.TimeLimit,
            withTeXml: ( x )=>x.TimeLimit,
            applicationDefault: ( x )=>x.TimeLimit);
        }
    }

    public long? Timeout {
        get {
            return Match<long?>(withUrl: ( x )=>x.Timeout,
            withTeXml: ( x )=>x.Timeout,
            applicationDefault: ( x )=>x.Timeout);
        }
    }

    public string? To {
        get {
            return Match<string?>(withUrl: ( x )=>x.To,
            withTeXml: ( x )=>x.To,
            applicationDefault: ( x )=>x.To);
        }
    }

    public Body (WithUrl value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (WithTeXml value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (ApplicationDefault value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Body (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WithUrl"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWithUrl(out var value)) {
///     // `value` is of type `WithUrl`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWithUrl([NotNullWhen(true)] out WithUrl? value)
    {
        value =this.Value as WithUrl ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="WithTeXml"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickWithTeXml(out var value)) {
///     // `value` is of type `WithTeXml`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickWithTeXml([NotNullWhen(true)] out WithTeXml? value)
    {
        value =this.Value as WithTeXml ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="ApplicationDefault"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickApplicationDefault(out var value)) {
///     // `value` is of type `ApplicationDefault`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickApplicationDefault(
        [NotNullWhen(true)] out ApplicationDefault? value
    )
    {
        value =this.Value as ApplicationDefault ;
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
///     (WithUrl value) =&gt; {...},
///     (WithTeXml value) =&gt; {...},
///     (ApplicationDefault value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<WithUrl> withUrl,
        System::Action<WithTeXml> withTeXml,
        System::Action<ApplicationDefault> applicationDefault
    )
    {
        switch (this.Value)
        {
            case WithUrl value:
                withUrl(value);
                break;
            case WithTeXml value:
                withTeXml(value);
                break;
            case ApplicationDefault value:
                applicationDefault(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Body");

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
///     (WithUrl value) =&gt; {...},
///     (WithTeXml value) =&gt; {...},
///     (ApplicationDefault value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<WithUrl, T> withUrl,
        System::Func<WithTeXml, T> withTeXml,
        System::Func<ApplicationDefault, T> applicationDefault
    )
    {
        return this.Value switch
        {
            WithUrl value=>withUrl(value),
            WithTeXml value=>withTeXml(value),
            ApplicationDefault value=>applicationDefault(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Body")
        } ;
    }

    public static implicit operator Body (WithUrl value)=> new(value) ;

    public static implicit operator Body (WithTeXml value)=> new(value) ;

    public static implicit operator Body (
        ApplicationDefault value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Body");
        }
        this.Switch((withUrl) => withUrl.Validate(),
        (withTeXml) => withTeXml.Validate(),
        (applicationDefault) => applicationDefault.Validate());
    }

    public virtual bool Equals(Body? other)
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
        { WithUrl _=>0, WithTeXml _=>1, ApplicationDefault _=>2, _ =>-1 } ;
    }
}

sealed class BodyConverter : JsonConverter<Body>
{
    public override Body? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? url;
        try {
            url = element.GetProperty("Url").GetString();
        } catch {
            url = null;
        }

        switch (url)
        {
            default:
                {
                    try
                    {
                        var deserialized = JsonSerializer.Deserialize<WithUrl>(element, options);
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
                        var deserialized = JsonSerializer.Deserialize<WithTeXml>(element, options);
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
                        var deserialized = JsonSerializer.Deserialize<ApplicationDefault>(element, options);
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

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Body value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}

[JsonConverter(typeof(JsonModelConverter<WithUrl, WithUrlFromRaw>))]
public sealed record class WithUrl : JsonModel
{
    /// <summary>
    /// The URL from which Telnyx will retrieve the TeXML call instructions.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "Url"
            );
        }
        init { this._rawData.Set("Url", value); }
    }

    /// <summary>
    /// The ID of the TeXML Application.
    /// </summary>
    public string? ApplicationSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ApplicationSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ApplicationSid", value);
        }
    }

    /// <summary>
    /// Select whether to perform answering machine detection in the background.
    /// By default execution is blocked until Answering Machine Detection is completed.
    /// </summary>
    public bool? AsyncAmd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "AsyncAmd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmd", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send AMD callback events to for the call.
    /// </summary>
    public string? AsyncAmdStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "AsyncAmdStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `AsyncAmdStatusCallback`. The default value is
    /// inherited from TeXML Application setting.
    /// </summary>
    public ApiEnum<string, AsyncAmdStatusCallbackMethod>? AsyncAmdStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AsyncAmdStatusCallbackMethod>>(
                "AsyncAmdStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// To be used as the caller id name (SIP From Display Name) presented to the
    /// destination (`To` number). The string should have a maximum of 128 characters,
    /// containing only letters, numbers, spaces, and `-_~!.+` special characters.
    /// If ommited, the display name will be the same as the number in the `From` field.
    /// </summary>
    public string? CallerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "CallerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CallerId", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `greeting ended` detection. Defaults
    /// to `true`.
    /// </summary>
    public bool? CancelPlaybackOnDetectMessageEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnDetectMessageEnd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnDetectMessageEnd", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `machine` detection. Defaults to `true`.
    /// </summary>
    public bool? CancelPlaybackOnMachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnMachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnMachineDetection", value);
        }
    }

    /// <summary>
    /// Custom HTTP headers to be sent with the call. Each header should be an object
    /// with 'name' and 'value' properties.
    /// </summary>
    public IReadOnlyList<CustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CustomHeader>>(
                "CustomHeaders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CustomHeader>?>(
                "CustomHeaders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Enables Deepfake Detection on the dialed call. When enabled, audio from the
    /// remote party is analyzed to determine whether the voice is AI-generated. Results
    /// are delivered asynchronously via a callback.
    /// </summary>
    public ApiEnum<string, DeepfakeDetection>? DeepfakeDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeepfakeDetection>>(
                "DeepfakeDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetection", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
    /// </summary>
    public ApiEnum<string, DeepfakeDetectionCallbackMethod>? DeepfakeDetectionCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DeepfakeDetectionCallbackMethod>>(
                "DeepfakeDetectionCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackMethod", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send deepfake detection callback events to for
    /// the call.
    /// </summary>
    public string? DeepfakeDetectionCallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "DeepfakeDetectionCallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackUrl", value);
        }
    }

    /// <summary>
    /// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
    /// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
    /// </summary>
    public ApiEnum<string, DetectionMode>? DetectionMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DetectionMode>>(
                "DetectionMode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DetectionMode", value);
        }
    }

    /// <summary>
    /// A failover URL for which Telnyx will retrieve the TeXML call instructions
    /// if the `Url` is not responding.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "FallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("FallbackUrl", value);
        }
    }

    /// <summary>
    /// The phone number of the party that initiated the call. Phone numbers are formatted
    /// with a `+` and country code.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "From"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("From", value);
        }
    }

    /// <summary>
    /// Enables Answering Machine Detection.
    /// </summary>
    public ApiEnum<string, MachineDetection>? MachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MachineDetection>>(
                "MachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetection", value);
        }
    }

    /// <summary>
    /// Highest frequency, in Hz, that a tone can reach and still be treated as a
    /// beep. Only used when MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMaxFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMaxFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMaxFrequency", value);
        }
    }

    /// <summary>
    /// Lowest frequency, in Hz, that a tone must reach to be treated as a beep. Raising
    /// it above 480 excludes North American ringback (440 + 480 Hz), which can otherwise
    /// be reported as a beep when the `freq_only` profile is in use. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinFrequency", value);
        }
    }

    /// <summary>
    /// Shortest tone, in milliseconds, that can be treated as a beep. Raising it
    /// rejects brief tones such as call-progress blips. Only used when MachineDetection
    /// is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinToneDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinToneDuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinToneDuration", value);
        }
    }

    /// <summary>
    /// Selects which detectors must validate a beep. `both` requires the amplitude
    /// and frequency detectors to agree. `freq_only` uses the frequency detector
    /// alone, for beeps whose volume is too unsteady for the default profile. Only
    /// used when MachineDetection is enabled.
    /// </summary>
    public ApiEnum<string, MachineDetectionBeepProfile>? MachineDetectionBeepProfile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MachineDetectionBeepProfile>>(
                "MachineDetectionBeepProfile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepProfile", value);
        }
    }

    /// <summary>
    /// When enabled, a candidate beep must pass an additional spectral check before
    /// it is reported. Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralConfirmation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralConfirmation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralConfirmation", value);
        }
    }

    /// <summary>
    /// Minimum spectral purity, from 0 to 1, for a tone to be treated as a beep.
    /// Raising it rejects mixed tones such as ringback, which combines two frequencies.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public double? MachineDetectionBeepSpectralMinPurity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "MachineDetectionBeepSpectralMinPurity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralMinPurity", value);
        }
    }

    /// <summary>
    /// When enabled, the fax CNG tone is rejected rather than reported as a beep.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralRejectFaxCng {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralRejectFaxCng"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralRejectFaxCng", value);
        }
    }

    /// <summary>
    /// Length of the spectral confirmation window, in milliseconds. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepSpectralWindow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepSpectralWindow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralWindow", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a call screening prompt before ending prompt
    /// detection, in milliseconds. Used when `DetectionMode` is `PremiumCallScreening`.
    /// </summary>
    public long? MachineDetectionPromptEndTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionPromptEndTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionPromptEndTimeout", value);
        }
    }

    /// <summary>
    /// If initial silence duration is greater than this value, consider it a machine.
    /// Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSilenceTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSilenceTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSilenceTimeout", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a greeting message or voice for it be considered
    /// human. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechEndThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechEndThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechEndThreshold", value);
        }
    }

    /// <summary>
    /// Maximum threshold of a human greeting. If greeting longer than this value,
    /// considered machine. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechThreshold", value);
        }
    }

    /// <summary>
    /// Maximum timeout threshold in milliseconds for overall detection.
    /// </summary>
    public long? MachineDetectionTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionTimeout", value);
        }
    }

    /// <summary>
    /// Defines whether media should be encrypted on the call. When set to `SRTP`,
    /// the call will use Secure Real-time Transport Protocol for media encryption.
    /// When set to `DTLS`, the call will use DTLS for media encryption. Only supported
    /// for SIP destinations.
    /// </summary>
    public ApiEnum<string, MediaEncryption>? MediaEncryption {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, MediaEncryption>>(
                "MediaEncryption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MediaEncryption", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs to be offered on a call.
    /// </summary>
    public string? PreferredCodecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "PreferredCodecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("PreferredCodecs", value);
        }
    }

    /// <summary>
    /// Whether to record the entire participant's call leg. Defaults to `false`.
    /// </summary>
    public bool? Record {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "Record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Record", value);
        }
    }

    /// <summary>
    /// The number of channels in the final recording. Defaults to `mono`.
    /// </summary>
    public ApiEnum<string, RecordingChannels>? RecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingChannels>>(
                "RecordingChannels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingChannels", value);
        }
    }

    /// <summary>
    /// The URL the recording callbacks will be sent to.
    /// </summary>
    public string? RecordingStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the recording's state that should generate a call to `RecoridngStatusCallback`.
    /// Can be: `in-progress`, `completed` and `absent`. Separate multiple values
    /// with a space. Defaults to `completed`.
    /// </summary>
    public string? RecordingStatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, RecordingStatusCallbackMethod>? RecordingStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingStatusCallbackMethod>>(
                "RecordingStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// Please note that the transcription is used to detect silence and the related
    /// charge will be applied. The minimum value is 0. The default value is 0 (infinite)
    /// </summary>
    public long? RecordingTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "RecordingTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTimeout", value);
        }
    }

    /// <summary>
    /// The audio track to record for the call. The default is `both`.
    /// </summary>
    public ApiEnum<string, RecordingTrack>? RecordingTrack {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordingTrack>>(
                "RecordingTrack"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTrack", value);
        }
    }

    /// <summary>
    /// Whether to send RecordingUrl in webhooks.
    /// </summary>
    public bool? SendRecordingUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "SendRecordingUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SendRecordingUrl", value);
        }
    }

    /// <summary>
    /// The password to use for SIP authentication.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthPassword"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthPassword", value);
        }
    }

    /// <summary>
    /// The username to use for SIP authentication.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthUsername"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthUsername", value);
        }
    }

    /// <summary>
    /// Defines the SIP region to be used for the call.
    /// </summary>
    public ApiEnum<string, SipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SipRegion>>(
                "SipRegion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipRegion", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// The call events for which Telnyx should send a webhook. Multiple events can
    /// be defined when separated by a space.
    /// </summary>
    public string? StatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, WithUrlStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithUrlStatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The call control ID of the existing call to supervise. When provided, the
    /// created leg will be added to the specified call in supervising mode. Status
    /// callbacks and action callbacks will NOT be sent for the supervising leg.
    /// </summary>
    public string? SuperviseCallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SuperviseCallSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SuperviseCallSid", value);
        }
    }

    /// <summary>
    /// The supervising role for the new leg. Determines the audio behavior: barge
    /// (hear both sides), whisper (only hear supervisor), monitor (hear both sides
    /// but supervisor muted). Default: barge
    /// </summary>
    public ApiEnum<string, SupervisingRole>? SupervisingRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SupervisingRole>>(
                "SupervisingRole"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SupervisingRole", value);
        }
    }

    public string? Texml {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Texml"
            );
        }
        init { this._rawData.Set("Texml", value); }
    }

    /// <summary>
    /// The maximum duration of the call in seconds. The minimum value is 30 and
    /// the maximum value is 14400 (4 hours). Default is 14400 seconds.
    /// </summary>
    public long? TimeLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "TimeLimit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("TimeLimit", value);
        }
    }

    /// <summary>
    /// The number of seconds to wait for the called party to answer the call before
    /// the call is canceled. The minimum value is 5 and the maximum value is 120.
    /// Default is 30 seconds.
    /// </summary>
    public long? Timeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "Timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Timeout", value);
        }
    }

    /// <summary>
    /// The phone number of the called party. Phone numbers are formatted with a `+`
    /// and country code.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "To"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("To", value);
        }
    }

    /// <summary>
    /// Whether to trim any leading and trailing silence from the recording. Defaults
    /// to `trim-silence`.
    /// </summary>
    public ApiEnum<string, Trim>? Trim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Trim>>(
                "Trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Trim", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `Url`. The default value is inherited from TeXML
    /// Application setting.
    /// </summary>
    public ApiEnum<string, UrlMethod>? UrlMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, UrlMethod>>(
                "UrlMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("UrlMethod", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Url;
        _ = this.ApplicationSid;
        _ = this.AsyncAmd;
        _ = this.AsyncAmdStatusCallback;
        this.AsyncAmdStatusCallbackMethod?.Validate();
        _ = this.CallerID;
        _ = this.CancelPlaybackOnDetectMessageEnd;
        _ = this.CancelPlaybackOnMachineDetection;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        this.DeepfakeDetection?.Validate();
        this.DeepfakeDetectionCallbackMethod?.Validate();
        _ = this.DeepfakeDetectionCallbackUrl;
        this.DetectionMode?.Validate();
        _ = this.FallbackUrl;
        _ = this.From;
        this.MachineDetection?.Validate();
        _ = this.MachineDetectionBeepMaxFrequency;
        _ = this.MachineDetectionBeepMinFrequency;
        _ = this.MachineDetectionBeepMinToneDuration;
        this.MachineDetectionBeepProfile?.Validate();
        _ = this.MachineDetectionBeepSpectralConfirmation;
        _ = this.MachineDetectionBeepSpectralMinPurity;
        _ = this.MachineDetectionBeepSpectralRejectFaxCng;
        _ = this.MachineDetectionBeepSpectralWindow;
        _ = this.MachineDetectionPromptEndTimeout;
        _ = this.MachineDetectionSilenceTimeout;
        _ = this.MachineDetectionSpeechEndThreshold;
        _ = this.MachineDetectionSpeechThreshold;
        _ = this.MachineDetectionTimeout;
        this.MediaEncryption?.Validate();
        _ = this.PreferredCodecs;
        _ = this.Record;
        this.RecordingChannels?.Validate();
        _ = this.RecordingStatusCallback;
        _ = this.RecordingStatusCallbackEvent;
        this.RecordingStatusCallbackMethod?.Validate();
        _ = this.RecordingTimeout;
        this.RecordingTrack?.Validate();
        _ = this.SendRecordingUrl;
        _ = this.SipAuthPassword;
        _ = this.SipAuthUsername;
        this.SipRegion?.Validate();
        _ = this.StatusCallback;
        _ = this.StatusCallbackEvent;
        this.StatusCallbackMethod?.Validate();
        _ = this.SuperviseCallSid;
        this.SupervisingRole?.Validate();
        _ = this.Texml;
        _ = this.TimeLimit;
        _ = this.Timeout;
        _ = this.To;
        this.Trim?.Validate();
        this.UrlMethod?.Validate();
    }

    public WithUrl ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WithUrl (WithUrl withUrl) : base(withUrl)
    {  }
    #pragma warning restore CS8618

    public WithUrl (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WithUrl (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WithUrlFromRaw.FromRawUnchecked"/>
    public static WithUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WithUrl (string url) : this()
    { this.Url = url; }
}

class WithUrlFromRaw : IFromRawJson<WithUrl>
{
    /// <inheritdoc/>
    public WithUrl FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WithUrl.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `AsyncAmdStatusCallback`. The default value is inherited
/// from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(AsyncAmdStatusCallbackMethodConverter))]
public enum AsyncAmdStatusCallbackMethod
{
    Get, Post
}

sealed class AsyncAmdStatusCallbackMethodConverter : JsonConverter<AsyncAmdStatusCallbackMethod>
{
    public override AsyncAmdStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>AsyncAmdStatusCallbackMethod.Get,
            "POST"=>AsyncAmdStatusCallbackMethod.Post,
            _ =>(AsyncAmdStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AsyncAmdStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AsyncAmdStatusCallbackMethod.Get=>"GET",
            AsyncAmdStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<CustomHeader, CustomHeaderFromRaw>))]
public sealed record class CustomHeader : JsonModel
{
    /// <summary>
    /// The name of the custom header
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
    /// The value of the custom header
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
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

    public CustomHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CustomHeaderFromRaw.FromRawUnchecked"/>
    public static CustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CustomHeaderFromRaw : IFromRawJson<CustomHeader>
{
    /// <inheritdoc/>
    public CustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CustomHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// Enables Deepfake Detection on the dialed call. When enabled, audio from the remote
/// party is analyzed to determine whether the voice is AI-generated. Results are
/// delivered asynchronously via a callback.
/// </summary>
[JsonConverter(typeof(DeepfakeDetectionConverter))]
public enum DeepfakeDetection
{
    Enable
}

sealed class DeepfakeDetectionConverter : JsonConverter<DeepfakeDetection>
{
    public override DeepfakeDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "Enable"=>DeepfakeDetection.Enable, _ =>(DeepfakeDetection)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepfakeDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepfakeDetection.Enable=>"Enable",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
/// </summary>
[JsonConverter(typeof(DeepfakeDetectionCallbackMethodConverter))]
public enum DeepfakeDetectionCallbackMethod
{
    Get, Post
}

sealed class DeepfakeDetectionCallbackMethodConverter : JsonConverter<DeepfakeDetectionCallbackMethod>
{
    public override DeepfakeDetectionCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>DeepfakeDetectionCallbackMethod.Get,
            "POST"=>DeepfakeDetectionCallbackMethod.Post,
            _ =>(DeepfakeDetectionCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DeepfakeDetectionCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DeepfakeDetectionCallbackMethod.Get=>"GET",
            DeepfakeDetectionCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
/// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
/// </summary>
[JsonConverter(typeof(DetectionModeConverter))]
public enum DetectionMode
{
    Premium, Regular, PremiumCallScreening
}

sealed class DetectionModeConverter : JsonConverter<DetectionMode>
{
    public override DetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Premium"=>DetectionMode.Premium,
            "Regular"=>DetectionMode.Regular,
            "PremiumCallScreening"=>DetectionMode.PremiumCallScreening,
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
            DetectionMode.Premium=>"Premium",
            DetectionMode.Regular=>"Regular",
            DetectionMode.PremiumCallScreening=>"PremiumCallScreening",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Enables Answering Machine Detection.
/// </summary>
[JsonConverter(typeof(MachineDetectionConverter))]
public enum MachineDetection
{
    Enable, Disable, DetectMessageEnd
}

sealed class MachineDetectionConverter : JsonConverter<MachineDetection>
{
    public override MachineDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>MachineDetection.Enable,
            "Disable"=>MachineDetection.Disable,
            "DetectMessageEnd"=>MachineDetection.DetectMessageEnd,
            _ =>(MachineDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MachineDetection.Enable=>"Enable",
            MachineDetection.Disable=>"Disable",
            MachineDetection.DetectMessageEnd=>"DetectMessageEnd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Selects which detectors must validate a beep. `both` requires the amplitude and
/// frequency detectors to agree. `freq_only` uses the frequency detector alone,
/// for beeps whose volume is too unsteady for the default profile. Only used when
/// MachineDetection is enabled.
/// </summary>
[JsonConverter(typeof(MachineDetectionBeepProfileConverter))]
public enum MachineDetectionBeepProfile
{
    Both, FreqOnly
}

sealed class MachineDetectionBeepProfileConverter : JsonConverter<MachineDetectionBeepProfile>
{
    public override MachineDetectionBeepProfile Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>MachineDetectionBeepProfile.Both,
            "freq_only"=>MachineDetectionBeepProfile.FreqOnly,
            _ =>(MachineDetectionBeepProfile)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MachineDetectionBeepProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MachineDetectionBeepProfile.Both=>"both",
            MachineDetectionBeepProfile.FreqOnly=>"freq_only",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines whether media should be encrypted on the call. When set to `SRTP`, the
/// call will use Secure Real-time Transport Protocol for media encryption. When set
/// to `DTLS`, the call will use DTLS for media encryption. Only supported for SIP destinations.
/// </summary>
[JsonConverter(typeof(MediaEncryptionConverter))]
public enum MediaEncryption
{
    Disabled, Srtp, Dtls
}

sealed class MediaEncryptionConverter : JsonConverter<MediaEncryption>
{
    public override MediaEncryption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>MediaEncryption.Disabled,
            "SRTP"=>MediaEncryption.Srtp,
            "DTLS"=>MediaEncryption.Dtls,
            _ =>(MediaEncryption)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MediaEncryption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MediaEncryption.Disabled=>"disabled",
            MediaEncryption.Srtp=>"SRTP",
            MediaEncryption.Dtls=>"DTLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The number of channels in the final recording. Defaults to `mono`.
/// </summary>
[JsonConverter(typeof(RecordingChannelsConverter))]
public enum RecordingChannels
{
    Mono, Dual
}

sealed class RecordingChannelsConverter : JsonConverter<RecordingChannels>
{
    public override RecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mono"=>RecordingChannels.Mono,
            "dual"=>RecordingChannels.Dual,
            _ =>(RecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingChannels.Mono=>"mono",
            RecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(RecordingStatusCallbackMethodConverter))]
public enum RecordingStatusCallbackMethod
{
    Get, Post
}

sealed class RecordingStatusCallbackMethodConverter : JsonConverter<RecordingStatusCallbackMethod>
{
    public override RecordingStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>RecordingStatusCallbackMethod.Get,
            "POST"=>RecordingStatusCallbackMethod.Post,
            _ =>(RecordingStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingStatusCallbackMethod.Get=>"GET",
            RecordingStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to record for the call. The default is `both`.
/// </summary>
[JsonConverter(typeof(RecordingTrackConverter))]
public enum RecordingTrack
{
    Inbound, Outbound, Both
}

sealed class RecordingTrackConverter : JsonConverter<RecordingTrack>
{
    public override RecordingTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>RecordingTrack.Inbound,
            "outbound"=>RecordingTrack.Outbound,
            "both"=>RecordingTrack.Both,
            _ =>(RecordingTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RecordingTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordingTrack.Inbound=>"inbound",
            RecordingTrack.Outbound=>"outbound",
            RecordingTrack.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the SIP region to be used for the call.
/// </summary>
[JsonConverter(typeof(SipRegionConverter))]
public enum SipRegion
{
    Us, Europe, Canada, Australia, MiddleEast
}

sealed class SipRegionConverter : JsonConverter<SipRegion>
{
    public override SipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>SipRegion.Us,
            "Europe"=>SipRegion.Europe,
            "Canada"=>SipRegion.Canada,
            "Australia"=>SipRegion.Australia,
            "Middle East"=>SipRegion.MiddleEast,
            _ =>(SipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SipRegion value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SipRegion.Us=>"US",
            SipRegion.Europe=>"Europe",
            SipRegion.Canada=>"Canada",
            SipRegion.Australia=>"Australia",
            SipRegion.MiddleEast=>"Middle East",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(WithUrlStatusCallbackMethodConverter))]
public enum WithUrlStatusCallbackMethod
{
    Get, Post
}

sealed class WithUrlStatusCallbackMethodConverter : JsonConverter<WithUrlStatusCallbackMethod>
{
    public override WithUrlStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithUrlStatusCallbackMethod.Get,
            "POST"=>WithUrlStatusCallbackMethod.Post,
            _ =>(WithUrlStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithUrlStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithUrlStatusCallbackMethod.Get=>"GET",
            WithUrlStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The supervising role for the new leg. Determines the audio behavior: barge (hear
/// both sides), whisper (only hear supervisor), monitor (hear both sides but supervisor
/// muted). Default: barge
/// </summary>
[JsonConverter(typeof(SupervisingRoleConverter))]
public enum SupervisingRole
{
    Barge, Whisper, Monitor
}

sealed class SupervisingRoleConverter : JsonConverter<SupervisingRole>
{
    public override SupervisingRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>SupervisingRole.Barge,
            "whisper"=>SupervisingRole.Whisper,
            "monitor"=>SupervisingRole.Monitor,
            _ =>(SupervisingRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SupervisingRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SupervisingRole.Barge=>"barge",
            SupervisingRole.Whisper=>"whisper",
            SupervisingRole.Monitor=>"monitor",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to trim any leading and trailing silence from the recording. Defaults
/// to `trim-silence`.
/// </summary>
[JsonConverter(typeof(TrimConverter))]
public enum Trim
{
    TrimSilence, DoNotTrim
}

sealed class TrimConverter : JsonConverter<Trim>
{
    public override Trim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>Trim.TrimSilence,
            "do-not-trim"=>Trim.DoNotTrim,
            _ =>(Trim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Trim value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Trim.TrimSilence=>"trim-silence",
            Trim.DoNotTrim=>"do-not-trim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `Url`. The default value is inherited from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(UrlMethodConverter))]
public enum UrlMethod
{
    Get, Post
}

sealed class UrlMethodConverter : JsonConverter<UrlMethod>
{
    public override UrlMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "GET"=>UrlMethod.Get, "POST"=>UrlMethod.Post, _ =>(UrlMethod)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, UrlMethod value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            UrlMethod.Get=>"GET",
            UrlMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<WithTeXml, WithTeXmlFromRaw>))]
public sealed record class WithTeXml : JsonModel
{
    /// <summary>
    /// TeXML to be used as instructions for the call. If provided, the call will
    /// execute these instructions instead of fetching from the Url.
    /// </summary>
    public required string Texml {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "Texml"
            );
        }
        init { this._rawData.Set("Texml", value); }
    }

    /// <summary>
    /// The ID of the TeXML Application.
    /// </summary>
    public string? ApplicationSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ApplicationSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ApplicationSid", value);
        }
    }

    /// <summary>
    /// Select whether to perform answering machine detection in the background.
    /// By default execution is blocked until Answering Machine Detection is completed.
    /// </summary>
    public bool? AsyncAmd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "AsyncAmd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmd", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send AMD callback events to for the call.
    /// </summary>
    public string? AsyncAmdStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "AsyncAmdStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `AsyncAmdStatusCallback`. The default value is
    /// inherited from TeXML Application setting.
    /// </summary>
    public ApiEnum<string, WithTeXmlAsyncAmdStatusCallbackMethod>? AsyncAmdStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlAsyncAmdStatusCallbackMethod>>(
                "AsyncAmdStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// To be used as the caller id name (SIP From Display Name) presented to the
    /// destination (`To` number). The string should have a maximum of 128 characters,
    /// containing only letters, numbers, spaces, and `-_~!.+` special characters.
    /// If ommited, the display name will be the same as the number in the `From` field.
    /// </summary>
    public string? CallerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "CallerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CallerId", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `greeting ended` detection. Defaults
    /// to `true`.
    /// </summary>
    public bool? CancelPlaybackOnDetectMessageEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnDetectMessageEnd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnDetectMessageEnd", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `machine` detection. Defaults to `true`.
    /// </summary>
    public bool? CancelPlaybackOnMachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnMachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnMachineDetection", value);
        }
    }

    /// <summary>
    /// Custom HTTP headers to be sent with the call. Each header should be an object
    /// with 'name' and 'value' properties.
    /// </summary>
    public IReadOnlyList<WithTeXmlCustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WithTeXmlCustomHeader>>(
                "CustomHeaders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WithTeXmlCustomHeader>?>(
                "CustomHeaders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Enables Deepfake Detection on the dialed call. When enabled, audio from the
    /// remote party is analyzed to determine whether the voice is AI-generated. Results
    /// are delivered asynchronously via a callback.
    /// </summary>
    public ApiEnum<string, WithTeXmlDeepfakeDetection>? DeepfakeDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlDeepfakeDetection>>(
                "DeepfakeDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetection", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
    /// </summary>
    public ApiEnum<string, WithTeXmlDeepfakeDetectionCallbackMethod>? DeepfakeDetectionCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlDeepfakeDetectionCallbackMethod>>(
                "DeepfakeDetectionCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackMethod", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send deepfake detection callback events to for
    /// the call.
    /// </summary>
    public string? DeepfakeDetectionCallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "DeepfakeDetectionCallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackUrl", value);
        }
    }

    /// <summary>
    /// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
    /// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
    /// </summary>
    public ApiEnum<string, WithTeXmlDetectionMode>? DetectionMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlDetectionMode>>(
                "DetectionMode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DetectionMode", value);
        }
    }

    /// <summary>
    /// A failover URL for which Telnyx will retrieve the TeXML call instructions
    /// if the `Url` is not responding.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "FallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("FallbackUrl", value);
        }
    }

    /// <summary>
    /// The phone number of the party that initiated the call. Phone numbers are formatted
    /// with a `+` and country code.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "From"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("From", value);
        }
    }

    /// <summary>
    /// Enables Answering Machine Detection.
    /// </summary>
    public ApiEnum<string, WithTeXmlMachineDetection>? MachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlMachineDetection>>(
                "MachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetection", value);
        }
    }

    /// <summary>
    /// Highest frequency, in Hz, that a tone can reach and still be treated as a
    /// beep. Only used when MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMaxFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMaxFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMaxFrequency", value);
        }
    }

    /// <summary>
    /// Lowest frequency, in Hz, that a tone must reach to be treated as a beep. Raising
    /// it above 480 excludes North American ringback (440 + 480 Hz), which can otherwise
    /// be reported as a beep when the `freq_only` profile is in use. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinFrequency", value);
        }
    }

    /// <summary>
    /// Shortest tone, in milliseconds, that can be treated as a beep. Raising it
    /// rejects brief tones such as call-progress blips. Only used when MachineDetection
    /// is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinToneDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinToneDuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinToneDuration", value);
        }
    }

    /// <summary>
    /// Selects which detectors must validate a beep. `both` requires the amplitude
    /// and frequency detectors to agree. `freq_only` uses the frequency detector
    /// alone, for beeps whose volume is too unsteady for the default profile. Only
    /// used when MachineDetection is enabled.
    /// </summary>
    public ApiEnum<string, WithTeXmlMachineDetectionBeepProfile>? MachineDetectionBeepProfile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlMachineDetectionBeepProfile>>(
                "MachineDetectionBeepProfile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepProfile", value);
        }
    }

    /// <summary>
    /// When enabled, a candidate beep must pass an additional spectral check before
    /// it is reported. Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralConfirmation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralConfirmation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralConfirmation", value);
        }
    }

    /// <summary>
    /// Minimum spectral purity, from 0 to 1, for a tone to be treated as a beep.
    /// Raising it rejects mixed tones such as ringback, which combines two frequencies.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public double? MachineDetectionBeepSpectralMinPurity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "MachineDetectionBeepSpectralMinPurity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralMinPurity", value);
        }
    }

    /// <summary>
    /// When enabled, the fax CNG tone is rejected rather than reported as a beep.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralRejectFaxCng {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralRejectFaxCng"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralRejectFaxCng", value);
        }
    }

    /// <summary>
    /// Length of the spectral confirmation window, in milliseconds. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepSpectralWindow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepSpectralWindow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralWindow", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a call screening prompt before ending prompt
    /// detection, in milliseconds. Used when `DetectionMode` is `PremiumCallScreening`.
    /// </summary>
    public long? MachineDetectionPromptEndTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionPromptEndTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionPromptEndTimeout", value);
        }
    }

    /// <summary>
    /// If initial silence duration is greater than this value, consider it a machine.
    /// Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSilenceTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSilenceTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSilenceTimeout", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a greeting message or voice for it be considered
    /// human. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechEndThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechEndThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechEndThreshold", value);
        }
    }

    /// <summary>
    /// Maximum threshold of a human greeting. If greeting longer than this value,
    /// considered machine. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechThreshold", value);
        }
    }

    /// <summary>
    /// Maximum timeout threshold in milliseconds for overall detection.
    /// </summary>
    public long? MachineDetectionTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionTimeout", value);
        }
    }

    /// <summary>
    /// Defines whether media should be encrypted on the call. When set to `SRTP`,
    /// the call will use Secure Real-time Transport Protocol for media encryption.
    /// When set to `DTLS`, the call will use DTLS for media encryption. Only supported
    /// for SIP destinations.
    /// </summary>
    public ApiEnum<string, WithTeXmlMediaEncryption>? MediaEncryption {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlMediaEncryption>>(
                "MediaEncryption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MediaEncryption", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs to be offered on a call.
    /// </summary>
    public string? PreferredCodecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "PreferredCodecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("PreferredCodecs", value);
        }
    }

    /// <summary>
    /// Whether to record the entire participant's call leg. Defaults to `false`.
    /// </summary>
    public bool? Record {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "Record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Record", value);
        }
    }

    /// <summary>
    /// The number of channels in the final recording. Defaults to `mono`.
    /// </summary>
    public ApiEnum<string, WithTeXmlRecordingChannels>? RecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlRecordingChannels>>(
                "RecordingChannels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingChannels", value);
        }
    }

    /// <summary>
    /// The URL the recording callbacks will be sent to.
    /// </summary>
    public string? RecordingStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the recording's state that should generate a call to `RecoridngStatusCallback`.
    /// Can be: `in-progress`, `completed` and `absent`. Separate multiple values
    /// with a space. Defaults to `completed`.
    /// </summary>
    public string? RecordingStatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, WithTeXmlRecordingStatusCallbackMethod>? RecordingStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlRecordingStatusCallbackMethod>>(
                "RecordingStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// Please note that the transcription is used to detect silence and the related
    /// charge will be applied. The minimum value is 0. The default value is 0 (infinite)
    /// </summary>
    public long? RecordingTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "RecordingTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTimeout", value);
        }
    }

    /// <summary>
    /// The audio track to record for the call. The default is `both`.
    /// </summary>
    public ApiEnum<string, WithTeXmlRecordingTrack>? RecordingTrack {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlRecordingTrack>>(
                "RecordingTrack"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTrack", value);
        }
    }

    /// <summary>
    /// Whether to send RecordingUrl in webhooks.
    /// </summary>
    public bool? SendRecordingUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "SendRecordingUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SendRecordingUrl", value);
        }
    }

    /// <summary>
    /// The password to use for SIP authentication.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthPassword"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthPassword", value);
        }
    }

    /// <summary>
    /// The username to use for SIP authentication.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthUsername"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthUsername", value);
        }
    }

    /// <summary>
    /// Defines the SIP region to be used for the call.
    /// </summary>
    public ApiEnum<string, WithTeXmlSipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlSipRegion>>(
                "SipRegion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipRegion", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// The call events for which Telnyx should send a webhook. Multiple events can
    /// be defined when separated by a space.
    /// </summary>
    public string? StatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, WithTeXmlStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlStatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The call control ID of the existing call to supervise. When provided, the
    /// created leg will be added to the specified call in supervising mode. Status
    /// callbacks and action callbacks will NOT be sent for the supervising leg.
    /// </summary>
    public string? SuperviseCallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SuperviseCallSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SuperviseCallSid", value);
        }
    }

    /// <summary>
    /// The supervising role for the new leg. Determines the audio behavior: barge
    /// (hear both sides), whisper (only hear supervisor), monitor (hear both sides
    /// but supervisor muted). Default: barge
    /// </summary>
    public ApiEnum<string, WithTeXmlSupervisingRole>? SupervisingRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlSupervisingRole>>(
                "SupervisingRole"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SupervisingRole", value);
        }
    }

    /// <summary>
    /// The maximum duration of the call in seconds. The minimum value is 30 and
    /// the maximum value is 14400 (4 hours). Default is 14400 seconds.
    /// </summary>
    public long? TimeLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "TimeLimit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("TimeLimit", value);
        }
    }

    /// <summary>
    /// The number of seconds to wait for the called party to answer the call before
    /// the call is canceled. The minimum value is 5 and the maximum value is 120.
    /// Default is 30 seconds.
    /// </summary>
    public long? Timeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "Timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Timeout", value);
        }
    }

    /// <summary>
    /// The phone number of the called party. Phone numbers are formatted with a `+`
    /// and country code.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "To"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("To", value);
        }
    }

    /// <summary>
    /// Whether to trim any leading and trailing silence from the recording. Defaults
    /// to `trim-silence`.
    /// </summary>
    public ApiEnum<string, WithTeXmlTrim>? Trim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlTrim>>(
                "Trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Trim", value);
        }
    }

    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Url"
            );
        }
        init { this._rawData.Set("Url", value); }
    }

    /// <summary>
    /// HTTP request type used for `Url`. The default value is inherited from TeXML
    /// Application setting.
    /// </summary>
    public ApiEnum<string, WithTeXmlUrlMethod>? UrlMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WithTeXmlUrlMethod>>(
                "UrlMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("UrlMethod", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Texml;
        _ = this.ApplicationSid;
        _ = this.AsyncAmd;
        _ = this.AsyncAmdStatusCallback;
        this.AsyncAmdStatusCallbackMethod?.Validate();
        _ = this.CallerID;
        _ = this.CancelPlaybackOnDetectMessageEnd;
        _ = this.CancelPlaybackOnMachineDetection;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        this.DeepfakeDetection?.Validate();
        this.DeepfakeDetectionCallbackMethod?.Validate();
        _ = this.DeepfakeDetectionCallbackUrl;
        this.DetectionMode?.Validate();
        _ = this.FallbackUrl;
        _ = this.From;
        this.MachineDetection?.Validate();
        _ = this.MachineDetectionBeepMaxFrequency;
        _ = this.MachineDetectionBeepMinFrequency;
        _ = this.MachineDetectionBeepMinToneDuration;
        this.MachineDetectionBeepProfile?.Validate();
        _ = this.MachineDetectionBeepSpectralConfirmation;
        _ = this.MachineDetectionBeepSpectralMinPurity;
        _ = this.MachineDetectionBeepSpectralRejectFaxCng;
        _ = this.MachineDetectionBeepSpectralWindow;
        _ = this.MachineDetectionPromptEndTimeout;
        _ = this.MachineDetectionSilenceTimeout;
        _ = this.MachineDetectionSpeechEndThreshold;
        _ = this.MachineDetectionSpeechThreshold;
        _ = this.MachineDetectionTimeout;
        this.MediaEncryption?.Validate();
        _ = this.PreferredCodecs;
        _ = this.Record;
        this.RecordingChannels?.Validate();
        _ = this.RecordingStatusCallback;
        _ = this.RecordingStatusCallbackEvent;
        this.RecordingStatusCallbackMethod?.Validate();
        _ = this.RecordingTimeout;
        this.RecordingTrack?.Validate();
        _ = this.SendRecordingUrl;
        _ = this.SipAuthPassword;
        _ = this.SipAuthUsername;
        this.SipRegion?.Validate();
        _ = this.StatusCallback;
        _ = this.StatusCallbackEvent;
        this.StatusCallbackMethod?.Validate();
        _ = this.SuperviseCallSid;
        this.SupervisingRole?.Validate();
        _ = this.TimeLimit;
        _ = this.Timeout;
        _ = this.To;
        this.Trim?.Validate();
        _ = this.Url;
        this.UrlMethod?.Validate();
    }

    public WithTeXml ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WithTeXml (WithTeXml withTeXml) : base(withTeXml)
    {  }
    #pragma warning restore CS8618

    public WithTeXml (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WithTeXml (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WithTeXmlFromRaw.FromRawUnchecked"/>
    public static WithTeXml FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public WithTeXml (string texml) : this()
    { this.Texml = texml; }
}

class WithTeXmlFromRaw : IFromRawJson<WithTeXml>
{
    /// <inheritdoc/>
    public WithTeXml FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WithTeXml.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `AsyncAmdStatusCallback`. The default value is inherited
/// from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(WithTeXmlAsyncAmdStatusCallbackMethodConverter))]
public enum WithTeXmlAsyncAmdStatusCallbackMethod
{
    Get, Post
}

sealed class WithTeXmlAsyncAmdStatusCallbackMethodConverter : JsonConverter<WithTeXmlAsyncAmdStatusCallbackMethod>
{
    public override WithTeXmlAsyncAmdStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithTeXmlAsyncAmdStatusCallbackMethod.Get,
            "POST"=>WithTeXmlAsyncAmdStatusCallbackMethod.Post,
            _ =>(WithTeXmlAsyncAmdStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlAsyncAmdStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlAsyncAmdStatusCallbackMethod.Get=>"GET",
            WithTeXmlAsyncAmdStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<WithTeXmlCustomHeader, WithTeXmlCustomHeaderFromRaw>))]
public sealed record class WithTeXmlCustomHeader : JsonModel
{
    /// <summary>
    /// The name of the custom header
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
    /// The value of the custom header
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public WithTeXmlCustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WithTeXmlCustomHeader (
        WithTeXmlCustomHeader withTeXmlCustomHeader
    ) : base(withTeXmlCustomHeader)
    {  }
    #pragma warning restore CS8618

    public WithTeXmlCustomHeader (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WithTeXmlCustomHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WithTeXmlCustomHeaderFromRaw.FromRawUnchecked"/>
    public static WithTeXmlCustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WithTeXmlCustomHeaderFromRaw : IFromRawJson<WithTeXmlCustomHeader>
{
    /// <inheritdoc/>
    public WithTeXmlCustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WithTeXmlCustomHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// Enables Deepfake Detection on the dialed call. When enabled, audio from the remote
/// party is analyzed to determine whether the voice is AI-generated. Results are
/// delivered asynchronously via a callback.
/// </summary>
[JsonConverter(typeof(WithTeXmlDeepfakeDetectionConverter))]
public enum WithTeXmlDeepfakeDetection
{
    Enable
}

sealed class WithTeXmlDeepfakeDetectionConverter : JsonConverter<WithTeXmlDeepfakeDetection>
{
    public override WithTeXmlDeepfakeDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>WithTeXmlDeepfakeDetection.Enable,
            _ =>(WithTeXmlDeepfakeDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlDeepfakeDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlDeepfakeDetection.Enable=>"Enable",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
/// </summary>
[JsonConverter(typeof(WithTeXmlDeepfakeDetectionCallbackMethodConverter))]
public enum WithTeXmlDeepfakeDetectionCallbackMethod
{
    Get, Post
}

sealed class WithTeXmlDeepfakeDetectionCallbackMethodConverter : JsonConverter<WithTeXmlDeepfakeDetectionCallbackMethod>
{
    public override WithTeXmlDeepfakeDetectionCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithTeXmlDeepfakeDetectionCallbackMethod.Get,
            "POST"=>WithTeXmlDeepfakeDetectionCallbackMethod.Post,
            _ =>(WithTeXmlDeepfakeDetectionCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlDeepfakeDetectionCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlDeepfakeDetectionCallbackMethod.Get=>"GET",
            WithTeXmlDeepfakeDetectionCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
/// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
/// </summary>
[JsonConverter(typeof(WithTeXmlDetectionModeConverter))]
public enum WithTeXmlDetectionMode
{
    Premium, Regular, PremiumCallScreening
}

sealed class WithTeXmlDetectionModeConverter : JsonConverter<WithTeXmlDetectionMode>
{
    public override WithTeXmlDetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Premium"=>WithTeXmlDetectionMode.Premium,
            "Regular"=>WithTeXmlDetectionMode.Regular,
            "PremiumCallScreening"=>WithTeXmlDetectionMode.PremiumCallScreening,
            _ =>(WithTeXmlDetectionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlDetectionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlDetectionMode.Premium=>"Premium",
            WithTeXmlDetectionMode.Regular=>"Regular",
            WithTeXmlDetectionMode.PremiumCallScreening=>"PremiumCallScreening",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Enables Answering Machine Detection.
/// </summary>
[JsonConverter(typeof(WithTeXmlMachineDetectionConverter))]
public enum WithTeXmlMachineDetection
{
    Enable, Disable, DetectMessageEnd
}

sealed class WithTeXmlMachineDetectionConverter : JsonConverter<WithTeXmlMachineDetection>
{
    public override WithTeXmlMachineDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>WithTeXmlMachineDetection.Enable,
            "Disable"=>WithTeXmlMachineDetection.Disable,
            "DetectMessageEnd"=>WithTeXmlMachineDetection.DetectMessageEnd,
            _ =>(WithTeXmlMachineDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlMachineDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlMachineDetection.Enable=>"Enable",
            WithTeXmlMachineDetection.Disable=>"Disable",
            WithTeXmlMachineDetection.DetectMessageEnd=>"DetectMessageEnd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Selects which detectors must validate a beep. `both` requires the amplitude and
/// frequency detectors to agree. `freq_only` uses the frequency detector alone,
/// for beeps whose volume is too unsteady for the default profile. Only used when
/// MachineDetection is enabled.
/// </summary>
[JsonConverter(typeof(WithTeXmlMachineDetectionBeepProfileConverter))]
public enum WithTeXmlMachineDetectionBeepProfile
{
    Both, FreqOnly
}

sealed class WithTeXmlMachineDetectionBeepProfileConverter : JsonConverter<WithTeXmlMachineDetectionBeepProfile>
{
    public override WithTeXmlMachineDetectionBeepProfile Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>WithTeXmlMachineDetectionBeepProfile.Both,
            "freq_only"=>WithTeXmlMachineDetectionBeepProfile.FreqOnly,
            _ =>(WithTeXmlMachineDetectionBeepProfile)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlMachineDetectionBeepProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlMachineDetectionBeepProfile.Both=>"both",
            WithTeXmlMachineDetectionBeepProfile.FreqOnly=>"freq_only",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines whether media should be encrypted on the call. When set to `SRTP`, the
/// call will use Secure Real-time Transport Protocol for media encryption. When set
/// to `DTLS`, the call will use DTLS for media encryption. Only supported for SIP destinations.
/// </summary>
[JsonConverter(typeof(WithTeXmlMediaEncryptionConverter))]
public enum WithTeXmlMediaEncryption
{
    Disabled, Srtp, Dtls
}

sealed class WithTeXmlMediaEncryptionConverter : JsonConverter<WithTeXmlMediaEncryption>
{
    public override WithTeXmlMediaEncryption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>WithTeXmlMediaEncryption.Disabled,
            "SRTP"=>WithTeXmlMediaEncryption.Srtp,
            "DTLS"=>WithTeXmlMediaEncryption.Dtls,
            _ =>(WithTeXmlMediaEncryption)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlMediaEncryption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlMediaEncryption.Disabled=>"disabled",
            WithTeXmlMediaEncryption.Srtp=>"SRTP",
            WithTeXmlMediaEncryption.Dtls=>"DTLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The number of channels in the final recording. Defaults to `mono`.
/// </summary>
[JsonConverter(typeof(WithTeXmlRecordingChannelsConverter))]
public enum WithTeXmlRecordingChannels
{
    Mono, Dual
}

sealed class WithTeXmlRecordingChannelsConverter : JsonConverter<WithTeXmlRecordingChannels>
{
    public override WithTeXmlRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mono"=>WithTeXmlRecordingChannels.Mono,
            "dual"=>WithTeXmlRecordingChannels.Dual,
            _ =>(WithTeXmlRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlRecordingChannels.Mono=>"mono",
            WithTeXmlRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(WithTeXmlRecordingStatusCallbackMethodConverter))]
public enum WithTeXmlRecordingStatusCallbackMethod
{
    Get, Post
}

sealed class WithTeXmlRecordingStatusCallbackMethodConverter : JsonConverter<WithTeXmlRecordingStatusCallbackMethod>
{
    public override WithTeXmlRecordingStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithTeXmlRecordingStatusCallbackMethod.Get,
            "POST"=>WithTeXmlRecordingStatusCallbackMethod.Post,
            _ =>(WithTeXmlRecordingStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlRecordingStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlRecordingStatusCallbackMethod.Get=>"GET",
            WithTeXmlRecordingStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to record for the call. The default is `both`.
/// </summary>
[JsonConverter(typeof(WithTeXmlRecordingTrackConverter))]
public enum WithTeXmlRecordingTrack
{
    Inbound, Outbound, Both
}

sealed class WithTeXmlRecordingTrackConverter : JsonConverter<WithTeXmlRecordingTrack>
{
    public override WithTeXmlRecordingTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>WithTeXmlRecordingTrack.Inbound,
            "outbound"=>WithTeXmlRecordingTrack.Outbound,
            "both"=>WithTeXmlRecordingTrack.Both,
            _ =>(WithTeXmlRecordingTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlRecordingTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlRecordingTrack.Inbound=>"inbound",
            WithTeXmlRecordingTrack.Outbound=>"outbound",
            WithTeXmlRecordingTrack.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the SIP region to be used for the call.
/// </summary>
[JsonConverter(typeof(WithTeXmlSipRegionConverter))]
public enum WithTeXmlSipRegion
{
    Us, Europe, Canada, Australia, MiddleEast
}

sealed class WithTeXmlSipRegionConverter : JsonConverter<WithTeXmlSipRegion>
{
    public override WithTeXmlSipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>WithTeXmlSipRegion.Us,
            "Europe"=>WithTeXmlSipRegion.Europe,
            "Canada"=>WithTeXmlSipRegion.Canada,
            "Australia"=>WithTeXmlSipRegion.Australia,
            "Middle East"=>WithTeXmlSipRegion.MiddleEast,
            _ =>(WithTeXmlSipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlSipRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlSipRegion.Us=>"US",
            WithTeXmlSipRegion.Europe=>"Europe",
            WithTeXmlSipRegion.Canada=>"Canada",
            WithTeXmlSipRegion.Australia=>"Australia",
            WithTeXmlSipRegion.MiddleEast=>"Middle East",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(WithTeXmlStatusCallbackMethodConverter))]
public enum WithTeXmlStatusCallbackMethod
{
    Get, Post
}

sealed class WithTeXmlStatusCallbackMethodConverter : JsonConverter<WithTeXmlStatusCallbackMethod>
{
    public override WithTeXmlStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithTeXmlStatusCallbackMethod.Get,
            "POST"=>WithTeXmlStatusCallbackMethod.Post,
            _ =>(WithTeXmlStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlStatusCallbackMethod.Get=>"GET",
            WithTeXmlStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The supervising role for the new leg. Determines the audio behavior: barge (hear
/// both sides), whisper (only hear supervisor), monitor (hear both sides but supervisor
/// muted). Default: barge
/// </summary>
[JsonConverter(typeof(WithTeXmlSupervisingRoleConverter))]
public enum WithTeXmlSupervisingRole
{
    Barge, Whisper, Monitor
}

sealed class WithTeXmlSupervisingRoleConverter : JsonConverter<WithTeXmlSupervisingRole>
{
    public override WithTeXmlSupervisingRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>WithTeXmlSupervisingRole.Barge,
            "whisper"=>WithTeXmlSupervisingRole.Whisper,
            "monitor"=>WithTeXmlSupervisingRole.Monitor,
            _ =>(WithTeXmlSupervisingRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlSupervisingRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlSupervisingRole.Barge=>"barge",
            WithTeXmlSupervisingRole.Whisper=>"whisper",
            WithTeXmlSupervisingRole.Monitor=>"monitor",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to trim any leading and trailing silence from the recording. Defaults
/// to `trim-silence`.
/// </summary>
[JsonConverter(typeof(WithTeXmlTrimConverter))]
public enum WithTeXmlTrim
{
    TrimSilence, DoNotTrim
}

sealed class WithTeXmlTrimConverter : JsonConverter<WithTeXmlTrim>
{
    public override WithTeXmlTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>WithTeXmlTrim.TrimSilence,
            "do-not-trim"=>WithTeXmlTrim.DoNotTrim,
            _ =>(WithTeXmlTrim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlTrim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlTrim.TrimSilence=>"trim-silence",
            WithTeXmlTrim.DoNotTrim=>"do-not-trim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `Url`. The default value is inherited from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(WithTeXmlUrlMethodConverter))]
public enum WithTeXmlUrlMethod
{
    Get, Post
}

sealed class WithTeXmlUrlMethodConverter : JsonConverter<WithTeXmlUrlMethod>
{
    public override WithTeXmlUrlMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>WithTeXmlUrlMethod.Get,
            "POST"=>WithTeXmlUrlMethod.Post,
            _ =>(WithTeXmlUrlMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WithTeXmlUrlMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WithTeXmlUrlMethod.Get=>"GET",
            WithTeXmlUrlMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ApplicationDefault, ApplicationDefaultFromRaw>))]
public sealed record class ApplicationDefault : JsonModel
{
    /// <summary>
    /// The ID of the TeXML Application.
    /// </summary>
    public string? ApplicationSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ApplicationSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ApplicationSid", value);
        }
    }

    /// <summary>
    /// Select whether to perform answering machine detection in the background.
    /// By default execution is blocked until Answering Machine Detection is completed.
    /// </summary>
    public bool? AsyncAmd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "AsyncAmd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmd", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send AMD callback events to for the call.
    /// </summary>
    public string? AsyncAmdStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "AsyncAmdStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallback", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `AsyncAmdStatusCallback`. The default value is
    /// inherited from TeXML Application setting.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultAsyncAmdStatusCallbackMethod>? AsyncAmdStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultAsyncAmdStatusCallbackMethod>>(
                "AsyncAmdStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("AsyncAmdStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// To be used as the caller id name (SIP From Display Name) presented to the
    /// destination (`To` number). The string should have a maximum of 128 characters,
    /// containing only letters, numbers, spaces, and `-_~!.+` special characters.
    /// If ommited, the display name will be the same as the number in the `From` field.
    /// </summary>
    public string? CallerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "CallerId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CallerId", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `greeting ended` detection. Defaults
    /// to `true`.
    /// </summary>
    public bool? CancelPlaybackOnDetectMessageEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnDetectMessageEnd"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnDetectMessageEnd", value);
        }
    }

    /// <summary>
    /// Whether to cancel ongoing playback on `machine` detection. Defaults to `true`.
    /// </summary>
    public bool? CancelPlaybackOnMachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "CancelPlaybackOnMachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("CancelPlaybackOnMachineDetection", value);
        }
    }

    /// <summary>
    /// Custom HTTP headers to be sent with the call. Each header should be an object
    /// with 'name' and 'value' properties.
    /// </summary>
    public IReadOnlyList<ApplicationDefaultCustomHeader>? CustomHeaders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApplicationDefaultCustomHeader>>(
                "CustomHeaders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApplicationDefaultCustomHeader>?>(
                "CustomHeaders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Enables Deepfake Detection on the dialed call. When enabled, audio from the
    /// remote party is analyzed to determine whether the voice is AI-generated. Results
    /// are delivered asynchronously via a callback.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultDeepfakeDetection>? DeepfakeDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultDeepfakeDetection>>(
                "DeepfakeDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetection", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultDeepfakeDetectionCallbackMethod>? DeepfakeDetectionCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultDeepfakeDetectionCallbackMethod>>(
                "DeepfakeDetectionCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackMethod", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send deepfake detection callback events to for
    /// the call.
    /// </summary>
    public string? DeepfakeDetectionCallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "DeepfakeDetectionCallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DeepfakeDetectionCallbackUrl", value);
        }
    }

    /// <summary>
    /// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
    /// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
    /// </summary>
    public ApiEnum<string, ApplicationDefaultDetectionMode>? DetectionMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultDetectionMode>>(
                "DetectionMode"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("DetectionMode", value);
        }
    }

    /// <summary>
    /// A failover URL for which Telnyx will retrieve the TeXML call instructions
    /// if the `Url` is not responding.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "FallbackUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("FallbackUrl", value);
        }
    }

    /// <summary>
    /// The phone number of the party that initiated the call. Phone numbers are formatted
    /// with a `+` and country code.
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "From"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("From", value);
        }
    }

    /// <summary>
    /// Enables Answering Machine Detection.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultMachineDetection>? MachineDetection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultMachineDetection>>(
                "MachineDetection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetection", value);
        }
    }

    /// <summary>
    /// Highest frequency, in Hz, that a tone can reach and still be treated as a
    /// beep. Only used when MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMaxFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMaxFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMaxFrequency", value);
        }
    }

    /// <summary>
    /// Lowest frequency, in Hz, that a tone must reach to be treated as a beep. Raising
    /// it above 480 excludes North American ringback (440 + 480 Hz), which can otherwise
    /// be reported as a beep when the `freq_only` profile is in use. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinFrequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinFrequency", value);
        }
    }

    /// <summary>
    /// Shortest tone, in milliseconds, that can be treated as a beep. Raising it
    /// rejects brief tones such as call-progress blips. Only used when MachineDetection
    /// is enabled.
    /// </summary>
    public int? MachineDetectionBeepMinToneDuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepMinToneDuration"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepMinToneDuration", value);
        }
    }

    /// <summary>
    /// Selects which detectors must validate a beep. `both` requires the amplitude
    /// and frequency detectors to agree. `freq_only` uses the frequency detector
    /// alone, for beeps whose volume is too unsteady for the default profile. Only
    /// used when MachineDetection is enabled.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultMachineDetectionBeepProfile>? MachineDetectionBeepProfile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultMachineDetectionBeepProfile>>(
                "MachineDetectionBeepProfile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepProfile", value);
        }
    }

    /// <summary>
    /// When enabled, a candidate beep must pass an additional spectral check before
    /// it is reported. Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralConfirmation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralConfirmation"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralConfirmation", value);
        }
    }

    /// <summary>
    /// Minimum spectral purity, from 0 to 1, for a tone to be treated as a beep.
    /// Raising it rejects mixed tones such as ringback, which combines two frequencies.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public double? MachineDetectionBeepSpectralMinPurity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "MachineDetectionBeepSpectralMinPurity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralMinPurity", value);
        }
    }

    /// <summary>
    /// When enabled, the fax CNG tone is rejected rather than reported as a beep.
    /// Only used when MachineDetection is enabled.
    /// </summary>
    public bool? MachineDetectionBeepSpectralRejectFaxCng {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "MachineDetectionBeepSpectralRejectFaxCng"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralRejectFaxCng", value);
        }
    }

    /// <summary>
    /// Length of the spectral confirmation window, in milliseconds. Only used when
    /// MachineDetection is enabled.
    /// </summary>
    public int? MachineDetectionBeepSpectralWindow {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>(
                "MachineDetectionBeepSpectralWindow"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionBeepSpectralWindow", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a call screening prompt before ending prompt
    /// detection, in milliseconds. Used when `DetectionMode` is `PremiumCallScreening`.
    /// </summary>
    public long? MachineDetectionPromptEndTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionPromptEndTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionPromptEndTimeout", value);
        }
    }

    /// <summary>
    /// If initial silence duration is greater than this value, consider it a machine.
    /// Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSilenceTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSilenceTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSilenceTimeout", value);
        }
    }

    /// <summary>
    /// Silence duration threshold after a greeting message or voice for it be considered
    /// human. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechEndThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechEndThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechEndThreshold", value);
        }
    }

    /// <summary>
    /// Maximum threshold of a human greeting. If greeting longer than this value,
    /// considered machine. Ignored when `premium` detection is used.
    /// </summary>
    public long? MachineDetectionSpeechThreshold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionSpeechThreshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionSpeechThreshold", value);
        }
    }

    /// <summary>
    /// Maximum timeout threshold in milliseconds for overall detection.
    /// </summary>
    public long? MachineDetectionTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "MachineDetectionTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MachineDetectionTimeout", value);
        }
    }

    /// <summary>
    /// Defines whether media should be encrypted on the call. When set to `SRTP`,
    /// the call will use Secure Real-time Transport Protocol for media encryption.
    /// When set to `DTLS`, the call will use DTLS for media encryption. Only supported
    /// for SIP destinations.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultMediaEncryption>? MediaEncryption {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultMediaEncryption>>(
                "MediaEncryption"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("MediaEncryption", value);
        }
    }

    /// <summary>
    /// The list of comma-separated codecs to be offered on a call.
    /// </summary>
    public string? PreferredCodecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "PreferredCodecs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("PreferredCodecs", value);
        }
    }

    /// <summary>
    /// Whether to record the entire participant's call leg. Defaults to `false`.
    /// </summary>
    public bool? Record {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "Record"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Record", value);
        }
    }

    /// <summary>
    /// The number of channels in the final recording. Defaults to `mono`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultRecordingChannels>? RecordingChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultRecordingChannels>>(
                "RecordingChannels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingChannels", value);
        }
    }

    /// <summary>
    /// The URL the recording callbacks will be sent to.
    /// </summary>
    public string? RecordingStatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallback", value);
        }
    }

    /// <summary>
    /// The changes to the recording's state that should generate a call to `RecoridngStatusCallback`.
    /// Can be: `in-progress`, `completed` and `absent`. Separate multiple values
    /// with a space. Defaults to `completed`.
    /// </summary>
    public string? RecordingStatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "RecordingStatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultRecordingStatusCallbackMethod>? RecordingStatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultRecordingStatusCallbackMethod>>(
                "RecordingStatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingStatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The number of seconds that Telnyx will wait for the recording to be stopped
    /// if silence is detected. The timer only starts when the speech is detected.
    /// Please note that the transcription is used to detect silence and the related
    /// charge will be applied. The minimum value is 0. The default value is 0 (infinite)
    /// </summary>
    public long? RecordingTimeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "RecordingTimeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTimeout", value);
        }
    }

    /// <summary>
    /// The audio track to record for the call. The default is `both`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultRecordingTrack>? RecordingTrack {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultRecordingTrack>>(
                "RecordingTrack"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("RecordingTrack", value);
        }
    }

    /// <summary>
    /// Whether to send RecordingUrl in webhooks.
    /// </summary>
    public bool? SendRecordingUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "SendRecordingUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SendRecordingUrl", value);
        }
    }

    /// <summary>
    /// The password to use for SIP authentication.
    /// </summary>
    public string? SipAuthPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthPassword"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthPassword", value);
        }
    }

    /// <summary>
    /// The username to use for SIP authentication.
    /// </summary>
    public string? SipAuthUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SipAuthUsername"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipAuthUsername", value);
        }
    }

    /// <summary>
    /// Defines the SIP region to be used for the call.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultSipRegion>? SipRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultSipRegion>>(
                "SipRegion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SipRegion", value);
        }
    }

    /// <summary>
    /// URL destination for Telnyx to send status callback events to for the call.
    /// </summary>
    public string? StatusCallback {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallback"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallback", value);
        }
    }

    /// <summary>
    /// The call events for which Telnyx should send a webhook. Multiple events can
    /// be defined when separated by a space.
    /// </summary>
    public string? StatusCallbackEvent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "StatusCallbackEvent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackEvent", value);
        }
    }

    /// <summary>
    /// HTTP request type used for `StatusCallback`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultStatusCallbackMethod>? StatusCallbackMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultStatusCallbackMethod>>(
                "StatusCallbackMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("StatusCallbackMethod", value);
        }
    }

    /// <summary>
    /// The call control ID of the existing call to supervise. When provided, the
    /// created leg will be added to the specified call in supervising mode. Status
    /// callbacks and action callbacks will NOT be sent for the supervising leg.
    /// </summary>
    public string? SuperviseCallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "SuperviseCallSid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SuperviseCallSid", value);
        }
    }

    /// <summary>
    /// The supervising role for the new leg. Determines the audio behavior: barge
    /// (hear both sides), whisper (only hear supervisor), monitor (hear both sides
    /// but supervisor muted). Default: barge
    /// </summary>
    public ApiEnum<string, ApplicationDefaultSupervisingRole>? SupervisingRole {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultSupervisingRole>>(
                "SupervisingRole"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("SupervisingRole", value);
        }
    }

    public string? Texml {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Texml"
            );
        }
        init { this._rawData.Set("Texml", value); }
    }

    /// <summary>
    /// The maximum duration of the call in seconds. The minimum value is 30 and
    /// the maximum value is 14400 (4 hours). Default is 14400 seconds.
    /// </summary>
    public long? TimeLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "TimeLimit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("TimeLimit", value);
        }
    }

    /// <summary>
    /// The number of seconds to wait for the called party to answer the call before
    /// the call is canceled. The minimum value is 5 and the maximum value is 120.
    /// Default is 30 seconds.
    /// </summary>
    public long? Timeout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "Timeout"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Timeout", value);
        }
    }

    /// <summary>
    /// The phone number of the called party. Phone numbers are formatted with a `+`
    /// and country code.
    /// </summary>
    public string? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "To"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("To", value);
        }
    }

    /// <summary>
    /// Whether to trim any leading and trailing silence from the recording. Defaults
    /// to `trim-silence`.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultTrim>? Trim {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultTrim>>(
                "Trim"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("Trim", value);
        }
    }

    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "Url"
            );
        }
        init { this._rawData.Set("Url", value); }
    }

    /// <summary>
    /// HTTP request type used for `Url`. The default value is inherited from TeXML
    /// Application setting.
    /// </summary>
    public ApiEnum<string, ApplicationDefaultUrlMethod>? UrlMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ApplicationDefaultUrlMethod>>(
                "UrlMethod"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("UrlMethod", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApplicationSid;
        _ = this.AsyncAmd;
        _ = this.AsyncAmdStatusCallback;
        this.AsyncAmdStatusCallbackMethod?.Validate();
        _ = this.CallerID;
        _ = this.CancelPlaybackOnDetectMessageEnd;
        _ = this.CancelPlaybackOnMachineDetection;
        foreach (var item in this.CustomHeaders ?? [])
        {
            item.Validate();
        }
        this.DeepfakeDetection?.Validate();
        this.DeepfakeDetectionCallbackMethod?.Validate();
        _ = this.DeepfakeDetectionCallbackUrl;
        this.DetectionMode?.Validate();
        _ = this.FallbackUrl;
        _ = this.From;
        this.MachineDetection?.Validate();
        _ = this.MachineDetectionBeepMaxFrequency;
        _ = this.MachineDetectionBeepMinFrequency;
        _ = this.MachineDetectionBeepMinToneDuration;
        this.MachineDetectionBeepProfile?.Validate();
        _ = this.MachineDetectionBeepSpectralConfirmation;
        _ = this.MachineDetectionBeepSpectralMinPurity;
        _ = this.MachineDetectionBeepSpectralRejectFaxCng;
        _ = this.MachineDetectionBeepSpectralWindow;
        _ = this.MachineDetectionPromptEndTimeout;
        _ = this.MachineDetectionSilenceTimeout;
        _ = this.MachineDetectionSpeechEndThreshold;
        _ = this.MachineDetectionSpeechThreshold;
        _ = this.MachineDetectionTimeout;
        this.MediaEncryption?.Validate();
        _ = this.PreferredCodecs;
        _ = this.Record;
        this.RecordingChannels?.Validate();
        _ = this.RecordingStatusCallback;
        _ = this.RecordingStatusCallbackEvent;
        this.RecordingStatusCallbackMethod?.Validate();
        _ = this.RecordingTimeout;
        this.RecordingTrack?.Validate();
        _ = this.SendRecordingUrl;
        _ = this.SipAuthPassword;
        _ = this.SipAuthUsername;
        this.SipRegion?.Validate();
        _ = this.StatusCallback;
        _ = this.StatusCallbackEvent;
        this.StatusCallbackMethod?.Validate();
        _ = this.SuperviseCallSid;
        this.SupervisingRole?.Validate();
        _ = this.Texml;
        _ = this.TimeLimit;
        _ = this.Timeout;
        _ = this.To;
        this.Trim?.Validate();
        _ = this.Url;
        this.UrlMethod?.Validate();
    }

    public ApplicationDefault ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApplicationDefault (ApplicationDefault applicationDefault) : base(
        applicationDefault
    )
    {  }
    #pragma warning restore CS8618

    public ApplicationDefault (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ApplicationDefault (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ApplicationDefaultFromRaw.FromRawUnchecked"/>
    public static ApplicationDefault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ApplicationDefaultFromRaw : IFromRawJson<ApplicationDefault>
{
    /// <inheritdoc/>
    public ApplicationDefault FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ApplicationDefault.FromRawUnchecked(rawData);
}

/// <summary>
/// HTTP request type used for `AsyncAmdStatusCallback`. The default value is inherited
/// from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultAsyncAmdStatusCallbackMethodConverter))]
public enum ApplicationDefaultAsyncAmdStatusCallbackMethod
{
    Get, Post
}

sealed class ApplicationDefaultAsyncAmdStatusCallbackMethodConverter : JsonConverter<ApplicationDefaultAsyncAmdStatusCallbackMethod>
{
    public override ApplicationDefaultAsyncAmdStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ApplicationDefaultAsyncAmdStatusCallbackMethod.Get,
            "POST"=>ApplicationDefaultAsyncAmdStatusCallbackMethod.Post,
            _ =>(ApplicationDefaultAsyncAmdStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultAsyncAmdStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultAsyncAmdStatusCallbackMethod.Get=>"GET",
            ApplicationDefaultAsyncAmdStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<ApplicationDefaultCustomHeader, ApplicationDefaultCustomHeaderFromRaw>))]
public sealed record class ApplicationDefaultCustomHeader : JsonModel
{
    /// <summary>
    /// The name of the custom header
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
    /// The value of the custom header
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Value;
    }

    public ApplicationDefaultCustomHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApplicationDefaultCustomHeader (
        ApplicationDefaultCustomHeader applicationDefaultCustomHeader
    ) : base(applicationDefaultCustomHeader)
    {  }
    #pragma warning restore CS8618

    public ApplicationDefaultCustomHeader (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ApplicationDefaultCustomHeader (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ApplicationDefaultCustomHeaderFromRaw.FromRawUnchecked"/>
    public static ApplicationDefaultCustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ApplicationDefaultCustomHeaderFromRaw : IFromRawJson<ApplicationDefaultCustomHeader>
{
    /// <inheritdoc/>
    public ApplicationDefaultCustomHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ApplicationDefaultCustomHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// Enables Deepfake Detection on the dialed call. When enabled, audio from the remote
/// party is analyzed to determine whether the voice is AI-generated. Results are
/// delivered asynchronously via a callback.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultDeepfakeDetectionConverter))]
public enum ApplicationDefaultDeepfakeDetection
{
    Enable
}

sealed class ApplicationDefaultDeepfakeDetectionConverter : JsonConverter<ApplicationDefaultDeepfakeDetection>
{
    public override ApplicationDefaultDeepfakeDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>ApplicationDefaultDeepfakeDetection.Enable,
            _ =>(ApplicationDefaultDeepfakeDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultDeepfakeDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultDeepfakeDetection.Enable=>"Enable",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `DeepfakeDetectionCallbackUrl`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultDeepfakeDetectionCallbackMethodConverter))]
public enum ApplicationDefaultDeepfakeDetectionCallbackMethod
{
    Get, Post
}

sealed class ApplicationDefaultDeepfakeDetectionCallbackMethodConverter : JsonConverter<ApplicationDefaultDeepfakeDetectionCallbackMethod>
{
    public override ApplicationDefaultDeepfakeDetectionCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ApplicationDefaultDeepfakeDetectionCallbackMethod.Get,
            "POST"=>ApplicationDefaultDeepfakeDetectionCallbackMethod.Post,
            _ =>(ApplicationDefaultDeepfakeDetectionCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultDeepfakeDetectionCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultDeepfakeDetectionCallbackMethod.Get=>"GET",
            ApplicationDefaultDeepfakeDetectionCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Allows you to choose between Regular, Premium, and PremiumCallScreening detections.
/// See https://developers.telnyx.com/docs/voice/programmable-voice/answering-machine-detection
/// </summary>
[JsonConverter(typeof(ApplicationDefaultDetectionModeConverter))]
public enum ApplicationDefaultDetectionMode
{
    Premium, Regular, PremiumCallScreening
}

sealed class ApplicationDefaultDetectionModeConverter : JsonConverter<ApplicationDefaultDetectionMode>
{
    public override ApplicationDefaultDetectionMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Premium"=>ApplicationDefaultDetectionMode.Premium,
            "Regular"=>ApplicationDefaultDetectionMode.Regular,
            "PremiumCallScreening"=>ApplicationDefaultDetectionMode.PremiumCallScreening,
            _ =>(ApplicationDefaultDetectionMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultDetectionMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultDetectionMode.Premium=>"Premium",
            ApplicationDefaultDetectionMode.Regular=>"Regular",
            ApplicationDefaultDetectionMode.PremiumCallScreening=>"PremiumCallScreening",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Enables Answering Machine Detection.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultMachineDetectionConverter))]
public enum ApplicationDefaultMachineDetection
{
    Enable, Disable, DetectMessageEnd
}

sealed class ApplicationDefaultMachineDetectionConverter : JsonConverter<ApplicationDefaultMachineDetection>
{
    public override ApplicationDefaultMachineDetection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Enable"=>ApplicationDefaultMachineDetection.Enable,
            "Disable"=>ApplicationDefaultMachineDetection.Disable,
            "DetectMessageEnd"=>ApplicationDefaultMachineDetection.DetectMessageEnd,
            _ =>(ApplicationDefaultMachineDetection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultMachineDetection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultMachineDetection.Enable=>"Enable",
            ApplicationDefaultMachineDetection.Disable=>"Disable",
            ApplicationDefaultMachineDetection.DetectMessageEnd=>"DetectMessageEnd",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Selects which detectors must validate a beep. `both` requires the amplitude and
/// frequency detectors to agree. `freq_only` uses the frequency detector alone,
/// for beeps whose volume is too unsteady for the default profile. Only used when
/// MachineDetection is enabled.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultMachineDetectionBeepProfileConverter))]
public enum ApplicationDefaultMachineDetectionBeepProfile
{
    Both, FreqOnly
}

sealed class ApplicationDefaultMachineDetectionBeepProfileConverter : JsonConverter<ApplicationDefaultMachineDetectionBeepProfile>
{
    public override ApplicationDefaultMachineDetectionBeepProfile Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "both"=>ApplicationDefaultMachineDetectionBeepProfile.Both,
            "freq_only"=>ApplicationDefaultMachineDetectionBeepProfile.FreqOnly,
            _ =>(ApplicationDefaultMachineDetectionBeepProfile)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultMachineDetectionBeepProfile value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultMachineDetectionBeepProfile.Both=>"both",
            ApplicationDefaultMachineDetectionBeepProfile.FreqOnly=>"freq_only",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines whether media should be encrypted on the call. When set to `SRTP`, the
/// call will use Secure Real-time Transport Protocol for media encryption. When set
/// to `DTLS`, the call will use DTLS for media encryption. Only supported for SIP destinations.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultMediaEncryptionConverter))]
public enum ApplicationDefaultMediaEncryption
{
    Disabled, Srtp, Dtls
}

sealed class ApplicationDefaultMediaEncryptionConverter : JsonConverter<ApplicationDefaultMediaEncryption>
{
    public override ApplicationDefaultMediaEncryption Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "disabled"=>ApplicationDefaultMediaEncryption.Disabled,
            "SRTP"=>ApplicationDefaultMediaEncryption.Srtp,
            "DTLS"=>ApplicationDefaultMediaEncryption.Dtls,
            _ =>(ApplicationDefaultMediaEncryption)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultMediaEncryption value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultMediaEncryption.Disabled=>"disabled",
            ApplicationDefaultMediaEncryption.Srtp=>"SRTP",
            ApplicationDefaultMediaEncryption.Dtls=>"DTLS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The number of channels in the final recording. Defaults to `mono`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultRecordingChannelsConverter))]
public enum ApplicationDefaultRecordingChannels
{
    Mono, Dual
}

sealed class ApplicationDefaultRecordingChannelsConverter : JsonConverter<ApplicationDefaultRecordingChannels>
{
    public override ApplicationDefaultRecordingChannels Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mono"=>ApplicationDefaultRecordingChannels.Mono,
            "dual"=>ApplicationDefaultRecordingChannels.Dual,
            _ =>(ApplicationDefaultRecordingChannels)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultRecordingChannels value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultRecordingChannels.Mono=>"mono",
            ApplicationDefaultRecordingChannels.Dual=>"dual",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `RecordingStatusCallback`. Defaults to `POST`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultRecordingStatusCallbackMethodConverter))]
public enum ApplicationDefaultRecordingStatusCallbackMethod
{
    Get, Post
}

sealed class ApplicationDefaultRecordingStatusCallbackMethodConverter : JsonConverter<ApplicationDefaultRecordingStatusCallbackMethod>
{
    public override ApplicationDefaultRecordingStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ApplicationDefaultRecordingStatusCallbackMethod.Get,
            "POST"=>ApplicationDefaultRecordingStatusCallbackMethod.Post,
            _ =>(ApplicationDefaultRecordingStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultRecordingStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultRecordingStatusCallbackMethod.Get=>"GET",
            ApplicationDefaultRecordingStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The audio track to record for the call. The default is `both`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultRecordingTrackConverter))]
public enum ApplicationDefaultRecordingTrack
{
    Inbound, Outbound, Both
}

sealed class ApplicationDefaultRecordingTrackConverter : JsonConverter<ApplicationDefaultRecordingTrack>
{
    public override ApplicationDefaultRecordingTrack Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>ApplicationDefaultRecordingTrack.Inbound,
            "outbound"=>ApplicationDefaultRecordingTrack.Outbound,
            "both"=>ApplicationDefaultRecordingTrack.Both,
            _ =>(ApplicationDefaultRecordingTrack)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultRecordingTrack value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultRecordingTrack.Inbound=>"inbound",
            ApplicationDefaultRecordingTrack.Outbound=>"outbound",
            ApplicationDefaultRecordingTrack.Both=>"both",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Defines the SIP region to be used for the call.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultSipRegionConverter))]
public enum ApplicationDefaultSipRegion
{
    Us, Europe, Canada, Australia, MiddleEast
}

sealed class ApplicationDefaultSipRegionConverter : JsonConverter<ApplicationDefaultSipRegion>
{
    public override ApplicationDefaultSipRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "US"=>ApplicationDefaultSipRegion.Us,
            "Europe"=>ApplicationDefaultSipRegion.Europe,
            "Canada"=>ApplicationDefaultSipRegion.Canada,
            "Australia"=>ApplicationDefaultSipRegion.Australia,
            "Middle East"=>ApplicationDefaultSipRegion.MiddleEast,
            _ =>(ApplicationDefaultSipRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultSipRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultSipRegion.Us=>"US",
            ApplicationDefaultSipRegion.Europe=>"Europe",
            ApplicationDefaultSipRegion.Canada=>"Canada",
            ApplicationDefaultSipRegion.Australia=>"Australia",
            ApplicationDefaultSipRegion.MiddleEast=>"Middle East",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `StatusCallback`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultStatusCallbackMethodConverter))]
public enum ApplicationDefaultStatusCallbackMethod
{
    Get, Post
}

sealed class ApplicationDefaultStatusCallbackMethodConverter : JsonConverter<ApplicationDefaultStatusCallbackMethod>
{
    public override ApplicationDefaultStatusCallbackMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ApplicationDefaultStatusCallbackMethod.Get,
            "POST"=>ApplicationDefaultStatusCallbackMethod.Post,
            _ =>(ApplicationDefaultStatusCallbackMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultStatusCallbackMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultStatusCallbackMethod.Get=>"GET",
            ApplicationDefaultStatusCallbackMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The supervising role for the new leg. Determines the audio behavior: barge (hear
/// both sides), whisper (only hear supervisor), monitor (hear both sides but supervisor
/// muted). Default: barge
/// </summary>
[JsonConverter(typeof(ApplicationDefaultSupervisingRoleConverter))]
public enum ApplicationDefaultSupervisingRole
{
    Barge, Whisper, Monitor
}

sealed class ApplicationDefaultSupervisingRoleConverter : JsonConverter<ApplicationDefaultSupervisingRole>
{
    public override ApplicationDefaultSupervisingRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>ApplicationDefaultSupervisingRole.Barge,
            "whisper"=>ApplicationDefaultSupervisingRole.Whisper,
            "monitor"=>ApplicationDefaultSupervisingRole.Monitor,
            _ =>(ApplicationDefaultSupervisingRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultSupervisingRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultSupervisingRole.Barge=>"barge",
            ApplicationDefaultSupervisingRole.Whisper=>"whisper",
            ApplicationDefaultSupervisingRole.Monitor=>"monitor",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Whether to trim any leading and trailing silence from the recording. Defaults
/// to `trim-silence`.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultTrimConverter))]
public enum ApplicationDefaultTrim
{
    TrimSilence, DoNotTrim
}

sealed class ApplicationDefaultTrimConverter : JsonConverter<ApplicationDefaultTrim>
{
    public override ApplicationDefaultTrim Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trim-silence"=>ApplicationDefaultTrim.TrimSilence,
            "do-not-trim"=>ApplicationDefaultTrim.DoNotTrim,
            _ =>(ApplicationDefaultTrim)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultTrim value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultTrim.TrimSilence=>"trim-silence",
            ApplicationDefaultTrim.DoNotTrim=>"do-not-trim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// HTTP request type used for `Url`. The default value is inherited from TeXML Application setting.
/// </summary>
[JsonConverter(typeof(ApplicationDefaultUrlMethodConverter))]
public enum ApplicationDefaultUrlMethod
{
    Get, Post
}

sealed class ApplicationDefaultUrlMethodConverter : JsonConverter<ApplicationDefaultUrlMethod>
{
    public override ApplicationDefaultUrlMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GET"=>ApplicationDefaultUrlMethod.Get,
            "POST"=>ApplicationDefaultUrlMethod.Post,
            _ =>(ApplicationDefaultUrlMethod)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ApplicationDefaultUrlMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ApplicationDefaultUrlMethod.Get=>"GET",
            ApplicationDefaultUrlMethod.Post=>"POST",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}