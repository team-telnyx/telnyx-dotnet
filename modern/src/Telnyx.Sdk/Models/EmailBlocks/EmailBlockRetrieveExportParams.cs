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
/// Streams the account's suppressions as a chunked CSV (server-side cursor; never
/// materialized). Content-type `text/csv`, header `Content-Disposition: attachment; filename="email_blocks_export.csv"`.
///
/// <para>Filters (`filter[reason]`, `filter[domain_id]`, `filter[created_after]`,
/// `filter[created_before]`) are the only params that affect output. `sort` and
/// `page[*]` are **parsed** (bad values still produce `400`) but **ignored** — rows
/// stream `ORDER BY created_at ASC, id ASC` with no pagination.</para>
///
/// <para>CSV columns: `id,to,from,reason,source,scope,status,domain_id, created_at,updated_at,expires_at,group_id,bounce_category,dsn_code,
/// meta` (15 columns). The first 12 columns are the stable native signature; `bounce_category`,
/// `dsn_code`, and `meta` are optional backup fields (empty when unset). The CSV
/// carries the `group_id` column so group-scoped suppressions' group link survives
/// the export (empty for account-scope rows).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class EmailBlockRetrieveExportParams : ParamsBase
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
    public ApiEnum<string, EmailBlockRetrieveExportParamsFilterReason>? FilterReason {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, EmailBlockRetrieveExportParamsFilterReason>>(
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
    public ApiEnum<string, EmailBlockRetrieveExportParamsSort>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, EmailBlockRetrieveExportParamsSort>>(
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

    public EmailBlockRetrieveExportParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockRetrieveExportParams (
        EmailBlockRetrieveExportParams emailBlockRetrieveExportParams
    ) : base(emailBlockRetrieveExportParams)
    {  }
    #pragma warning restore CS8618

    public EmailBlockRetrieveExportParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockRetrieveExportParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static EmailBlockRetrieveExportParams FromRawUnchecked(
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

    public virtual bool Equals(EmailBlockRetrieveExportParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/email_blocks/export"
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
        request.Headers.Add("Accept", "text/csv");
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
[JsonConverter(typeof(EmailBlockRetrieveExportParamsFilterReasonConverter))]
public enum EmailBlockRetrieveExportParamsFilterReason
{
    HardBounce, SpamComplaint, Unsubscribe, Invalid, ManualBlock
}

sealed class EmailBlockRetrieveExportParamsFilterReasonConverter : JsonConverter<EmailBlockRetrieveExportParamsFilterReason>
{
    public override EmailBlockRetrieveExportParamsFilterReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hard_bounce"=>EmailBlockRetrieveExportParamsFilterReason.HardBounce,
            "spam_complaint"=>EmailBlockRetrieveExportParamsFilterReason.SpamComplaint,
            "unsubscribe"=>EmailBlockRetrieveExportParamsFilterReason.Unsubscribe,
            "invalid"=>EmailBlockRetrieveExportParamsFilterReason.Invalid,
            "manual_block"=>EmailBlockRetrieveExportParamsFilterReason.ManualBlock,
            _ =>(EmailBlockRetrieveExportParamsFilterReason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailBlockRetrieveExportParamsFilterReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailBlockRetrieveExportParamsFilterReason.HardBounce=>"hard_bounce",
            EmailBlockRetrieveExportParamsFilterReason.SpamComplaint=>"spam_complaint",
            EmailBlockRetrieveExportParamsFilterReason.Unsubscribe=>"unsubscribe",
            EmailBlockRetrieveExportParamsFilterReason.Invalid=>"invalid",
            EmailBlockRetrieveExportParamsFilterReason.ManualBlock=>"manual_block",
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
[JsonConverter(typeof(EmailBlockRetrieveExportParamsSortConverter))]
public enum EmailBlockRetrieveExportParamsSort
{
    CreatedAt, CreatedAtDesc
}

sealed class EmailBlockRetrieveExportParamsSortConverter : JsonConverter<EmailBlockRetrieveExportParamsSort>
{
    public override EmailBlockRetrieveExportParamsSort Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "created_at"=>EmailBlockRetrieveExportParamsSort.CreatedAt,
            "-created_at"=>EmailBlockRetrieveExportParamsSort.CreatedAtDesc,
            _ =>(EmailBlockRetrieveExportParamsSort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailBlockRetrieveExportParamsSort value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            EmailBlockRetrieveExportParamsSort.CreatedAt=>"created_at",
            EmailBlockRetrieveExportParamsSort.CreatedAtDesc=>"-created_at",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}