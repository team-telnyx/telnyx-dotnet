using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

/// <summary>
/// Slim list-endpoint shape. Omits per-number results and webhook URLs to keep responses small.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RemediationListResponse, RemediationListResponseFromRaw>))]
public sealed record class RemediationListResponse : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string CallPurpose {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "call_purpose"
            );
        }
        init { this._rawData.Set("call_purpose", value); }
    }

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required long PhoneNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "phone_numbers_count"
            );
        }
        init { this._rawData.Set("phone_numbers_count", value); }
    }

    /// <summary>
    /// Customer-facing status of a remediation request.
    /// </summary>
    public required ApiEnum<string, RemediationStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RemediationStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public DateTimeOffset? Tier1CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "tier1_completed_at"
            );
        }
        init { this._rawData.Set("tier1_completed_at", value); }
    }

    public DateTimeOffset? Tier2CompletedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "tier2_completed_at"
            );
        }
        init { this._rawData.Set("tier2_completed_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallPurpose;
        _ = this.CreatedAt;
        _ = this.PhoneNumbersCount;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.Tier1CompletedAt;
        _ = this.Tier2CompletedAt;
    }

    public RemediationListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemediationListResponse (
        RemediationListResponse remediationListResponse
    ) : base(remediationListResponse)
    {  }
    #pragma warning restore CS8618

    public RemediationListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RemediationListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RemediationListResponseFromRaw.FromRawUnchecked"/>
    public static RemediationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RemediationListResponseFromRaw : IFromRawJson<RemediationListResponse>
{
    /// <inheritdoc/>
    public RemediationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RemediationListResponse.FromRawUnchecked(rawData);
}