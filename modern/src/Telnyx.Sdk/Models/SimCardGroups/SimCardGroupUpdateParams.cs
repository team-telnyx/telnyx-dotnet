using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

/// <summary>
/// Updates the specified SIM card group's attributes and returns the updated group.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SimCardGroupUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Upper limit on the amount of data the SIM cards, within the group, can use.
    /// </summary>
    public SimCardGroupUpdateParamsDataLimit? DataLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SimCardGroupUpdateParamsDataLimit>(
                "data_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("data_limit", value);
        }
    }

    /// <summary>
    /// A user friendly name for the SIM card group.
    /// </summary>
    public string? Name {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("name", value);
        }
    }

    public SimCardGroupUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupUpdateParams (
        SimCardGroupUpdateParams simCardGroupUpdateParams
    ) : base(simCardGroupUpdateParams)
    {
        this.ID = simCardGroupUpdateParams.ID;

        this._rawBodyData = new(simCardGroupUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public SimCardGroupUpdateParams (
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
    SimCardGroupUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SimCardGroupUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SimCardGroupUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/sim_card_groups/{0}",
            EncodePathSegment(this.ID))
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
/// Upper limit on the amount of data the SIM cards, within the group, can use.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardGroupUpdateParamsDataLimit, SimCardGroupUpdateParamsDataLimitFromRaw>))]
public sealed record class SimCardGroupUpdateParamsDataLimit : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Unit;
    }

    public SimCardGroupUpdateParamsDataLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupUpdateParamsDataLimit (
        SimCardGroupUpdateParamsDataLimit simCardGroupUpdateParamsDataLimit
    ) : base(simCardGroupUpdateParamsDataLimit)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupUpdateParamsDataLimit (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupUpdateParamsDataLimit (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupUpdateParamsDataLimitFromRaw.FromRawUnchecked"/>
    public static SimCardGroupUpdateParamsDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupUpdateParamsDataLimitFromRaw : IFromRawJson<SimCardGroupUpdateParamsDataLimit>
{
    /// <inheritdoc/>
    public SimCardGroupUpdateParamsDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupUpdateParamsDataLimit.FromRawUnchecked(rawData);
}