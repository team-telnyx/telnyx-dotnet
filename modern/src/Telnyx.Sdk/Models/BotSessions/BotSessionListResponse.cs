using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.BotSessions;

[JsonConverter(typeof(JsonModelConverter<BotSessionListResponse, BotSessionListResponseFromRaw>))]
public sealed record class BotSessionListResponse : JsonModel
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

    public BotSessionListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BotSessionListResponse (
        BotSessionListResponse botSessionListResponse
    ) : base(botSessionListResponse)
    {  }
    #pragma warning restore CS8618

    public BotSessionListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BotSessionListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BotSessionListResponseFromRaw.FromRawUnchecked"/>
    public static BotSessionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BotSessionListResponse (Data data) : this()
    { this.Data = data; }
}

class BotSessionListResponseFromRaw : IFromRawJson<BotSessionListResponse>
{
    /// <inheritdoc/>
    public BotSessionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BotSessionListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// API v2 session token for the signed-in user. Use it as a bearer token on authenticated endpoints.
    /// </summary>
    public required string ApiV2Token {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_v2_token"
            );
        }
        init { this._rawData.Set("api_v2_token", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.ApiV2Token; }

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

    [SetsRequiredMembers]
    public Data (string apiV2Token) : this()
    { this.ApiV2Token = apiV2Token; }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}