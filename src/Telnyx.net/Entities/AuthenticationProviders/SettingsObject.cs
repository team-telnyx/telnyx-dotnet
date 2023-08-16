namespace Telnyx.net.Entities.AuthenticationProviders
{
    using Newtonsoft.Json;

    public class SettingsObject
    {
        [JsonProperty("assertion_consumer_service_url")]
        public string AssertionConsumerServiceUrl { get; set; }

        [JsonProperty("idp_cert_fingerprint")]
        public string IdpCertFingerprint { get; set; }

        [JsonProperty("idp_cert_fingerprint_algorithm")]
        public string IdpCertFingerprintAlgorithm { get; set; } = "sha1";

        [JsonProperty("idp_entity_id")]
        public string IdpEntityId { get; set; }

        [JsonProperty("idp_sso_target_url")]
        public string IdpSsoTargetUrl { get; set; }

        [JsonProperty("name_identifier_format")]
        public string NameIdentifierFormat { get; set; }

        [JsonProperty("service_provider_entity_id")]
        public string ServiceProviderEntityId { get; set; }
    }
}
