using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthRetrieveJwksResponse, OAuthRetrieveJwksResponseFromRaw>))]
public sealed record class OAuthRetrieveJwksResponse : JsonModel
{
    public IReadOnlyList<Key>? Keys {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Key>>(
                "keys"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Key>?>(
                "keys",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Keys ?? [])
        {
            item.Validate();
        }
    }

    public OAuthRetrieveJwksResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthRetrieveJwksResponse (
        OAuthRetrieveJwksResponse oauthRetrieveJwksResponse
    ) : base(oauthRetrieveJwksResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthRetrieveJwksResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthRetrieveJwksResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthRetrieveJwksResponseFromRaw.FromRawUnchecked"/>
    public static OAuthRetrieveJwksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthRetrieveJwksResponseFromRaw : IFromRawJson<OAuthRetrieveJwksResponse>
{
    /// <inheritdoc/>
    public OAuthRetrieveJwksResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthRetrieveJwksResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Key, KeyFromRaw>))]
public sealed record class Key : JsonModel
{
    /// <summary>
    /// Algorithm
    /// </summary>
    public string? Alg {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "alg"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("alg", value);
        }
    }

    /// <summary>
    /// Key ID
    /// </summary>
    public string? Kid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "kid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("kid", value);
        }
    }

    /// <summary>
    /// Key type
    /// </summary>
    public string? Kty {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "kty"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("kty", value);
        }
    }

    /// <summary>
    /// Key use
    /// </summary>
    public string? Use {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "use"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alg;
        _ = this.Kid;
        _ = this.Kty;
        _ = this.Use;
    }

    public Key ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Key (Key key) : base(key)
    {  }
    #pragma warning restore CS8618

    public Key (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Key (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="KeyFromRaw.FromRawUnchecked"/>
    public static Key FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class KeyFromRaw : IFromRawJson<Key>
{
    /// <inheritdoc/>
    public Key FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Key.FromRawUnchecked(rawData);
}