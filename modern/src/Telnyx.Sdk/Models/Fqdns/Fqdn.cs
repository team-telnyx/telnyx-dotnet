using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<Fqdn, FqdnFromRaw>))]
public sealed record class Fqdn : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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

    /// <summary>
    /// ID of the FQDN connection to which this FQDN is attached.
    /// </summary>
    public string? ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("connection_id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
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
    /// The DNS record type for the FQDN. For cases where a port is not set, the
    /// DNS record type must be 'srv'. For cases where a port is set, the DNS record
    /// type must be 'a'. If the DNS record type is 'a' and a port is not specified,
    /// 5060 will be used.
    /// </summary>
    public string? DnsRecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "dns_record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dns_record_type", value);
        }
    }

    /// <summary>
    /// FQDN represented by this resource.
    /// </summary>
    public string? FqdnValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fqdn"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fqdn", value);
        }
    }

    /// <summary>
    /// Port to use when connecting to this FQDN.
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

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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
    /// ISO 8601 formatted date indicating when the resource was updated.
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
        _ = this.ID;
        _ = this.ConnectionID;
        _ = this.CreatedAt;
        _ = this.DnsRecordType;
        _ = this.FqdnValue;
        _ = this.Port;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public Fqdn ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Fqdn (Fqdn fqdn) : base(fqdn)
    {  }
    #pragma warning restore CS8618

    public Fqdn (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Fqdn (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnFromRaw.FromRawUnchecked"/>
    public static Fqdn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnFromRaw : IFromRawJson<Fqdn>
{
    /// <inheritdoc/>
    public Fqdn FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Fqdn.FromRawUnchecked(rawData);
}