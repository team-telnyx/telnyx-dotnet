using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Compute.Funcs;

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveShipInspectionResponse, FuncRetrieveShipInspectionResponseFromRaw>))]
public sealed record class FuncRetrieveShipInspectionResponse : JsonModel
{
    public FuncRetrieveShipInspectionResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FuncRetrieveShipInspectionResponseData>(
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

    public FuncRetrieveShipInspectionResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveShipInspectionResponse (
        FuncRetrieveShipInspectionResponse funcRetrieveShipInspectionResponse
    ) : base(funcRetrieveShipInspectionResponse)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveShipInspectionResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveShipInspectionResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveShipInspectionResponseFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveShipInspectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FuncRetrieveShipInspectionResponseFromRaw : IFromRawJson<FuncRetrieveShipInspectionResponse>
{
    /// <inheritdoc/>
    public FuncRetrieveShipInspectionResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveShipInspectionResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<FuncRetrieveShipInspectionResponseData, FuncRetrieveShipInspectionResponseDataFromRaw>))]
public sealed record class FuncRetrieveShipInspectionResponseData : JsonModel
{
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

    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <summary>
    /// Stable record type retained by both inspection path aliases.
    /// </summary>
    public ApiEnum<string, FuncRetrieveShipInspectionResponseDataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, FuncRetrieveShipInspectionResponseDataRecordType>>(
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

    public string? Runtime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "runtime"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("runtime", value);
        }
    }

    public string? Snippet {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "snippet"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("snippet", value);
        }
    }

    public ApiEnum<string, Stage>? Stage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Stage>>(
                "stage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("stage", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CreatedAt;
        _ = this.Reason;
        this.RecordType?.Validate();
        _ = this.Runtime;
        _ = this.Snippet;
        this.Stage?.Validate();
    }

    public FuncRetrieveShipInspectionResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveShipInspectionResponseData (
        FuncRetrieveShipInspectionResponseData funcRetrieveShipInspectionResponseData
    ) : base(funcRetrieveShipInspectionResponseData)
    {  }
    #pragma warning restore CS8618

    public FuncRetrieveShipInspectionResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveShipInspectionResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FuncRetrieveShipInspectionResponseDataFromRaw.FromRawUnchecked"/>
    public static FuncRetrieveShipInspectionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FuncRetrieveShipInspectionResponseDataFromRaw : IFromRawJson<FuncRetrieveShipInspectionResponseData>
{
    /// <inheritdoc/>
    public FuncRetrieveShipInspectionResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FuncRetrieveShipInspectionResponseData.FromRawUnchecked(rawData);
}/// <summary>
/// Stable record type retained by both inspection path aliases.
/// </summary>
[JsonConverter(typeof(FuncRetrieveShipInspectionResponseDataRecordTypeConverter))]
public enum FuncRetrieveShipInspectionResponseDataRecordType
{
    BuildLogInspection
}sealed class FuncRetrieveShipInspectionResponseDataRecordTypeConverter : JsonConverter<FuncRetrieveShipInspectionResponseDataRecordType>
{
    public override FuncRetrieveShipInspectionResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "build_log_inspection"=>FuncRetrieveShipInspectionResponseDataRecordType.BuildLogInspection,
            _ =>(FuncRetrieveShipInspectionResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        FuncRetrieveShipInspectionResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FuncRetrieveShipInspectionResponseDataRecordType.BuildLogInspection=>"build_log_inspection",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StageConverter))]
public enum Stage
{
    Build, Platform, PreBuild, Deploy, SecurityReview, None, Pending
}sealed class StageConverter : JsonConverter<Stage>
{
    public override Stage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "build"=>Stage.Build,
            "platform"=>Stage.Platform,
            "pre_build"=>Stage.PreBuild,
            "deploy"=>Stage.Deploy,
            "security_review"=>Stage.SecurityReview,
            "none"=>Stage.None,
            "pending"=>Stage.Pending,
            _ =>(Stage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Stage value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Stage.Build=>"build",
            Stage.Platform=>"platform",
            Stage.PreBuild=>"pre_build",
            Stage.Deploy=>"deploy",
            Stage.SecurityReview=>"security_review",
            Stage.None=>"none",
            Stage.Pending=>"pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}