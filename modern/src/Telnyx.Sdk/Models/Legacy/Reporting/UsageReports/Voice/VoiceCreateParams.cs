using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Voice;

/// <summary>
/// Creates a new legacy usage V2 CDR report request with the specified filters
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class VoiceCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// End time in ISO format
    /// </summary>
    public required DateTimeOffset EndTime {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>(
                "end_time"
            );
        }
        init { this._rawBodyData.Set("end_time", value); }
    }

    /// <summary>
    /// Start time in ISO format
    /// </summary>
    public required DateTimeOffset StartTime {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<DateTimeOffset>(
                "start_time"
            );
        }
        init { this._rawBodyData.Set("start_time", value); }
    }

    /// <summary>
    /// Aggregation type: All = 0, By Connections = 1, By Tags = 2, By Billing Group
    /// = 3
    /// </summary>
    public int? AggregationType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "aggregation_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("aggregation_type", value);
        }
    }

    /// <summary>
    /// List of connections to filter by
    /// </summary>
    public IReadOnlyList<long>? Connections {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<long>>(
                "connections"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<long>?>(
                "connections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of managed accounts to include
    /// </summary>
    public IReadOnlyList<string>? ManagedAccounts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "managed_accounts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "managed_accounts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Product breakdown type: No breakdown = 0, DID vs Toll-free = 1, Country =
    /// 2, DID vs Toll-free per Country = 3
    /// </summary>
    public int? ProductBreakdown {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "product_breakdown"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("product_breakdown", value);
        }
    }

    /// <summary>
    /// Whether to select all managed accounts
    /// </summary>
    public bool? SelectAllManagedAccounts {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "select_all_managed_accounts"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("select_all_managed_accounts", value);
        }
    }

    public VoiceCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceCreateParams (VoiceCreateParams voiceCreateParams) : base(
        voiceCreateParams
    )
    { this._rawBodyData = new(voiceCreateParams._rawBodyData); }
    #pragma warning restore CS8618

    public VoiceCreateParams (
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
    VoiceCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static VoiceCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(VoiceCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/legacy/reporting/usage_reports/voice"
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