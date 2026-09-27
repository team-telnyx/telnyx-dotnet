using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.ActionRequirements;

[JsonConverter(typeof(JsonModelConverter<PortingActionRequirement, PortingActionRequirementFromRaw>))]
public sealed record class PortingActionRequirement : JsonModel
{
    /// <summary>
    /// Identifies the action requirement
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
    /// The type of action required
    /// </summary>
    public string? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "action_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action_type", value);
        }
    }

    /// <summary>
    /// Optional URL for the action
    /// </summary>
    public string? ActionUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "action_url"
            );
        }
        init { this._rawData.Set("action_url", value); }
    }

    /// <summary>
    /// Reason for cancellation if status is 'cancelled'
    /// </summary>
    public string? CancelReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "cancel_reason"
            );
        }
        init { this._rawData.Set("cancel_reason", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created
    /// </summary>
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

    /// <summary>
    /// The ID of the porting order this action requirement belongs to
    /// </summary>
    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource
    /// </summary>
    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// The ID of the requirement type
    /// </summary>
    public string? RequirementTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_type_id", value);
        }
    }

    /// <summary>
    /// Current status of the action requirement
    /// </summary>
    public ApiEnum<string, PortingActionRequirementStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingActionRequirementStatus>>(
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
    /// ISO 8601 formatted date-time indicating when the resource was updated
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActionType;
        _ = this.ActionUrl;
        _ = this.CancelReason;
        _ = this.CreatedAt;
        _ = this.PortingOrderID;
        this.RecordType?.Validate();
        _ = this.RequirementTypeID;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public PortingActionRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingActionRequirement (
        PortingActionRequirement portingActionRequirement
    ) : base(portingActionRequirement)
    {  }
    #pragma warning restore CS8618

    public PortingActionRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingActionRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingActionRequirementFromRaw.FromRawUnchecked"/>
    public static PortingActionRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingActionRequirementFromRaw : IFromRawJson<PortingActionRequirement>
{
    /// <inheritdoc/>
    public PortingActionRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingActionRequirement.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies the type of the resource
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    PortingActionRequirement
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_action_requirement"=>RecordType.PortingActionRequirement,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.PortingActionRequirement=>"porting_action_requirement",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Current status of the action requirement
/// </summary>
[JsonConverter(typeof(PortingActionRequirementStatusConverter))]
public enum PortingActionRequirementStatus
{
    Created, Pending, Completed, Cancelled, Failed
}sealed class PortingActionRequirementStatusConverter : JsonConverter<PortingActionRequirementStatus>
{
    public override PortingActionRequirementStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created"=>PortingActionRequirementStatus.Created,
            "pending"=>PortingActionRequirementStatus.Pending,
            "completed"=>PortingActionRequirementStatus.Completed,
            "cancelled"=>PortingActionRequirementStatus.Cancelled,
            "failed"=>PortingActionRequirementStatus.Failed,
            _ =>(PortingActionRequirementStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortingActionRequirementStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortingActionRequirementStatus.Created=>"created",
            PortingActionRequirementStatus.Pending=>"pending",
            PortingActionRequirementStatus.Completed=>"completed",
            PortingActionRequirementStatus.Cancelled=>"cancelled",
            PortingActionRequirementStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}