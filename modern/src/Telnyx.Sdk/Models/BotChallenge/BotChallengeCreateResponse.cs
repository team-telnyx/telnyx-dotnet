using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.BotChallenge;

[JsonConverter(typeof(JsonModelConverter<BotChallengeCreateResponse, BotChallengeCreateResponseFromRaw>))]
public sealed record class BotChallengeCreateResponse : JsonModel
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

    public BotChallengeCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BotChallengeCreateResponse (
        BotChallengeCreateResponse botChallengeCreateResponse
    ) : base(botChallengeCreateResponse)
    {  }
    #pragma warning restore CS8618

    public BotChallengeCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BotChallengeCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BotChallengeCreateResponseFromRaw.FromRawUnchecked"/>
    public static BotChallengeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BotChallengeCreateResponse (Data data) : this()
    { this.Data = data; }
}

class BotChallengeCreateResponseFromRaw : IFromRawJson<BotChallengeCreateResponse>
{
    /// <inheritdoc/>
    public BotChallengeCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BotChallengeCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Type of challenge.
    /// </summary>
    public required ApiEnum<string, ChallengeType> ChallengeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChallengeType>>(
                "challenge_type"
            );
        }
        init { this._rawData.Set("challenge_type", value); }
    }

    /// <summary>
    /// Single-use challenge identifier. Submit it as `bot_challenge_nonce` on the
    /// signup request.
    /// </summary>
    public required string Nonce {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "nonce"
            );
        }
        init { this._rawData.Set("nonce", value); }
    }

    /// <summary>
    /// Current privacy-policy URL. Echo this back on the signup request.
    /// </summary>
    public required string PrivacyPolicyUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "privacy_policy_url"
            );
        }
        init { this._rawData.Set("privacy_policy_url", value); }
    }

    /// <summary>
    /// Problem text to solve. Math problems are obfuscated and end with an unobfuscated
    /// rounding instruction; string and binary problems are returned as-is.
    /// </summary>
    public required string Problem {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "problem"
            );
        }
        init { this._rawData.Set("problem", value); }
    }

    /// <summary>
    /// Current terms-and-conditions URL. Echo this back on the signup request.
    /// </summary>
    public required string TermsAndConditionsUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "terms_and_conditions_url"
            );
        }
        init { this._rawData.Set("terms_and_conditions_url", value); }
    }

    /// <summary>
    /// Decimal places expected in the answer. Present only for math challenges.
    /// </summary>
    public long? Precision {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "precision"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("precision", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChallengeType.Validate();
        _ = this.Nonce;
        _ = this.PrivacyPolicyUrl;
        _ = this.Problem;
        _ = this.TermsAndConditionsUrl;
        _ = this.Precision;
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
}/// <summary>
/// Type of challenge.
/// </summary>
[JsonConverter(typeof(ChallengeTypeConverter))]
public enum ChallengeType
{
    Math, String, Binary
}sealed class ChallengeTypeConverter : JsonConverter<ChallengeType>
{
    public override ChallengeType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "math"=>ChallengeType.Math,
            "string"=>ChallengeType.String,
            "binary"=>ChallengeType.Binary,
            _ =>(ChallengeType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChallengeType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ChallengeType.Math=>"math",
            ChallengeType.String=>"string",
            ChallengeType.Binary=>"binary",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}