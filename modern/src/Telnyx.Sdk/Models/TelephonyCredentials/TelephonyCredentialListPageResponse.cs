using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredentialListPageResponse, TelephonyCredentialListPageResponseFromRaw>))]
public sealed record class TelephonyCredentialListPageResponse : JsonModel
{
    public IReadOnlyList<TelephonyCredential>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TelephonyCredential>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TelephonyCredential>?>(
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

    public TelephonyCredentialListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredentialListPageResponse (
        TelephonyCredentialListPageResponse telephonyCredentialListPageResponse
    ) : base(telephonyCredentialListPageResponse)
    {  }
    #pragma warning restore CS8618

    public TelephonyCredentialListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredentialListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialListPageResponseFromRaw.FromRawUnchecked"/>
    public static TelephonyCredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialListPageResponseFromRaw : IFromRawJson<TelephonyCredentialListPageResponse>
{
    /// <inheritdoc/>
    public TelephonyCredentialListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredentialListPageResponse.FromRawUnchecked(rawData);
}