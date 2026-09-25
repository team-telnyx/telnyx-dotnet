using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Reports;

/// <summary>
/// Returns wireless detail records (WDRs) matching the provided criteria, such as
/// date range, SIM card, IMSI, or phone number, with pagination and sorting.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReportListWdrsParams : ParamsBase
{
    /// <summary>
    /// Filter results by identifier.
    /// </summary>
    public string? ID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("id", value);
        }
    }

    /// <summary>
    /// End date
    /// </summary>
    public string? EndDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "end_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("end_date", value);
        }
    }

    /// <summary>
    /// Filter results by imsi.
    /// </summary>
    public string? Imsi {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "imsi"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("imsi", value);
        }
    }

    /// <summary>
    /// Filter results by mcc.
    /// </summary>
    public string? Mcc {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("mcc", value);
        }
    }

    /// <summary>
    /// Filter results by mnc.
    /// </summary>
    public string? Mnc {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("mnc", value);
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
    /// Filter results by sim card id.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// Filter results by sim group id.
    /// </summary>
    public string? SimGroupID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "sim_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sim_group_id", value);
        }
    }

    /// <summary>
    /// Filter results by sim group name.
    /// </summary>
    public string? SimGroupName {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "sim_group_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sim_group_name", value);
        }
    }

    /// <summary>
    /// Field and direction to sort the results by.
    /// </summary>
    public IReadOnlyList<string>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "sort",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start date
    /// </summary>
    public string? StartDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "start_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("start_date", value);
        }
    }

    public ReportListWdrsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListWdrsParams (
        ReportListWdrsParams reportListWdrsParams
    ) : base(reportListWdrsParams)
    {  }
    #pragma warning restore CS8618

    public ReportListWdrsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListWdrsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReportListWdrsParams FromRawUnchecked(
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

    public virtual bool Equals(ReportListWdrsParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/reports/wdrs"
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