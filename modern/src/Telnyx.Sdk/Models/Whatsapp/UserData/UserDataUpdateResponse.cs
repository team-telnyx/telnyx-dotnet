using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.UserData;

[JsonConverter(typeof(JsonModelConverter<UserDataUpdateResponse, UserDataUpdateResponseFromRaw>))]
public sealed record class UserDataUpdateResponse : JsonModel
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

    public UserDataUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserDataUpdateResponse (
        UserDataUpdateResponse userDataUpdateResponse
    ) : base(userDataUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public UserDataUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserDataUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserDataUpdateResponseFromRaw.FromRawUnchecked"/>
    public static UserDataUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserDataUpdateResponseFromRaw : IFromRawJson<UserDataUpdateResponse>
{
    /// <inheritdoc/>
    public UserDataUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserDataUpdateResponse.FromRawUnchecked(rawData);
}