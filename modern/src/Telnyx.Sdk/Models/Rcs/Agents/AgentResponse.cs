using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rcs.Agents.TestDevices;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentResponse, AgentResponseFromRaw>))]
public sealed record class AgentResponse : JsonModel
{
    public required string AgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "agent_id"
            );
        }
        init { this._rawData.Set("agent_id", value); }
    }

    public required ApiEnum<string, AgentSubmissionStatus>? BasicsStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AgentSubmissionStatus>>(
                "basics_status"
            );
        }
        init { this._rawData.Set("basics_status", value); }
    }

    public required ApiEnum<string, BillingCategory>? BillingCategory {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BillingCategory>>(
                "billing_category"
            );
        }
        init { this._rawData.Set("billing_category", value); }
    }

    public required string BrandID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "brand_id"
            );
        }
        init { this._rawData.Set("brand_id", value); }
    }

    public required ApiEnum<string, AgentSubmissionStatus>? CampaignStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AgentSubmissionStatus>>(
                "campaign_status"
            );
        }
        init { this._rawData.Set("campaign_status", value); }
    }

    public required CapabilitiesResponse Capabilities {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CapabilitiesResponse>(
                "capabilities"
            );
        }
        init { this._rawData.Set("capabilities", value); }
    }

    public required IReadOnlyList<CarrierApprovalResponse> CarrierApprovals {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<CarrierApprovalResponse>>(
                "carrier_approvals"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<CarrierApprovalResponse>>(
                "carrier_approvals",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required AgentConfiguration Configuration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<AgentConfiguration>(
                "configuration"
            );
        }
        init { this._rawData.Set("configuration", value); }
    }

    public required string DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "display_name"
            );
        }
        init { this._rawData.Set("display_name", value); }
    }

    public required string? HostingRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "hosting_region"
            );
        }
        init { this._rawData.Set("hosting_region", value); }
    }

    public required string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init { this._rawData.Set("profile_id", value); }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required IReadOnlyList<TestDeviceResponse> TestDevices {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TestDeviceResponse>>(
                "test_devices"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<TestDeviceResponse>>(
                "test_devices",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, AgentSubmissionStatus>? TestingStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AgentSubmissionStatus>>(
                "testing_status"
            );
        }
        init { this._rawData.Set("testing_status", value); }
    }

    public required ApiEnum<string, AgentUseCase> UseCase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AgentUseCase>>(
                "use_case"
            );
        }
        init { this._rawData.Set("use_case", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        this.BasicsStatus?.Validate();
        this.BillingCategory?.Validate();
        _ = this.BrandID;
        this.CampaignStatus?.Validate();
        this.Capabilities.Validate();
        foreach (var item in this.CarrierApprovals)
        {
            item.Validate();
        }
        this.Configuration.Validate();
        _ = this.DisplayName;
        _ = this.HostingRegion;
        _ = this.ProfileID;
        this.Status.Validate();
        foreach (var item in this.TestDevices)
        {
            item.Validate();
        }
        this.TestingStatus?.Validate();
        this.UseCase.Validate();
    }

    public AgentResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentResponse (AgentResponse agentResponse) : base(agentResponse)
    {  }
    #pragma warning restore CS8618

    public AgentResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AgentResponseFromRaw.FromRawUnchecked"/>
    public static AgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AgentResponseFromRaw : IFromRawJson<AgentResponse>
{
    /// <inheritdoc/>
    public AgentResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AgentResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BillingCategoryConverter))]
public enum BillingCategory
{
    NonConversational, Conversational
}sealed class BillingCategoryConverter : JsonConverter<BillingCategory>
{
    public override BillingCategory Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "NON_CONVERSATIONAL"=>BillingCategory.NonConversational,
            "CONVERSATIONAL"=>BillingCategory.Conversational,
            _ =>(BillingCategory)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BillingCategory value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BillingCategory.NonConversational=>"NON_CONVERSATIONAL",
            BillingCategory.Conversational=>"CONVERSATIONAL",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created,
    Submitted,
    Verifying,
    Verified,
    Launching,
    Launched,
    Live,
    Rejected,
    Failed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CREATED"=>Status.Created,
            "SUBMITTED"=>Status.Submitted,
            "VERIFYING"=>Status.Verifying,
            "VERIFIED"=>Status.Verified,
            "LAUNCHING"=>Status.Launching,
            "LAUNCHED"=>Status.Launched,
            "LIVE"=>Status.Live,
            "REJECTED"=>Status.Rejected,
            "FAILED"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Created=>"CREATED",
            Status.Submitted=>"SUBMITTED",
            Status.Verifying=>"VERIFYING",
            Status.Verified=>"VERIFIED",
            Status.Launching=>"LAUNCHING",
            Status.Launched=>"LAUNCHED",
            Status.Live=>"LIVE",
            Status.Rejected=>"REJECTED",
            Status.Failed=>"FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}