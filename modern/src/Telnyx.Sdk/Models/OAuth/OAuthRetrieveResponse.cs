using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuth;

[JsonConverter(typeof(JsonModelConverter<OAuthRetrieveResponse, OAuthRetrieveResponseFromRaw>))]
public sealed record class OAuthRetrieveResponse : JsonModel
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

    public OAuthRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthRetrieveResponse (
        OAuthRetrieveResponse oauthRetrieveResponse
    ) : base(oauthRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static OAuthRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthRetrieveResponseFromRaw : IFromRawJson<OAuthRetrieveResponse>
{
    /// <inheritdoc/>
    public OAuthRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Client ID
    /// </summary>
    public string? ClientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "client_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("client_id", value);
        }
    }

    /// <summary>
    /// URL of the client logo
    /// </summary>
    public string? LogoUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_uri"
            );
        }
        init { this._rawData.Set("logo_uri", value); }
    }

    /// <summary>
    /// Client name
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// URL of the client's privacy policy
    /// </summary>
    public string? PolicyUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "policy_uri"
            );
        }
        init { this._rawData.Set("policy_uri", value); }
    }

    /// <summary>
    /// The redirect URI for this authorization
    /// </summary>
    public string? RedirectUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "redirect_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("redirect_uri", value);
        }
    }

    public IReadOnlyList<RequestedScope>? RequestedScopes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<RequestedScope>>(
                "requested_scopes"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<RequestedScope>?>(
                "requested_scopes",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// URL of the client's terms of service
    /// </summary>
    public string? TosUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tos_uri"
            );
        }
        init { this._rawData.Set("tos_uri", value); }
    }

    /// <summary>
    /// Whether the client is verified
    /// </summary>
    public bool? Verified {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "verified"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("verified", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ClientID;
        _ = this.LogoUri;
        _ = this.Name;
        _ = this.PolicyUri;
        _ = this.RedirectUri;
        foreach (var item in this.RequestedScopes ?? [])
        {
            item.Validate();
        }
        _ = this.TosUri;
        _ = this.Verified;
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
}[JsonConverter(typeof(JsonModelConverter<RequestedScope, RequestedScopeFromRaw>))]
public sealed record class RequestedScope : JsonModel
{
    /// <summary>
    /// Scope ID
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Scope description
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Scope name
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
    }

    public RequestedScope ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestedScope (RequestedScope requestedScope) : base(requestedScope)
    {  }
    #pragma warning restore CS8618

    public RequestedScope (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestedScope (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequestedScopeFromRaw.FromRawUnchecked"/>
    public static RequestedScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class RequestedScopeFromRaw : IFromRawJson<RequestedScope>
{
    /// <inheritdoc/>
    public RequestedScope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequestedScope.FromRawUnchecked(rawData);
}