using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Dir.PhoneNumbers;

namespace Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

/// <summary>
/// A phone-number batch groups all numbers added in a single bulk-add request. Telnyx
/// vets the batch as a unit. The response embeds the full `phone_numbers` array
/// so you can read per-number status without a separate call, plus a batch-level
/// `status` summarising the unit's progress.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberBatch, PhoneNumberBatchFromRaw>))]
public sealed record class PhoneNumberBatch : JsonModel
{
    public string? BatchID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "batch_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("batch_id", value);
        }
    }

    /// <summary>
    /// The DIR's display name at the time the batch was read.
    /// </summary>
    public string? DirDisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dir_display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dir_display_name", value);
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

    /// <summary>
    /// Documents attached to this batch (e.g. a Letter of Authorization). Empty when
    /// none were supplied at add time.
    /// </summary>
    public IReadOnlyList<Document>? Documents {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Document>>(
                "documents"
            );
        }
        init {
            if (value == null) {
                return;
            }

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

    /// <summary>
    /// All phone numbers in this batch, with per-number status.
    /// </summary>
    public IReadOnlyList<DirPhoneNumber>? PhoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DirPhoneNumber>>(
                "phone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DirPhoneNumber>?>(
                "phone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Aggregate batch status. Mirrors the values used on individual phone numbers
    /// (`submitted`, `in_review`, `verified`, `unsuccessful`, `permanently_rejected`, etc.).
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

    /// <summary>
    /// When the batch was created (and implicitly submitted for vetting).
    /// </summary>
    public DateTimeOffset? SubmittedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <summary>
    /// Number of phone numbers in this batch (length of `phone_numbers`).
    /// </summary>
    public long? TotalCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BatchID;
        _ = this.DirDisplayName;
        _ = this.DirID;
        foreach (var item in this.Documents ?? [])
        {
            item.Validate();
        }
        _ = this.EnterpriseID;
        foreach (var item in this.PhoneNumbers ?? [])
        {
            item.Validate();
        }
        this.Status?.Validate();
        _ = this.SubmittedAt;
        _ = this.TotalCount;
    }

    public PhoneNumberBatch ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBatch (PhoneNumberBatch phoneNumberBatch) : base(
        phoneNumberBatch
    )
    {  }
    #pragma warning restore CS8618

    public PhoneNumberBatch (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBatch (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberBatchFromRaw.FromRawUnchecked"/>
    public static PhoneNumberBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberBatchFromRaw : IFromRawJson<PhoneNumberBatch>
{
    /// <inheritdoc/>
    public PhoneNumberBatch FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberBatch.FromRawUnchecked(rawData);
}