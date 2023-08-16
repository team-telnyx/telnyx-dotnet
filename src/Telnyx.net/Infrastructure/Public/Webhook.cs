namespace Telnyx.net.Infrastructure.Public
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using Newtonsoft.Json;
    using Rebex.Security.Cryptography;
    using Telnyx.Infrastructure;
    using Telnyx.net.Entities;

    [ExcludeFromCodeCoverage] // Only used by Telnyx.Example project which is out of scope of test coverage.
    public static class Webhook
    {
        private const int DEFAULT_TOLERANCE = 300;

        private static TelnyxWebhook<object> ParseEvent(string json)
        {
            var telnyxwebook = JsonConvert.DeserializeObject<TelnyxWebhook<object>>(json);
            return telnyxwebook;
        }

        /// <summary>
        /// Construct the event with signature verification. More info here: https://developers.telnyx.com/docs/api/v2/overview#webhooks.
        /// </summary>
        /// <param name="json">Request Body.</param>
        /// <param name="telynxSignatureHeader">Request Header: "telnyx-signature-ed25519".</param>
        /// <param name="telnyxtimestamp">Request Header: "telnyx-timestamp".</param>
        /// <param name="secret">Public Key on https://portal.telnyx.com/#/app/account/public-key. </param>
        /// <param name="tolerance">Timestamp tolerance.</param>
        /// <returns>WebhookData.</returns>
        public static TelnyxWebhook<object> ConstructEvent(
            string json,
            string telynxSignatureHeader,
            string telnyxtimestamp,
            string secret,
            long tolerance = DEFAULT_TOLERANCE)
        {
            return ConstructEvent(
                json,
                telynxSignatureHeader,
                telnyxtimestamp,
                secret,
                tolerance,
                DateTime.UtcNow.ConvertDateTimeToEpoch());
        }

        private static TelnyxWebhook<object> ConstructEvent(
            string json,
            string telnyxSignatureHeader,
            string telnyxtimestamp,
            string secret,
            long tolerance,
            long utcNow)
        {
            ValidateSignature(json, telnyxSignatureHeader, telnyxtimestamp, secret, tolerance, utcNow);
            return ParseEvent(json);
        }

        private static void ValidateSignature(string json, string telynxSignatureHeader, string telnyxtimestamp, string secret, long tolerance, long utcNow)
        {
            var base64decodedSignatureHeader = Convert.FromBase64String(telynxSignatureHeader);
            var base64decodedPublicKey = Convert.FromBase64String(secret);
            bool isVerified;
            try
            {
                var payloadBytes = Encoding.UTF8.GetBytes($"{telnyxtimestamp}|{json}");
                var algo = new Ed25519();
                algo.FromPublicKey(base64decodedPublicKey); // load public key
                isVerified = algo.VerifyMessage(payloadBytes, base64decodedSignatureHeader);
            }
            catch (Exception ex)
            {
                throw new TelnyxException(
                    "The webhook cannot be processed because the signature cannot be safely calculated.",
                    ex);
            }

            if (!isVerified)
            {
                throw new TelnyxException(
                    "The signature for the webhook is not present in the Telnyx-Signature header.");
            }

            var webhookUtc = Convert.ToInt64(telnyxtimestamp);

            if (Math.Abs(utcNow - webhookUtc) > tolerance)
            {
                throw new TelnyxException(
                    "The webhook cannot be processed because the current timestamp is outside of the allowed tolerance.");
            }
        }
    }
}
