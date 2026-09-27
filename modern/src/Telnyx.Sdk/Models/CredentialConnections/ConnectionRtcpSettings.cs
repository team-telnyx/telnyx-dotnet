using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CredentialConnections;

[JsonConverter(typeof(JsonModelConverter<ConnectionRtcpSettings, ConnectionRtcpSettingsFromRaw>))]
public sealed record class ConnectionRtcpSettings : JsonModel
{
    /// <summary>
    /// Enable the capture and storage of RTCP messages to create QoS reports on the
    /// Telnyx Mission Control Portal.
    /// </summary>
    public bool? CaptureEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "capture_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("capture_enabled", value);
        }
    }

    /// <summary>
    /// RTCP port by default is rtp+1, it can also be set to rtcp-mux
    /// </summary>
    public ApiEnum<string, Port>? Port {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Port>>(
                "port"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("port", value);
        }
    }

    /// <summary>
    /// RTCP reports are sent to customers based on the frequency set. Frequency
    /// is in seconds and it can be set to values from 5 to 3000 seconds.
    /// </summary>
    public long? ReportFrequencySecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "report_frequency_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("report_frequency_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CaptureEnabled;
        this.Port?.Validate();
        _ = this.ReportFrequencySecs;
    }

    public ConnectionRtcpSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionRtcpSettings (
        ConnectionRtcpSettings connectionRtcpSettings
    ) : base(connectionRtcpSettings)
    {  }
    #pragma warning restore CS8618

    public ConnectionRtcpSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionRtcpSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionRtcpSettingsFromRaw.FromRawUnchecked"/>
    public static ConnectionRtcpSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionRtcpSettingsFromRaw : IFromRawJson<ConnectionRtcpSettings>
{
    /// <inheritdoc/>
    public ConnectionRtcpSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionRtcpSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// RTCP port by default is rtp+1, it can also be set to rtcp-mux
/// </summary>
[JsonConverter(typeof(PortConverter))]
public enum Port
{
    RtcpMux, Rtp1
}sealed class PortConverter : JsonConverter<Port>
{
    public override Port Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "rtcp-mux"=>Port.RtcpMux, "rtp+1"=>Port.Rtp1, _ =>(Port)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Port value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Port.RtcpMux=>"rtcp-mux",
            Port.Rtp1=>"rtp+1",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}