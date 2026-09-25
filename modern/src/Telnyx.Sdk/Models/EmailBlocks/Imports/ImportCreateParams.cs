using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailBlocks.Imports;

/// <summary>
/// Accepts `multipart/form-data` with a `file` field (the CSV) and an optional `block_ttl_days`
/// (integer &gt;0, default 30). Validates:   - content ≤ 25 MiB, else `413`   - row
/// count ≤ 250 000, else `413`   - header-only / all-blank / undetectable provider
/// → `400` Returns `202` with the import record (status `pending`); an Oban worker
/// (`EmailBlockImportWorker`, max_attempts 3) transitions `pending → processing →
/// completed | failed`.
///
/// <para>Native Telnyx exports are detected by the stable first-12-column header
/// signature (`id` … `group_id`) and are restored with their original `from`, `domain_id`,
/// `group_id`, `source`, `status`, `expires_at`, plus `bounce_category`, `dsn_code`,
/// and `meta` when present (`scope` is re-derived from `domain_id`/`from`; the exported
/// `scope` cell must be a valid enum value). Lifecycle changes reconcile through
/// the same create path as the API: a row already in the requested state restores
/// its mutable backup fields without a new audit event, and a real transition (e.g.
/// tombstone → active) appends the matching lifecycle event. `block_ttl_days` is
/// not applied to native rows — their exported `expires_at` is preserved verbatim.</para>
///
/// <para>Competitor and generic imports (SendGrid / Mailgun / SES / generic) remain
/// account-scoped (`from`, `domain_id`, `group_id`, `scope` are not read) and `block_ttl_days`
/// applies only to imported `manual_block` rows; other reasons get `expires_at:
/// nil`. Provider is auto-detected from the CSV header (`sendgrid` / `mailgun` /
/// `ses` / `generic`).</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ImportCreateParams : ParamsBase
{
    readonly MultipartJsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, MultipartJsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// The CSV file (Plug.Upload). Missing/non-upload → 400.
    /// </summary>
    public required BinaryContent File {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<BinaryContent>(
                "file"
            );
        }
        init { this._rawBodyData.Set("file", value); }
    }

    /// <summary>
    /// TTL for imported `manual_block` rows; other reasons get `expires_at: null`.
    /// Invalid/missing → falls back to 30.
    /// </summary>
    public long? BlockTtlDays {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "block_ttl_days"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("block_ttl_days", value);
        }
    }

    public ImportCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImportCreateParams (ImportCreateParams importCreateParams) : base(
        importCreateParams
    )
    { this._rawBodyData = new(importCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public ImportCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ImportCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ImportCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, MultipartJsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, MultipartJsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ImportCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/email_blocks/import"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    { return MultipartJsonSerializer.Serialize(RawBodyData) ; }

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