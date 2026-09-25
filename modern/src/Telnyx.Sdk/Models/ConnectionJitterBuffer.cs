using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

/// <summary>
/// Configuration options for Jitter Buffer. Enables Jitter Buffer for RTP streams
/// of SIP Trunking calls. The feature is off unless enabled. You may define min and
/// max values in msec for customized buffering behaviors. Larger values add latency
/// but tolerate more jitter, while smaller values reduce latency but are more sensitive
/// to jitter and reordering.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConnectionJitterBuffer, ConnectionJitterBufferFromRaw>))]
public sealed record class ConnectionJitterBuffer : JsonModel
{
    /// <summary>
    /// Enables Jitter Buffer for RTP streams of SIP Trunking calls. The feature
    /// is off unless enabled.
    /// </summary>
    public bool? EnableJitterBuffer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_jitter_buffer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_jitter_buffer", value);
        }
    }

    /// <summary>
    /// The maximum jitter buffer size in milliseconds. Must be between 40 and 400.
    /// Has no effect if enable_jitter_buffer is not true.
    /// </summary>
    public long? JitterbufferMsecMax {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "jitterbuffer_msec_max"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jitterbuffer_msec_max", value);
        }
    }

    /// <summary>
    /// The minimum jitter buffer size in milliseconds. Must be between 40 and 400.
    /// Has no effect if enable_jitter_buffer is not true.
    /// </summary>
    public long? JitterbufferMsecMin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "jitterbuffer_msec_min"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("jitterbuffer_msec_min", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EnableJitterBuffer;
        _ = this.JitterbufferMsecMax;
        _ = this.JitterbufferMsecMin;
    }

    public ConnectionJitterBuffer ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionJitterBuffer (
        ConnectionJitterBuffer connectionJitterBuffer
    ) : base(connectionJitterBuffer)
    {  }
    #pragma warning restore CS8618

    public ConnectionJitterBuffer (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionJitterBuffer (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionJitterBufferFromRaw.FromRawUnchecked"/>
    public static ConnectionJitterBuffer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionJitterBufferFromRaw : IFromRawJson<ConnectionJitterBuffer>
{
    /// <inheritdoc/>
    public ConnectionJitterBuffer FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionJitterBuffer.FromRawUnchecked(rawData);
}