using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCards;

[JsonConverter(typeof(JsonModelConverter<SimCard, SimCardFromRaw>))]
public sealed record class SimCard : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// Indicate whether the SIM card has any pending (in-progress) actions.
    /// </summary>
    public bool? ActionsInProgress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "actions_in_progress"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("actions_in_progress", value);
        }
    }

    /// <summary>
    /// List of IMEIs authorized to use a given SIM card.
    /// </summary>
    public IReadOnlyList<string>? AuthorizedImeis {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "authorized_imeis"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>?>(
                "authorized_imeis",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The SIM card consumption so far in the current billing cycle.
    /// </summary>
    public CurrentBillingPeriodConsumedData? CurrentBillingPeriodConsumedData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CurrentBillingPeriodConsumedData>(
                "current_billing_period_consumed_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_billing_period_consumed_data", value);
        }
    }

    /// <summary>
    /// Current physical location data of a given SIM card. Accuracy is given in meters.
    /// </summary>
    public CurrentDeviceLocation? CurrentDeviceLocation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CurrentDeviceLocation>(
                "current_device_location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_device_location", value);
        }
    }

    /// <summary>
    /// IMEI of the device where a given SIM card is currently being used.
    /// </summary>
    public string? CurrentImei {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "current_imei"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_imei", value);
        }
    }

    /// <summary>
    /// Mobile Country Code of the current network to which the SIM card is connected.
    /// It's a three decimal digit that identifies a country.&lt;br/&gt;&lt;br/&gt;
    /// This code is commonly seen joined with a Mobile Network Code (MNC) in a tuple
    /// that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? CurrentMcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "current_mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_mcc", value);
        }
    }

    /// <summary>
    /// Mobile Network Code of the current network to which the SIM card is connected.
    /// It's a two to three decimal digits that identify a network.&lt;br/&gt;&lt;br/&gt;
    ///  This code is commonly seen joined with a Mobile Country Code (MCC) in a tuple
    /// that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? CurrentMnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "current_mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_mnc", value);
        }
    }

    /// <summary>
    /// The SIM card individual data limit configuration.
    /// </summary>
    public SimCardDataLimit? DataLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardDataLimit>(
                "data_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_limit", value);
        }
    }

    /// <summary>
    /// The Embedded Identity Document (eID) for eSIM cards.
    /// </summary>
    public string? Eid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eid"
            );
        }
        init { this._rawData.Set("eid", value); }
    }

    /// <summary>
    /// The installation status of the eSIM. Only applicable for eSIM cards.
    /// </summary>
    public ApiEnum<string, EsimInstallationStatus>? EsimInstallationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, EsimInstallationStatus>>(
                "esim_installation_status"
            );
        }
        init { this._rawData.Set("esim_installation_status", value); }
    }

    /// <summary>
    /// The ICCID is the identifier of the specific SIM card/chip. Each SIM is internationally
    /// identified by its integrated circuit card identifier (ICCID). ICCIDs are
    /// stored in the SIM card's memory and are also engraved or printed on the SIM
    /// card body during a process called personalization.
    /// </summary>
    public string? Iccid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "iccid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("iccid", value);
        }
    }

    /// <summary>
    /// SIM cards are identified on their individual network operators by a unique
    /// International Mobile Subscriber Identity (IMSI). &lt;br/&gt; Mobile network
    /// operators connect mobile phone calls and communicate with their market SIM
    /// cards using their IMSIs. The IMSI is stored in the Subscriber  Identity Module
    /// (SIM) inside the device and is sent by the device to the appropriate network.
    /// It is used to acquire the details of the device in the Home  Location Register
    /// (HLR) or the Visitor Location Register (VLR).
    /// </summary>
    public string? Imsi {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "imsi"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("imsi", value);
        }
    }

    /// <summary>
    /// The SIM's address in the currently connected network. This IPv4 address is
    /// usually obtained dynamically, so it may vary according to the location or
    /// new connections.
    /// </summary>
    public string? Ipv4 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ipv4"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ipv4", value);
        }
    }

    /// <summary>
    /// The SIM's address in the currently connected network. This IPv6 address is
    /// usually obtained dynamically, so it may vary according to the location or
    /// new connections.
    /// </summary>
    public string? Ipv6 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ipv6"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ipv6", value);
        }
    }

    /// <summary>
    /// Indicates whether the device is actively connected to a network and able
    /// to run data.
    /// </summary>
    public ApiEnum<string, LiveDataSession>? LiveDataSession {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LiveDataSession>>(
                "live_data_session"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("live_data_session", value);
        }
    }

    /// <summary>
    /// Mobile Station International Subscriber Directory Number (MSISDN) is a number
    /// used to identify a mobile phone number internationally. &lt;br/&gt; MSISDN
    /// is defined by the E.164 numbering plan. It includes a country code and a
    /// National Destination Code which identifies the subscriber's operator.
    /// </summary>
    public string? Msisdn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "msisdn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("msisdn", value);
        }
    }

    /// <summary>
    /// PIN and PUK codes for the SIM card. Only available when include_pin_puk_codes=true
    /// is set in the request.
    /// </summary>
    public PinPukCodes? PinPukCodes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PinPukCodes>(
                "pin_puk_codes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pin_puk_codes", value);
        }
    }

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
    /// List of resources with actions in progress.
    /// </summary>
    public IReadOnlyList<IReadOnlyDictionary<string, JsonElement>>? ResourcesWithInProgressActions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "resources_with_in_progress_actions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>?>(
                "resources_with_in_progress_actions",
                value == null ? null : ImmutableArray.ToImmutableArray(Enumerable.Select(value, ( item )=>FrozenDictionary.ToFrozenDictionary(item)))
            );
        }
    }

    /// <summary>
    /// The group SIMCardGroup identification. This attribute can be &lt;code&gt;null&lt;/code&gt;
    /// when it's present in an associated resource.
    /// </summary>
    public string? SimCardGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_group_id", value);
        }
    }

    public SimCardStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardStatus>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// Searchable tags associated with the SIM card
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The type of SIM card
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.SimCards.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.SimCards.Type>>(
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

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// The version of the SIM card.
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
    /// Indicates whether voice services are enabled for the SIM card.
    /// </summary>
    public bool? VoiceEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "voice_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("voice_enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActionsInProgress;
        _ = this.AuthorizedImeis;
        _ = this.CreatedAt;
        this.CurrentBillingPeriodConsumedData?.Validate();
        this.CurrentDeviceLocation?.Validate();
        _ = this.CurrentImei;
        _ = this.CurrentMcc;
        _ = this.CurrentMnc;
        this.DataLimit?.Validate();
        _ = this.Eid;
        this.EsimInstallationStatus?.Validate();
        _ = this.Iccid;
        _ = this.Imsi;
        _ = this.Ipv4;
        _ = this.Ipv6;
        this.LiveDataSession?.Validate();
        _ = this.Msisdn;
        this.PinPukCodes?.Validate();
        _ = this.RecordType;
        _ = this.ResourcesWithInProgressActions;
        _ = this.SimCardGroupID;
        this.Status?.Validate();
        _ = this.Tags;
        this.Type?.Validate();
        _ = this.UpdatedAt;
        _ = this.Version;
        _ = this.VoiceEnabled;
    }

    public SimCard ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCard (SimCard simCard) : base(simCard)
    {  }
    #pragma warning restore CS8618

    public SimCard (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCard (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardFromRaw.FromRawUnchecked"/>
    public static SimCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardFromRaw : IFromRawJson<SimCard>
{
    /// <inheritdoc/>
    public SimCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCard.FromRawUnchecked(rawData);
}

/// <summary>
/// The SIM card consumption so far in the current billing cycle.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CurrentBillingPeriodConsumedData, CurrentBillingPeriodConsumedDataFromRaw>))]
public sealed record class CurrentBillingPeriodConsumedData : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Unit;
    }

    public CurrentBillingPeriodConsumedData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrentBillingPeriodConsumedData (
        CurrentBillingPeriodConsumedData currentBillingPeriodConsumedData
    ) : base(currentBillingPeriodConsumedData)
    {  }
    #pragma warning restore CS8618

    public CurrentBillingPeriodConsumedData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrentBillingPeriodConsumedData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CurrentBillingPeriodConsumedDataFromRaw.FromRawUnchecked"/>
    public static CurrentBillingPeriodConsumedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CurrentBillingPeriodConsumedDataFromRaw : IFromRawJson<CurrentBillingPeriodConsumedData>
{
    /// <inheritdoc/>
    public CurrentBillingPeriodConsumedData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CurrentBillingPeriodConsumedData.FromRawUnchecked(rawData);
}/// <summary>
/// Current physical location data of a given SIM card. Accuracy is given in meters.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CurrentDeviceLocation, CurrentDeviceLocationFromRaw>))]
public sealed record class CurrentDeviceLocation : JsonModel
{
    public long? Accuracy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "accuracy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("accuracy", value);
        }
    }

    public string? AccuracyUnit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "accuracy_unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("accuracy_unit", value);
        }
    }

    public string? Latitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "latitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    public string? Longitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "longitude"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Accuracy;
        _ = this.AccuracyUnit;
        _ = this.Latitude;
        _ = this.Longitude;
    }

    public CurrentDeviceLocation ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CurrentDeviceLocation (
        CurrentDeviceLocation currentDeviceLocation
    ) : base(currentDeviceLocation)
    {  }
    #pragma warning restore CS8618

    public CurrentDeviceLocation (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CurrentDeviceLocation (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CurrentDeviceLocationFromRaw.FromRawUnchecked"/>
    public static CurrentDeviceLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CurrentDeviceLocationFromRaw : IFromRawJson<CurrentDeviceLocation>
{
    /// <inheritdoc/>
    public CurrentDeviceLocation FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CurrentDeviceLocation.FromRawUnchecked(rawData);
}/// <summary>
/// The SIM card individual data limit configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardDataLimit, SimCardDataLimitFromRaw>))]
public sealed record class SimCardDataLimit : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public ApiEnum<string, SimCardDataLimitUnit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardDataLimitUnit>>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Unit?.Validate();
    }

    public SimCardDataLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataLimit (SimCardDataLimit simCardDataLimit) : base(
        simCardDataLimit
    )
    {  }
    #pragma warning restore CS8618

    public SimCardDataLimit (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataLimit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataLimitFromRaw.FromRawUnchecked"/>
    public static SimCardDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardDataLimitFromRaw : IFromRawJson<SimCardDataLimit>
{
    /// <inheritdoc/>
    public SimCardDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataLimit.FromRawUnchecked(rawData);
}[JsonConverter(typeof(SimCardDataLimitUnitConverter))]
public enum SimCardDataLimitUnit
{
    MB, GB
}sealed class SimCardDataLimitUnitConverter : JsonConverter<SimCardDataLimitUnit>
{
    public override SimCardDataLimitUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MB"=>SimCardDataLimitUnit.MB,
            "GB"=>SimCardDataLimitUnit.GB,
            _ =>(SimCardDataLimitUnit)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardDataLimitUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardDataLimitUnit.MB=>"MB",
            SimCardDataLimitUnit.GB=>"GB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The installation status of the eSIM. Only applicable for eSIM cards.
/// </summary>
[JsonConverter(typeof(EsimInstallationStatusConverter))]
public enum EsimInstallationStatus
{
    Released, Disabled
}sealed class EsimInstallationStatusConverter : JsonConverter<EsimInstallationStatus>
{
    public override EsimInstallationStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "released"=>EsimInstallationStatus.Released,
            "disabled"=>EsimInstallationStatus.Disabled,
            _ =>(EsimInstallationStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EsimInstallationStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EsimInstallationStatus.Released=>"released",
            EsimInstallationStatus.Disabled=>"disabled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Indicates whether the device is actively connected to a network and able to run data.
/// </summary>
[JsonConverter(typeof(LiveDataSessionConverter))]
public enum LiveDataSession
{
    Connected, Disconnected, Unknown
}sealed class LiveDataSessionConverter : JsonConverter<LiveDataSession>
{
    public override LiveDataSession Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "connected"=>LiveDataSession.Connected,
            "disconnected"=>LiveDataSession.Disconnected,
            "unknown"=>LiveDataSession.Unknown,
            _ =>(LiveDataSession)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LiveDataSession value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LiveDataSession.Connected=>"connected",
            LiveDataSession.Disconnected=>"disconnected",
            LiveDataSession.Unknown=>"unknown",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// PIN and PUK codes for the SIM card. Only available when include_pin_puk_codes=true
/// is set in the request.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PinPukCodes, PinPukCodesFromRaw>))]
public sealed record class PinPukCodes : JsonModel
{
    /// <summary>
    /// The primary Personal Identification Number (PIN) for the SIM card. This is
    /// a 4-digit code used to protect the SIM card from unauthorized use.
    /// </summary>
    public string? Pin1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pin1"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pin1", value);
        }
    }

    /// <summary>
    /// The secondary Personal Identification Number (PIN2) for the SIM card. This
    /// is a 4-digit code used for additional security features.
    /// </summary>
    public string? Pin2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pin2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pin2", value);
        }
    }

    /// <summary>
    /// The primary Personal Unblocking Key (PUK1) for the SIM card. This is an 8-digit
    /// code used to unlock the SIM card if PIN1 is entered incorrectly multiple times.
    /// </summary>
    public string? Puk1 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "puk1"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("puk1", value);
        }
    }

    /// <summary>
    /// The secondary Personal Unblocking Key (PUK2) for the SIM card. This is an
    /// 8-digit code used to unlock the SIM card if PIN2 is entered incorrectly multiple times.
    /// </summary>
    public string? Puk2 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "puk2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("puk2", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Pin1;
        _ = this.Pin2;
        _ = this.Puk1;
        _ = this.Puk2;
    }

    public PinPukCodes ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PinPukCodes (PinPukCodes pinPukCodes) : base(pinPukCodes)
    {  }
    #pragma warning restore CS8618

    public PinPukCodes (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PinPukCodes (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PinPukCodesFromRaw.FromRawUnchecked"/>
    public static PinPukCodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PinPukCodesFromRaw : IFromRawJson<PinPukCodes>
{
    /// <inheritdoc/>
    public PinPukCodes FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PinPukCodes.FromRawUnchecked(rawData);
}/// <summary>
/// The type of SIM card
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Physical, Esim
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.SimCards.Type>
{
    public override global::Telnyx.Sdk.Models.SimCards.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical"=>global::Telnyx.Sdk.Models.SimCards.Type.Physical,
            "esim"=>global::Telnyx.Sdk.Models.SimCards.Type.Esim,
            _ =>(global::Telnyx.Sdk.Models.SimCards.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.SimCards.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.SimCards.Type.Physical=>"physical",
            global::Telnyx.Sdk.Models.SimCards.Type.Esim=>"esim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}