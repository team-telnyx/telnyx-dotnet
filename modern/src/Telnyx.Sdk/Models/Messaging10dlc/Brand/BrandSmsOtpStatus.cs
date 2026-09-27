using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// Status information for an SMS OTP sent during Sole Proprietor brand verification
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BrandSmsOtpStatus, BrandSmsOtpStatusFromRaw>))]
public sealed record class BrandSmsOtpStatus : JsonModel
{
    /// <summary>
    /// The Brand ID associated with this OTP request
    /// </summary>
    public required string BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "brandId"
            );
        }
        init { this._rawData.Set("brandId", value); }
    }

    /// <summary>
    /// The current delivery status of the OTP SMS message. Common values include:
    /// `DELIVERED_HANDSET`, `PENDING`, `FAILED`, `EXPIRED`
    /// </summary>
    public required string DeliveryStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "deliveryStatus"
            );
        }
        init { this._rawData.Set("deliveryStatus", value); }
    }

    /// <summary>
    /// The mobile phone number where the OTP was sent, in E.164 format
    /// </summary>
    public required string MobilePhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "mobilePhone"
            );
        }
        init { this._rawData.Set("mobilePhone", value); }
    }

    /// <summary>
    /// The reference ID for this OTP request, used for status queries
    /// </summary>
    public required string ReferenceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "referenceId"
            );
        }
        init { this._rawData.Set("referenceId", value); }
    }

    /// <summary>
    /// The timestamp when the OTP request was initiated
    /// </summary>
    public required DateTimeOffset RequestDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "requestDate"
            );
        }
        init { this._rawData.Set("requestDate", value); }
    }

    /// <summary>
    /// The timestamp when the delivery status was last updated
    /// </summary>
    public DateTimeOffset? DeliveryStatusDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "deliveryStatusDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deliveryStatusDate", value);
        }
    }

    /// <summary>
    /// Additional details about the delivery status
    /// </summary>
    public string? DeliveryStatusDetails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "deliveryStatusDetails"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("deliveryStatusDetails", value);
        }
    }

    /// <summary>
    /// The timestamp when the OTP was successfully verified (if applicable)
    /// </summary>
    public DateTimeOffset? VerifyDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "verifyDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verifyDate", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.DeliveryStatus;
        _ = this.MobilePhone;
        _ = this.ReferenceID;
        _ = this.RequestDate;
        _ = this.DeliveryStatusDate;
        _ = this.DeliveryStatusDetails;
        _ = this.VerifyDate;
    }

    public BrandSmsOtpStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandSmsOtpStatus (BrandSmsOtpStatus brandSmsOtpStatus) : base(
        brandSmsOtpStatus
    )
    {  }
    #pragma warning restore CS8618

    public BrandSmsOtpStatus (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSmsOtpStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandSmsOtpStatusFromRaw.FromRawUnchecked"/>
    public static BrandSmsOtpStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandSmsOtpStatusFromRaw : IFromRawJson<BrandSmsOtpStatus>
{
    /// <inheritdoc/>
    public BrandSmsOtpStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandSmsOtpStatus.FromRawUnchecked(rawData);
}