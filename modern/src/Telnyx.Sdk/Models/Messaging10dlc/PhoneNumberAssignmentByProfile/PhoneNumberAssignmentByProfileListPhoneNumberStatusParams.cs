using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.PhoneNumberAssignmentByProfile;

/// <summary>
/// Check the status of the individual phone number/campaign assignments associated
/// with the supplied `taskId`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberAssignmentByProfileListPhoneNumberStatusParams : ParamsBase
{
    public string? TaskID { get; init; }

    /// <summary>
    /// Page number to retrieve (1-based).
    /// </summary>
    public long? Page {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page", value);
        }
    }

    /// <summary>
    /// Number of records to return per page.
    /// </summary>
    public long? RecordsPerPage {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "recordsPerPage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("recordsPerPage", value);
        }
    }

    public PhoneNumberAssignmentByProfileListPhoneNumberStatusParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignmentByProfileListPhoneNumberStatusParams (
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams phoneNumberAssignmentByProfileListPhoneNumberStatusParams
    ) : base(phoneNumberAssignmentByProfileListPhoneNumberStatusParams)
    {
        this.TaskID = phoneNumberAssignmentByProfileListPhoneNumberStatusParams.TaskID;
    }
    #pragma warning restore CS8618

    public PhoneNumberAssignmentByProfileListPhoneNumberStatusParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignmentByProfileListPhoneNumberStatusParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string taskID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.TaskID = taskID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberAssignmentByProfileListPhoneNumberStatusParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string taskID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            taskID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["TaskID"] = JsonSerializer.SerializeToElement(this.TaskID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(
        PhoneNumberAssignmentByProfileListPhoneNumberStatusParams? other
    )
    {
        if (other == null)
        {
            return false;
        }
        return (this.TaskID?.Equals(other.TaskID) ?? other.TaskID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/phoneNumberAssignmentByProfile/{0}/phoneNumbers",
            EncodePathSegment(this.TaskID))
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