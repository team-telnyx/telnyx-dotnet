using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents;

[JsonConverter(typeof(JsonModelConverter<CarrierApprovalResponse, CarrierApprovalResponseFromRaw>))]
public sealed record class CarrierApprovalResponse : JsonModel
{
    public required string ApprovalID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "approval_id"
            );
        }
        init { this._rawData.Set("approval_id", value); }
    }

    public required System::DateTimeOffset? ApprovedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "approved_at"
            );
        }
        init { this._rawData.Set("approved_at", value); }
    }

    public required string? Carrier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "carrier"
            );
        }
        init { this._rawData.Set("carrier", value); }
    }

    public required string? RejectedReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rejected_reason"
            );
        }
        init { this._rawData.Set("rejected_reason", value); }
    }

    public required ApiEnum<string, ScopeType> ScopeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ScopeType>>(
                "scope_type"
            );
        }
        init { this._rawData.Set("scope_type", value); }
    }

    public required ApiEnum<string, CarrierApprovalResponseStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CarrierApprovalResponseStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required System::DateTimeOffset? SubmittedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "submitted_at"
            );
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApprovalID;
        _ = this.ApprovedAt;
        _ = this.Carrier;
        _ = this.RejectedReason;
        this.ScopeType.Validate();
        this.Status.Validate();
        _ = this.SubmittedAt;
    }

    public CarrierApprovalResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CarrierApprovalResponse (
        CarrierApprovalResponse carrierApprovalResponse
    ) : base(carrierApprovalResponse)
    {  }
    #pragma warning restore CS8618

    public CarrierApprovalResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CarrierApprovalResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CarrierApprovalResponseFromRaw.FromRawUnchecked"/>
    public static CarrierApprovalResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CarrierApprovalResponseFromRaw : IFromRawJson<CarrierApprovalResponse>
{
    /// <inheritdoc/>
    public CarrierApprovalResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CarrierApprovalResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ScopeTypeConverter))]
public enum ScopeType
{
    Carrier, Hub, Bot
}sealed class ScopeTypeConverter : JsonConverter<ScopeType>
{
    public override ScopeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "carrier"=>ScopeType.Carrier,
            "hub"=>ScopeType.Hub,
            "bot"=>ScopeType.Bot,
            _ =>(ScopeType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ScopeType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ScopeType.Carrier=>"carrier",
            ScopeType.Hub=>"hub",
            ScopeType.Bot=>"bot",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(CarrierApprovalResponseStatusConverter))]
public enum CarrierApprovalResponseStatus
{
    Pending, Submitted, Approved, Rejected
}sealed class CarrierApprovalResponseStatusConverter : JsonConverter<CarrierApprovalResponseStatus>
{
    public override CarrierApprovalResponseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING"=>CarrierApprovalResponseStatus.Pending,
            "SUBMITTED"=>CarrierApprovalResponseStatus.Submitted,
            "APPROVED"=>CarrierApprovalResponseStatus.Approved,
            "REJECTED"=>CarrierApprovalResponseStatus.Rejected,
            _ =>(CarrierApprovalResponseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CarrierApprovalResponseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            CarrierApprovalResponseStatus.Pending=>"PENDING",
            CarrierApprovalResponseStatus.Submitted=>"SUBMITTED",
            CarrierApprovalResponseStatus.Approved=>"APPROVED",
            CarrierApprovalResponseStatus.Rejected=>"REJECTED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}