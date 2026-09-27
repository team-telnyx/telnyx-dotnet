using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberGetResponse, PhoneNumberGetResponseFromRaw>))]
public sealed record class PhoneNumberGetResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public MessagingPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingPaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public PhoneNumberGetResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberGetResponse (
        PhoneNumberGetResponse phoneNumberGetResponse
    ) : base(phoneNumberGetResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberGetResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberGetResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberGetResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberGetResponseFromRaw : IFromRawJson<PhoneNumberGetResponse>
{
    /// <inheritdoc/>
    public PhoneNumberGetResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberGetResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public bool? CallingEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "calling_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("calling_enabled", value);
        }
    }

    /// <summary>
    /// Current lifecycle state for a coexistence number. This is null for a standard
    /// Cloud API number.
    /// </summary>
    public ApiEnum<string, DataCoexistenceState>? CoexistenceState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataCoexistenceState>>(
                "coexistence_state"
            );
        }
        init { this._rawData.Set("coexistence_state", value); }
    }

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

    public string? DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// Indicates whether the number is connected to both the WhatsApp Business app
    /// and Cloud API through WhatsApp Coexistence.
    /// </summary>
    public bool? IsOnBizApp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "is_on_biz_app"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("is_on_biz_app", value);
        }
    }

    /// <summary>
    /// Phone number in E164 format
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Whatsapp phone number ID
    /// </summary>
    public string? PhoneNumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_id", value);
        }
    }

    /// <summary>
    /// Whatsapp quality rating
    /// </summary>
    public string? QualityRating {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "quality_rating"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quality_rating", value);
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

    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Deadline for initiating the current coexistence synchronization cycle. This
    /// is null when no deadline applies.
    /// </summary>
    public System::DateTimeOffset? SyncDeadline {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "sync_deadline"
            );
        }
        init { this._rawData.Set("sync_deadline", value); }
    }

    /// <summary>
    /// Synchronization progress. This object is returned only while a coexistence
    /// number is synchronizing.
    /// </summary>
    public DataSyncProgress? SyncProgress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataSyncProgress>(
                "sync_progress"
            );
        }
        init { this._rawData.Set("sync_progress", value); }
    }

    /// <summary>
    /// User ID
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <summary>
    /// WABA ID of Whatsapp business account
    /// </summary>
    public string? WabaID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "waba_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("waba_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CallingEnabled;
        this.CoexistenceState?.Validate();
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Enabled;
        _ = this.IsOnBizApp;
        _ = this.PhoneNumber;
        _ = this.PhoneNumberID;
        _ = this.QualityRating;
        _ = this.RecordType;
        _ = this.Status;
        _ = this.SyncDeadline;
        this.SyncProgress?.Validate();
        _ = this.UserID;
        _ = this.WabaID;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// Current lifecycle state for a coexistence number. This is null for a standard
/// Cloud API number.
/// </summary>
[JsonConverter(typeof(DataCoexistenceStateConverter))]
public enum DataCoexistenceState
{
    PendingOnboarding,
    SyncPending,
    Syncing,
    SyncComplete,
    Active,
    HistoryDeclined,
    SyncDeadlineExpired,
    Offboarded,
    Disconnected
}sealed class DataCoexistenceStateConverter : JsonConverter<DataCoexistenceState>
{
    public override DataCoexistenceState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_onboarding"=>DataCoexistenceState.PendingOnboarding,
            "sync_pending"=>DataCoexistenceState.SyncPending,
            "syncing"=>DataCoexistenceState.Syncing,
            "sync_complete"=>DataCoexistenceState.SyncComplete,
            "active"=>DataCoexistenceState.Active,
            "history_declined"=>DataCoexistenceState.HistoryDeclined,
            "sync_deadline_expired"=>DataCoexistenceState.SyncDeadlineExpired,
            "offboarded"=>DataCoexistenceState.Offboarded,
            "disconnected"=>DataCoexistenceState.Disconnected,
            _ =>(DataCoexistenceState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataCoexistenceState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataCoexistenceState.PendingOnboarding=>"pending_onboarding",
            DataCoexistenceState.SyncPending=>"sync_pending",
            DataCoexistenceState.Syncing=>"syncing",
            DataCoexistenceState.SyncComplete=>"sync_complete",
            DataCoexistenceState.Active=>"active",
            DataCoexistenceState.HistoryDeclined=>"history_declined",
            DataCoexistenceState.SyncDeadlineExpired=>"sync_deadline_expired",
            DataCoexistenceState.Offboarded=>"offboarded",
            DataCoexistenceState.Disconnected=>"disconnected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Synchronization progress. This object is returned only while a coexistence number
/// is synchronizing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataSyncProgress, DataSyncProgressFromRaw>))]
public sealed record class DataSyncProgress : JsonModel
{
    public string? ContactsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contacts_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contacts_status", value);
        }
    }

    public long? HistoryChunkOrder {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "history_chunk_order"
            );
        }
        init { this._rawData.Set("history_chunk_order", value); }
    }

    public long? HistoryPhase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "history_phase"
            );
        }
        init { this._rawData.Set("history_phase", value); }
    }

    public long? HistoryProgress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "history_progress"
            );
        }
        init { this._rawData.Set("history_progress", value); }
    }

    public string? HistoryStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "history_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("history_status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContactsStatus;
        _ = this.HistoryChunkOrder;
        _ = this.HistoryPhase;
        _ = this.HistoryProgress;
        _ = this.HistoryStatus;
    }

    public DataSyncProgress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSyncProgress (DataSyncProgress dataSyncProgress) : base(
        dataSyncProgress
    )
    {  }
    #pragma warning restore CS8618

    public DataSyncProgress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSyncProgress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataSyncProgressFromRaw.FromRawUnchecked"/>
    public static DataSyncProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataSyncProgressFromRaw : IFromRawJson<DataSyncProgress>
{
    /// <inheritdoc/>
    public DataSyncProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DataSyncProgress.FromRawUnchecked(rawData);
}