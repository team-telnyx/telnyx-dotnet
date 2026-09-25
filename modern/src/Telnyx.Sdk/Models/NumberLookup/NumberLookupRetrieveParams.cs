using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.NumberLookup;

/// <summary>
/// Returns information about the provided phone number.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NumberLookupRetrieveParams : ParamsBase
{
    public string? PhoneNumber { get; init; }

    /// <summary>
    /// Specifies the type of number lookup to be performed
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.NumberLookup.Type>? Type {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.NumberLookup.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public NumberLookupRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberLookupRetrieveParams (
        NumberLookupRetrieveParams numberLookupRetrieveParams
    ) : base(numberLookupRetrieveParams)
    { this.PhoneNumber = numberLookupRetrieveParams.PhoneNumber; }
    #pragma warning restore CS8618

    public NumberLookupRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberLookupRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string phoneNumber
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.PhoneNumber = phoneNumber;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NumberLookupRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string phoneNumber
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            phoneNumber
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["PhoneNumber"] = JsonSerializer.SerializeToElement(this.PhoneNumber),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(NumberLookupRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PhoneNumber?.Equals(other.PhoneNumber) ?? other.PhoneNumber == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/number_lookup/{0}",
            this.PhoneNumber)
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
/// Specifies the type of number lookup to be performed
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Carrier, CallerName
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.NumberLookup.Type>
{
    public override global::Telnyx.Sdk.Models.NumberLookup.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "carrier"=>global::Telnyx.Sdk.Models.NumberLookup.Type.Carrier,
            "caller-name"=>global::Telnyx.Sdk.Models.NumberLookup.Type.CallerName,
            _ =>(global::Telnyx.Sdk.Models.NumberLookup.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.NumberLookup.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.NumberLookup.Type.Carrier=>"carrier",
            global::Telnyx.Sdk.Models.NumberLookup.Type.CallerName=>"caller-name",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}