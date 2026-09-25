using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailMessages.Recipients;

/// <summary>
/// Lists per-recipient delivery states for a single message with cursor pagination.
/// Each recipient has an independent status, billable flag, and lifecycle timestamps.
/// BCC recipient addresses are redacted (returned as null) to protect BCC privacy.
/// Default page size is 25, maximum is 100.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RecipientListParams : ParamsBase
{
    public string? EmailID { get; init; }

    /// <summary>
    /// Filter recipients by address kind.
    /// </summary>
    public ApiEnum<string, Kind>? Kind {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Kind>>(
                "kind"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("kind", value);
        }
    }

    /// <summary>
    /// Opaque URL-safe Base64 cursor returned by a previous list response.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_cursor", value);
        }
    }

    /// <summary>
    /// Number of results to return. Defaults to 25; maximum is 100. Invalid values
    /// are clamped to the valid range.
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Filter recipients by status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>(
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

    public RecipientListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecipientListParams (RecipientListParams recipientListParams) : base(
        recipientListParams
    )
    { this.EmailID = recipientListParams.EmailID; }
    #pragma warning restore CS8618

    public RecipientListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string emailID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.EmailID = emailID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RecipientListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string emailID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            emailID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["EmailID"] = JsonSerializer.SerializeToElement(this.EmailID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(RecipientListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.EmailID?.Equals(other.EmailID) ?? other.EmailID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_messages/{0}/recipients",
            this.EmailID)
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
/// Filter recipients by address kind.
/// </summary>
[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    To, Cc, Bcc
}

sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "to"=>Kind.To, "cc"=>Kind.Cc, "bcc"=>Kind.Bcc, _ =>(Kind)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Kind value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Kind.To=>"to",
            Kind.Cc=>"cc",
            Kind.Bcc=>"bcc",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter recipients by status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Queued,
    Sending,
    Sent,
    Deferred,
    Delivered,
    Bounced,
    Failed,
    GwReject,
    Cancelled,
    InjectionTimeout,
    Expired
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued"=>Status.Queued,
            "sending"=>Status.Sending,
            "sent"=>Status.Sent,
            "deferred"=>Status.Deferred,
            "delivered"=>Status.Delivered,
            "bounced"=>Status.Bounced,
            "failed"=>Status.Failed,
            "gw_reject"=>Status.GwReject,
            "cancelled"=>Status.Cancelled,
            "injection_timeout"=>Status.InjectionTimeout,
            "expired"=>Status.Expired,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Queued=>"queued",
            Status.Sending=>"sending",
            Status.Sent=>"sent",
            Status.Deferred=>"deferred",
            Status.Delivered=>"delivered",
            Status.Bounced=>"bounced",
            Status.Failed=>"failed",
            Status.GwReject=>"gw_reject",
            Status.Cancelled=>"cancelled",
            Status.InjectionTimeout=>"injection_timeout",
            Status.Expired=>"expired",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}