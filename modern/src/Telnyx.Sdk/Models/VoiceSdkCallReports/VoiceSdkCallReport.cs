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

namespace Telnyx.Sdk.Models.VoiceSdkCallReports;

/// <summary>
/// A raw call report stats JSON payload. The schema is intentionally permissive
/// because Voice SDK clients can add fields over time.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceSdkCallReport, VoiceSdkCallReportFromRaw>))]
public sealed record class VoiceSdkCallReport : JsonModel
{
    /// <summary>
    /// Unique call identifier.
    /// </summary>
    public string? CallID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_id", value);
        }
    }

    /// <summary>
    /// User-scoped storage grouping identifier derived from the authenticated user.
    /// This is not a unique per-call report identifier and may be shared by multiple
    /// calls for the same user.
    /// </summary>
    public string? CallReportID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_report_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_report_id", value);
        }
    }

    /// <summary>
    /// Creation timestamp when present.
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
    /// Reason the SDK flushed this stats report segment, for example an intermediate
    /// socket-close flush.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? FlushReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "flushReason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "flushReason",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Raw logs payload emitted by the Voice SDK and stored without normalization.
    /// Live responses commonly return an array of log entries, but object-shaped
    /// log payloads are also allowed for compatibility.
    /// </summary>
    public Logs? Logs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Logs>(
                "logs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("logs", value);
        }
    }

    /// <summary>
    /// Organization associated with the stored call report when provided by the Voice
    /// SDK reporting path.
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
    /// Zero-based stats segment index when the SDK sends segmented or intermediate reports.
    /// </summary>
    public long? Segment {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "segment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("segment", value);
        }
    }

    /// <summary>
    /// Raw stats payload emitted by the Voice SDK and stored without normalization.
    /// The exact shape can vary by SDK platform and version. Live responses commonly
    /// return an array of interval snapshots, but object-shaped stats payloads are
    /// also allowed for compatibility.
    /// </summary>
    public Stats? Stats {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Stats>(
                "stats"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stats", value);
        }
    }

    /// <summary>
    /// Time when the call report was stored.
    /// </summary>
    public System::DateTimeOffset? StoredAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "stored_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stored_at", value);
        }
    }

    /// <summary>
    /// High-level call metadata.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Summary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "summary"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "summary",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Telnyx call leg identifier for correlating the report with call-control,
    /// SIP, and media troubleshooting data.
    /// </summary>
    public string? TelnyxLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telnyx_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telnyx_leg_id", value);
        }
    }

    /// <summary>
    /// Telnyx RTC session identifier for correlating the report with Voice SDK signaling
    /// and media-session logs.
    /// </summary>
    public string? TelnyxSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telnyx_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telnyx_session_id", value);
        }
    }

    /// <summary>
    /// Voice SDK user agent string reported by the client. This is the preferred
    /// SDK/platform/version dimension when present.
    /// </summary>
    public string? UserAgent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_agent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_agent", value);
        }
    }

    /// <summary>
    /// Authenticated user that owns the call report.
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

    /// <summary>
    /// Legacy SDK version value when the client reports one separately from the
    /// user agent.
    /// </summary>
    public string? Version {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("version", value);
        }
    }

    /// <summary>
    /// Voice SDK instance identifier.
    /// </summary>
    public string? VoiceSdkID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice_sdk_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_sdk_id", value);
        }
    }

    /// <summary>
    /// Decoded Voice SDK identifier metadata emitted by voice-sdk-proxy when available.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? VoiceSdkIDDecoded {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "voice_sdk_id_decoded"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "voice_sdk_id_decoded",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Voice SDK session correlation identifier used to group stats segments for
    /// the same SDK session.
    /// </summary>
    public string? VoiceSdkSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "voice_sdk_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_sdk_session_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallID;
        _ = this.CallReportID;
        _ = this.CreatedAt;
        _ = this.FlushReason;
        this.Logs?.Validate();
        _ = this.OrganizationID;
        _ = this.Segment;
        this.Stats?.Validate();
        _ = this.StoredAt;
        _ = this.Summary;
        _ = this.TelnyxLegID;
        _ = this.TelnyxSessionID;
        _ = this.UserAgent;
        _ = this.UserID;
        _ = this.Version;
        _ = this.VoiceSdkID;
        _ = this.VoiceSdkIDDecoded;
        _ = this.VoiceSdkSessionID;
    }

    public VoiceSdkCallReport ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSdkCallReport (VoiceSdkCallReport voiceSdkCallReport) : base(
        voiceSdkCallReport
    )
    {  }
    #pragma warning restore CS8618

    public VoiceSdkCallReport (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSdkCallReport (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSdkCallReportFromRaw.FromRawUnchecked"/>
    public static VoiceSdkCallReport FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceSdkCallReportFromRaw : IFromRawJson<VoiceSdkCallReport>
{
    /// <inheritdoc/>
    public VoiceSdkCallReport FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceSdkCallReport.FromRawUnchecked(rawData);
}

/// <summary>
/// Raw logs payload emitted by the Voice SDK and stored without normalization. Live
/// responses commonly return an array of log entries, but object-shaped log payloads
/// are also allowed for compatibility.
/// </summary>
[JsonConverter(typeof(LogsConverter))]
public record class Logs : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Logs (
        Generic::IReadOnlyList<VoiceSdkCallReportLogEntry> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(value);
        this._element = element;
    }

    public Logs (Entries value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Logs (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Generic::List{T}"/> where <c>T</c> is a <c>VoiceSdkCallReportLogEntry</c>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickVoiceSdkCallReportLogEntries(out var value)) {
///     // `value` is of type `Generic::IReadOnlyList&lt;VoiceSdkCallReportLogEntry&gt;`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickVoiceSdkCallReportLogEntries(
        [NotNullWhen(true)] out Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>? value
    )
    {
        value =this.Value as Generic::IReadOnlyList<VoiceSdkCallReportLogEntry> ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Entries"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickEntries(out var value)) {
///     // `value` is of type `Entries`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickEntries([NotNullWhen(true)] out Entries? value)
    {
        value =this.Value as Entries ;
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
///     (Generic::IReadOnlyList&lt;VoiceSdkCallReportLogEntry&gt; value) =&gt; {...},
///     (Entries value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>> voiceSdkCallReportLogEntries,
        System::Action<Entries> entries
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<VoiceSdkCallReportLogEntry> value:
                voiceSdkCallReportLogEntries(value);
                break;
            case Entries value:
                entries(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Logs");

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
///     (Generic::IReadOnlyList&lt;VoiceSdkCallReportLogEntry&gt; value) =&gt; {...},
///     (Entries value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>, T> voiceSdkCallReportLogEntries,
        System::Func<Entries, T> entries
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<VoiceSdkCallReportLogEntry> value=>voiceSdkCallReportLogEntries(value),
            Entries value=>entries(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Logs")
        } ;
    }

    public static implicit operator Logs (
        Generic::List<VoiceSdkCallReportLogEntry> value
    )=> new((Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>)value) ;

    public static implicit operator Logs (Entries value)=> new(value) ;

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
            throw new TelnyxInvalidDataException("Data did not match any variant of Logs");
        }
        this.Switch((voiceSdkCallReportLogEntries) => {foreach (var item in voiceSdkCallReportLogEntries)
        {
            item.Validate();
        }},
        (entries) => entries.Validate());
    }

    public virtual bool Equals(Logs? other)
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
            Generic::IReadOnlyList<VoiceSdkCallReportLogEntry> _=>0,
            Entries _=>1,
            _ =>-1
        } ;
    }
}sealed class LogsConverter : JsonConverter<Logs>
{
    public override Logs? Read(
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
            var deserialized = JsonSerializer.Deserialize<Entries>(element, options);
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
            var deserialized = JsonSerializer.Deserialize<Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>>(element, options);
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
        Utf8JsonWriter writer, Logs value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Raw logs object emitted by the Voice SDK when logs are grouped under an entries field.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Entries, EntriesFromRaw>))]
public sealed record class Entries : JsonModel
{
    /// <summary>
    /// Raw log entries when the SDK groups logs under an entries field.
    /// </summary>
    public Generic::IReadOnlyList<VoiceSdkCallReportLogEntry>? EntriesValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<VoiceSdkCallReportLogEntry>>(
                "entries"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<VoiceSdkCallReportLogEntry>?>(
                "entries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.EntriesValue ?? [])
        {
            item.Validate();
        }
    }

    public Entries ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Entries (Entries entries) : base(entries)
    {  }
    #pragma warning restore CS8618

    public Entries (Generic::IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Entries (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EntriesFromRaw.FromRawUnchecked"/>
    public static Entries FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EntriesFromRaw : IFromRawJson<Entries>
{
    /// <inheritdoc/>
    public Entries FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Entries.FromRawUnchecked(rawData);
}/// <summary>
/// Raw stats payload emitted by the Voice SDK and stored without normalization.
/// The exact shape can vary by SDK platform and version. Live responses commonly
/// return an array of interval snapshots, but object-shaped stats payloads are also
/// allowed for compatibility.
/// </summary>
[JsonConverter(typeof(StatsConverter))]
public record class Stats : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public Stats (
        Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value,
        JsonElement? element = null
    )
    {
        this.Value = ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)));
        this._element = element;
    }

    public Stats (
        VoiceSdkCallReportStatsObject value, JsonElement? element = null
    )
    {
        this.Value = value;
        this._element = element;
    }

    public Stats (JsonElement element)
    { this._element = element; }

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
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="VoiceSdkCallReportStatsObject"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickVoiceSdkCallReportStatsObject(out var value)) {
///     // `value` is of type `VoiceSdkCallReportStatsObject`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickVoiceSdkCallReportStatsObject(
        [NotNullWhen(true)] out VoiceSdkCallReportStatsObject? value
    )
    {
        value =this.Value as VoiceSdkCallReportStatsObject ;
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
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (VoiceSdkCallReportStatsObject value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>> jsonElements,
        System::Action<VoiceSdkCallReportStatsObject> voiceSdkCallReportStatsObject
    )
    {
        switch (this.Value)
        {
            case Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value:
                jsonElements(value);
                break;
            case VoiceSdkCallReportStatsObject value:
                voiceSdkCallReportStatsObject(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Stats");

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
///     (Generic::IReadOnlyList&lt;Generic::IReadOnlyDictionary&lt;string, JsonElement&gt;&gt; value) =&gt; {...},
///     (VoiceSdkCallReportStatsObject value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (
        System::Func<Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>, T> jsonElements,
        System::Func<VoiceSdkCallReportStatsObject, T> voiceSdkCallReportStatsObject
    )
    {
        return this.Value switch
        {
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> value=>jsonElements(value),
            VoiceSdkCallReportStatsObject value=>voiceSdkCallReportStatsObject(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Stats")
        } ;
    }

    public static implicit operator Stats (
        Generic::List<Generic::Dictionary<string, JsonElement>> value
    )=> new((Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>>)value) ;

    public static implicit operator Stats (
        VoiceSdkCallReportStatsObject value
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
            throw new TelnyxInvalidDataException("Data did not match any variant of Stats");
        }
        this.Switch((_) => {},
        (voiceSdkCallReportStatsObject) => voiceSdkCallReportStatsObject.Validate());
    }

    public virtual bool Equals(Stats? other)
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
            Generic::IReadOnlyList<Generic::IReadOnlyDictionary<string, JsonElement>> _=>0,
            VoiceSdkCallReportStatsObject _=>1,
            _ =>-1
        } ;
    }
}sealed class StatsConverter : JsonConverter<Stats>
{
    public override Stats? Read(
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
            var deserialized = JsonSerializer.Deserialize<VoiceSdkCallReportStatsObject>(element, options);
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
        Utf8JsonWriter writer, Stats value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}/// <summary>
/// Raw stats object emitted by the Voice SDK.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceSdkCallReportStatsObject, VoiceSdkCallReportStatsObjectFromRaw>))]
public sealed record class VoiceSdkCallReportStatsObject : JsonModel
{
    /// <summary>
    /// Raw audio stats such as inbound/outbound packet, byte, jitter, packet-loss,
    /// bitrate, and audio-level metrics.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Audio {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "audio"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "audio",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Raw connection stats such as round-trip time, packets, and bytes sent or received.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Connection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "connection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "connection",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Raw ICE candidate-pair information, including selected pair, local/remote
    /// candidates, state, and nomination data when provided by the SDK.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Ice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "ice"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "ice",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Raw transport stats such as ICE state, DTLS state, SRTP cipher, TLS version,
    /// and selected-candidate-pair changes.
    /// </summary>
    public Generic::IReadOnlyDictionary<string, JsonElement>? Transport {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "transport"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "transport",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Audio;
        _ = this.Connection;
        _ = this.Ice;
        _ = this.Transport;
    }

    public VoiceSdkCallReportStatsObject ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceSdkCallReportStatsObject (
        VoiceSdkCallReportStatsObject voiceSdkCallReportStatsObject
    ) : base(voiceSdkCallReportStatsObject)
    {  }
    #pragma warning restore CS8618

    public VoiceSdkCallReportStatsObject (
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceSdkCallReportStatsObject (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceSdkCallReportStatsObjectFromRaw.FromRawUnchecked"/>
    public static VoiceSdkCallReportStatsObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class VoiceSdkCallReportStatsObjectFromRaw : IFromRawJson<VoiceSdkCallReportStatsObject>
{
    /// <inheritdoc/>
    public VoiceSdkCallReportStatsObject FromRawUnchecked(
        Generic::IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceSdkCallReportStatsObject.FromRawUnchecked(rawData);
}