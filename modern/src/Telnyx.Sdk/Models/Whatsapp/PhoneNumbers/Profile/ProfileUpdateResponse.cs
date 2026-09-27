using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile;

[JsonConverter(typeof(JsonModelConverter<ProfileUpdateResponse, ProfileUpdateResponseFromRaw>))]
public sealed record class ProfileUpdateResponse : JsonModel
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

    public ProfileUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileUpdateResponse (
        ProfileUpdateResponse profileUpdateResponse
    ) : base(profileUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProfileUpdateResponseFromRaw : IFromRawJson<ProfileUpdateResponse>
{
    /// <inheritdoc/>
    public ProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileUpdateResponse.FromRawUnchecked(rawData);
}