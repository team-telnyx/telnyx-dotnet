using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<CapabilitiesResponse, CapabilitiesResponseFromRaw>))]
public sealed record class CapabilitiesResponse : JsonModel
{
    public required bool BrandEntity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "brand_entity"
            );
        }
        init { this._rawData.Set("brand_entity", value); }
    }

    public required bool BrandVerification {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "brand_verification"
            );
        }
        init { this._rawData.Set("brand_verification", value); }
    }

    public required bool Campaigns {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "campaigns"
            );
        }
        init { this._rawData.Set("campaigns", value); }
    }

    public required bool DistinctLaunchPhase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "distinct_launch_phase"
            );
        }
        init { this._rawData.Set("distinct_launch_phase", value); }
    }

    public required bool InviteTestDevices {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "invite_test_devices"
            );
        }
        init { this._rawData.Set("invite_test_devices", value); }
    }

    public required bool PerCarrierApproval {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "per_carrier_approval"
            );
        }
        init { this._rawData.Set("per_carrier_approval", value); }
    }

    public required bool SubmissionSections {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "submission_sections"
            );
        }
        init { this._rawData.Set("submission_sections", value); }
    }

    public required bool Templates {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "templates"
            );
        }
        init { this._rawData.Set("templates", value); }
    }

    public required bool VendorWebhooks {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "vendor_webhooks"
            );
        }
        init { this._rawData.Set("vendor_webhooks", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BrandEntity;
        _ = this.BrandVerification;
        _ = this.Campaigns;
        _ = this.DistinctLaunchPhase;
        _ = this.InviteTestDevices;
        _ = this.PerCarrierApproval;
        _ = this.SubmissionSections;
        _ = this.Templates;
        _ = this.VendorWebhooks;
    }

    public CapabilitiesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CapabilitiesResponse (
        CapabilitiesResponse capabilitiesResponse
    ) : base(capabilitiesResponse)
    {  }
    #pragma warning restore CS8618

    public CapabilitiesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CapabilitiesResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CapabilitiesResponseFromRaw.FromRawUnchecked"/>
    public static CapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CapabilitiesResponseFromRaw : IFromRawJson<CapabilitiesResponse>
{
    /// <inheritdoc/>
    public CapabilitiesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CapabilitiesResponse.FromRawUnchecked(rawData);
}