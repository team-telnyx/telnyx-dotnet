using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionShareResponse, ActionShareResponseFromRaw>))]
public sealed record class ActionShareResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ActionShareResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionShareResponse (ActionShareResponse actionShareResponse) : base(
        actionShareResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionShareResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionShareResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionShareResponseFromRaw.FromRawUnchecked"/>
    public static ActionShareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionShareResponseFromRaw : IFromRawJson<ActionShareResponse>
{
    /// <inheritdoc/>
    public ActionShareResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionShareResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Uniquely identifies this sharing token
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
    /// A signed JWT token that can be used to access the shared resource
    /// </summary>
    public string? Token {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// ISO 8601 formatted date indicating when the sharing token expires.
    /// </summary>
    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    /// <summary>
    /// The number of seconds until the sharing token expires
    /// </summary>
    public long? ExpiresInSeconds {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "expires_in_seconds"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_in_seconds", value);
        }
    }

    /// <summary>
    /// The permissions granted to the sharing token
    /// </summary>
    public IReadOnlyList<ApiEnum<string, Permission>>? Permissions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Permission>>>(
                "permissions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Permission>>?>(
                "permissions",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the porting order resource being shared
    /// </summary>
    public string? PortingOrderID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "porting_order_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("porting_order_id", value);
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Token;
        _ = this.CreatedAt;
        _ = this.ExpiresAt;
        _ = this.ExpiresInSeconds;
        foreach (var item in this.Permissions ?? [])
        {
            item.Validate();
        }
        _ = this.PortingOrderID;
        _ = this.RecordType;
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
}[JsonConverter(typeof(PermissionConverter))]
public enum Permission
{
    PortingOrderDocumentRead, PortingOrderDocumentUpdate
}sealed class PermissionConverter : JsonConverter<Permission>
{
    public override Permission Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "porting_order.document.read"=>Permission.PortingOrderDocumentRead,
            "porting_order.document.update"=>Permission.PortingOrderDocumentUpdate,
            _ =>(Permission)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Permission value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Permission.PortingOrderDocumentRead=>"porting_order.document.read",
            Permission.PortingOrderDocumentUpdate=>"porting_order.document.update",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}