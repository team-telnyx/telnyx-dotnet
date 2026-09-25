using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberCampaigns;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberCampaign, PhoneNumberCampaignFromRaw>))]
public sealed record class PhoneNumberCampaign : JsonModel
{
    /// <summary>
    /// For shared campaigns, this is the TCR campaign ID, otherwise it is the campaign
    /// ID
    /// </summary>
    public required string CampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "campaignId"
            );
        }
        init { this._rawData.Set("campaignId", value); }
    }

    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "createdAt"
            );
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phoneNumber"
            );
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updatedAt"
            );
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// The assignment status of the number.
    /// </summary>
    public ApiEnum<string, AssignmentStatus>? AssignmentStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AssignmentStatus>>(
                "assignmentStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assignmentStatus", value);
        }
    }

    /// <summary>
    /// Brand ID. Empty if the number is associated to a shared campaign.
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
    /// Extra info about a failure to assign/unassign a number. Relevant only if
    /// the assignmentStatus is either FAILED_ASSIGNMENT or FAILED_UNASSIGNMENT
    /// </summary>
    public string? FailureReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "failureReasons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("failureReasons", value);
        }
    }

    /// <summary>
    /// The assignment status of the number towards other carriers.
    /// </summary>
    public string? NonTmobileNumberMappingStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "nonTmobileNumberMappingStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("nonTmobileNumberMappingStatus", value);
        }
    }

    /// <summary>
    /// TCR's alphanumeric ID for the brand.
    /// </summary>
    public string? TcrBrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcrBrandId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcrBrandId", value);
        }
    }

    /// <summary>
    /// TCR's alphanumeric ID for the campaign.
    /// </summary>
    public string? TcrCampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tcrCampaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tcrCampaignId", value);
        }
    }

    /// <summary>
    /// Campaign ID. Empty if the number is associated to a shared campaign.
    /// </summary>
    public string? TelnyxCampaignID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telnyxCampaignId"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telnyxCampaignId", value);
        }
    }

    /// <summary>
    /// The T-Mobile assignment status of the number.
    /// </summary>
    public string? TmobileNumberMappingStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tmobileNumberMappingStatus"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tmobileNumberMappingStatus", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CampaignID;
        _ = this.CreatedAt;
        _ = this.PhoneNumber;
        _ = this.UpdatedAt;
        this.AssignmentStatus?.Validate();
        _ = this.BrandID;
        _ = this.FailureReasons;
        _ = this.NonTmobileNumberMappingStatus;
        _ = this.TcrBrandID;
        _ = this.TcrCampaignID;
        _ = this.TelnyxCampaignID;
        _ = this.TmobileNumberMappingStatus;
    }

    public PhoneNumberCampaign ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberCampaign (PhoneNumberCampaign phoneNumberCampaign) : base(
        phoneNumberCampaign
    )
    {  }
    #pragma warning restore CS8618

    public PhoneNumberCampaign (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberCampaign (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberCampaignFromRaw.FromRawUnchecked"/>
    public static PhoneNumberCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberCampaignFromRaw : IFromRawJson<PhoneNumberCampaign>
{
    /// <inheritdoc/>
    public PhoneNumberCampaign FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberCampaign.FromRawUnchecked(rawData);
}

/// <summary>
/// The assignment status of the number.
/// </summary>
[JsonConverter(typeof(AssignmentStatusConverter))]
public enum AssignmentStatus
{
    FailedAssignment,
    PendingAssignment,
    Assigned,
    PendingUnassignment,
    FailedUnassignment
}sealed class AssignmentStatusConverter : JsonConverter<AssignmentStatus>
{
    public override AssignmentStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "FAILED_ASSIGNMENT"=>AssignmentStatus.FailedAssignment,
            "PENDING_ASSIGNMENT"=>AssignmentStatus.PendingAssignment,
            "ASSIGNED"=>AssignmentStatus.Assigned,
            "PENDING_UNASSIGNMENT"=>AssignmentStatus.PendingUnassignment,
            "FAILED_UNASSIGNMENT"=>AssignmentStatus.FailedUnassignment,
            _ =>(AssignmentStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AssignmentStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AssignmentStatus.FailedAssignment=>"FAILED_ASSIGNMENT",
            AssignmentStatus.PendingAssignment=>"PENDING_ASSIGNMENT",
            AssignmentStatus.Assigned=>"ASSIGNED",
            AssignmentStatus.PendingUnassignment=>"PENDING_UNASSIGNMENT",
            AssignmentStatus.FailedUnassignment=>"FAILED_UNASSIGNMENT",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}