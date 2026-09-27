using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrievePhoneNumberResponse, PhoneNumberRetrievePhoneNumberResponseFromRaw>))]
public sealed record class PhoneNumberRetrievePhoneNumberResponse : JsonModel
{
    public required PhoneNumberRetrievePhoneNumberResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhoneNumberRetrievePhoneNumberResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public PhoneNumberRetrievePhoneNumberResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrievePhoneNumberResponse (
        PhoneNumberRetrievePhoneNumberResponse phoneNumberRetrievePhoneNumberResponse
    ) : base(phoneNumberRetrievePhoneNumberResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrievePhoneNumberResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrievePhoneNumberResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrievePhoneNumberResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrievePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PhoneNumberRetrievePhoneNumberResponse (
        PhoneNumberRetrievePhoneNumberResponseData data
    ) : this()
    { this.Data = data; }
}

class PhoneNumberRetrievePhoneNumberResponseFromRaw : IFromRawJson<PhoneNumberRetrievePhoneNumberResponse>
{
    /// <inheritdoc/>
    public PhoneNumberRetrievePhoneNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrievePhoneNumberResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrievePhoneNumberResponseData, PhoneNumberRetrievePhoneNumberResponseDataFromRaw>))]
public sealed record class PhoneNumberRetrievePhoneNumberResponseData : JsonModel
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
    public ApiEnum<string, PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState>? CoexistenceState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState>>(
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
    public PhoneNumberRetrievePhoneNumberResponseDataSyncProgress? SyncProgress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberRetrievePhoneNumberResponseDataSyncProgress>(
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

    public PhoneNumberRetrievePhoneNumberResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrievePhoneNumberResponseData (
        PhoneNumberRetrievePhoneNumberResponseData phoneNumberRetrievePhoneNumberResponseData
    ) : base(phoneNumberRetrievePhoneNumberResponseData)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrievePhoneNumberResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrievePhoneNumberResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrievePhoneNumberResponseDataFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrievePhoneNumberResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberRetrievePhoneNumberResponseDataFromRaw : IFromRawJson<PhoneNumberRetrievePhoneNumberResponseData>
{
    /// <inheritdoc/>
    public PhoneNumberRetrievePhoneNumberResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrievePhoneNumberResponseData.FromRawUnchecked(rawData);
}/// <summary>
/// Current lifecycle state for a coexistence number. This is null for a standard
/// Cloud API number.
/// </summary>
[JsonConverter(typeof(PhoneNumberRetrievePhoneNumberResponseDataCoexistenceStateConverter))]
public enum PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState
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
}sealed class PhoneNumberRetrievePhoneNumberResponseDataCoexistenceStateConverter : JsonConverter<PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState>
{
    public override PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_onboarding"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.PendingOnboarding,
            "sync_pending"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncPending,
            "syncing"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Syncing,
            "sync_complete"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncComplete,
            "active"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Active,
            "history_declined"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.HistoryDeclined,
            "sync_deadline_expired"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncDeadlineExpired,
            "offboarded"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Offboarded,
            "disconnected"=>PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Disconnected,
            _ =>(PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.PendingOnboarding=>"pending_onboarding",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncPending=>"sync_pending",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Syncing=>"syncing",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncComplete=>"sync_complete",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Active=>"active",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.HistoryDeclined=>"history_declined",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.SyncDeadlineExpired=>"sync_deadline_expired",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Offboarded=>"offboarded",
            PhoneNumberRetrievePhoneNumberResponseDataCoexistenceState.Disconnected=>"disconnected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Synchronization progress. This object is returned only while a coexistence number
/// is synchronizing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberRetrievePhoneNumberResponseDataSyncProgress, PhoneNumberRetrievePhoneNumberResponseDataSyncProgressFromRaw>))]
public sealed record class PhoneNumberRetrievePhoneNumberResponseDataSyncProgress : JsonModel
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

    public PhoneNumberRetrievePhoneNumberResponseDataSyncProgress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRetrievePhoneNumberResponseDataSyncProgress (
        PhoneNumberRetrievePhoneNumberResponseDataSyncProgress phoneNumberRetrievePhoneNumberResponseDataSyncProgress
    ) : base(phoneNumberRetrievePhoneNumberResponseDataSyncProgress)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRetrievePhoneNumberResponseDataSyncProgress (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRetrievePhoneNumberResponseDataSyncProgress (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRetrievePhoneNumberResponseDataSyncProgressFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRetrievePhoneNumberResponseDataSyncProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneNumberRetrievePhoneNumberResponseDataSyncProgressFromRaw : IFromRawJson<PhoneNumberRetrievePhoneNumberResponseDataSyncProgress>
{
    /// <inheritdoc/>
    public PhoneNumberRetrievePhoneNumberResponseDataSyncProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRetrievePhoneNumberResponseDataSyncProgress.FromRawUnchecked(rawData);
}