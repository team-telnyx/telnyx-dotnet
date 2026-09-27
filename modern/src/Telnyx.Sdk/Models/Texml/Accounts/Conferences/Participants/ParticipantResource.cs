using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences.Participants;

[JsonConverter(typeof(JsonModelConverter<ParticipantResource, ParticipantResourceFromRaw>))]
public sealed record class ParticipantResource : JsonModel
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
    /// The version of the API that was used to make the request.
    /// </summary>
    public string? ApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_version", value);
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
    /// The identifier of this participant's call.
    /// </summary>
    public string? CallSidLegacy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid_legacy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid_legacy", value);
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
    /// The identifier of the coached participant's call.
    /// </summary>
    public string? CoachingCallSidLegacy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "coaching_call_sid_legacy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("coaching_call_sid_legacy", value);
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
    /// The timestamp of when the resource was created.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was last updated.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_updated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated", value);
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
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
        _ = this.ApiVersion;
        _ = this.CallSid;
        _ = this.CallSidLegacy;
        _ = this.Coaching;
        _ = this.CoachingCallSid;
        _ = this.CoachingCallSidLegacy;
        _ = this.ConferenceSid;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.EndConferenceOnExit;
        _ = this.Hold;
        _ = this.Muted;
        this.Status?.Validate();
        _ = this.Uri;
    }

    public ParticipantResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ParticipantResource (ParticipantResource participantResource) : base(
        participantResource
    )
    {  }
    #pragma warning restore CS8618

    public ParticipantResource (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ParticipantResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ParticipantResourceFromRaw.FromRawUnchecked"/>
    public static ParticipantResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ParticipantResourceFromRaw : IFromRawJson<ParticipantResource>
{
    /// <inheritdoc/>
    public ParticipantResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ParticipantResource.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the participant's call in the conference.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Connecting, Connected, Completed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "connecting"=>Status.Connecting,
            "connected"=>Status.Connected,
            "completed"=>Status.Completed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Connecting=>"connecting",
            Status.Connected=>"connected",
            Status.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}