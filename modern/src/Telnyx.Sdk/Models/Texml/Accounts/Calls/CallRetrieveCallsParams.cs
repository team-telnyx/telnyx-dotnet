using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls;

/// <summary>
/// Returns multiple call resouces for an account. This endpoint is eventually consistent.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CallRetrieveCallsParams : ParamsBase
{
    public string? AccountSid { get; init; }

    /// <summary>
    /// Filters calls by their end date. Expected format is YYYY-MM-DD
    /// </summary>
    public string? EndTime {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "EndTime"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("EndTime", value);
        }
    }

    /// <summary>
    /// Filters calls by their end date (before). Expected format is YYYY-MM-DD
    /// </summary>
    public string? EndTimeLt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "EndTime<"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("EndTime<", value);
        }
    }

    /// <summary>
    /// Filters calls by their end date (after). Expected format is YYYY-MM-DD
    /// </summary>
    public string? EndTimeGt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "EndTime>"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("EndTime>", value);
        }
    }

    /// <summary>
    /// Filters calls by the from number.
    /// </summary>
    public string? From {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "From"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("From", value);
        }
    }

    /// <summary>
    /// The number of the page to be displayed, zero-indexed, should be used in conjuction
    /// with PageToken.
    /// </summary>
    public long? Page {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "Page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("Page", value);
        }
    }

    /// <summary>
    /// The number of records to be displayed on a page
    /// </summary>
    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "PageSize"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageSize", value);
        }
    }

    /// <summary>
    /// Used to request the next page of results.
    /// </summary>
    public string? PageToken {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "PageToken"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("PageToken", value);
        }
    }

    /// <summary>
    /// Filters calls by their start date. Expected format is YYYY-MM-DD.
    /// </summary>
    public string? StartTime {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "StartTime"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("StartTime", value);
        }
    }

    /// <summary>
    /// Filters calls by their start date (before). Expected format is YYYY-MM-DD
    /// </summary>
    public string? StartTimeLt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "StartTime<"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("StartTime<", value);
        }
    }

    /// <summary>
    /// Filters calls by their start date (after). Expected format is YYYY-MM-DD
    /// </summary>
    public string? StartTimeGt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "StartTime>"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("StartTime>", value);
        }
    }

    /// <summary>
    /// Filters calls by status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>(
                "Status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("Status", value);
        }
    }

    /// <summary>
    /// Filters calls by the to number.
    /// </summary>
    public string? To {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "To"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("To", value);
        }
    }

    public CallRetrieveCallsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveCallsParams (
        CallRetrieveCallsParams callRetrieveCallsParams
    ) : base(callRetrieveCallsParams)
    { this.AccountSid = callRetrieveCallsParams.AccountSid; }
    #pragma warning restore CS8618

    public CallRetrieveCallsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveCallsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.AccountSid = accountSid;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CallRetrieveCallsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string accountSid
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            accountSid
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AccountSid"] = JsonSerializer.SerializeToElement(this.AccountSid),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(CallRetrieveCallsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AccountSid?.Equals(other.AccountSid) ?? other.AccountSid == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Calls",
            EncodePathSegment(this.AccountSid))
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
/// Filters calls by status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Canceled, Completed, Failed, Busy, NoAnswer
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
            "canceled"=>Status.Canceled,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            "busy"=>Status.Busy,
            "no-answer"=>Status.NoAnswer,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Canceled=>"canceled",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            Status.Busy=>"busy",
            Status.NoAnswer=>"no-answer",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}