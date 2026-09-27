using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailBlocks;

/// <summary>
/// Account-scoped list. Two mutually exclusive pagination modes:
///
/// <para>  - **Offset**: `page[number]` (default 1) + `page[size]`     (default
/// 25, max 100). `meta` contains `total_pages`.   - **Cursor**: `page[after]` and/or
/// `page[before]` (opaque     `Base.url_encode64` of `{"created_at","id"}`). Cannot
/// combine     with `page[number]`; `after`+`before` together is an error.     `meta`
/// contains `next_cursor` / `previous_cursor` (omitted when     their flag is false).</para>
///
/// <para>Sort defaults to `-created_at` (desc); only `created_at` is sortable. A
/// `--` prefix is an error. `nil`/empty filter values are silently dropped.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailBlockListParams : ParamsBase
{
    /// <summary>
    /// `created_at &gt; value` (ISO 8601).
    /// </summary>
    public System::DateTimeOffset? FilterCreatedAfter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[created_after]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[created_after]", value);
        }
    }

    /// <summary>
    /// `created_at &lt; value` (ISO 8601).
    /// </summary>
    public System::DateTimeOffset? FilterCreatedBefore {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "filter[created_before]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[created_before]", value);
        }
    }

    /// <summary>
    /// Exact-match filter on domain_id (UUID).
    /// </summary>
    public string? FilterDomainID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[domain_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[domain_id]", value);
        }
    }

    /// <summary>
    /// Exact-match filter on reason.
    /// </summary>
    public ApiEnum<string, FilterReason>? FilterReason {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterReason>>(
                "filter[reason]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[reason]", value);
        }
    }

    /// <summary>
    /// Opaque cursor (`Base.url_encode64` of `{"created_at","id"}`). Cursor mode;
    /// mutually exclusive with `page[number]` and `page[before]`.
    /// </summary>
    public string? PageAfter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[after]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[after]", value);
        }
    }

    /// <summary>
    /// Opaque cursor (see `page[after]`). Mutually exclusive with `page[after]`
    /// and `page[number]`.
    /// </summary>
    public string? PageBefore {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[before]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[before]", value);
        }
    }

    /// <summary>
    /// Offset page number (≥1, default 1).
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
    /// Page size (1–100, default 25).
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
    /// Sort field. Leading `-` = desc; only `created_at` is sortable. Default `-created_at`.
    /// `--` is an error.
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

    public EmailBlockListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockListParams (
        EmailBlockListParams emailBlockListParams
    ) : base(emailBlockListParams)
    {  }
    #pragma warning restore CS8618

    public EmailBlockListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailBlockListParams FromRawUnchecked(
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

    public virtual bool Equals(EmailBlockListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/email_blocks"
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
/// Exact-match filter on reason.
/// </summary>
[JsonConverter(typeof(FilterReasonConverter))]
public enum FilterReason
{
    HardBounce, SpamComplaint, Unsubscribe, Invalid, ManualBlock
}

sealed class FilterReasonConverter : JsonConverter<FilterReason>
{
    public override FilterReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hard_bounce"=>FilterReason.HardBounce,
            "spam_complaint"=>FilterReason.SpamComplaint,
            "unsubscribe"=>FilterReason.Unsubscribe,
            "invalid"=>FilterReason.Invalid,
            "manual_block"=>FilterReason.ManualBlock,
            _ =>(FilterReason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterReason value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterReason.HardBounce=>"hard_bounce",
            FilterReason.SpamComplaint=>"spam_complaint",
            FilterReason.Unsubscribe=>"unsubscribe",
            FilterReason.Invalid=>"invalid",
            FilterReason.ManualBlock=>"manual_block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sort field. Leading `-` = desc; only `created_at` is sortable. Default `-created_at`.
/// `--` is an error.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt, CreatedAtDesc
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
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}