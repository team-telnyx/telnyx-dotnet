using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Compute.Funcs.Export;

[JsonConverter(typeof(JsonModelConverter<FuncLogExportConfigResponse, FuncLogExportConfigResponseFromRaw>))]
public sealed record class FuncLogExportConfigResponse : JsonModel
{
    /// <summary>
    /// Metadata-only view of a function's log export destination. Header values
    /// are write-only (encrypted server-side) and never appear in any response.
    /// </summary>
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

    public FuncLogExportConfigResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncLogExportConfigResponse (
        FuncLogExportConfigResponse funcLogExportConfigResponse
    ) : base(funcLogExportConfigResponse)
    {  }
    #pragma warning restore CS8618

    public FuncLogExportConfigResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncLogExportConfigResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncLogExportConfigResponseFromRaw.FromRawUnchecked"/>
    public static FuncLogExportConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncLogExportConfigResponseFromRaw : IFromRawJson<FuncLogExportConfigResponse>
{
    /// <inheritdoc/>
    public FuncLogExportConfigResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncLogExportConfigResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Metadata-only view of a function's log export destination. Header values are write-only
/// (encrypted server-side) and never appear in any response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Configuration record ID
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
    /// Whether export is enabled for this function
    /// </summary>
    public bool? Enabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// HTTPS OTLP endpoint URL logs are pushed to
    /// </summary>
    public string? Endpoint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "endpoint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("endpoint", value);
        }
    }

    /// <summary>
    /// Function ID this configuration belongs to
    /// </summary>
    public string? FuncID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "func_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("func_id", value);
        }
    }

    /// <summary>
    /// Whether invocation records (one per HTTP request) are exported
    /// </summary>
    public bool? InvocationExportEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "invocation_export_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("invocation_export_enabled", value);
        }
    }

    public ApiEnum<string, RecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RecordType>>(
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
    /// Whether runtime logs (function stdout/stderr) are exported
    /// </summary>
    public bool? RuntimeExportEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "runtime_export_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("runtime_export_enabled", value);
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
        _ = this.Enabled;
        _ = this.Endpoint;
        _ = this.FuncID;
        _ = this.InvocationExportEnabled;
        this.RecordType?.Validate();
        _ = this.RuntimeExportEnabled;
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
}[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    ComputeFuncLogExportConfig
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "compute_func_log_export_config"=>RecordType.ComputeFuncLogExportConfig,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.ComputeFuncLogExportConfig=>"compute_func_log_export_config",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}