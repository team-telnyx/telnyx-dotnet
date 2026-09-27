using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.UserAddresses;

[JsonConverter(typeof(JsonModelConverter<UserAddressListPageResponse, UserAddressListPageResponseFromRaw>))]
public sealed record class UserAddressListPageResponse : JsonModel
{
    public IReadOnlyList<UserAddressesUserAddress>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<UserAddressesUserAddress>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<UserAddressesUserAddress>?>(
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

    public UserAddressListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddressListPageResponse (
        UserAddressListPageResponse userAddressListPageResponse
    ) : base(userAddressListPageResponse)
    {  }
    #pragma warning restore CS8618

    public UserAddressListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddressListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserAddressListPageResponseFromRaw.FromRawUnchecked"/>
    public static UserAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserAddressListPageResponseFromRaw : IFromRawJson<UserAddressListPageResponse>
{
    /// <inheritdoc/>
    public UserAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserAddressListPageResponse.FromRawUnchecked(rawData);
}