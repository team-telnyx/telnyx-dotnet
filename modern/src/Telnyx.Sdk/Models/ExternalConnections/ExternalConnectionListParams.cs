using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections;

/// <summary>
/// This endpoint returns a list of your External Connections inside the 'data' attribute
/// of the response. External Connections are used by Telnyx customers to seamless
/// configure SIP trunking integrations with Telnyx Partners, through External Voice
/// Integrations in Mission Control Portal.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ExternalConnectionListParams : ParamsBase
{
    /// <summary>
    /// Filter parameter for external connections (deepObject style). Supports filtering
    /// by connection_name, external_sip_connection, id, created_at, and phone_number.
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
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

    public ExternalConnectionListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionListParams (
        ExternalConnectionListParams externalConnectionListParams
    ) : base(externalConnectionListParams)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ExternalConnectionListParams FromRawUnchecked(
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

    public virtual bool Equals(ExternalConnectionListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/external_connections"
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
/// Filter parameter for external connections (deepObject style). Supports filtering
/// by connection_name, external_sip_connection, id, created_at, and phone_number.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// If present, connections with &lt;code&gt;id&lt;/code&gt; matching the given
    /// value will be returned.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public ConnectionName? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionName>(
                "connection_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_name", value);
        }
    }

    /// <summary>
    /// If present, connections with &lt;code&gt;created_at&lt;/code&gt; date matching
    /// the given YYYY-MM-DD date will be returned.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// If present, connections with &lt;code&gt;external_sip_connection&lt;/code&gt;
    /// matching the given value will be returned.
    /// </summary>
    public ApiEnum<string, FilterExternalSipConnection>? ExternalSipConnection {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FilterExternalSipConnection>>(
                "external_sip_connection"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_sip_connection", value);
        }
    }

    /// <summary>
    /// Phone number filter for connections. Note: Despite the 'contains' name, this
    /// requires a full E164 match per the original specification.
    /// </summary>
    public PhoneNumber? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumber>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ConnectionName?.Validate();
        _ = this.CreatedAt;
        this.ExternalSipConnection?.Validate();
        this.PhoneNumber?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ConnectionName, ConnectionNameFromRaw>))]
public sealed record class ConnectionName : JsonModel
{
    /// <summary>
    /// If present, connections with &lt;code&gt;connection_name&lt;/code&gt; containing
    /// the given value will be returned. Matching is not case-sensitive. Requires
    /// at least three characters.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public ConnectionName ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionName (ConnectionName connectionName) : base(connectionName)
    {  }
    #pragma warning restore CS8618

    public ConnectionName (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionName (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionNameFromRaw.FromRawUnchecked"/>
    public static ConnectionName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionNameFromRaw : IFromRawJson<ConnectionName>
{
    /// <inheritdoc/>
    public ConnectionName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionName.FromRawUnchecked(rawData);
}

/// <summary>
/// If present, connections with &lt;code&gt;external_sip_connection&lt;/code&gt;
/// matching the given value will be returned.
/// </summary>
[JsonConverter(typeof(FilterExternalSipConnectionConverter))]
public enum FilterExternalSipConnection
{
    Zoom, OperatorConnect
}

sealed class FilterExternalSipConnectionConverter : JsonConverter<FilterExternalSipConnection>
{
    public override FilterExternalSipConnection Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "zoom"=>FilterExternalSipConnection.Zoom,
            "operator_connect"=>FilterExternalSipConnection.OperatorConnect,
            _ =>(FilterExternalSipConnection)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FilterExternalSipConnection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterExternalSipConnection.Zoom=>"zoom",
            FilterExternalSipConnection.OperatorConnect=>"operator_connect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Phone number filter for connections. Note: Despite the 'contains' name, this requires
/// a full E164 match per the original specification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumber, PhoneNumberFromRaw>))]
public sealed record class PhoneNumber : JsonModel
{
    /// <summary>
    /// If present, connections associated with the given phone_number will be returned.
    /// A full match is necessary with a e164 format.
    /// </summary>
    public string? Contains {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "contains"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("contains", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Contains; }

    public PhoneNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumber (PhoneNumber phoneNumber) : base(phoneNumber)
    {  }
    #pragma warning restore CS8618

    public PhoneNumber (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumber (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberFromRaw.FromRawUnchecked"/>
    public static PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberFromRaw : IFromRawJson<PhoneNumber>
{
    /// <inheritdoc/>
    public PhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumber.FromRawUnchecked(rawData);
}