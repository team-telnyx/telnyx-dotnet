using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.Profile;

[JsonConverter(typeof(JsonModelConverter<WhatsappProfileData, WhatsappProfileDataFromRaw>))]
public sealed record class WhatsappProfileData : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? About {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "about"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("about", value);
        }
    }

    public string? Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("address", value);
        }
    }

    public string? Category {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "category"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("category", value);
        }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? DisplayName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "display_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("display_name", value);
        }
    }

    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Whatsapp phone number ID
    /// </summary>
    public string? PhoneNumberID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_id", value);
        }
    }

    public string? ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_id", value);
        }
    }

    public string? ProfilePhotoUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "profile_photo_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("profile_photo_url", value);
        }
    }

    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public string? Website {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "website"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("website", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.About;
        _ = this.Address;
        _ = this.Category;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.DisplayName;
        _ = this.Email;
        _ = this.PhoneNumberID;
        _ = this.ProfileID;
        _ = this.ProfilePhotoUrl;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.Website;
    }

    public WhatsappProfileData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappProfileData (WhatsappProfileData whatsappProfileData) : base(
        whatsappProfileData
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappProfileData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappProfileData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappProfileDataFromRaw.FromRawUnchecked"/>
    public static WhatsappProfileData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappProfileDataFromRaw : IFromRawJson<WhatsappProfileData>
{
    /// <inheritdoc/>
    public WhatsappProfileData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappProfileData.FromRawUnchecked(rawData);
}