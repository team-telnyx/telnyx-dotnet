using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts;

[JsonConverter(typeof(JsonModelConverter<PortoutDetails, PortoutDetailsFromRaw>))]
public sealed record class PortoutDetails : JsonModel
{
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
    /// Is true when the number is already ported
    /// </summary>
    public bool? AlreadyPorted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "already_ported"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("already_ported", value);
        }
    }

    /// <summary>
    /// Name of person authorizing the porting order
    /// </summary>
    public string? AuthorizedName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorized_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("authorized_name", value);
        }
    }

    /// <summary>
    /// Carrier the number will be ported out to
    /// </summary>
    public string? CarrierName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("carrier_name", value);
        }
    }

    /// <summary>
    /// City or municipality of billing address
    /// </summary>
    public string? City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the portout was created
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// The current carrier
    /// </summary>
    public string? CurrentCarrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "current_carrier"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("current_carrier", value);
        }
    }

    /// <summary>
    /// Person name or company name requesting the port
    /// </summary>
    public string? EndUserName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_user_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_user_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted Date/Time of the FOC date
    /// </summary>
    public string? FocDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "foc_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("foc_date", value);
        }
    }

    /// <summary>
    /// Indicates whether messaging services should be maintained with Telnyx after
    /// the port out completes
    /// </summary>
    public bool? HostMessaging {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "host_messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("host_messaging", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the portout was created
    /// </summary>
    public string? InsertedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "inserted_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inserted_at", value);
        }
    }

    /// <summary>
    /// The Local Service Request
    /// </summary>
    public IReadOnlyList<string>? Lsr {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "lsr"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "lsr",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone numbers associated with this portout
    /// </summary>
    public IReadOnlyList<string>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Port order number assigned by the carrier the number will be ported out to
    /// </summary>
    public string? Pon {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pon"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pon", value);
        }
    }

    /// <summary>
    /// The reason why the order is being rejected by the user. If the order is authorized,
    /// this field can be left null
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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
    /// The rejection code for one of the valid rejections to reject a port out order
    /// </summary>
    public long? RejectionCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "rejection_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rejection_code", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted Date/Time of the user requested FOC date
    /// </summary>
    public string? RequestedFocDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requested_foc_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requested_foc_date", value);
        }
    }

    /// <summary>
    /// First line of billing address (street address)
    /// </summary>
    public string? ServiceAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "service_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("service_address", value);
        }
    }

    /// <summary>
    /// New service provider spid
    /// </summary>
    public string? Spid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("spid", value);
        }
    }

    /// <summary>
    /// State, province, or similar of billing address
    /// </summary>
    public string? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    /// <summary>
    /// Status of portout request
    /// </summary>
    public ApiEnum<string, PortoutDetailsStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortoutDetailsStatus>>(
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
    /// A key to reference this port out request when contacting Telnyx customer support
    /// </summary>
    public string? SupportKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "support_key"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("support_key", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date of when the portout was last updated
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Identifies the user (or organization) who requested the port out
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
    /// Telnyx partner providing network coverage
    /// </summary>
    public string? Vendor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "vendor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("vendor", value);
        }
    }

    /// <summary>
    /// Postal Code of billing address
    /// </summary>
    public string? Zip {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zip", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AlreadyPorted;
        _ = this.AuthorizedName;
        _ = this.CarrierName;
        _ = this.City;
        _ = this.CreatedAt;
        _ = this.CurrentCarrier;
        _ = this.EndUserName;
        _ = this.FocDate;
        _ = this.HostMessaging;
        _ = this.InsertedAt;
        _ = this.Lsr;
        _ = this.PhoneNumbers;
        _ = this.Pon;
        _ = this.Reason;
        _ = this.RecordType;
        _ = this.RejectionCode;
        _ = this.RequestedFocDate;
        _ = this.ServiceAddress;
        _ = this.Spid;
        _ = this.State;
        this.Status?.Validate();
        _ = this.SupportKey;
        _ = this.UpdatedAt;
        _ = this.UserID;
        _ = this.Vendor;
        _ = this.Zip;
    }

    public PortoutDetails ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutDetails (PortoutDetails portoutDetails) : base(portoutDetails)
    {  }
    #pragma warning restore CS8618

    public PortoutDetails (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutDetails (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutDetailsFromRaw.FromRawUnchecked"/>
    public static PortoutDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutDetailsFromRaw : IFromRawJson<PortoutDetails>
{
    /// <inheritdoc/>
    public PortoutDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutDetails.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of portout request
/// </summary>
[JsonConverter(typeof(PortoutDetailsStatusConverter))]
public enum PortoutDetailsStatus
{
    Pending, Authorized, Ported, Rejected, RejectedPending, Canceled
}sealed class PortoutDetailsStatusConverter : JsonConverter<PortoutDetailsStatus>
{
    public override PortoutDetailsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>PortoutDetailsStatus.Pending,
            "authorized"=>PortoutDetailsStatus.Authorized,
            "ported"=>PortoutDetailsStatus.Ported,
            "rejected"=>PortoutDetailsStatus.Rejected,
            "rejected-pending"=>PortoutDetailsStatus.RejectedPending,
            "canceled"=>PortoutDetailsStatus.Canceled,
            _ =>(PortoutDetailsStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortoutDetailsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortoutDetailsStatus.Pending=>"pending",
            PortoutDetailsStatus.Authorized=>"authorized",
            PortoutDetailsStatus.Ported=>"ported",
            PortoutDetailsStatus.Rejected=>"rejected",
            PortoutDetailsStatus.RejectedPending=>"rejected-pending",
            PortoutDetailsStatus.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}