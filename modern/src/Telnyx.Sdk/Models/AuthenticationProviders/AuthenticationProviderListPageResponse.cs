using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderListPageResponse, AuthenticationProviderListPageResponseFromRaw>))]
public sealed record class AuthenticationProviderListPageResponse : JsonModel
{
    public IReadOnlyList<AuthenticationProvider>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<AuthenticationProvider>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<AuthenticationProvider>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public AuthenticationProviderListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderListPageResponse (
        AuthenticationProviderListPageResponse authenticationProviderListPageResponse
    ) : base(authenticationProviderListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderListPageResponseFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderListPageResponseFromRaw : IFromRawJson<AuthenticationProviderListPageResponse>
{
    /// <inheritdoc/>
    public AuthenticationProviderListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderListPageResponse.FromRawUnchecked(rawData);
}