using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AuthenticationProviders;

/// <summary>
/// The settings associated with the authentication provider.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<AuthenticationProviderSettings, AuthenticationProviderSettingsFromRaw>))]
public sealed record class AuthenticationProviderSettings : JsonModel
{
    /// <summary>
    /// The certificate fingerprint for the identity provider (IdP)
    /// </summary>
    public required string IdpCertFingerprint {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "idp_cert_fingerprint"
            );
        }
        init { this._rawData.Set("idp_cert_fingerprint", value); }
    }

    /// <summary>
    /// The Entity ID for the identity provider (IdP).
    /// </summary>
    public required string IdpEntityID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "idp_entity_id"
            );
        }
        init { this._rawData.Set("idp_entity_id", value); }
    }

    /// <summary>
    /// The SSO target url for the identity provider (IdP).
    /// </summary>
    public required string IdpSsoTargetUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "idp_sso_target_url"
            );
        }
        init { this._rawData.Set("idp_sso_target_url", value); }
    }

    /// <summary>
    /// The algorithm used to generate the identity provider's (IdP) certificate fingerprint
    /// </summary>
    public ApiEnum<string, AuthenticationProviderSettingsIdpCertFingerprintAlgorithm>? IdpCertFingerprintAlgorithm {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AuthenticationProviderSettingsIdpCertFingerprintAlgorithm>>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IdpCertFingerprint;
        _ = this.IdpEntityID;
        _ = this.IdpSsoTargetUrl;
        this.IdpCertFingerprintAlgorithm?.Validate();
    }

    public AuthenticationProviderSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AuthenticationProviderSettings (
        AuthenticationProviderSettings authenticationProviderSettings
    ) : base(authenticationProviderSettings)
    {  }
    #pragma warning restore CS8618

    public AuthenticationProviderSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationProviderSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationProviderSettingsFromRaw.FromRawUnchecked"/>
    public static AuthenticationProviderSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AuthenticationProviderSettingsFromRaw : IFromRawJson<AuthenticationProviderSettings>
{
    /// <inheritdoc/>
    public AuthenticationProviderSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AuthenticationProviderSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The algorithm used to generate the identity provider's (IdP) certificate fingerprint
/// </summary>
[JsonConverter(typeof(AuthenticationProviderSettingsIdpCertFingerprintAlgorithmConverter))]
public enum AuthenticationProviderSettingsIdpCertFingerprintAlgorithm
{
    Sha1, Sha256, Sha384, Sha512
}sealed class AuthenticationProviderSettingsIdpCertFingerprintAlgorithmConverter : JsonConverter<AuthenticationProviderSettingsIdpCertFingerprintAlgorithm>
{
    public override AuthenticationProviderSettingsIdpCertFingerprintAlgorithm Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sha1"=>AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha1,
            "sha256"=>AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha256,
            "sha384"=>AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha384,
            "sha512"=>AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha512,
            _ =>(AuthenticationProviderSettingsIdpCertFingerprintAlgorithm)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AuthenticationProviderSettingsIdpCertFingerprintAlgorithm value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha1=>"sha1",
            AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha256=>"sha256",
            AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha384=>"sha384",
            AuthenticationProviderSettingsIdpCertFingerprintAlgorithm.Sha512=>"sha512",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}