using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Dir;

/// <summary>
/// Returns every DIR (Display Identity Record) you own, across all of your enterprises,
/// as a single list. Pagination is JSON:API style (`page[number]`, `page[size]`,
/// max 250). Supports `filter[]` query params: `filter[enterprise_id]`, `filter[status]`,
/// `filter[display_name][contains]`, `filter[call_reason][contains]`, plus the renewal-window
/// filters `filter[expiring_at][gte]` / `filter[expiring_at][lte]`. Sortable by
/// `created_at`, `updated_at`, `display_name`, `status` (prefix `-` for descending;
/// default `-created_at`).
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DirListParams : ParamsBase
{
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
    /// Filter by enterprise ID.
    /// </summary>
    public string? FilterEnterpriseID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[enterprise_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[enterprise_id]", value);
        }
    }

    /// <summary>
    /// Return only DIRs whose `expiring_at` is at or after this ISO-8601 timestamp.
    /// Pairs with the `[lte]` variant to build renewal-window dashboards.
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
    /// Filter by DIR status.
    /// </summary>
    public ApiEnum<string, DirStatus>? FilterStatus {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, DirStatus>>(
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
    /// Sort field. Allowed values: `created_at`, `updated_at`, `display_name`, `status`.
    /// Prefix with `-` for descending. Default `-created_at`.
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
    {  }
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
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DirListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DirListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/dir"
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
/// Sort field. Allowed values: `created_at`, `updated_at`, `display_name`, `status`.
/// Prefix with `-` for descending. Default `-created_at`.
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
    StatusDesc
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
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}