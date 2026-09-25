using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Get a list of previously-submitted tollfree verification requests
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RequestListParams : ParamsBase
{
    /// <summary>
    /// Page number to retrieve (1-based).
    /// </summary>
    public required long Page {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<long>(
                "page"
            );
        }
        init { this._rawQueryData.Set("page", value); }
    }

    /// <summary>
    ///          Request this many records per page
    ///
    /// <para>        This value is automatically clamped if the provided value is
    /// too large.         </para>
    /// </summary>
    public required long PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawQueryData.Set("page_size", value); }
    }

    /// <summary>
    /// Filter verification requests by business name
    /// </summary>
    public string? BusinessName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "business_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("business_name", value);
        }
    }

    /// <summary>
    /// End of the date range filter (inclusive, ISO 8601).
    /// </summary>
    public DateTimeOffset? DateEnd {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>(
                "date_end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("date_end", value);
        }
    }

    /// <summary>
    /// Start of the date range filter (inclusive, ISO 8601).
    /// </summary>
    public DateTimeOffset? DateStart {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<DateTimeOffset>(
                "date_start"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("date_start", value);
        }
    }

    /// <summary>
    /// Filter results by phone number.
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Filter results by status.
    /// </summary>
    public ApiEnum<string, TfVerificationStatus>? Status {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, TfVerificationStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public RequestListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestListParams (RequestListParams requestListParams) : base(
        requestListParams
    )
    {  }
    #pragma warning restore CS8618

    public RequestListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RequestListParams FromRawUnchecked(
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

    public virtual bool Equals(RequestListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/messaging_tollfree/verification/requests"
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