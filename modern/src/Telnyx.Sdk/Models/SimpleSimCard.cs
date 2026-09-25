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

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<SimpleSimCard, SimpleSimCardFromRaw>))]
public sealed record class SimpleSimCard : JsonModel
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
    /// The SIM card individual data limit configuration.
    /// </summary>
    public DataLimit? DataLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataLimit>(
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
    public ApiEnum<string, SimpleSimCardType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimpleSimCardType>>(
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
        this.DataLimit?.Validate();
        _ = this.Eid;
        this.EsimInstallationStatus?.Validate();
        _ = this.Iccid;
        _ = this.Imsi;
        _ = this.Msisdn;
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

    public SimpleSimCard ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimpleSimCard (SimpleSimCard simpleSimCard) : base(simpleSimCard)
    {  }
    #pragma warning restore CS8618

    public SimpleSimCard (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimpleSimCard (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimpleSimCardFromRaw.FromRawUnchecked"/>
    public static SimpleSimCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimpleSimCardFromRaw : IFromRawJson<SimpleSimCard>
{
    /// <inheritdoc/>
    public SimpleSimCard FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimpleSimCard.FromRawUnchecked(rawData);
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
/// The SIM card individual data limit configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataLimit, DataLimitFromRaw>))]
public sealed record class DataLimit : JsonModel
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

    public ApiEnum<string, Unit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Unit>>(
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

    public DataLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataLimit (DataLimit dataLimit) : base(dataLimit)
    {  }
    #pragma warning restore CS8618

    public DataLimit (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DataLimit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataLimitFromRaw.FromRawUnchecked"/>
    public static DataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataLimitFromRaw : IFromRawJson<DataLimit>
{
    /// <inheritdoc/>
    public DataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DataLimit.FromRawUnchecked(rawData);
}[JsonConverter(typeof(UnitConverter))]
public enum Unit
{
    MB, GB
}sealed class UnitConverter : JsonConverter<Unit>
{
    public override Unit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "MB"=>Unit.MB, "GB"=>Unit.GB, _ =>(Unit)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Unit value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Unit.MB=>"MB",
            Unit.GB=>"GB",
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
/// The type of SIM card
/// </summary>
[JsonConverter(typeof(SimpleSimCardTypeConverter))]
public enum SimpleSimCardType
{
    Physical, Esim
}sealed class SimpleSimCardTypeConverter : JsonConverter<SimpleSimCardType>
{
    public override SimpleSimCardType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "physical"=>SimpleSimCardType.Physical,
            "esim"=>SimpleSimCardType.Esim,
            _ =>(SimpleSimCardType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimpleSimCardType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimpleSimCardType.Physical=>"physical",
            SimpleSimCardType.Esim=>"esim",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}