using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Organizations.Users;

/// <summary>
/// Returns a list of the users in your organization.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UserListParams : ParamsBase
{
    /// <summary>
    /// Filter by email address (partial match)
    /// </summary>
    public string? FilterEmail {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[email]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[email]", value);
        }
    }

    /// <summary>
    /// Filter by user status
    /// </summary>
    public ApiEnum<string, FilterUserStatus>? FilterUserStatus {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterUserStatus>>(
                "filter[user_status]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[user_status]", value);
        }
    }

    /// <summary>
    /// When set to true, includes the groups array for each user in the response.
    /// The groups array contains objects with id and name for each group the user
    /// belongs to.
    /// </summary>
    public bool? IncludeGroups {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_groups"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_groups", value);
        }
    }

    /// <summary>
    /// The page number to load
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
    /// The size of the page
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

    public UserListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserListParams (UserListParams userListParams) : base(userListParams)
    {  }
    #pragma warning restore CS8618

    public UserListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UserListParams FromRawUnchecked(
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

    public virtual bool Equals(UserListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/organizations/users"
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
/// Filter by user status
/// </summary>
[JsonConverter(typeof(FilterUserStatusConverter))]
public enum FilterUserStatus
{
    Enabled, Disabled, Blocked
}

sealed class FilterUserStatusConverter : JsonConverter<FilterUserStatus>
{
    public override FilterUserStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enabled"=>FilterUserStatus.Enabled,
            "disabled"=>FilterUserStatus.Disabled,
            "blocked"=>FilterUserStatus.Blocked,
            _ =>(FilterUserStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterUserStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterUserStatus.Enabled=>"enabled",
            FilterUserStatus.Disabled=>"disabled",
            FilterUserStatus.Blocked=>"blocked",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}