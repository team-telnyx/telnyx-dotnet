using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceParticipant, ConferenceParticipantFromRaw>))]
public sealed record class ConferenceParticipant : JsonModel
{
    /// <summary>
    /// Uniquely identifies the participant.
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
    /// Unique identifier and token for controlling the participant's call leg.
    /// </summary>
    public string? CallControlID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_control_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_control_id", value);
        }
    }

    /// <summary>
    /// Unique identifier for the call leg.
    /// </summary>
    public string? CallLegID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_leg_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_leg_id", value);
        }
    }

    /// <summary>
    /// Unique identifier for the conference.
    /// </summary>
    public string? ConferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "conference_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("conference_id", value);
        }
    }

    /// <summary>
    /// Timestamp when the participant joined.
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
    /// Whether the conference ends when this participant exits.
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
    /// Label assigned to the participant when joining.
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
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
    /// Whether the participant is on hold.
    /// </summary>
    public bool? OnHold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "on_hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_hold", value);
        }
    }

    /// <summary>
    /// Whether the conference soft-ends when this participant exits.
    /// </summary>
    public bool? SoftEndConferenceOnExit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "soft_end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("soft_end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Status of the participant.
    /// </summary>
    public ApiEnum<string, ConferenceParticipantStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceParticipantStatus>>(
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
    /// Timestamp when the participant was last updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// List of call control IDs this participant is whispering to.
    /// </summary>
    public IReadOnlyList<string>? WhisperCallControlIds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "whisper_call_control_ids"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "whisper_call_control_ids",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallControlID;
        _ = this.CallLegID;
        _ = this.ConferenceID;
        _ = this.CreatedAt;
        _ = this.EndConferenceOnExit;
        _ = this.Label;
        _ = this.Muted;
        _ = this.OnHold;
        _ = this.SoftEndConferenceOnExit;
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.WhisperCallControlIds;
    }

    public ConferenceParticipant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceParticipant (
        ConferenceParticipant conferenceParticipant
    ) : base(conferenceParticipant)
    {  }
    #pragma warning restore CS8618

    public ConferenceParticipant (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceParticipant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceParticipantFromRaw.FromRawUnchecked"/>
    public static ConferenceParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceParticipantFromRaw : IFromRawJson<ConferenceParticipant>
{
    /// <inheritdoc/>
    public ConferenceParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceParticipant.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the participant.
/// </summary>
[JsonConverter(typeof(ConferenceParticipantStatusConverter))]
public enum ConferenceParticipantStatus
{
    Joining, Joined, Left
}sealed class ConferenceParticipantStatusConverter : JsonConverter<ConferenceParticipantStatus>
{
    public override ConferenceParticipantStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "joining"=>ConferenceParticipantStatus.Joining,
            "joined"=>ConferenceParticipantStatus.Joined,
            "left"=>ConferenceParticipantStatus.Left,
            _ =>(ConferenceParticipantStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceParticipantStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceParticipantStatus.Joining=>"joining",
            ConferenceParticipantStatus.Joined=>"joined",
            ConferenceParticipantStatus.Left=>"left",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}