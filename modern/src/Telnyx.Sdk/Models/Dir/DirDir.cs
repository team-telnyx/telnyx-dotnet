using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.PhoneNumbers;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<DirDir, DirDirFromRaw>))]
public sealed record class DirDir : JsonModel
{
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

    public string? AuthorizerEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorizer_email"
            );
        }
        init { this._rawData.Set("authorizer_email", value); }
    }

    public string? AuthorizerName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "authorizer_name"
            );
        }
        init { this._rawData.Set("authorizer_name", value); }
    }

    public IReadOnlyList<CallReason>? CallReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallReason>>(
                "call_reasons"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallReason>?>(
                "call_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? CertifyBrandIsAccurate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "certify_brand_is_accurate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certify_brand_is_accurate", value);
        }
    }

    public bool? CertifyIPOwnership {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "certify_ip_ownership"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certify_ip_ownership", value);
        }
    }

    public bool? CertifyNoShaftContent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "certify_no_shaft_content"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("certify_no_shaft_content", value);
        }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public IReadOnlyList<Document>? Documents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Document>>(
                "documents"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Document>?>(
                "documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    public DateTimeOffset? ExpiringAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "expiring_at"
            );
        }
        init { this._rawData.Set("expiring_at", value); }
    }

    public string? LogoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_url"
            );
        }
        init { this._rawData.Set("logo_url", value); }
    }

    public DateTimeOffset? RejectedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "rejected_at"
            );
        }
        init { this._rawData.Set("rejected_at", value); }
    }

    /// <summary>
    /// Populated when `status` is `rejected`; cleared on `/submit` or successful approval.
    /// </summary>
    public IReadOnlyList<RejectionReason>? RejectionReasons {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RejectionReason>>(
                "rejection_reasons"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<RejectionReason>?>(
                "rejection_reasons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? Reselling {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reselling"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reselling", value);
        }
    }

    /// <summary>
    /// DIR lifecycle status. - `draft` - newly created; editable; not yet submitted.
    /// - `submitted` / `in_review` - Telnyx is reviewing. - `verified` - approved;
    /// phone numbers may be attached. - `rejected` - Telnyx rejected this submission;
    /// `rejection_reasons` is populated; customer can edit and resubmit. - `unsuccessful`
    /// - system-side error during processing; customer can edit and resubmit. - `suspended`
    /// - temporarily disabled (e.g. by an active infringement claim). - `expired`
    /// - verification expired; customer must resubmit. - `infringement_claimed` -
    /// a trademark/impersonation claim is open against this DIR. - `permanently_rejected`
    /// - terminal; cannot be resubmitted.
    /// </summary>
    public ApiEnum<string, DirStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DirStatus>>(
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

    public DateTimeOffset? SubmittedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "submitted_at"
            );
        }
        init { this._rawData.Set("submitted_at", value); }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public DateTimeOffset? VerifiedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "verified_at"
            );
        }
        init { this._rawData.Set("verified_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AuthorizerEmail;
        _ = this.AuthorizerName;
        foreach (var item in this.CallReasons ?? [])
        {
            item.Validate();
        }
        _ = this.CertifyBrandIsAccurate;
        _ = this.CertifyIPOwnership;
        _ = this.CertifyNoShaftContent;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.EnterpriseID;
        _ = this.ExpiringAt;
        _ = this.LogoUrl;
        _ = this.RejectedAt;
        foreach (var item in this.RejectionReasons ?? [])
        {
            item.Validate();
        }
        _ = this.Reselling;
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.UpdatedAt;
        _ = this.VerifiedAt;
    }

    public DirDir ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirDir (DirDir dirDir) : base(dirDir)
    {  }
    #pragma warning restore CS8618

    public DirDir (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirDir (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirDirFromRaw.FromRawUnchecked"/>
    public static DirDir FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirDirFromRaw : IFromRawJson<DirDir>
{
    /// <inheritdoc/>
    public DirDir FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirDir.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<CallReason, CallReasonFromRaw>))]
public sealed record class CallReason : JsonModel
{
    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Reason;
    }

    public CallReason ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallReason (CallReason callReason) : base(callReason)
    {  }
    #pragma warning restore CS8618

    public CallReason (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallReason (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallReasonFromRaw.FromRawUnchecked"/>
    public static CallReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CallReasonFromRaw : IFromRawJson<CallReason>
{
    /// <inheritdoc/>
    public CallReason FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallReason.FromRawUnchecked(rawData);
}