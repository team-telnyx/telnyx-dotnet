using Newtonsoft.Json;
using System;
using Telnyx.net.Entities;
using Telnyx.net.Services.Calls.CallCommands;
using Telnyx.net.Services.Calls.CallControl.RecordActions;

namespace Telnyx.Example
{
    public class CallControlExample
    {
        private readonly CallControlService callControlService = new CallControlService();

        public void SetCallControlId(string callControlId)
        {
            callControlService.CallControlId = callControlId;
        }

        public CallDialResponse Dial()
        {
            CallDialResponse callDialResponse = new CallDialResponse();
            CallControlDialOptions callControlDialOptions = new CallControlDialOptions
            {
                To = "+18005550100 or SIP:username@sip.telnyx.com",
                From = "+18005550101",
                ConnectionId = "string",
                AudioUrl = "http://example.com/message.wav",
                TimeoutSecs = 60,
                TimeLimitSecs = 600,
                ClientState = "aGF2ZSBhIG5pY2UgZGF5ID1d",
                CommandId = new Guid("891510ac-f3e4-11e8-af5b-de00688a4901"),
                LinkTo = "ilditnZK_eVysupV21KzmzN_sM29ygfauQojpm4BgFtfX5hXAcjotg==",
                SipAuthUsername = "string",
                SipAuthPassword = "string",
                FromDisplayName = "string"
            };
            Console.WriteLine(JsonConvert.SerializeObject(callControlDialOptions));

            try
            {
                callDialResponse = callControlService.Dial(callControlDialOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callDialResponse));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callDialResponse;
        }

        public CallSpeakResponse Speak()
        {
            CallSpeakResponse callSpeakResponse = new CallSpeakResponse();
            CallControlSpeakOptions callControlSpeakOptions = new CallControlSpeakOptions
            {
                Payload = "Say this on the call",
                Language = "en-US",
                Voice = "female"
            };
            Console.WriteLine(JsonConvert.SerializeObject(callControlSpeakOptions));

            try
            {
                callSpeakResponse = callControlService.Speak(callControlSpeakOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callSpeakResponse));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callSpeakResponse;
        }

        public CallBridgeResponse Bridge()
        {
            CallBridgeResponse response = new CallBridgeResponse();
            CallControlBridgeOptions options = new CallControlBridgeOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Bridge(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallForkStartResponse ForkingStart()
        {
            CallForkStartResponse response = new CallForkStartResponse();
            CallControlForkStartOptions options = new CallControlForkStartOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.ForkStart(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallForkStopResponse ForkingStop()
        {
            CallForkStopResponse response = new CallForkStopResponse();
            CallControlForkStopOptions options = new CallControlForkStopOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.ForkStop(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallGatherUsingAudioResponse GatherUsingAudio()
        {
            CallGatherUsingAudioResponse response = new CallGatherUsingAudioResponse();
            CallControlGatherUsingAudioOptions options = new CallControlGatherUsingAudioOptions
            {
                AudioUrl = "https://audio.example.com"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.GatherUsingAudio(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallGatherUsingSpeakResponse GatherUsingSpeak()
        {
            CallGatherUsingSpeakResponse response = new CallGatherUsingSpeakResponse();
            CallControlGatherUsingSpeakOptions options = new CallControlGatherUsingSpeakOptions
            {
                Language = "en-US",
                Voice = "female",
                Payload = "Telnyx call control test"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.GatherUsingSpeak(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallHangUpResponse Hangup()
        {
            CallHangUpResponse response = new CallHangUpResponse();
            CallControlHangupOptions options = new CallControlHangupOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.HangUp(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallPlaybackStartResponse PlaybackStart()
        {
            CallPlaybackStartResponse response = new CallPlaybackStartResponse();
            CallControlPlaybackStartOptions options = new CallControlPlaybackStartOptions
            {
                AudioUrl = "https://audio.example.com"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.PlaybackStart(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallPlaybackStopResponse PlaybackStop()
        {
            CallPlaybackStopResponse response = new CallPlaybackStopResponse();
            CallControlPlaybackStopOptions options = new CallControlPlaybackStopOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.PlaybackStop(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public TelnyxApiResponse RecordStart()
        {
            TelnyxApiResponse response = new TelnyxApiResponse();
            RecordStartOptions options = new RecordStartOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.RecordStart(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public TelnyxApiResponse RecordStop()
        {
            TelnyxApiResponse response = new TelnyxApiResponse();
            RecordActionOptions options = new RecordActionOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.RecordStop(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallRejectResponse Reject()
        {
            CallRejectResponse response = new CallRejectResponse();
            CallControlRejectOptions options = new CallControlRejectOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Reject(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallSendDTMFResponse SendDTMF()
        {
            CallSendDTMFResponse response = new CallSendDTMFResponse();
            CallControlSendDTMFOptions options = new CallControlSendDTMFOptions
            {
                Digits = "1www2WABCDw9"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.SendDTMF(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallTransferResponse Transfer()
        {
            CallTransferResponse response = new CallTransferResponse();
            CallControlTransferOptions options = new CallControlTransferOptions
            {
                To = "+15552223333"
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Transfer(options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }
    }
}
