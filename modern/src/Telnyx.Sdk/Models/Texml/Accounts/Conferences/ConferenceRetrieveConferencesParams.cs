using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences;

/// <summary>
/// Returns a paginated list of conference resources for the account, with support
/// for filtering by friendly name, status, and creation or update dates.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceRetrieveConferencesParams : ParamsBase
{
    public string? AccountSid { get; init; }

    /// <summary>
    /// Filters conferences by the creation date. Expected format is YYYY-MM-DD.
    /// Also accepts inequality operators, e.g. DateCreated&gt;=2023-05-22.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "DateCreated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("DateCreated", value);
        }
    }

    /// <summary>
    /// Filters conferences by the time they were last updated. Expected format is
    /// YYYY-MM-DD. Also accepts inequality operators, e.g. DateUpdated&gt;=2023-05-22.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "DateUpdated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("DateUpdated", value);
        }
    }

    /// <summary>
    /// Filters conferences by their friendly name.
    /// </summary>
    public string? FriendlyName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "FriendlyName"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("FriendlyName", value);
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
    /// Filters conferences by status.
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

    public ConferenceRetrieveConferencesParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRetrieveConferencesParams (
        ConferenceRetrieveConferencesParams conferenceRetrieveConferencesParams
    ) : base(conferenceRetrieveConferencesParams)
    { this.AccountSid = conferenceRetrieveConferencesParams.AccountSid; }
    #pragma warning restore CS8618

    public ConferenceRetrieveConferencesParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRetrieveConferencesParams (
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
    public static ConferenceRetrieveConferencesParams FromRawUnchecked(
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

    public virtual bool Equals(ConferenceRetrieveConferencesParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/texml/Accounts/{0}/Conferences",
            this.AccountSid)
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
/// Filters conferences by status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Init, InProgress, Completed
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
            "init"=>Status.Init,
            "in-progress"=>Status.InProgress,
            "completed"=>Status.Completed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Init=>"init",
            Status.InProgress=>"in-progress",
            Status.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}