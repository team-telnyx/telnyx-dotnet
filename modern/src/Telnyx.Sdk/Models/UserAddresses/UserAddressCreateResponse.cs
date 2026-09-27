using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UserAddresses;

[JsonConverter(typeof(JsonModelConverter<UserAddressCreateResponse, UserAddressCreateResponseFromRaw>))]
public sealed record class UserAddressCreateResponse : JsonModel
{
    public UserAddressesUserAddress? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<UserAddressesUserAddress>(
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

    public UserAddressCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddressCreateResponse (
        UserAddressCreateResponse userAddressCreateResponse
    ) : base(userAddressCreateResponse)
    {  }
    #pragma warning restore CS8618

    public UserAddressCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddressCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserAddressCreateResponseFromRaw.FromRawUnchecked"/>
    public static UserAddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserAddressCreateResponseFromRaw : IFromRawJson<UserAddressCreateResponse>
{
    /// <inheritdoc/>
    public UserAddressCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserAddressCreateResponse.FromRawUnchecked(rawData);
}