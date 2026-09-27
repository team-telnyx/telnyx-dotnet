using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SiprecConnectors;

[JsonConverter(typeof(JsonModelConverter<SiprecConnectorResponse, SiprecConnectorResponseFromRaw>))]
public sealed record class SiprecConnectorResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public SiprecConnectorResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SiprecConnectorResponse (
        SiprecConnectorResponse siprecConnectorResponse
    ) : base(siprecConnectorResponse)
    {  }
    #pragma warning restore CS8618

    public SiprecConnectorResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SiprecConnectorResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SiprecConnectorResponseFromRaw.FromRawUnchecked"/>
    public static SiprecConnectorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public SiprecConnectorResponse (Data data) : this()
    { this.Data = data; }
}

class SiprecConnectorResponseFromRaw : IFromRawJson<SiprecConnectorResponse>
{
    /// <inheritdoc/>
    public SiprecConnectorResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SiprecConnectorResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Subdomain to route calls when using Telnyx SRS (optional).
    /// </summary>
    public string? AppSubdomain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "app_subdomain"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("app_subdomain", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date/time of creation.
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
    /// Hostname/IPv4 address of the SIPREC SRS.
    /// </summary>
    public string? Host {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "host"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("host", value);
        }
    }

    /// <summary>
    /// Name for the SIPREC connector resource.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Port for the SIPREC SRS.
    /// </summary>
    public long? Port {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "port"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("port", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date/time of last update.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AppSubdomain;
        _ = this.CreatedAt;
        _ = this.Host;
        _ = this.Name;
        _ = this.Port;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}