using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.Sqldbs;

[JsonConverter(typeof(JsonModelConverter<SqlDatabase, SqlDatabaseFromRaw>))]
public sealed record class SqlDatabase : JsonModel
{
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
    /// Provisioning status. A database is usable once `status` is `provision_ok`.
    /// Once deletion completes, the database no longer appears in the API.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public SqlDatabase ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SqlDatabase (SqlDatabase sqlDatabase) : base(sqlDatabase)
    {  }
    #pragma warning restore CS8618

    public SqlDatabase (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SqlDatabase (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SqlDatabaseFromRaw.FromRawUnchecked"/>
    public static SqlDatabase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SqlDatabaseFromRaw : IFromRawJson<SqlDatabase>
{
    /// <inheritdoc/>
    public SqlDatabase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SqlDatabase.FromRawUnchecked(rawData);
}

/// <summary>
/// Provisioning status. A database is usable once `status` is `provision_ok`. Once
/// deletion completes, the database no longer appears in the API.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, ProvisionOk, ProvisionFailed, Deleting, DeleteFailed
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "provision_ok"=>Status.ProvisionOk,
            "provision_failed"=>Status.ProvisionFailed,
            "deleting"=>Status.Deleting,
            "delete_failed"=>Status.DeleteFailed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.ProvisionOk=>"provision_ok",
            Status.ProvisionFailed=>"provision_failed",
            Status.Deleting=>"deleting",
            Status.DeleteFailed=>"delete_failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}