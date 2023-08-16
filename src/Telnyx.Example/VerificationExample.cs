using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Telnyx.net.Services.VerifyAPI;

namespace Telnyx.Example
{
    [ExcludeFromCodeCoverage]
    public class VerificationExample
    {
        private VerificationService verifyService = new VerificationService();

        public async Task RunVerification()
        {
            VerifyProfileOptions profileOptions = new VerifyProfileOptions
            {
                DefaultTimeoutSecs = 300,
                MessagingEnabled = true,
                MessagingTemplate = "Hello this is a test {code}",
                Name = "Test Profile",
                RcsEnabled = false
            };
            Console.WriteLine($"Creating profile: {profileOptions.Name}");
            var profile = await verifyService.CreateVerificationProfileAsync(profileOptions);
            Console.WriteLine($"Profile Created. Id: {profile.Id.Value}");
            VerifyOptions verifyOptions = new VerifyOptions
            {
                TimeoutSecs = 300,
                PhoneNumber = "+13100000010",
                VerifyProfileId = profile.Id.Value,
                Type = "sms",
            };
            Console.WriteLine($"Creating verification");
            var verification = await verifyService.CreateVerificationAsync(verifyOptions);
            Console.WriteLine($"Verification created successfully: {verification.Id} with status {verification.Status}");

            Console.WriteLine($"Checking verification status current status: {verification.Status}");
            var getStatus = await verifyService.GetVerificationAsync(verification.Id.ToString());
            Console.WriteLine($"Verification retrieved previous status: {verification.Status}, current status: {getStatus.Status}");



        }
    }
}
