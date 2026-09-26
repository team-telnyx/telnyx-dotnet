using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalRequirements.SubNumberOrders;

/// <summary>
/// Submits the end user's details to the external verification provider and returns
/// the requirement action. Australia mobile ID verification is currently the only
/// action requirement. It generates a unique Onfido verification link, returned in
/// `requirement_action.value`, which you share with the end user. The end user's
/// `first_name` and `last_name` must be nested inside a `requirement` object; sending
/// them at the top level is rejected.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SubNumberOrderUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string RegulatoryRequirementID { get; init; }

    public string? SubNumberOrderID { get; init; }

    /// <summary>
    /// The end user's identity details for the action requirement. Australia mobile
    /// ID verification is currently the only action requirement. It requires `first_name`
    /// and `last_name`, the same fields the corresponding GET lists in `fields_required`.
    /// </summary>
    public required Requirement Requirement {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<Requirement>(
                "requirement"
            );
        }
        init { this._rawBodyData.Set("requirement", value); }
    }

    public SubNumberOrderUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubNumberOrderUpdateParams (
        SubNumberOrderUpdateParams subNumberOrderUpdateParams
    ) : base(subNumberOrderUpdateParams)
    {
        this.RegulatoryRequirementID = subNumberOrderUpdateParams.RegulatoryRequirementID;
        this.SubNumberOrderID = subNumberOrderUpdateParams.SubNumberOrderID;

        this._rawBodyData = new(subNumberOrderUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public SubNumberOrderUpdateParams (
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
    SubNumberOrderUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string regulatoryRequirementID,
        string subNumberOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RegulatoryRequirementID = regulatoryRequirementID;
        this.SubNumberOrderID = subNumberOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SubNumberOrderUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string regulatoryRequirementID,
        string subNumberOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SubNumberOrderUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RegulatoryRequirementID.Equals(other.RegulatoryRequirementID)&&(this.SubNumberOrderID?.Equals(other.SubNumberOrderID) ?? other.SubNumberOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/external_requirements/{0}/sub_number_orders/{1}",
            EncodePathSegment(this.RegulatoryRequirementID),
            EncodePathSegment(this.SubNumberOrderID))
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
/// The end user's identity details for the action requirement. Australia mobile ID
/// verification is currently the only action requirement. It requires `first_name`
/// and `last_name`, the same fields the corresponding GET lists in `fields_required`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Requirement, RequirementFromRaw>))]
public sealed record class Requirement : JsonModel
{
    /// <summary>
    /// The end user's first name.
    /// </summary>
    public required string FirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "first_name"
            );
        }
        init { this._rawData.Set("first_name", value); }
    }

    /// <summary>
    /// The end user's last name.
    /// </summary>
    public required string LastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "last_name"
            );
        }
        init { this._rawData.Set("last_name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FirstName;
        _ = this.LastName;
    }

    public Requirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Requirement (Requirement requirement) : base(requirement)
    {  }
    #pragma warning restore CS8618

    public Requirement (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Requirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementFromRaw.FromRawUnchecked"/>
    public static Requirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementFromRaw : IFromRawJson<Requirement>
{
    /// <inheritdoc/>
    public Requirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Requirement.FromRawUnchecked(rawData);
}