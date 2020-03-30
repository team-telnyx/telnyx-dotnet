using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telnyx.net.Services.Calls.CallCommands;

namespace Telnyx.Example
{
    public class CallCommandsExample
    {
        private readonly CallCommandService callCommandService = new CallCommandService();

        public CallDialResponse Dial()
        {
            CallDialResponse callDialResponse = new CallDialResponse();
            CallControlDialCreateOptions callControlDialCreateOptions = new CallControlDialCreateOptions {
                To = "+18005550100 or SIP:username@sip.telnyx.com",
                From = "+18005550101",
                ConnectionId= "string",
                AudioUrl = "http://example.com/message.wav",
                TimeoutSecs= 60,
                TimeLimitSecs = 600,
                AnsweringMachineDetection = false,
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                LinkTo =  "ilditnZK_eVysupV21KzmzN_sM29ygfauQojpm4BgFtfX5hXAcjotg==",
                SipAuthUsername = "string",
                SipAuthPassword = "string"
            };
            Console.WriteLine(JsonConvert.SerializeObject(callControlDialCreateOptions));

            try
            {
                callDialResponse = callCommandService.Dial(callControlDialCreateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callDialResponse));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callDialResponse;
        }

        public CallSpeakResponse Speak(string callControlId)
        {
            CallSpeakResponse callSpeakResponse = new CallSpeakResponse();
            CallControlSpeakCreateOptions callControlSpeakCreateOptions = new CallControlSpeakCreateOptions
            {
               Payload = "Say this on the call",
               PayloadType= "ssml",
               ServiceLevel = "premium",
               Stop = "current",
               Voice = "female",
               Language = "en-US",
               ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
               CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901")
            };
            Console.WriteLine(JsonConvert.SerializeObject(callControlSpeakCreateOptions));

            try
            {
                callSpeakResponse = callCommandService.Speak(callControlId, callControlSpeakCreateOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callSpeakResponse));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callSpeakResponse;
        }
    }
}
