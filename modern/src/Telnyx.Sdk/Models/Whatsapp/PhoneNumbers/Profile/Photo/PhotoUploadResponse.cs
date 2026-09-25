using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile.Photo;

[JsonConverter(typeof(JsonModelConverter<PhotoUploadResponse, PhotoUploadResponseFromRaw>))]
public sealed record class PhotoUploadResponse : JsonModel
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

    public PhotoUploadResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhotoUploadResponse (PhotoUploadResponse photoUploadResponse) : base(
        photoUploadResponse
    )
    {  }
    #pragma warning restore CS8618

    public PhotoUploadResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhotoUploadResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhotoUploadResponseFromRaw.FromRawUnchecked"/>
    public static PhotoUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhotoUploadResponseFromRaw : IFromRawJson<PhotoUploadResponse>
{
    /// <inheritdoc/>
    public PhotoUploadResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhotoUploadResponse.FromRawUnchecked(rawData);
}