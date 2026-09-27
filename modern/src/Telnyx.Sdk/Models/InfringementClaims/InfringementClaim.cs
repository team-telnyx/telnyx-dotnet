using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir;

namespace Telnyx.Sdk.Models.InfringementClaims;

[JsonConverter(typeof(JsonModelConverter<InfringementClaim, InfringementClaimFromRaw>))]
public sealed record class InfringementClaim : JsonModel
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

    /// <summary>
    /// When the claim was filed (set by the claimant's representative at file time).
    /// </summary>
    public System::DateTimeOffset? ClaimDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "claim_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("claim_date", value);
        }
    }

    public string? ClaimDescription {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "claim_description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("claim_description", value);
        }
    }

    /// <summary>
    /// Category of infringement being claimed.
    /// </summary>
    public ApiEnum<string, ClaimType>? ClaimType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ClaimType>>(
                "claim_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("claim_type", value);
        }
    }

    public string? ClaimantContact {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "claimant_contact"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("claimant_contact", value);
        }
    }

    public string? ClaimantName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "claimant_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("claimant_name", value);
        }
    }

    /// <summary>
    /// Aggregated across all customer contest submissions on this claim.
    /// </summary>
    public IReadOnlyList<Document>? ContestDocuments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Document>>(
                "contest_documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Document>?>(
                "contest_documents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Per-round submission audit trail. Each entry records one `POST /infringement_claims/{id}/contest`
    /// call (notes, timestamp, document count). Aggregated documents live on `contest_documents`.
    /// </summary>
    public IReadOnlyList<ContestHistory>? ContestHistory {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ContestHistory>>(
                "contest_history"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ContestHistory>?>(
                "contest_history",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// Snapshot of the DIR the claim is filed against, embedded for convenience.
    /// </summary>
    public InfringementClaimDir? Dir {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<InfringementClaimDir>(
                "dir"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dir", value);
        }
    }

    public string? DirID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dir_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dir_id", value);
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
    /// Set only when `status` is `resolved`.
    /// </summary>
    public ApiEnum<string, Resolution>? Resolution {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Resolution>>(
                "resolution"
            );
        }
        init { this._rawData.Set("resolution", value); }
    }

    public System::DateTimeOffset? ResolutionDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "resolution_date"
            );
        }
        init { this._rawData.Set("resolution_date", value); }
    }

    public string? ResolutionNotes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resolution_notes"
            );
        }
        init { this._rawData.Set("resolution_notes", value); }
    }

    /// <summary>
    /// Lifecycle status. `pending` - newly filed; the DIR is auto-suspended. `contested`
    /// - you have submitted contest evidence; awaiting Telnyx review. `resolved`
    /// - final.
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
        _ = this.ID;
        _ = this.ClaimDate;
        _ = this.ClaimDescription;
        this.ClaimType?.Validate();
        _ = this.ClaimantContact;
        _ = this.ClaimantName;
        foreach (var item in this.ContestDocuments ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.ContestHistory ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        this.Dir?.Validate();
        _ = this.DirID;
        _ = this.EnterpriseID;
        this.Resolution?.Validate();
        _ = this.ResolutionDate;
        _ = this.ResolutionNotes;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public InfringementClaim ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfringementClaim (InfringementClaim infringementClaim) : base(
        infringementClaim
    )
    {  }
    #pragma warning restore CS8618

    public InfringementClaim (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InfringementClaim (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InfringementClaimFromRaw.FromRawUnchecked"/>
    public static InfringementClaim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InfringementClaimFromRaw : IFromRawJson<InfringementClaim>
{
    /// <inheritdoc/>
    public InfringementClaim FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InfringementClaim.FromRawUnchecked(rawData);
}

/// <summary>
/// Category of infringement being claimed.
/// </summary>
[JsonConverter(typeof(ClaimTypeConverter))]
public enum ClaimType
{
    Trademark, Copyright
}sealed class ClaimTypeConverter : JsonConverter<ClaimType>
{
    public override ClaimType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "trademark"=>ClaimType.Trademark,
            "copyright"=>ClaimType.Copyright,
            _ =>(ClaimType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ClaimType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ClaimType.Trademark=>"trademark",
            ClaimType.Copyright=>"copyright",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// One round of customer contest evidence on an infringement claim. The aggregated
/// documents across rounds live on the parent claim's `contest_documents`; this
/// submission record carries only the per-round notes and document count.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContestHistory, ContestHistoryFromRaw>))]
public sealed record class ContestHistory : JsonModel
{
    public long? DocumentCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "document_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("document_count", value);
        }
    }

    public string? Notes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "notes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("notes", value);
        }
    }

    public System::DateTimeOffset? SubmittedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "submitted_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("submitted_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DocumentCount;
        _ = this.Notes;
        _ = this.SubmittedAt;
    }

    public ContestHistory ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContestHistory (ContestHistory contestHistory) : base(contestHistory)
    {  }
    #pragma warning restore CS8618

    public ContestHistory (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ContestHistory (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ContestHistoryFromRaw.FromRawUnchecked"/>
    public static ContestHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ContestHistoryFromRaw : IFromRawJson<ContestHistory>
{
    /// <inheritdoc/>
    public ContestHistory FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ContestHistory.FromRawUnchecked(rawData);
}/// <summary>
/// Snapshot of the DIR the claim is filed against, embedded for convenience.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<InfringementClaimDir, InfringementClaimDirFromRaw>))]
public sealed record class InfringementClaimDir : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DisplayName;
        _ = this.EnterpriseID;
        this.Status?.Validate();
    }

    public InfringementClaimDir ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfringementClaimDir (
        InfringementClaimDir infringementClaimDir
    ) : base(infringementClaimDir)
    {  }
    #pragma warning restore CS8618

    public InfringementClaimDir (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InfringementClaimDir (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InfringementClaimDirFromRaw.FromRawUnchecked"/>
    public static InfringementClaimDir FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class InfringementClaimDirFromRaw : IFromRawJson<InfringementClaimDir>
{
    /// <inheritdoc/>
    public InfringementClaimDir FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InfringementClaimDir.FromRawUnchecked(rawData);
}/// <summary>
/// Set only when `status` is `resolved`.
/// </summary>
[JsonConverter(typeof(ResolutionConverter))]
public enum Resolution
{
    Upheld, Rejected, Modified
}sealed class ResolutionConverter : JsonConverter<Resolution>
{
    public override Resolution Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "upheld"=>Resolution.Upheld,
            "rejected"=>Resolution.Rejected,
            "modified"=>Resolution.Modified,
            _ =>(Resolution)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Resolution value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Resolution.Upheld=>"upheld",
            Resolution.Rejected=>"rejected",
            Resolution.Modified=>"modified",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Lifecycle status. `pending` - newly filed; the DIR is auto-suspended. `contested`
/// - you have submitted contest evidence; awaiting Telnyx review. `resolved` - final.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Contested, Resolved
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
            "contested"=>Status.Contested,
            "resolved"=>Status.Resolved,
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
            Status.Contested=>"contested",
            Status.Resolved=>"resolved",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}