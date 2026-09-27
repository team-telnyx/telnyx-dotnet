using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.BusinessAccounts;

[JsonConverter(typeof(JsonModelConverter<BusinessAccountRetrieveResponse, BusinessAccountRetrieveResponseFromRaw>))]
public sealed record class BusinessAccountRetrieveResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public BusinessAccountRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BusinessAccountRetrieveResponse (
        BusinessAccountRetrieveResponse businessAccountRetrieveResponse
    ) : base(businessAccountRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BusinessAccountRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BusinessAccountRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BusinessAccountRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BusinessAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BusinessAccountRetrieveResponseFromRaw : IFromRawJson<BusinessAccountRetrieveResponse>
{
    /// <inheritdoc/>
    public BusinessAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BusinessAccountRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Internal ID of Whatsapp business account
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
    /// Account review status of Whatsapp business account
    /// </summary>
    public string? AccountReviewStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_review_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_review_status", value);
        }
    }

    /// <summary>
    /// Business verification status of Whatsapp business account
    /// </summary>
    public string? BusinessVerificationStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "business_verification_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("business_verification_status", value);
        }
    }

    /// <summary>
    /// Country associated with Whatsapp business account
    /// </summary>
    public string? Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

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
    /// Name of Whatsapp business account
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Count of phone numbers associated with Whatsapp business account
    /// </summary>
    public long? PhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "phone_numbers_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_numbers_count", value);
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
    /// Status of Whatsapp business account
    /// </summary>
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
        _ = this.ID;
        _ = this.AccountReviewStatus;
        _ = this.BusinessVerificationStatus;
        _ = this.Country;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.PhoneNumbersCount;
        _ = this.RecordType;
        _ = this.Status;
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
}