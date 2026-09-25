using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<CampaignStatusUpdate, CampaignStatusUpdateFromRaw>))]
public sealed record class CampaignStatusUpdate : JsonModel
{
    /// <summary>
    /// Brand ID associated with the campaign.
    /// </summary>
    public string? BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "brandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("brandId", value);
        }
    }

    /// <summary>
    /// The ID of the campaign.
    /// </summary>
    public string? CampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "campaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("campaignId", value);
        }
    }

    /// <summary>
    /// Unix timestamp when campaign was created.
    /// </summary>
    public string? CreateDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "createDate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("createDate", value);
        }
    }

    /// <summary>
    /// Alphanumeric identifier of the CSP associated with this campaign.
    /// </summary>
    public string? CspID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cspId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cspId", value);
        }
    }

    /// <summary>
    /// Description of the event.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Indicates whether the campaign is registered with T-Mobile.
    /// </summary>
    public bool? IsTMobileRegistered {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "isTMobileRegistered"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("isTMobileRegistered", value);
        }
    }

    /// <summary>
    /// The status of the campaign.
    /// </summary>
    public ApiEnum<string, CampaignStatusUpdateStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CampaignStatusUpdateStatus>>(
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

    public ApiEnum<string, global::Telnyx.Sdk.Models.Webhooks.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Webhooks.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandID;
        _ = this.CampaignID;
        _ = this.CreateDate;
        _ = this.CspID;
        _ = this.Description;
        _ = this.IsTMobileRegistered;
        this.Status?.Validate();
        this.Type?.Validate();
    }

    public CampaignStatusUpdate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignStatusUpdate (
        CampaignStatusUpdate campaignStatusUpdate
    ) : base(campaignStatusUpdate)
    {  }
    #pragma warning restore CS8618

    public CampaignStatusUpdate (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignStatusUpdate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignStatusUpdateFromRaw.FromRawUnchecked"/>
    public static CampaignStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignStatusUpdateFromRaw : IFromRawJson<CampaignStatusUpdate>
{
    /// <inheritdoc/>
    public CampaignStatusUpdate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignStatusUpdate.FromRawUnchecked(rawData);
}

/// <summary>
/// The status of the campaign.
/// </summary>
[JsonConverter(typeof(CampaignStatusUpdateStatusConverter))]
public enum CampaignStatusUpdateStatus
{
    Accepted, Rejected, Dormant, Success, Failed
}sealed class CampaignStatusUpdateStatusConverter : JsonConverter<CampaignStatusUpdateStatus>
{
    public override CampaignStatusUpdateStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ACCEPTED"=>CampaignStatusUpdateStatus.Accepted,
            "REJECTED"=>CampaignStatusUpdateStatus.Rejected,
            "DORMANT"=>CampaignStatusUpdateStatus.Dormant,
            "success"=>CampaignStatusUpdateStatus.Success,
            "failed"=>CampaignStatusUpdateStatus.Failed,
            _ =>(CampaignStatusUpdateStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CampaignStatusUpdateStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CampaignStatusUpdateStatus.Accepted=>"ACCEPTED",
            CampaignStatusUpdateStatus.Rejected=>"REJECTED",
            CampaignStatusUpdateStatus.Dormant=>"DORMANT",
            CampaignStatusUpdateStatus.Success=>"success",
            CampaignStatusUpdateStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    TelnyxEvent,
    Registration,
    MnoReview,
    TelnyxReview,
    NumberPoolProvisioned,
    NumberPoolDeprovisioned,
    TcrEvent,
    Verified
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Webhooks.Type>
{
    public override global::Telnyx.Sdk.Models.Webhooks.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TELNYX_EVENT"=>global::Telnyx.Sdk.Models.Webhooks.Type.TelnyxEvent,
            "REGISTRATION"=>global::Telnyx.Sdk.Models.Webhooks.Type.Registration,
            "MNO_REVIEW"=>global::Telnyx.Sdk.Models.Webhooks.Type.MnoReview,
            "TELNYX_REVIEW"=>global::Telnyx.Sdk.Models.Webhooks.Type.TelnyxReview,
            "NUMBER_POOL_PROVISIONED"=>global::Telnyx.Sdk.Models.Webhooks.Type.NumberPoolProvisioned,
            "NUMBER_POOL_DEPROVISIONED"=>global::Telnyx.Sdk.Models.Webhooks.Type.NumberPoolDeprovisioned,
            "TCR_EVENT"=>global::Telnyx.Sdk.Models.Webhooks.Type.TcrEvent,
            "VERIFIED"=>global::Telnyx.Sdk.Models.Webhooks.Type.Verified,
            _ =>(global::Telnyx.Sdk.Models.Webhooks.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Webhooks.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Webhooks.Type.TelnyxEvent=>"TELNYX_EVENT",
            global::Telnyx.Sdk.Models.Webhooks.Type.Registration=>"REGISTRATION",
            global::Telnyx.Sdk.Models.Webhooks.Type.MnoReview=>"MNO_REVIEW",
            global::Telnyx.Sdk.Models.Webhooks.Type.TelnyxReview=>"TELNYX_REVIEW",
            global::Telnyx.Sdk.Models.Webhooks.Type.NumberPoolProvisioned=>"NUMBER_POOL_PROVISIONED",
            global::Telnyx.Sdk.Models.Webhooks.Type.NumberPoolDeprovisioned=>"NUMBER_POOL_DEPROVISIONED",
            global::Telnyx.Sdk.Models.Webhooks.Type.TcrEvent=>"TCR_EVENT",
            global::Telnyx.Sdk.Models.Webhooks.Type.Verified=>"VERIFIED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}