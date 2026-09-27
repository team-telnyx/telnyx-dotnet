using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants.Tools;

/// <summary>
/// Response model for webhook tool test results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolTestResponse, ToolTestResponseFromRaw>))]
public sealed record class ToolTestResponse : JsonModel
{
    /// <summary>
    /// Response model for webhook tool test results
    /// </summary>
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

    public ToolTestResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolTestResponse (ToolTestResponse toolTestResponse) : base(
        toolTestResponse
    )
    {  }
    #pragma warning restore CS8618

    public ToolTestResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTestResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToolTestResponseFromRaw.FromRawUnchecked"/>
    public static ToolTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ToolTestResponse (Data data) : this()
    { this.Data = data; }
}

class ToolTestResponseFromRaw : IFromRawJson<ToolTestResponse>
{
    /// <inheritdoc/>
    public ToolTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ToolTestResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Response model for webhook tool test results
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string ContentType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "content_type"
            );
        }
        init { this._rawData.Set("content_type", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Request {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "request"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "request",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string Response {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "response"
            );
        }
        init { this._rawData.Set("response", value); }
    }

    public required long StatusCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "status_code"
            );
        }
        init { this._rawData.Set("status_code", value); }
    }

    public required bool Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "success"
            );
        }
        init { this._rawData.Set("success", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ContentType;
        _ = this.Request;
        _ = this.Response;
        _ = this.StatusCode;
        _ = this.Success;
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