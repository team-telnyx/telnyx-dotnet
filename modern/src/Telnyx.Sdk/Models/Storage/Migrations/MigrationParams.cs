using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Storage.Migrations;

[JsonConverter(typeof(JsonModelConverter<MigrationParams, MigrationParamsFromRaw>))]
public sealed record class MigrationParams : JsonModel
{
    /// <summary>
    /// ID of the Migration Source from which to migrate data.
    /// </summary>
    public required string SourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "source_id"
            );
        }
        init { this._rawData.Set("source_id", value); }
    }

    /// <summary>
    /// Bucket name to migrate the data into. Will default to the same name as the `source_bucket_name`.
    /// </summary>
    public required string TargetBucketName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "target_bucket_name"
            );
        }
        init { this._rawData.Set("target_bucket_name", value); }
    }

    /// <summary>
    /// Telnyx Cloud Storage region to migrate the data to.
    /// </summary>
    public required string TargetRegion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "target_region"
            );
        }
        init { this._rawData.Set("target_region", value); }
    }

    /// <summary>
    /// Unique identifier for the data migration.
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
    /// Total amount of data that has been succesfully migrated.
    /// </summary>
    public long? BytesMigrated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_migrated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_migrated", value);
        }
    }

    /// <summary>
    /// Total amount of data found in source bucket to migrate.
    /// </summary>
    public long? BytesToMigrate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "bytes_to_migrate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("bytes_to_migrate", value);
        }
    }

    /// <summary>
    /// Time when data migration was created
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
    /// Estimated time the migration will complete.
    /// </summary>
    public System::DateTimeOffset? Eta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "eta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eta", value);
        }
    }

    /// <summary>
    /// Time when data migration was last copied from the source.
    /// </summary>
    public System::DateTimeOffset? LastCopy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "last_copy"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_copy", value);
        }
    }

    /// <summary>
    /// If true, will continue to poll the source bucket to ensure new data is continually
    /// migrated over.
    /// </summary>
    public bool? Refresh {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "refresh"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("refresh", value);
        }
    }

    /// <summary>
    /// Current speed of the migration.
    /// </summary>
    public long? Speed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "speed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speed", value);
        }
    }

    /// <summary>
    /// Status of the migration.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.SourceID;
        _ = this.TargetBucketName;
        _ = this.TargetRegion;
        _ = this.ID;
        _ = this.BytesMigrated;
        _ = this.BytesToMigrate;
        _ = this.CreatedAt;
        _ = this.Eta;
        _ = this.LastCopy;
        _ = this.Refresh;
        _ = this.Speed;
        this.Status?.Validate();
    }

    public MigrationParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationParams (MigrationParams migrationParams) : base(
        migrationParams
    )
    {  }
    #pragma warning restore CS8618

    public MigrationParams (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationParamsFromRaw.FromRawUnchecked"/>
    public static MigrationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationParamsFromRaw : IFromRawJson<MigrationParams>
{
    /// <inheritdoc/>
    public MigrationParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationParams.FromRawUnchecked(rawData);
}

/// <summary>
/// Status of the migration.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Checking, Migrating, Complete, Error, Stopped
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
            "checking"=>Status.Checking,
            "migrating"=>Status.Migrating,
            "complete"=>Status.Complete,
            "error"=>Status.Error,
            "stopped"=>Status.Stopped,
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
            Status.Checking=>"checking",
            Status.Migrating=>"migrating",
            Status.Complete=>"complete",
            Status.Error=>"error",
            Status.Stopped=>"stopped",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}