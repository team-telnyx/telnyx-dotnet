using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms;

[JsonConverter(typeof(JsonModelConverter<Room, RoomFromRaw>))]
public sealed record class Room : JsonModel
{
    /// <summary>
    /// A unique identifier for the room.
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
    /// The identifier of the active room session if any.
    /// </summary>
    public string? ActiveSessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "active_session_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active_session_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room was created.
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
    /// Enable or disable recording for that room.
    /// </summary>
    public bool? EnableRecording {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable_recording"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable_recording", value);
        }
    }

    /// <summary>
    /// Maximum participants allowed in the room.
    /// </summary>
    public long? MaxParticipants {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "max_participants"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("max_participants", value);
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

    public IReadOnlyList<RoomSession>? Sessions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RoomSession>>(
                "sessions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RoomSession>?>(
                "sessions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The unique (within the Telnyx account scope) name of the room.
    /// </summary>
    public string? UniqueName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unique_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unique_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room was updated.
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

    /// <summary>
    /// The failover URL where webhooks related to this room will be sent if sending
    /// to the primary URL fails. Must include a scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_failover_url", value);
        }
    }

    /// <summary>
    /// The URL where webhooks related to this room will be sent. Must include a
    /// scheme, such as 'https'.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_event_url", value);
        }
    }

    /// <summary>
    /// Specifies how many seconds to wait before timing out a webhook.
    /// </summary>
    public long? WebhookTimeoutSecs {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "webhook_timeout_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_timeout_secs", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActiveSessionID;
        _ = this.CreatedAt;
        _ = this.EnableRecording;
        _ = this.MaxParticipants;
        _ = this.RecordType;
        foreach (var item in this.Sessions ?? [])
        {
            item.Validate();
        }
        _ = this.UniqueName;
        _ = this.UpdatedAt;
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
        _ = this.WebhookTimeoutSecs;
    }

    public Room ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Room (Room room) : base(room)
    {  }
    #pragma warning restore CS8618

    public Room (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Room (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RoomFromRaw.FromRawUnchecked"/>
    public static Room FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RoomFromRaw : IFromRawJson<Room>
{
    /// <inheritdoc/>
    public Room FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Room.FromRawUnchecked(rawData);
}