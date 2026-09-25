using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

[JsonConverter(typeof(JsonModelConverter<ParticipantParticipantsResponse, ParticipantParticipantsResponseFromRaw>))]
public sealed record class ParticipantParticipantsResponse : JsonModel
{
    /// <summary>
    /// The id of the account the resource belongs to.
    /// </summary>
    public string? AccountSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_sid", value);
        }
    }

    /// <summary>
    /// The identifier of this participant's call.
    /// </summary>
    public string? CallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid", value);
        }
    }

    /// <summary>
    /// Whether the participant is coaching another call.
    /// </summary>
    public bool? Coaching {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "coaching"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("coaching", value);
        }
    }

    /// <summary>
    /// The identifier of the coached participant's call.
    /// </summary>
    public string? CoachingCallSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "coaching_call_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("coaching_call_sid", value);
        }
    }

    /// <summary>
    /// The unique identifier for the conference.
    /// </summary>
    public string? ConferenceSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_sid", value);
        }
    }

    /// <summary>
    /// Whether the conference ends when the participant leaves.
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the participant is on hold.
    /// </summary>
    public bool? Hold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("hold", value);
        }
    }

    /// <summary>
    /// Whether the participant is muted.
    /// </summary>
    public bool? Muted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "muted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("muted", value);
        }
    }

    /// <summary>
    /// The status of the participant's call in the conference.
    /// </summary>
    public ApiEnum<string, ParticipantParticipantsResponseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ParticipantParticipantsResponseStatus>>(
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
    /// The relative URI for this participant.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountSid;
        _ = this.CallSid;
        _ = this.Coaching;
        _ = this.CoachingCallSid;
        _ = this.ConferenceSid;
        _ = this.EndConferenceOnExit;
        _ = this.Hold;
        _ = this.Muted;
        this.Status?.Validate();
        _ = this.Uri;
    }

    public ParticipantParticipantsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParticipantParticipantsResponse (
        ParticipantParticipantsResponse participantParticipantsResponse
    ) : base(participantParticipantsResponse)
    {  }
    #pragma warning restore CS8618

    public ParticipantParticipantsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ParticipantParticipantsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParticipantParticipantsResponseFromRaw.FromRawUnchecked"/>
    public static ParticipantParticipantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ParticipantParticipantsResponseFromRaw : IFromRawJson<ParticipantParticipantsResponse>
{
    /// <inheritdoc/>
    public ParticipantParticipantsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ParticipantParticipantsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the participant's call in the conference.
/// </summary>
[JsonConverter(typeof(ParticipantParticipantsResponseStatusConverter))]
public enum ParticipantParticipantsResponseStatus
{
    Connecting, Connected, Completed
}sealed class ParticipantParticipantsResponseStatusConverter : JsonConverter<ParticipantParticipantsResponseStatus>
{
    public override ParticipantParticipantsResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "connecting"=>ParticipantParticipantsResponseStatus.Connecting,
            "connected"=>ParticipantParticipantsResponseStatus.Connected,
            "completed"=>ParticipantParticipantsResponseStatus.Completed,
            _ =>(ParticipantParticipantsResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ParticipantParticipantsResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ParticipantParticipantsResponseStatus.Connecting=>"connecting",
            ParticipantParticipantsResponseStatus.Connected=>"connected",
            ParticipantParticipantsResponseStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}