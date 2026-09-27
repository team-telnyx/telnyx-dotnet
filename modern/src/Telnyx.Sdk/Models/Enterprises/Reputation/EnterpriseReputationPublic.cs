using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Enterprises.Reputation;

[JsonConverter(typeof(JsonModelConverter<EnterpriseReputationPublic, EnterpriseReputationPublicFromRaw>))]
public sealed record class EnterpriseReputationPublic : JsonModel
{
    /// <summary>
    /// How often Telnyx refreshes the stored reputation data for this enterprise's
    /// registered numbers.
    /// </summary>
    public ApiEnum<string, ReputationCheckFrequency>? CheckFrequency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReputationCheckFrequency>>(
                "check_frequency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("check_frequency", value);
        }
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

    public string? EnterpriseID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "enterprise_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enterprise_id", value);
        }
    }

    /// <summary>
    /// Id of the signed LOA document.
    /// </summary>
    public string? LoaDocumentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "loa_document_id"
            );
        }
        init { this._rawData.Set("loa_document_id", value); }
    }

    /// <summary>
    /// Customer-facing Letter-of-Authorization verification state. `approved` is
    /// required (alongside reputation status) before phone numbers can be added.
    /// </summary>
    public ApiEnum<string, LoaStatus>? LoaStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, LoaStatus>>(
                "loa_status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("loa_status", value);
        }
    }

    /// <summary>
    /// Populated when `status` is `rejected`.
    /// </summary>
    public IReadOnlyList<string>? RejectionReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "rejection_reasons"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>?>(
                "rejection_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Lifecycle status of the enterprise's Phone Number Reputation activation.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
        this.CheckFrequency?.Validate();
        _ = this.CreatedAt;
        _ = this.EnterpriseID;
        _ = this.LoaDocumentID;
        this.LoaStatus?.Validate();
        _ = this.RejectionReasons;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public EnterpriseReputationPublic ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterpriseReputationPublic (
        EnterpriseReputationPublic enterpriseReputationPublic
    ) : base(enterpriseReputationPublic)
    {  }
    #pragma warning restore CS8618

    public EnterpriseReputationPublic (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EnterpriseReputationPublic (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EnterpriseReputationPublicFromRaw.FromRawUnchecked"/>
    public static EnterpriseReputationPublic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EnterpriseReputationPublicFromRaw : IFromRawJson<EnterpriseReputationPublic>
{
    /// <inheritdoc/>
    public EnterpriseReputationPublic FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EnterpriseReputationPublic.FromRawUnchecked(rawData);
}

/// <summary>
/// Customer-facing Letter-of-Authorization verification state. `approved` is required
/// (alongside reputation status) before phone numbers can be added.
/// </summary>
[JsonConverter(typeof(LoaStatusConverter))]
public enum LoaStatus
{
    Pending, Approved, Rejected
}sealed class LoaStatusConverter : JsonConverter<LoaStatus>
{
    public override LoaStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>LoaStatus.Pending,
            "approved"=>LoaStatus.Approved,
            "rejected"=>LoaStatus.Rejected,
            _ =>(LoaStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, LoaStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LoaStatus.Pending=>"pending",
            LoaStatus.Approved=>"approved",
            LoaStatus.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Lifecycle status of the enterprise's Phone Number Reputation activation.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Approved, Deleted, Rejected
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
            "pending"=>Status.Pending,
            "approved"=>Status.Approved,
            "deleted"=>Status.Deleted,
            "rejected"=>Status.Rejected,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Approved=>"approved",
            Status.Deleted=>"deleted",
            Status.Rejected=>"rejected",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}