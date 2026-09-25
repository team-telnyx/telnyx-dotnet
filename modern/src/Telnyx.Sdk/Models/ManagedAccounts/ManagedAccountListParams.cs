using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ManagedAccounts;

/// <summary>
/// Lists the accounts managed by the current user. Users need to be explictly approved
/// by Telnyx in order to become manager accounts.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ManagedAccountListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[email][contains],
    /// filter[email][eq], filter[organization_name][contains], filter[organization_name][eq], filter[status][eq]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    /// <summary>
    /// Specifies if cancelled accounts should be included in the results.
    /// </summary>
    public bool? IncludeCancelledAccounts {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_cancelled_accounts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_cancelled_accounts", value);
        }
    }

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
    /// Specifies the sort order for results. By default sorting direction is ascending.
    /// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
    /// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;email&lt;/code&gt;:
    /// sorts the result by the     &lt;code&gt;email&lt;/code&gt; field in ascending
    /// order.   &lt;/li&gt;
    ///
    /// <para>  &lt;li&gt;     &lt;code&gt;-email&lt;/code&gt;: sorts the result by
    /// the     &lt;code&gt;email&lt;/code&gt; field in descending order.   &lt;/li&gt;
    /// &lt;/ul&gt; &lt;br/&gt; If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
    /// in descending order.</para>
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

    public ManagedAccountListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountListParams (
        ManagedAccountListParams managedAccountListParams
    ) : base(managedAccountListParams)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ManagedAccountListParams FromRawUnchecked(
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

    public virtual bool Equals(ManagedAccountListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/managed_accounts"
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
/// Consolidated filter parameter (deepObject style). Originally: filter[email][contains],
/// filter[email][eq], filter[organization_name][contains], filter[organization_name][eq], filter[status][eq]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    public Email? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Email>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    public OrganizationName? OrganizationName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OrganizationName>(
                "organization_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_name", value);
        }
    }

    public Status? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Status>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Email?.Validate();
        this.OrganizationName?.Validate();
        this.Status?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Email, EmailFromRaw>))]
public sealed record class Email : JsonModel
{
    /// <summary>
    /// If present, email containing the given value will be returned. Matching is
    /// not case-sensitive. Requires at least three characters.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// If present, only returns results with the &lt;code&gt;email&lt;/code&gt;
    /// matching exactly the value given.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.Eq;
    }

    public Email ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Email (Email email) : base(email)
    {  }
    #pragma warning restore CS8618

    public Email (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Email (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailFromRaw.FromRawUnchecked"/>
    public static Email FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailFromRaw : IFromRawJson<Email>
{
    /// <inheritdoc/>
    public Email FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Email.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<OrganizationName, OrganizationNameFromRaw>))]
public sealed record class OrganizationName : JsonModel
{
    /// <summary>
    /// If present, only returns results with the &lt;code&gt;organization_name&lt;/code&gt;
    /// containing the given value. Matching is not case-sensitive. Requires at least
    /// three characters.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <summary>
    /// If present, only returns results with the &lt;code&gt;organization_name&lt;/code&gt;
    /// matching exactly the value given.
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Contains;
        _ = this.Eq;
    }

    public OrganizationName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrganizationName (OrganizationName organizationName) : base(
        organizationName
    )
    {  }
    #pragma warning restore CS8618

    public OrganizationName (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OrganizationName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrganizationNameFromRaw.FromRawUnchecked"/>
    public static OrganizationName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OrganizationNameFromRaw : IFromRawJson<OrganizationName>
{
    /// <inheritdoc/>
    public OrganizationName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OrganizationName.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Status, StatusFromRaw>))]
public sealed record class Status : JsonModel
{
    /// <summary>
    /// If present, only returns managed accounts with the &lt;code&gt;status&lt;/code&gt;
    /// matching exactly the value given. Use &lt;code&gt;enabled&lt;/code&gt; or
    /// &lt;code&gt;disabled&lt;/code&gt; to filter accounts by whether they are currently
    /// able to use Telnyx services.
    /// </summary>
    public ApiEnum<string, Eq>? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Eq>>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Eq?.Validate(); }

    public Status ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Status (Status status) : base(status)
    {  }
    #pragma warning restore CS8618

    public Status (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Status (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="StatusFromRaw.FromRawUnchecked"/>
    public static Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class StatusFromRaw : IFromRawJson<Status>
{
    /// <inheritdoc/>
    public Status FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Status.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, only returns managed accounts with the &lt;code&gt;status&lt;/code&gt;
/// matching exactly the value given. Use &lt;code&gt;enabled&lt;/code&gt; or &lt;code&gt;disabled&lt;/code&gt;
/// to filter accounts by whether they are currently able to use Telnyx services.
/// </summary>
[JsonConverter(typeof(EqConverter))]
public enum Eq
{
    All, Active, Enabled, Cancelled, Disabled, Blocked
}

sealed class EqConverter : JsonConverter<Eq>
{
    public override Eq Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all"=>Eq.All,
            "active"=>Eq.Active,
            "enabled"=>Eq.Enabled,
            "cancelled"=>Eq.Cancelled,
            "disabled"=>Eq.Disabled,
            "blocked"=>Eq.Blocked,
            _ =>(Eq)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Eq value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Eq.All=>"all",
            Eq.Active=>"active",
            Eq.Enabled=>"enabled",
            Eq.Cancelled=>"cancelled",
            Eq.Disabled=>"disabled",
            Eq.Blocked=>"blocked",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Specifies the sort order for results. By default sorting direction is ascending.
/// To have the results sorted in descending order add the &lt;code&gt; -&lt;/code&gt;
/// prefix.&lt;br/&gt;&lt;br/&gt; That is: &lt;ul&gt;   &lt;li&gt;     &lt;code&gt;email&lt;/code&gt;:
/// sorts the result by the     &lt;code&gt;email&lt;/code&gt; field in ascending
/// order.   &lt;/li&gt;
///
/// <para>  &lt;li&gt;     &lt;code&gt;-email&lt;/code&gt;: sorts the result by the
///     &lt;code&gt;email&lt;/code&gt; field in descending order.   &lt;/li&gt; &lt;/ul&gt;
/// &lt;br/&gt; If not given, results are sorted by &lt;code&gt;created_at&lt;/code&gt;
/// in descending order.</para>
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt, Email
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
        { "created_at"=>Sort.CreatedAt, "email"=>Sort.Email, _ =>(Sort)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.Email=>"email",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}