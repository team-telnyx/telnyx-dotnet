using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

/// <summary>
/// Lists the CloudFS filesystems for the authenticated user's organization. Results
/// use cursor-based pagination: fetch the next page by passing `meta.cursors.after`
/// as `page[after]`, or follow the `meta.next` URL.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class CloudfListParams : ParamsBase
{
    /// <summary>
    /// Return only the filesystem whose name matches exactly.
    /// </summary>
    public string? FilterName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[name]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[name]", value);
        }
    }

    /// <summary>
    /// Return only filesystems in this region.
    /// </summary>
    public string? FilterRegion {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[region]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[region]", value);
        }
    }

    /// <summary>
    /// Return only filesystems with this status. Unrecognized values are ignored.
    /// </summary>
    public ApiEnum<string, FilterStatus>? FilterStatus {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterStatus>>(
                "filter[status]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[status]", value);
        }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `meta.cursors.after`; returns the
    /// page after it. Mutually exclusive with `page[before]`.
    /// </summary>
    public string? PageAfter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[after]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[after]", value);
        }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `meta.cursors.before`; returns the
    /// page before it. Mutually exclusive with `page[after]`.
    /// </summary>
    public string? PageBefore {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "page[before]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[before]", value);
        }
    }

    /// <summary>
    /// The number of filesystems to return per page. Values above 250 are treated
    /// as 250.
    /// </summary>
    public long? PageLimit {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[limit]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[limit]", value);
        }
    }

    /// <summary>
    /// Sort order for the results: a field name for ascending, or the field name
    /// prefixed with `-` for descending.
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

    public CloudfListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CloudfListParams (CloudfListParams cloudfListParams) : base(
        cloudfListParams
    )
    {  }
    #pragma warning restore CS8618

    public CloudfListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CloudfListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static CloudfListParams FromRawUnchecked(
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

    public virtual bool Equals(CloudfListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/storage/cloudfs"
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
/// Return only filesystems with this status. Unrecognized values are ignored.
/// </summary>
[JsonConverter(typeof(FilterStatusConverter))]
public enum FilterStatus
{
    Provisioning, Ready, NeedsFormat, Deleting, Failed
}

sealed class FilterStatusConverter : JsonConverter<FilterStatus>
{
    public override FilterStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "provisioning"=>FilterStatus.Provisioning,
            "ready"=>FilterStatus.Ready,
            "needs_format"=>FilterStatus.NeedsFormat,
            "deleting"=>FilterStatus.Deleting,
            "failed"=>FilterStatus.Failed,
            _ =>(FilterStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterStatus.Provisioning=>"provisioning",
            FilterStatus.Ready=>"ready",
            FilterStatus.NeedsFormat=>"needs_format",
            FilterStatus.Deleting=>"deleting",
            FilterStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sort order for the results: a field name for ascending, or the field name prefixed
/// with `-` for descending.
/// </summary>
[JsonConverter(typeof(SortConverter))]
public enum Sort
{
    CreatedAt, CreatedAtDesc, UpdatedAt, UpdatedAtDesc, Name, NameDesc
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
        {
            "created_at"=>Sort.CreatedAt,
            "-created_at"=>Sort.CreatedAtDesc,
            "updated_at"=>Sort.UpdatedAt,
            "-updated_at"=>Sort.UpdatedAtDesc,
            "name"=>Sort.Name,
            "-name"=>Sort.NameDesc,
            _ =>(Sort)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Sort value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Sort.CreatedAt=>"created_at",
            Sort.CreatedAtDesc=>"-created_at",
            Sort.UpdatedAt=>"updated_at",
            Sort.UpdatedAtDesc=>"-updated_at",
            Sort.Name=>"name",
            Sort.NameDesc=>"-name",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}