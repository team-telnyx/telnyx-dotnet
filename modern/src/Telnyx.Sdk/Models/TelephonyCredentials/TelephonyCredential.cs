using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TelephonyCredentials;

[JsonConverter(typeof(JsonModelConverter<TelephonyCredential, TelephonyCredentialFromRaw>))]
public sealed record class TelephonyCredential : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
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

    /// <summary>
    /// ISO-8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Defaults to false
    /// </summary>
    public bool? Expired {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "expired"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expired", value);
        }
    }

    /// <summary>
    /// ISO-8601 formatted date indicating when the resource will expire.
    /// </summary>
    public string? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "expires_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("expires_at", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
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

    /// <summary>
    /// Identifies the resource this credential is associated with.
    /// </summary>
    public string? ResourceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "resource_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("resource_id", value);
        }
    }

    /// <summary>
    /// The randomly generated SIP password for the credential.
    /// </summary>
    public string? SipPassword {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_password"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_password", value);
        }
    }

    /// <summary>
    /// The randomly generated SIP username for the credential.
    /// </summary>
    public string? SipUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_username"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sip_username", value);
        }
    }

    /// <summary>
    /// ISO-8601 formatted date indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <summary>
    /// Identifies the user this credential is associated with.
    /// </summary>
    public string? UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Expired;
        _ = this.ExpiresAt;
        _ = this.Name;
        _ = this.RecordType;
        _ = this.ResourceID;
        _ = this.SipPassword;
        _ = this.SipUsername;
        _ = this.UpdatedAt;
        _ = this.UserID;
    }

    public TelephonyCredential ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TelephonyCredential (TelephonyCredential telephonyCredential) : base(
        telephonyCredential
    )
    {  }
    #pragma warning restore CS8618

    public TelephonyCredential (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TelephonyCredential (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TelephonyCredentialFromRaw.FromRawUnchecked"/>
    public static TelephonyCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TelephonyCredentialFromRaw : IFromRawJson<TelephonyCredential>
{
    /// <inheritdoc/>
    public TelephonyCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TelephonyCredential.FromRawUnchecked(rawData);
}