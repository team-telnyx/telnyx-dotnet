using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

/// <summary>
/// Full detail of a remediation request, returned on submit and GET by id.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RemediationRequest, RemediationRequestFromRaw>))]
public sealed record class RemediationRequest : JsonModel
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

    /// <summary>
    /// Total phone numbers in this batch, including any later cancelled. May exceed
    /// the sum of the per-category result buckets, which omit cancelled numbers.
    /// </summary>
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
    /// Numbers rejected before submission (e.g. cooldown).
    /// </summary>
    public required long PhoneNumbersIneligible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "phone_numbers_ineligible"
            );
        }
        init { this._rawData.Set("phone_numbers_ineligible", value); }
    }

    /// <summary>
    /// Numbers accepted for remediation, i.e. not rejected as ineligible. Counts
    /// numbers still queued (pending) as well as processed ones.
    /// </summary>
    public required long PhoneNumbersSubmitted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "phone_numbers_submitted"
            );
        }
        init { this._rawData.Set("phone_numbers_submitted", value); }
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

    public string? ContactEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contact_email"
            );
        }
        init { this._rawData.Set("contact_email", value); }
    }

    /// <summary>
    /// Per-category buckets. Populated once results are available. Null while the
    /// request is still pending.
    /// </summary>
    public RemediationPerNumberResults? Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RemediationPerNumberResults>(
                "results"
            );
        }
        init { this._rawData.Set("results", value); }
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

    public string? WebhookUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_url"
            );
        }
        init { this._rawData.Set("webhook_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CallPurpose;
        _ = this.CreatedAt;
        _ = this.PhoneNumbersCount;
        _ = this.PhoneNumbersIneligible;
        _ = this.PhoneNumbersSubmitted;
        this.Status.Validate();
        _ = this.UpdatedAt;
        _ = this.ContactEmail;
        this.Results?.Validate();
        _ = this.Tier1CompletedAt;
        _ = this.Tier2CompletedAt;
        _ = this.WebhookUrl;
    }

    public RemediationRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemediationRequest (RemediationRequest remediationRequest) : base(
        remediationRequest
    )
    {  }
    #pragma warning restore CS8618

    public RemediationRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RemediationRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RemediationRequestFromRaw.FromRawUnchecked"/>
    public static RemediationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RemediationRequestFromRaw : IFromRawJson<RemediationRequest>
{
    /// <inheritdoc/>
    public RemediationRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RemediationRequest.FromRawUnchecked(rawData);
}