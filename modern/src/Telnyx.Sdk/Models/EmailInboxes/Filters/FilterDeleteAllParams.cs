using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Filters;

/// <summary>
/// Removes entries from either the allowlist or blocklist. The operation is idempotent:
/// removing an entry that is not present still returns the current filter lists.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FilterDeleteAllParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? InboxID { get; init; }

    public required IReadOnlyList<string> Entries {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "entries"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "entries",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The list to change.
    /// </summary>
    public required ApiEnum<string, FilterDeleteAllParamsType> Type {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, FilterDeleteAllParamsType>>(
                "type"
            );
        }
        init { this._rawBodyData.Set("type", value); }
    }

    public FilterDeleteAllParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FilterDeleteAllParams (
        FilterDeleteAllParams filterDeleteAllParams
    ) : base(filterDeleteAllParams)
    {
        this.InboxID = filterDeleteAllParams.InboxID;

        this._rawBodyData = new(filterDeleteAllParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public FilterDeleteAllParams (
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
    FilterDeleteAllParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string inboxID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.InboxID = inboxID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FilterDeleteAllParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string inboxID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            inboxID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["InboxID"] = JsonSerializer.SerializeToElement(this.InboxID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(FilterDeleteAllParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.InboxID?.Equals(other.InboxID) ?? other.InboxID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/email_inboxes/{0}/filters",
            EncodePathSegment(this.InboxID))
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

/// <summary>
/// The list to change.
/// </summary>
[JsonConverter(typeof(FilterDeleteAllParamsTypeConverter))]
public enum FilterDeleteAllParamsType
{
    Allowlist, Blocklist
}

sealed class FilterDeleteAllParamsTypeConverter : JsonConverter<FilterDeleteAllParamsType>
{
    public override FilterDeleteAllParamsType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "allowlist"=>FilterDeleteAllParamsType.Allowlist,
            "blocklist"=>FilterDeleteAllParamsType.Blocklist,
            _ =>(FilterDeleteAllParamsType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterDeleteAllParamsType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterDeleteAllParamsType.Allowlist=>"allowlist",
            FilterDeleteAllParamsType.Blocklist=>"blocklist",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}