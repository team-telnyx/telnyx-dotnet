using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<RoomParticipant, RoomParticipantFromRaw>))]
public sealed record class RoomParticipant : JsonModel
{
    /// <summary>
    /// A unique identifier for the room participant.
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
    /// Context provided to the given participant through the client SDK
    /// </summary>
    public string? Context {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "context"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("context", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the participant joined the session.
    /// </summary>
    public DateTimeOffset? JoinedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "joined_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("joined_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the participant left the session.
    /// </summary>
    public DateTimeOffset? LeftAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "left_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("left_at", value);
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
    /// Identify the room session that participant is part of.
    /// </summary>
    public string? SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("session_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the participant was updated.
    /// </summary>
    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Context;
        _ = this.JoinedAt;
        _ = this.LeftAt;
        _ = this.RecordType;
        _ = this.SessionID;
        _ = this.UpdatedAt;
    }

    public RoomParticipant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomParticipant (RoomParticipant roomParticipant) : base(
        roomParticipant
    )
    {  }
    #pragma warning restore CS8618

    public RoomParticipant (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomParticipant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomParticipantFromRaw.FromRawUnchecked"/>
    public static RoomParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomParticipantFromRaw : IFromRawJson<RoomParticipant>
{
    /// <inheritdoc/>
    public RoomParticipant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomParticipant.FromRawUnchecked(rawData);
}