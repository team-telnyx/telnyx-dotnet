using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc;

/// <summary>
/// Returns the accepted values for the selected 10DLC enumeration endpoint. Use these
/// values when constructing brand and campaign requests.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class Messaging10dlcGetEnumParams : ParamsBase
{
    public ApiEnum<string, Endpoint>? Endpoint { get; init; }

    public Messaging10dlcGetEnumParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Messaging10dlcGetEnumParams (
        Messaging10dlcGetEnumParams messaging10dlcGetEnumParams
    ) : base(messaging10dlcGetEnumParams)
    { this.Endpoint = messaging10dlcGetEnumParams.Endpoint; }
    #pragma warning restore CS8618

    public Messaging10dlcGetEnumParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Messaging10dlcGetEnumParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        ApiEnum<string, Endpoint> endpoint
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.Endpoint = endpoint;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static Messaging10dlcGetEnumParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        ApiEnum<string, Endpoint> endpoint
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            endpoint
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["Endpoint"] = JsonSerializer.SerializeToElement(this.Endpoint),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(Messaging10dlcGetEnumParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.Endpoint?.Equals(other.Endpoint) ?? other.Endpoint == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/10dlc/enum/{0}",
            EncodePathSegment(this.Endpoint?.Raw()))
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

[JsonConverter(typeof(EndpointConverter))]
public enum Endpoint
{
    Mno,
    OptionalAttributes,
    Usecase,
    Vertical,
    AltBusinessIDType,
    BrandIdentityStatus,
    BrandRelationship,
    CampaignStatus,
    EntityType,
    ExtVettingProvider,
    VettingStatus,
    BrandStatus,
    OperationStatus,
    ApprovedPublicCompany,
    StockExchange,
    VettingClass
}

sealed class EndpointConverter : JsonConverter<Endpoint>
{
    public override Endpoint Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "mno"=>Endpoint.Mno,
            "optionalAttributes"=>Endpoint.OptionalAttributes,
            "usecase"=>Endpoint.Usecase,
            "vertical"=>Endpoint.Vertical,
            "altBusinessIdType"=>Endpoint.AltBusinessIDType,
            "brandIdentityStatus"=>Endpoint.BrandIdentityStatus,
            "brandRelationship"=>Endpoint.BrandRelationship,
            "campaignStatus"=>Endpoint.CampaignStatus,
            "entityType"=>Endpoint.EntityType,
            "extVettingProvider"=>Endpoint.ExtVettingProvider,
            "vettingStatus"=>Endpoint.VettingStatus,
            "brandStatus"=>Endpoint.BrandStatus,
            "operationStatus"=>Endpoint.OperationStatus,
            "approvedPublicCompany"=>Endpoint.ApprovedPublicCompany,
            "stockExchange"=>Endpoint.StockExchange,
            "vettingClass"=>Endpoint.VettingClass,
            _ =>(Endpoint)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Endpoint value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Endpoint.Mno=>"mno",
            Endpoint.OptionalAttributes=>"optionalAttributes",
            Endpoint.Usecase=>"usecase",
            Endpoint.Vertical=>"vertical",
            Endpoint.AltBusinessIDType=>"altBusinessIdType",
            Endpoint.BrandIdentityStatus=>"brandIdentityStatus",
            Endpoint.BrandRelationship=>"brandRelationship",
            Endpoint.CampaignStatus=>"campaignStatus",
            Endpoint.EntityType=>"entityType",
            Endpoint.ExtVettingProvider=>"extVettingProvider",
            Endpoint.VettingStatus=>"vettingStatus",
            Endpoint.BrandStatus=>"brandStatus",
            Endpoint.OperationStatus=>"operationStatus",
            Endpoint.ApprovedPublicCompany=>"approvedPublicCompany",
            Endpoint.StockExchange=>"stockExchange",
            Endpoint.VettingClass=>"vettingClass",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}