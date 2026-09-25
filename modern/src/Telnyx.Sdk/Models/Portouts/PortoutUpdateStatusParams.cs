using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Portouts;

/// <summary>
/// Updates the status of the specified port-out request, using the status path segment
/// to authorize or reject the port-out.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PortoutUpdateStatusParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public ApiEnum<string, PortoutUpdateStatusParamsStatus>? Status {
        get; init;
    }

    /// <summary>
    /// Provide a reason if rejecting the port out request
    /// </summary>
    public required string Reason {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "reason"
            );
        }
        init { this._rawBodyData.Set("reason", value); }
    }

    /// <summary>
    /// Indicates whether messaging services should be maintained with Telnyx after
    /// the port out completes
    /// </summary>
    public bool? HostMessaging {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "host_messaging"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("host_messaging", value);
        }
    }

    public PortoutUpdateStatusParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutUpdateStatusParams (
        PortoutUpdateStatusParams portoutUpdateStatusParams
    ) : base(portoutUpdateStatusParams)
    {
        this.ID = portoutUpdateStatusParams.ID;
        this.Status = portoutUpdateStatusParams.Status;

        this._rawBodyData = new(portoutUpdateStatusParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PortoutUpdateStatusParams (
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
    PortoutUpdateStatusParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id,
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
        this.Status = status;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PortoutUpdateStatusParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id,
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id,
            status
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["Status"] = JsonSerializer.SerializeToElement(this.Status),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(PortoutUpdateStatusParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)&&(this.Status?.Equals(other.Status) ?? other.Status == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/portouts/{0}/{1}",
            this.ID,
            this.Status?.Raw())
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

[JsonConverter(typeof(PortoutUpdateStatusParamsStatusConverter))]
public enum PortoutUpdateStatusParamsStatus
{
    Authorized, RejectedPending
}

sealed class PortoutUpdateStatusParamsStatusConverter : JsonConverter<PortoutUpdateStatusParamsStatus>
{
    public override PortoutUpdateStatusParamsStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "authorized"=>PortoutUpdateStatusParamsStatus.Authorized,
            "rejected-pending"=>PortoutUpdateStatusParamsStatus.RejectedPending,
            _ =>(PortoutUpdateStatusParamsStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PortoutUpdateStatusParamsStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            PortoutUpdateStatusParamsStatus.Authorized=>"authorized",
            PortoutUpdateStatusParamsStatus.RejectedPending=>"rejected-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}