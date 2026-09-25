using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.UserData;

[JsonConverter(typeof(JsonModelConverter<UserDataRetrieveResponse, UserDataRetrieveResponseFromRaw>))]
public sealed record class UserDataRetrieveResponse : JsonModel
{
    public WhatsappUserData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappUserData>(
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

    public UserDataRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserDataRetrieveResponse (
        UserDataRetrieveResponse userDataRetrieveResponse
    ) : base(userDataRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UserDataRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserDataRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserDataRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UserDataRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserDataRetrieveResponseFromRaw : IFromRawJson<UserDataRetrieveResponse>
{
    /// <inheritdoc/>
    public UserDataRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserDataRetrieveResponse.FromRawUnchecked(rawData);
}