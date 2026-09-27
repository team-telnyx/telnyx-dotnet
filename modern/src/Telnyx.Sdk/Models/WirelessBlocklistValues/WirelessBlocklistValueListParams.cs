using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WirelessBlocklistValues;

/// <summary>
/// Retrieve all wireless blocklist values for a given blocklist type. The request
/// returns `422` when `type` is missing or invalid.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class WirelessBlocklistValueListParams : ParamsBase
{
    /// <summary>
    /// The Wireless Blocklist type for which to list possible values (e.g., `country`,
    /// `mcc`, `plmn`).
    /// </summary>
    public required ApiEnum<string, global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type> Type {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNotNullClass<ApiEnum<string, global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type>>(
                "type"
            );
        }
        init { this._rawQueryData.Set("type", value); }
    }

    public WirelessBlocklistValueListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessBlocklistValueListParams (
        WirelessBlocklistValueListParams wirelessBlocklistValueListParams
    ) : base(wirelessBlocklistValueListParams)
    {  }
    #pragma warning restore CS8618

    public WirelessBlocklistValueListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessBlocklistValueListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static WirelessBlocklistValueListParams FromRawUnchecked(
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

    public virtual bool Equals(WirelessBlocklistValueListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/wireless_blocklist_values"
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
/// The Wireless Blocklist type for which to list possible values (e.g., `country`,
/// `mcc`, `plmn`).
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Country, Mcc, Plmn
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type>
{
    public override global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "country"=>global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Country,
            "mcc"=>global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Mcc,
            "plmn"=>global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Plmn,
            _ =>(global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Country=>"country",
            global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Mcc=>"mcc",
            global::Telnyx.Sdk.Models.WirelessBlocklistValues.Type.Plmn=>"plmn",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}