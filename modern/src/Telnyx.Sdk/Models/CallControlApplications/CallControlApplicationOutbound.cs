using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationOutbound, CallControlApplicationOutboundFromRaw>))]
public sealed record class CallControlApplicationOutbound : JsonModel
{
    /// <summary>
    /// When set, this will limit the total number of outbound calls to phone numbers
    /// associated with this connection.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound_voice_profile_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelLimit;
        _ = this.OutboundVoiceProfileID;
    }

    public CallControlApplicationOutbound ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationOutbound (
        CallControlApplicationOutbound callControlApplicationOutbound
    ) : base(callControlApplicationOutbound)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationOutbound (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationOutbound (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationOutboundFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationOutboundFromRaw : IFromRawJson<CallControlApplicationOutbound>
{
    /// <inheritdoc/>
    public CallControlApplicationOutbound FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationOutbound.FromRawUnchecked(rawData);
}