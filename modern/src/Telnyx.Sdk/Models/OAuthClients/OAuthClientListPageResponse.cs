using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OAuthClients;

[JsonConverter(typeof(JsonModelConverter<OAuthClientListPageResponse, OAuthClientListPageResponseFromRaw>))]
public sealed record class OAuthClientListPageResponse : JsonModel
{
    public IReadOnlyList<OAuthClient>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<OAuthClient>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<OAuthClient>?>(
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

    public OAuthClientListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthClientListPageResponse (
        OAuthClientListPageResponse oauthClientListPageResponse
    ) : base(oauthClientListPageResponse)
    {  }
    #pragma warning restore CS8618

    public OAuthClientListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthClientListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthClientListPageResponseFromRaw.FromRawUnchecked"/>
    public static OAuthClientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthClientListPageResponseFromRaw : IFromRawJson<OAuthClientListPageResponse>
{
    /// <inheritdoc/>
    public OAuthClientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthClientListPageResponse.FromRawUnchecked(rawData);
}