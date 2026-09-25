using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionGenerateJoinClientTokenResponse, ActionGenerateJoinClientTokenResponseFromRaw>))]
public sealed record class ActionGenerateJoinClientTokenResponse : JsonModel
{
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

    public ActionGenerateJoinClientTokenResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGenerateJoinClientTokenResponse (
        ActionGenerateJoinClientTokenResponse actionGenerateJoinClientTokenResponse
    ) : base(actionGenerateJoinClientTokenResponse)
    {  }
    #pragma warning restore CS8618

    public ActionGenerateJoinClientTokenResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGenerateJoinClientTokenResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionGenerateJoinClientTokenResponseFromRaw.FromRawUnchecked"/>
    public static ActionGenerateJoinClientTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionGenerateJoinClientTokenResponseFromRaw : IFromRawJson<ActionGenerateJoinClientTokenResponse>
{
    /// <inheritdoc/>
    public ActionGenerateJoinClientTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionGenerateJoinClientTokenResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? Token {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token", value);
        }
    }

    public string? RefreshToken {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "refresh_token"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("refresh_token", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the refresh token expires.
    /// </summary>
    public DateTimeOffset? RefreshTokenExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "refresh_token_expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("refresh_token_expires_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp when the token expires.
    /// </summary>
    public DateTimeOffset? TokenExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "token_expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("token_expires_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Token;
        _ = this.RefreshToken;
        _ = this.RefreshTokenExpiresAt;
        _ = this.TokenExpiresAt;
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