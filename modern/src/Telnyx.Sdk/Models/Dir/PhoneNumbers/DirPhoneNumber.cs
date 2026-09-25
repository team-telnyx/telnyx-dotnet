using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

namespace Telnyx.Sdk.Models.Dir.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<DirPhoneNumber, DirPhoneNumberFromRaw>))]
public sealed record class DirPhoneNumber : JsonModel
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
    /// Id of the batch this number was vetted as part of.
    /// </summary>
    public string? BatchID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "batch_id"
            );
        }
        init { this._rawData.Set("batch_id", value); }
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
    /// Id of the Letter of Authorization document attached to this number's batch.
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
    /// E.164 with leading `+`.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Populated when `status` is `unsuccessful` or `permanently_rejected`.
    /// </summary>
    public RejectionReason? RejectionReason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RejectionReason>(
                "rejection_reason"
            );
        }
        init { this._rawData.Set("rejection_reason", value); }
    }

    /// <summary>
    /// Phone-number lifecycle status. - `submitted` / `in_review` - Telnyx is reviewing
    /// the batch this number belongs to. - `verified` - approved; the DIR's display
    /// identity will be shown on outbound calls from this number. - `unsuccessful`
    /// - Telnyx rejected this submission; the customer may re-add to retry. - `suspended`
    /// - temporarily disabled (e.g. by an active infringement claim on the DIR).
    /// - `expired` - verification expired; re-add to renew. - `permanently_rejected`
    /// - terminal; cannot be re-added on this or any other DIR you own.
    /// </summary>
    public ApiEnum<string, DirPhoneNumberStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DirPhoneNumberStatus>>(
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
        _ = this.BatchID;
        _ = this.CreatedAt;
        _ = this.DirID;
        _ = this.EnterpriseID;
        _ = this.LoaDocumentID;
        _ = this.PhoneNumber;
        this.RejectionReason?.Validate();
        this.Status?.Validate();
        _ = this.UpdatedAt;
        _ = this.VerifiedAt;
    }

    public DirPhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirPhoneNumber (DirPhoneNumber dirPhoneNumber) : base(dirPhoneNumber)
    {  }
    #pragma warning restore CS8618

    public DirPhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirPhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirPhoneNumberFromRaw.FromRawUnchecked"/>
    public static DirPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirPhoneNumberFromRaw : IFromRawJson<DirPhoneNumber>
{
    /// <inheritdoc/>
    public DirPhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirPhoneNumber.FromRawUnchecked(rawData);
}