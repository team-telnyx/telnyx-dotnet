using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<RoomSession, RoomSessionFromRaw>))]
public sealed record class RoomSession : JsonModel
{
    /// <summary>
    /// A unique identifier for the room session.
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
    /// Shows if the room session is active or not.
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room session was created.
    /// </summary>
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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
    /// ISO 8601 timestamp when the room session has ended.
    /// </summary>
    public DateTimeOffset? EndedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "ended_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ended_at", value);
        }
    }

    public IReadOnlyList<RoomParticipant>? Participants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RoomParticipant>>(
                "participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RoomParticipant>?>(
                "participants",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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
    /// Identify the room hosting that room session.
    /// </summary>
    public string? RoomID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "room_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("room_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room session was updated.
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
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.EndedAt;
        foreach (var item in this.Participants ?? [])
        {
            item.Validate();
        }
        _ = this.RecordType;
        _ = this.RoomID;
        _ = this.UpdatedAt;
    }

    public RoomSession ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RoomSession (RoomSession roomSession) : base(roomSession)
    {  }
    #pragma warning restore CS8618

    public RoomSession (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RoomSession (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomSessionFromRaw.FromRawUnchecked"/>
    public static RoomSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomSessionFromRaw : IFromRawJson<RoomSession>
{
    /// <inheritdoc/>
    public RoomSession FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RoomSession.FromRawUnchecked(rawData);
}