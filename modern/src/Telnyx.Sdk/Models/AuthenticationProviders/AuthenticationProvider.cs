using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

[JsonConverter(typeof(JsonModelConverter<AuthenticationProvider, AuthenticationProviderFromRaw>))]
public sealed record class AuthenticationProvider : JsonModel
{
    /// <summary>
    /// Uniquely identifies the authentication provider.
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
    /// ISO 8601 formatted date indicating when the authentication provider was activated.
    /// </summary>
    public System::DateTimeOffset? ActivatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "activated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activated_at", value);
        }
    }

    /// <summary>
    /// The active status of the authentication provider
    /// </summary>
    public bool? Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "active"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("active", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// The name associated with the authentication provider.
    /// </summary>
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
    /// The id from the Organization the authentication provider belongs to.
    /// </summary>
    public string? OrganizationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "organization_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("organization_id", value);
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
    /// The settings associated with the authentication provider.
    /// </summary>
    public Settings? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Settings>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    /// <summary>
    /// The short name associated with the authentication provider. This must be unique
    /// and URL-friendly, as it's going to be part of the login URL.
    /// </summary>
    public string? ShortName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "short_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("short_name", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was updated.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActivatedAt;
        _ = this.Active;
        _ = this.CreatedAt;
        _ = this.Name;
        _ = this.OrganizationID;
        _ = this.RecordType;
        this.Settings?.Validate();
        _ = this.ShortName;
        _ = this.UpdatedAt;
    }

    public AuthenticationProvider ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProvider (
        AuthenticationProvider authenticationProvider
    ) : base(authenticationProvider)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProvider (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProvider (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderFromRaw.FromRawUnchecked"/>
    public static AuthenticationProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderFromRaw : IFromRawJson<AuthenticationProvider>
{
    /// <inheritdoc/>
    public AuthenticationProvider FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProvider.FromRawUnchecked(rawData);
}

/// <summary>
/// The settings associated with the authentication provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Settings, SettingsFromRaw>))]
public sealed record class Settings : JsonModel
{
    /// <summary>
    /// The Assertion Consumer Service URL for the service provider (Telnyx).
    /// </summary>
    public string? AssertionConsumerServiceUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "assertion_consumer_service_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("assertion_consumer_service_url", value);
        }
    }

    /// <summary>
    /// Mapping of SAML attribute names used by the identity provider (IdP).
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? IdpAttributeNames {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "idp_attribute_names"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "idp_attribute_names",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The certificate fingerprint for the identity provider (IdP)
    /// </summary>
    public string? IdpCertFingerprint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idp_cert_fingerprint"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_cert_fingerprint", value);
        }
    }

    /// <summary>
    /// The algorithm used to generate the identity provider's (IdP) certificate fingerprint
    /// </summary>
    public ApiEnum<string, IdpCertFingerprintAlgorithm>? IdpCertFingerprintAlgorithm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, IdpCertFingerprintAlgorithm>>(
                "idp_cert_fingerprint_algorithm"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_cert_fingerprint_algorithm", value);
        }
    }

    /// <summary>
    /// The full X.509 certificate for the identity provider (IdP).
    /// </summary>
    public string? IdpCertificate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idp_certificate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_certificate", value);
        }
    }

    /// <summary>
    /// The Entity ID for the identity provider (IdP).
    /// </summary>
    public string? IdpEntityID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idp_entity_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_entity_id", value);
        }
    }

    /// <summary>
    /// The Single Logout (SLO) target URL for the identity provider (IdP).
    /// </summary>
    public string? IdpSloTargetUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idp_slo_target_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_slo_target_url", value);
        }
    }

    /// <summary>
    /// The SSO target url for the identity provider (IdP).
    /// </summary>
    public string? IdpSsoTargetUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "idp_sso_target_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("idp_sso_target_url", value);
        }
    }

    /// <summary>
    /// The name identifier format associated with the authentication provider. This
    /// must be the same for both the Identity Provider (IdP) and the service provider (Telnyx).
    /// </summary>
    public string? NameIdentifierFormat {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name_identifier_format"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name_identifier_format", value);
        }
    }

    /// <summary>
    /// Whether group provisioning is enabled for this authentication provider.
    /// </summary>
    public bool? ProvisionGroups {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "provision_groups"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("provision_groups", value);
        }
    }

    /// <summary>
    /// The Entity ID for the service provider (Telnyx).
    /// </summary>
    public string? ServiceProviderEntityID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "service_provider_entity_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("service_provider_entity_id", value);
        }
    }

    /// <summary>
    /// The login URL for the service provider (Telnyx). Users navigate to this URL
    /// to initiate SSO login.
    /// </summary>
    public string? ServiceProviderLoginUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "service_provider_login_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("service_provider_login_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AssertionConsumerServiceUrl;
        _ = this.IdpAttributeNames;
        _ = this.IdpCertFingerprint;
        this.IdpCertFingerprintAlgorithm?.Validate();
        _ = this.IdpCertificate;
        _ = this.IdpEntityID;
        _ = this.IdpSloTargetUrl;
        _ = this.IdpSsoTargetUrl;
        _ = this.NameIdentifierFormat;
        _ = this.ProvisionGroups;
        _ = this.ServiceProviderEntityID;
        _ = this.ServiceProviderLoginUrl;
    }

    public Settings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Settings (Settings settings) : base(settings)
    {  }
    #pragma warning restore CS8618

    public Settings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Settings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingsFromRaw.FromRawUnchecked"/>
    public static Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SettingsFromRaw : IFromRawJson<Settings>
{
    /// <inheritdoc/>
    public Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Settings.FromRawUnchecked(rawData);
}/// <summary>
/// The algorithm used to generate the identity provider's (IdP) certificate fingerprint
/// </summary>
[JsonConverter(typeof(IdpCertFingerprintAlgorithmConverter))]
public enum IdpCertFingerprintAlgorithm
{
    Sha1, Sha256, Sha384, Sha512
}sealed class IdpCertFingerprintAlgorithmConverter : JsonConverter<IdpCertFingerprintAlgorithm>
{
    public override IdpCertFingerprintAlgorithm Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sha1"=>IdpCertFingerprintAlgorithm.Sha1,
            "sha256"=>IdpCertFingerprintAlgorithm.Sha256,
            "sha384"=>IdpCertFingerprintAlgorithm.Sha384,
            "sha512"=>IdpCertFingerprintAlgorithm.Sha512,
            _ =>(IdpCertFingerprintAlgorithm)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        IdpCertFingerprintAlgorithm value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            IdpCertFingerprintAlgorithm.Sha1=>"sha1",
            IdpCertFingerprintAlgorithm.Sha256=>"sha256",
            IdpCertFingerprintAlgorithm.Sha384=>"sha384",
            IdpCertFingerprintAlgorithm.Sha512=>"sha512",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}