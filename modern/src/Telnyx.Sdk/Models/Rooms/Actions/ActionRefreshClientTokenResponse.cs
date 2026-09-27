using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRefreshClientTokenResponse, ActionRefreshClientTokenResponseFromRaw>))]
public sealed record class ActionRefreshClientTokenResponse : JsonModel
{
    public ActionRefreshClientTokenResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionRefreshClientTokenResponseData>(
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

    public ActionRefreshClientTokenResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRefreshClientTokenResponse (
        ActionRefreshClientTokenResponse actionRefreshClientTokenResponse
    ) : base(actionRefreshClientTokenResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRefreshClientTokenResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRefreshClientTokenResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRefreshClientTokenResponseFromRaw.FromRawUnchecked"/>
    public static ActionRefreshClientTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRefreshClientTokenResponseFromRaw : IFromRawJson<ActionRefreshClientTokenResponse>
{
    /// <inheritdoc/>
    public ActionRefreshClientTokenResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRefreshClientTokenResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionRefreshClientTokenResponseData, ActionRefreshClientTokenResponseDataFromRaw>))]
public sealed record class ActionRefreshClientTokenResponseData : JsonModel
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
        _ = this.TokenExpiresAt;
    }

    public ActionRefreshClientTokenResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRefreshClientTokenResponseData (
        ActionRefreshClientTokenResponseData actionRefreshClientTokenResponseData
    ) : base(actionRefreshClientTokenResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionRefreshClientTokenResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRefreshClientTokenResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRefreshClientTokenResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionRefreshClientTokenResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionRefreshClientTokenResponseDataFromRaw : IFromRawJson<ActionRefreshClientTokenResponseData>
{
    /// <inheritdoc/>
    public ActionRefreshClientTokenResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRefreshClientTokenResponseData.FromRawUnchecked(rawData);
}