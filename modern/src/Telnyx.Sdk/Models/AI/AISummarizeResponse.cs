using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI;

[JsonConverter(typeof(JsonModelConverter<AISummarizeResponse, AISummarizeResponseFromRaw>))]
public sealed record class AISummarizeResponse : JsonModel
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

    public AISummarizeResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AISummarizeResponse (AISummarizeResponse aiSummarizeResponse) : base(
        aiSummarizeResponse
    )
    {  }
    #pragma warning restore CS8618

    public AISummarizeResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AISummarizeResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AISummarizeResponseFromRaw.FromRawUnchecked"/>
    public static AISummarizeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public AISummarizeResponse (Data data) : this()
    { this.Data = data; }
}

class AISummarizeResponseFromRaw : IFromRawJson<AISummarizeResponse>
{
    /// <inheritdoc/>
    public AISummarizeResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AISummarizeResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public required string Summary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "summary"
            );
        }
        init { this._rawData.Set("summary", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Summary; }

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
    public Data (string summary) : this()
    { this.Summary = summary; }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}