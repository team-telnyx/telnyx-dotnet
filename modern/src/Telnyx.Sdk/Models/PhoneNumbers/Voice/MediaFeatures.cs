using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Voice;

/// <summary>
/// The media features settings for a phone number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MediaFeatures, MediaFeaturesFromRaw>))]
public sealed record class MediaFeatures : JsonModel
{
    /// <summary>
    /// When enabled, Telnyx will accept RTP packets from any customer-side IP address
    /// and port, not just those to which Telnyx is sending RTP.
    /// </summary>
    public bool? AcceptAnyRtpPacketsEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "accept_any_rtp_packets_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("accept_any_rtp_packets_enabled", value);
        }
    }

    /// <summary>
    /// When RTP Auto-Adjust is enabled, the destination RTP address port will be
    /// automatically changed to match the source of the incoming RTP packets.
    /// </summary>
    public bool? RtpAutoAdjustEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "rtp_auto_adjust_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rtp_auto_adjust_enabled", value);
        }
    }

    /// <summary>
    /// Controls whether Telnyx will accept a T.38 re-INVITE for this phone number.
    /// Note that Telnyx will not send a T.38 re-INVITE; this option only controls
    /// whether one will be accepted.
    /// </summary>
    public bool? T38FaxGatewayEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "t38_fax_gateway_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("t38_fax_gateway_enabled", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptAnyRtpPacketsEnabled;
        _ = this.RtpAutoAdjustEnabled;
        _ = this.T38FaxGatewayEnabled;
    }

    public MediaFeatures ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MediaFeatures (MediaFeatures mediaFeatures) : base(mediaFeatures)
    {  }
    #pragma warning restore CS8618

    public MediaFeatures (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MediaFeatures (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MediaFeaturesFromRaw.FromRawUnchecked"/>
    public static MediaFeatures FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MediaFeaturesFromRaw : IFromRawJson<MediaFeatures>
{
    /// <inheritdoc/>
    public MediaFeatures FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MediaFeatures.FromRawUnchecked(rawData);
}