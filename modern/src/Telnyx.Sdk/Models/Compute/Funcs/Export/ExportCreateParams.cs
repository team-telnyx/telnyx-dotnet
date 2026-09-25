using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Compute.Funcs.Export;

/// <summary>
/// Configures the external OTLP endpoint a function's runtime and/or invocation
/// logs are pushed to as they happen. This operation is a **full replace, not a patch**:
/// `endpoint`, `headers`, `runtime_export_enabled`, and `invocation_export_enabled`
/// are all required on every call — omitting any of them is a 422, not "keep the
/// current value". Headers are encrypted at rest and never returned in any response.
///
/// <para>The endpoint must be an HTTPS URL. When export is configured, new log records
/// are converted to OTLP log records and delivered continuously; export never bypasses
/// platform log storage, and delivery retries with a bounded policy while the destination
/// is unreachable. Only logs generated after configuration are exported — there
/// is no historical replay.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExportCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// HTTPS URL to push logs to
    /// </summary>
    public required string Endpoint {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "endpoint"
            );
        }
        init { this._rawBodyData.Set("endpoint", value); }
    }

    /// <summary>
    /// Headers attached to every export push, as key-value pairs (e.g. an auth token
    /// the collector expects). Required even when empty — {} means "no headers".
    /// Encrypted at rest; never returned.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Headers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, string>>(
                "headers"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, string>>(
                "headers",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Export invocation records (one per HTTP request) to this destination
    /// </summary>
    public required bool InvocationExportEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>(
                "invocation_export_enabled"
            );
        }
        init { this._rawBodyData.Set("invocation_export_enabled", value); }
    }

    /// <summary>
    /// Export runtime logs (function stdout/stderr) to this destination
    /// </summary>
    public required bool RuntimeExportEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<bool>(
                "runtime_export_enabled"
            );
        }
        init { this._rawBodyData.Set("runtime_export_enabled", value); }
    }

    public ExportCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExportCreateParams (ExportCreateParams exportCreateParams) : base(
        exportCreateParams
    )
    {
        this.ID = exportCreateParams.ID;

        this._rawBodyData = new(exportCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ExportCreateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExportCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExportCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ExportCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/compute/funcs/{0}/logs/export",
            this.ID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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