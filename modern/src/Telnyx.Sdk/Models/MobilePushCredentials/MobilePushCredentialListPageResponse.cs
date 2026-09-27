using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.MobilePushCredentials;

/// <summary>
/// Mobile mobile push credentials
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MobilePushCredentialListPageResponse, MobilePushCredentialListPageResponseFromRaw>))]
public sealed record class MobilePushCredentialListPageResponse : JsonModel
{
    public IReadOnlyList<PushCredential>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PushCredential>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PushCredential>?>(
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

    public MobilePushCredentialListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobilePushCredentialListPageResponse (
        MobilePushCredentialListPageResponse mobilePushCredentialListPageResponse
    ) : base(mobilePushCredentialListPageResponse)
    {  }
    #pragma warning restore CS8618

    public MobilePushCredentialListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobilePushCredentialListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobilePushCredentialListPageResponseFromRaw.FromRawUnchecked"/>
    public static MobilePushCredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobilePushCredentialListPageResponseFromRaw : IFromRawJson<MobilePushCredentialListPageResponse>
{
    /// <inheritdoc/>
    public MobilePushCredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobilePushCredentialListPageResponse.FromRawUnchecked(rawData);
}