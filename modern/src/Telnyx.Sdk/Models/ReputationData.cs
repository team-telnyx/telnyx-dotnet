using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

/// <summary>
/// Reputation snapshot for a phone number. Each metric is a 0–100 score; `spam_risk`
/// is a coarse bucket. Field set may grow over time - read by key.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReputationData, ReputationDataFromRaw>))]
public sealed record class ReputationData : JsonModel
{
    public long? ConnectionScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "connection_score"
            );
        }
        init { this._rawData.Set("connection_score", value); }
    }

    public long? EngagementScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "engagement_score"
            );
        }
        init { this._rawData.Set("engagement_score", value); }
    }

    public System::DateTimeOffset? LastRefreshedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "last_refreshed_at"
            );
        }
        init { this._rawData.Set("last_refreshed_at", value); }
    }

    public long? MaturityScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "maturity_score"
            );
        }
        init { this._rawData.Set("maturity_score", value); }
    }

    public long? SentimentScore {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "sentiment_score"
            );
        }
        init { this._rawData.Set("sentiment_score", value); }
    }

    /// <summary>
    /// Category label from the reputation feed when the number is flagged.
    /// </summary>
    public string? SpamCategory {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "spam_category"
            );
        }
        init { this._rawData.Set("spam_category", value); }
    }

    /// <summary>
    /// Overall spam-risk classification.
    /// </summary>
    public ApiEnum<string, SpamRisk>? SpamRisk {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SpamRisk>>(
                "spam_risk"
            );
        }
        init { this._rawData.Set("spam_risk", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectionScore;
        _ = this.EngagementScore;
        _ = this.LastRefreshedAt;
        _ = this.MaturityScore;
        _ = this.SentimentScore;
        _ = this.SpamCategory;
        this.SpamRisk?.Validate();
    }

    public ReputationData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReputationData (ReputationData reputationData) : base(reputationData)
    {  }
    #pragma warning restore CS8618

    public ReputationData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReputationData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReputationDataFromRaw.FromRawUnchecked"/>
    public static ReputationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReputationDataFromRaw : IFromRawJson<ReputationData>
{
    /// <inheritdoc/>
    public ReputationData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ReputationData.FromRawUnchecked(rawData);
}

/// <summary>
/// Overall spam-risk classification.
/// </summary>
[JsonConverter(typeof(SpamRiskConverter))]
public enum SpamRisk
{
    Low, Medium, High
}sealed class SpamRiskConverter : JsonConverter<SpamRisk>
{
    public override SpamRisk Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "low"=>SpamRisk.Low,
            "medium"=>SpamRisk.Medium,
            "high"=>SpamRisk.High,
            _ =>(SpamRisk)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, SpamRisk value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SpamRisk.Low=>"low",
            SpamRisk.Medium=>"medium",
            SpamRisk.High=>"high",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}