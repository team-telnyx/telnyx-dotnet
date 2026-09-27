using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.GlobalIPAssignments;

namespace Telnyx.Sdk.Models.GlobalIPHealthChecks;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheck, GlobalIPHealthCheckFromRaw>))]
public sealed record class GlobalIPHealthCheck : JsonModel
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
    /// ISO 8601 formatted date-time indicating when the resource was created.
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
    /// ISO 8601 formatted date-time indicating when the resource was updated.
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
    /// Global IP ID.
    /// </summary>
    public string? GlobalIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "global_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_id", value);
        }
    }

    /// <summary>
    /// A Global IP health check params.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? HealthCheckParams {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "health_check_params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "health_check_params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The Global IP health check type.
    /// </summary>
    public string? HealthCheckType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "health_check_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("health_check_type", value);
        }
    }

    public static implicit operator Record (
        GlobalIPHealthCheck globalIPHealthCheck
    )=> new() {
        ID = globalIPHealthCheck.ID,
        CreatedAt = globalIPHealthCheck.CreatedAt,
        RecordType = globalIPHealthCheck.RecordType,
        UpdatedAt = globalIPHealthCheck.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.GlobalIPID;
        _ = this.HealthCheckParams;
        _ = this.HealthCheckType;
    }

    public GlobalIPHealthCheck ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheck (GlobalIPHealthCheck globalIPHealthCheck) : base(
        globalIPHealthCheck
    )
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheck (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheck (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckFromRaw : IFromRawJson<GlobalIPHealthCheck>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheck.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckGlobalIPHealthCheck, GlobalIPHealthCheckGlobalIPHealthCheckFromRaw>))]
public sealed record class GlobalIPHealthCheckGlobalIPHealthCheck : JsonModel
{
    /// <summary>
    /// Global IP ID.
    /// </summary>
    public string? GlobalIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "global_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_id", value);
        }
    }

    /// <summary>
    /// A Global IP health check params.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? HealthCheckParams {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "health_check_params"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "health_check_params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The Global IP health check type.
    /// </summary>
    public string? HealthCheckType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "health_check_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("health_check_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GlobalIPID;
        _ = this.HealthCheckParams;
        _ = this.HealthCheckType;
    }

    public GlobalIPHealthCheckGlobalIPHealthCheck ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckGlobalIPHealthCheck (
        GlobalIPHealthCheckGlobalIPHealthCheck globalIPHealthCheckGlobalIPHealthCheck
    ) : base(globalIPHealthCheckGlobalIPHealthCheck)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckGlobalIPHealthCheck (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckGlobalIPHealthCheck (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckGlobalIPHealthCheckFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckGlobalIPHealthCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class GlobalIPHealthCheckGlobalIPHealthCheckFromRaw : IFromRawJson<GlobalIPHealthCheckGlobalIPHealthCheck>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckGlobalIPHealthCheck FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckGlobalIPHealthCheck.FromRawUnchecked(rawData);
}