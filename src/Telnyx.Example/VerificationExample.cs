using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telnyx.net.Services.Verify;

namespace Telnyx.Example
{
    public class VerificationExample
    {
        private VerificationService verifyService = new VerificationService();

        public async Task RunVerification()
        {
            TwoFaProfileOptions profileOptions = new TwoFaProfileOptions
            {
                DefaultTimeoutSecs = 300,
                MsgEnabled = true,
                MsgTemplate = "Hello this is a test {code}",
                Name = "Test Profile",
                RcsEnabled = false
            };
            Console.WriteLine($"Creating profile: {profileOptions.Name}");
            var profile = await verifyService.Create2FAProfileAsync(profileOptions);
            Console.WriteLine($"Profile Created. Id: {profile.Id.Value}");
            TwoFAOptions verifyOptions = new TwoFAOptions
            {
                TimeoutSecs = 300,
                PhoneNumber = "+13100000010",
                TwofaProfileId = profile.Id.Value,
                Type = "sms",
            };
            Console.WriteLine($"Creating verification");
            var verification = await verifyService.Create2FAVerificationAsync(verifyOptions);
            Console.WriteLine($"Verification created successfully: {verification.Id} with status {verification.Status}");

            Console.WriteLine($"Checking verification status current status: {verification.Status}");
            var getStatus = await verifyService.Get2FAVerificationAsync(verification.Id.ToString());
            Console.WriteLine($"Verification retrieved previous status: {verification.Status}, current status: {getStatus.Status}");
            


        }
    }
}
