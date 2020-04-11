using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Telnyx.net.Services.Calls.CallCommands;

namespace Telnyx.Example
{
    public class CallControlExample
    {
        private readonly CallControlService callControlService = new CallControlService();

        public CallDialResponse Dial()
        {
            CallDialResponse callDialResponse = new CallDialResponse();
            CallControlDialOptions callControlDialOptions = new CallControlDialOptions {
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

        public CallSpeakResponse Speak(string callControlId)
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
                callSpeakResponse = callControlService.Speak(callControlId, callControlSpeakOptions);
                Console.WriteLine(JsonConvert.SerializeObject(callSpeakResponse));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return callSpeakResponse;
        }

        public CallBridgeResponse Bridge(string callControlId)
        {
            CallBridgeResponse response = new CallBridgeResponse();
            CallControlBridgeOptions options = new CallControlBridgeOptions
            {
               
            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Bridge(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallForkStartResponse ForkingStart(string callControlId)
        {
            CallForkStartResponse response = new CallForkStartResponse();
            CallControlForkStartOptions options = new CallControlForkStartOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.ForkStart(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallForkStopResponse ForkingStop(string callControlId)
        {
            CallForkStopResponse response = new CallForkStopResponse();
            CallControlForkStopOptions options = new CallControlForkStopOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.ForkStop(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallGatherUsingAudioResponse GatherUsingAudio(string callControlId)
        {
            CallGatherUsingAudioResponse response = new CallGatherUsingAudioResponse();
            CallControlGatherUsingAudioOptions options = new CallControlGatherUsingAudioOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.GatherUsingAudio(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallGatherUsingSpeakResponse GatherUsingSpeak(string callControlId)
        {
            CallGatherUsingSpeakResponse response = new CallGatherUsingSpeakResponse();
            CallControlGatherUsingSpeakOptions options = new CallControlGatherUsingSpeakOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.GatherUsingSpeak(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallHangUpResponse Hangup(string callControlId)
        {
            CallHangUpResponse response = new CallHangUpResponse();
            CallControlHangupOptions options = new CallControlHangupOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.HangUp(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallPlaybackStartResponse PlaybackStart(string callControlId)
        {
            CallPlaybackStartResponse response = new CallPlaybackStartResponse();
            CallControlPlaybackStartOptions options = new CallControlPlaybackStartOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.PlaybackStart(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallPlaybackStopResponse PlaybackStop(string callControlId)
        {
            CallPlaybackStopResponse response = new CallPlaybackStopResponse();
            CallControlPlaybackStopOptions options = new CallControlPlaybackStopOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.PlaybackStop(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallRecordStartResponse RecordStart(string callControlId)
        {
            CallRecordStartResponse response = new CallRecordStartResponse();
            CallControlRecordStartOptions options = new CallControlRecordStartOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.RecordStart(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallRecordStopResponse RecordStop(string callControlId)
        {
            CallRecordStopResponse response = new CallRecordStopResponse();
            CallControlRecordStopOptions options = new CallControlRecordStopOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.RecordStop(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallRejectResponse Reject(string callControlId)
        {
            CallRejectResponse response = new CallRejectResponse();
            CallControlRejectOptions options = new CallControlRejectOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Reject(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallSendDTMFResponse SendDTMF(string callControlId)
        {
            CallSendDTMFResponse response = new CallSendDTMFResponse();
            CallControlSendDTMFOptions options = new CallControlSendDTMFOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.SendDTMF(callControlId, options);
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (TelnyxException ex)
            {
                Console.WriteLine("exception");
                Console.WriteLine(JsonConvert.SerializeObject(ex));
            }
            return response;
        }

        public CallTransferResponse Transfer(string callControlId)
        {
            CallTransferResponse response = new CallTransferResponse();
            CallControlTransferOptions options = new CallControlTransferOptions
            {

            };
            Console.WriteLine(JsonConvert.SerializeObject(options));

            try
            {
                response = callControlService.Transfer(callControlId, options);
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
