using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.UserAddresses;

[JsonConverter(typeof(JsonModelConverter<UserAddressRetrieveResponse, UserAddressRetrieveResponseFromRaw>))]
public sealed record class UserAddressRetrieveResponse : JsonModel
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

    public UserAddressRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserAddressRetrieveResponse (
        UserAddressRetrieveResponse userAddressRetrieveResponse
    ) : base(userAddressRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UserAddressRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserAddressRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserAddressRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UserAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserAddressRetrieveResponseFromRaw : IFromRawJson<UserAddressRetrieveResponse>
{
    /// <inheritdoc/>
    public UserAddressRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserAddressRetrieveResponse.FromRawUnchecked(rawData);
}