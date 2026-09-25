using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

/// <summary>
/// Returns the input fields an action requirement needs and the current requirement
/// action for a sub number order. Action requirements are fulfilled by an external
/// step rather than by uploading documents. Australia mobile ID verification is
/// currently the only action requirement. Once a verification link has been generated,
/// it is returned in `requirement_action.value`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubNumberOrderRetrieveParams : ParamsBase
{
    public required string RegulatoryRequirementID { get; init; }

    public string? SubNumberOrderID { get; init; }

    public SubNumberOrderRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderRetrieveParams (
        SubNumberOrderRetrieveParams subNumberOrderRetrieveParams
    ) : base(subNumberOrderRetrieveParams)
    {
        this.RegulatoryRequirementID = subNumberOrderRetrieveParams.RegulatoryRequirementID;
        this.SubNumberOrderID = subNumberOrderRetrieveParams.SubNumberOrderID;
    }
    #pragma warning restore CS8618

    public SubNumberOrderRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SubNumberOrderRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string regulatoryRequirementID,
        string subNumberOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RegulatoryRequirementID = regulatoryRequirementID;
        this.SubNumberOrderID = subNumberOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubNumberOrderRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string regulatoryRequirementID,
        string subNumberOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            regulatoryRequirementID,
            subNumberOrderID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["RegulatoryRequirementID"] = JsonSerializer.SerializeToElement(this.RegulatoryRequirementID),
        ["SubNumberOrderID"] = JsonSerializer.SerializeToElement(this.SubNumberOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SubNumberOrderRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RegulatoryRequirementID.Equals(other.RegulatoryRequirementID)&&(this.SubNumberOrderID?.Equals(other.SubNumberOrderID) ?? other.SubNumberOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/external_requirements/{0}/sub_number_orders/{1}",
            this.RegulatoryRequirementID,
            this.SubNumberOrderID)
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