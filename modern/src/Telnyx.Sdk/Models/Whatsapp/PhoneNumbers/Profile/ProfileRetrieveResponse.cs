using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile;

[JsonConverter(typeof(JsonModelConverter<ProfileRetrieveResponse, ProfileRetrieveResponseFromRaw>))]
public sealed record class ProfileRetrieveResponse : JsonModel
{
    public WhatsappProfileData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappProfileData>(
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

    public ProfileRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveResponse (
        ProfileRetrieveResponse profileRetrieveResponse
    ) : base(profileRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProfileRetrieveResponseFromRaw : IFromRawJson<ProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public ProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRetrieveResponse.FromRawUnchecked(rawData);
}