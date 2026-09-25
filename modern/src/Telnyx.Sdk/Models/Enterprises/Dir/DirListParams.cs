using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Dir = Telnyx.Sdk.Models.Dir;

namespace Telnyx.Sdk.Models.Enterprises.Dir;

/// <summary>
/// Return the DIRs (Display Identity Records) belonging to a single enterprise. Pagination
/// is JSON:API style (`page[number]`, `page[size]`, max 250). Supports `filter[]`
/// query params: `filter[status]`, `filter[display_name][contains]`, `filter[call_reason][contains]`,
/// plus the renewal-window filters `filter[expiring_at][gte]` / `filter[expiring_at][lte]`
/// and the convenience `filter[expiring_within_days]` (mutually exclusive with the
/// explicit gte/lte form). Sortable by `created_at`, `updated_at`, `display_name`,
/// `status`, `submitted_at`, `verified_at`, `expiring_at` (prefix `-` for descending;
/// default `-created_at`).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirListParams : ParamsBase
{
    public string? EnterpriseID { get; init; }

    /// <summary>
    /// Case-insensitive partial match on call reason.
    /// </summary>
    public string? FilterCallReasonContains {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[call_reason][contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[call_reason][contains]", value);
        }
    }

    /// <summary>
    /// Case-insensitive partial match on display name.
    /// </summary>
    public string? FilterDisplayNameContains {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[display_name][contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[display_name][contains]", value);
        }
    }

    /// <summary>
    /// Return only DIRs whose `expiring_at` is at or after this ISO-8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterExpiringAtGte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[expiring_at][gte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[expiring_at][gte]", value);
        }
    }

    /// <summary>
    /// Return only DIRs whose `expiring_at` is at or before this ISO-8601 timestamp.
    /// </summary>
    public System::DateTimeOffset? FilterExpiringAtLte {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[expiring_at][lte]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[expiring_at][lte]", value);
        }
    }

    /// <summary>
    /// Convenience: returns DIRs whose `expiring_at` falls within the next N days
    /// (1–365). Equivalent to setting `filter[expiring_at][gte]=&lt;now&gt;` + `filter[expiring_at][lte]=&lt;now+N&gt;`.
    /// Mutually exclusive with the explicit `[gte]`/`[lte]` filters - combining returns 400.
    /// </summary>
    public long? FilterExpiringWithinDays {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "filter[expiring_within_days]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[expiring_within_days]", value);
        }
    }

    /// <summary>
    /// Filter by DIR status.
    /// </summary>
    public ApiEnum<string, Dir::DirStatus>? FilterStatus {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Dir::DirStatus>>(
                "filter[status]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[status]", value);
        }
    }

    /// <summary>
    /// 1-based page number. Out-of-range values return an empty page with correct meta.
    /// </summary>
    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    /// <summary>
    /// Items per page. Maximum 250; values above are clamped to 250.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// Sort field. Allowed: `created_at`, `updated_at`, `display_name`, `status`,
    /// `submitted_at`, `verified_at`, `expiring_at`. Prefix with `-` for descending.
    /// Default `-created_at`.
    /// </summary>
    public ApiEnum<string, Sort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Sort>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort", value);
        }
    }

    public DirListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirListParams (DirListParams dirListParams) : base(dirListParams)
    { this.EnterpriseID = dirListParams.EnterpriseID; }
    #pragma warning restore CS8618

    public DirListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string enterpriseID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EnterpriseID = enterpriseID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DirListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string enterpriseID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            enterpriseID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EnterpriseID"] = JsonSerializer.SerializeToElement(this.EnterpriseID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DirListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EnterpriseID?.Equals(other.EnterpriseID) ?? other.EnterpriseID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/enterprises/{0}/dir",
            this.EnterpriseID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Sort field. Allowed: `created_at`, `updated_at`, `display_name`, `status`, `submitted_at`,
/// `verified_at`, `expiring_at`. Prefix with `-` for descending. Default `-created_at`.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt,
    CreatedAtDesc,
    UpdatedAt,
    UpdatedAtDesc,
    DisplayName,
    MinusDisplayName,
    Status,
    StatusDesc,
    SubmittedAt,
    MinusSubmittedAt,
    VerifiedAt,
    MinusVerifiedAt,
    ExpiringAt,
    MinusExpiringAt
}

sealed class SortConverter : JsonConverter<Sort>
{
    public override Sort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>Sort.CreatedAt,
            "-created_at"=>Sort.CreatedAtDesc,
            "updated_at"=>Sort.UpdatedAt,
            "-updated_at"=>Sort.UpdatedAtDesc,
            "display_name"=>Sort.DisplayName,
            "-display_name"=>Sort.MinusDisplayName,
            "status"=>Sort.Status,
            "-status"=>Sort.StatusDesc,
            "submitted_at"=>Sort.SubmittedAt,
            "-submitted_at"=>Sort.MinusSubmittedAt,
            "verified_at"=>Sort.VerifiedAt,
            "-verified_at"=>Sort.MinusVerifiedAt,
            "expiring_at"=>Sort.ExpiringAt,
            "-expiring_at"=>Sort.MinusExpiringAt,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.CreatedAtDesc=>"-created_at",
            Sort.UpdatedAt=>"updated_at",
            Sort.UpdatedAtDesc=>"-updated_at",
            Sort.DisplayName=>"display_name",
            Sort.MinusDisplayName=>"-display_name",
            Sort.Status=>"status",
            Sort.StatusDesc=>"-status",
            Sort.SubmittedAt=>"submitted_at",
            Sort.MinusSubmittedAt=>"-submitted_at",
            Sort.VerifiedAt=>"verified_at",
            Sort.MinusVerifiedAt=>"-verified_at",
            Sort.ExpiringAt=>"expiring_at",
            Sort.MinusExpiringAt=>"-expiring_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}