using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCards;

/// <summary>
/// This object represents a wireless connectivity session log that happened through
/// a SIM card. It aids in finding out potential problems when the SIM is not able
/// to attach properly.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardListWirelessConnectivityLogsResponse, SimCardListWirelessConnectivityLogsResponseFromRaw>))]
public sealed record class SimCardListWirelessConnectivityLogsResponse : JsonModel
{
    /// <summary>
    /// Uniquely identifies the session.
    /// </summary>
    public long? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
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
    /// The Access Point Name (APN) identifies the packet data network that a mobile
    /// data user wants to communicate with.
    /// </summary>
    public string? Apn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "apn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("apn", value);
        }
    }

    /// <summary>
    /// The cell ID to which the SIM connected.
    /// </summary>
    public string? CellID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cell_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cell_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the record was created.
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
    /// The International Mobile Equipment Identity (or IMEI) is a number, usually
    /// unique, that identifies the device currently being used connect to the network.
    /// </summary>
    public string? Imei {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "imei"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("imei", value);
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
    /// ISO 8601 formatted date-time indicating when the last heartbeat to the device
    /// was successfully recorded.
    /// </summary>
    public string? LastSeen {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_seen"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_seen", value);
        }
    }

    /// <summary>
    /// The type of the session, 'registration' being the initial authentication
    /// session and 'data' the actual data transfer sessions.
    /// </summary>
    public ApiEnum<string, LogType>? LogType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LogType>>(
                "log_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("log_type", value);
        }
    }

    /// <summary>
    /// It's a three decimal digit that identifies a country.&lt;br/&gt;&lt;br/&gt;
    /// This code is commonly seen joined with a Mobile Network Code (MNC) in a tuple
    /// that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? MobileCountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_country_code", value);
        }
    }

    /// <summary>
    /// It's a two to three decimal digits that identify a network.&lt;br/&gt;&lt;br/&gt;
    ///  This code is commonly seen joined with a Mobile Country Code (MCC) in a tuple
    /// that allows identifying a carrier known as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? MobileNetworkCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mobile_network_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mobile_network_code", value);
        }
    }

    /// <summary>
    /// The radio technology the SIM card used during the session.
    /// </summary>
    public string? RadioAccessTechnology {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "radio_access_technology"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("radio_access_technology", value);
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
    /// The identification UUID of the related SIM card resource.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the session started.
    /// </summary>
    public string? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// The state of the SIM card after when the session happened.
    /// </summary>
    public string? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the session ended.
    /// </summary>
    public string? StopTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "stop_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stop_time", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Apn;
        _ = this.CellID;
        _ = this.CreatedAt;
        _ = this.Imei;
        _ = this.Imsi;
        _ = this.Ipv4;
        _ = this.Ipv6;
        _ = this.LastSeen;
        this.LogType?.Validate();
        _ = this.MobileCountryCode;
        _ = this.MobileNetworkCode;
        _ = this.RadioAccessTechnology;
        _ = this.RecordType;
        _ = this.SimCardID;
        _ = this.StartTime;
        _ = this.State;
        _ = this.StopTime;
    }

    public SimCardListWirelessConnectivityLogsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardListWirelessConnectivityLogsResponse (
        SimCardListWirelessConnectivityLogsResponse simCardListWirelessConnectivityLogsResponse
    ) : base(simCardListWirelessConnectivityLogsResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardListWirelessConnectivityLogsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardListWirelessConnectivityLogsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardListWirelessConnectivityLogsResponseFromRaw.FromRawUnchecked"/>
    public static SimCardListWirelessConnectivityLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardListWirelessConnectivityLogsResponseFromRaw : IFromRawJson<SimCardListWirelessConnectivityLogsResponse>
{
    /// <inheritdoc/>
    public SimCardListWirelessConnectivityLogsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardListWirelessConnectivityLogsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The type of the session, 'registration' being the initial authentication session
/// and 'data' the actual data transfer sessions.
/// </summary>
[JsonConverter(typeof(LogTypeConverter))]
public enum LogType
{
    Registration, Data
}sealed class LogTypeConverter : JsonConverter<LogType>
{
    public override LogType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "registration"=>LogType.Registration,
            "data"=>LogType.Data,
            _ =>(LogType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, LogType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LogType.Registration=>"registration",
            LogType.Data=>"data",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}