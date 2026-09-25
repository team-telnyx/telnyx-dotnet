using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.CredentialConnections;

namespace Telnyx.Sdk.Models.Connections;

[JsonConverter(typeof(JsonModelConverter<Connection, ConnectionFromRaw>))]
public sealed record class Connection : JsonModel
{
    /// <summary>
    /// Identifies the specific resource.
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
    /// Defaults to true
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// `Latency` directs Telnyx to route media through the site with the lowest
    /// round-trip time to the user's connection. Telnyx calculates this time using
    /// ICMP ping messages. This can be disabled by specifying a site to handle all media.
    /// </summary>
    public ApiEnum<string, AnchorsiteOverride>? AnchorsiteOverride {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AnchorsiteOverride>>(
                "anchorsite_override"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("anchorsite_override", value);
        }
    }

    public string? ConnectionName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
    /// Identifies the associated outbound voice profile.
    /// </summary>
    public string? OutboundVoiceProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "outbound_voice_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("outbound_voice_profile_id", value);
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
    /// Tags associated with the connection.
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <summary>
    /// Determines which webhook format will be used, Telnyx API v1 or v2.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Connections.WebhookApiVersion>? WebhookApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Connections.WebhookApiVersion>>(
                "webhook_api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("webhook_api_version", value);
        }
    }

    /// <summary>
    /// The failover URL where webhooks related to this connection will be sent if
    /// sending to the primary URL fails.
    /// </summary>
    public string? WebhookEventFailoverUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_failover_url"
            );
        }
        init { this._rawData.Set("webhook_event_failover_url", value); }
    }

    /// <summary>
    /// The URL where webhooks related to this connection will be sent.
    /// </summary>
    public string? WebhookEventUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "webhook_event_url"
            );
        }
        init { this._rawData.Set("webhook_event_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        this.AnchorsiteOverride?.Validate();
        _ = this.ConnectionName;
        _ = this.CreatedAt;
        _ = this.OutboundVoiceProfileID;
        _ = this.RecordType;
        _ = this.Tags;
        _ = this.UpdatedAt;
        this.WebhookApiVersion?.Validate();
        _ = this.WebhookEventFailoverUrl;
        _ = this.WebhookEventUrl;
    }

    public Connection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Connection (Connection connection) : base(connection)
    {  }
    #pragma warning restore CS8618

    public Connection (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Connection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionFromRaw.FromRawUnchecked"/>
    public static Connection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConnectionFromRaw : IFromRawJson<Connection>
{
    /// <inheritdoc/>
    public Connection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Connection.FromRawUnchecked(rawData);
}

/// <summary>
/// Determines which webhook format will be used, Telnyx API v1 or v2.
/// </summary>
[JsonConverter(typeof(global::Telnyx.Sdk.Models.Connections.WebhookApiVersionConverter))]
public enum WebhookApiVersion
{
    V1, V2
}sealed class WebhookApiVersionConverter : JsonConverter<global::Telnyx.Sdk.Models.Connections.WebhookApiVersion>
{
    public override global::Telnyx.Sdk.Models.Connections.WebhookApiVersion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "1"=>global::Telnyx.Sdk.Models.Connections.WebhookApiVersion.V1,
            "2"=>global::Telnyx.Sdk.Models.Connections.WebhookApiVersion.V2,
            _ =>(global::Telnyx.Sdk.Models.Connections.WebhookApiVersion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Connections.WebhookApiVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Connections.WebhookApiVersion.V1=>"1",
            global::Telnyx.Sdk.Models.Connections.WebhookApiVersion.V2=>"2",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}