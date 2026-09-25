using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.OAuthClients;

namespace Telnyx.Sdk.Models.OAuthGrants;

[JsonConverter(typeof(JsonModelConverter<OAuthGrantListPageResponse, OAuthGrantListPageResponseFromRaw>))]
public sealed record class OAuthGrantListPageResponse : JsonModel
{
    public IReadOnlyList<OAuthGrant>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OAuthGrant>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OAuthGrant>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public OAuthOAuthPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OAuthOAuthPaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public OAuthGrantListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthGrantListPageResponse (
        OAuthGrantListPageResponse oauthGrantListPageResponse
    ) : base(oauthGrantListPageResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthGrantListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthGrantListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthGrantListPageResponseFromRaw.FromRawUnchecked"/>
    public static OAuthGrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthGrantListPageResponseFromRaw : IFromRawJson<OAuthGrantListPageResponse>
{
    /// <inheritdoc/>
    public OAuthGrantListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthGrantListPageResponse.FromRawUnchecked(rawData);
}