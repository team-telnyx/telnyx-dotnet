using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Actions;

/// <summary>
/// Synchronously create an Client Token to join a Room. Client Token is necessary
/// to join a Telnyx Room. Client Token will expire after `token_ttl_secs`, a Refresh
/// Token is also provided to refresh a Client Token, the Refresh Token expires after `refresh_token_ttl_secs`.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionGenerateJoinClientTokenParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? RoomID { get; init; }

    /// <summary>
    /// The time to live in seconds of the Refresh Token, after that time the Refresh
    /// Token is invalid and can't be used to refresh Client Token.
    /// </summary>
    public long? RefreshTokenTtlSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "refresh_token_ttl_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("refresh_token_ttl_secs", value);
        }
    }

    /// <summary>
    /// The time to live in seconds of the Client Token, after that time the Client
    /// Token is invalid and can't be used to join a Room.
    /// </summary>
    public long? TokenTtlSecs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "token_ttl_secs"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("token_ttl_secs", value);
        }
    }

    public ActionGenerateJoinClientTokenParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGenerateJoinClientTokenParams (
        ActionGenerateJoinClientTokenParams actionGenerateJoinClientTokenParams
    ) : base(actionGenerateJoinClientTokenParams)
    {
        this.RoomID = actionGenerateJoinClientTokenParams.RoomID;

        this._rawBodyData = new(actionGenerateJoinClientTokenParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionGenerateJoinClientTokenParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionGenerateJoinClientTokenParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string roomID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.RoomID = roomID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionGenerateJoinClientTokenParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string roomID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            roomID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["RoomID"] = JsonSerializer.SerializeToElement(this.RoomID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionGenerateJoinClientTokenParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.RoomID?.Equals(other.RoomID) ?? other.RoomID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/rooms/{0}/actions/generate_join_client_token",
            this.RoomID)
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}