using System;
using System.Collections.Generic;
using System.Text;

namespace Telnyx.net.Services.Calls.CallCommands
{
    public class CallControlService
    {
        private readonly CallControlAnswerService callControlAnswerService;
        private readonly CallControlDialService callControlDialService;
        private readonly CallControlSpeakService callControlSpeakService;
        private readonly CallControlBridgeService callControlBridgeService;
        private readonly CallControlForkStartService callControlForkStartService;
        private readonly CallControlForkStopService callControlForkStopService;
        private readonly CallControlGatherUsingAudioService callControlGatherUsingAudioService;
        private readonly CallControlGatherUsingSpeakService callControlGatherUsingSpeakService;
        private readonly CallControlHangupService callControlHangupService;
        private readonly CallControlPlaybackStartService callControlPlaybackStartService;
        private readonly CallControlPlaybackStopService callControlPlaybackStopService;
        private readonly CallControlRecordStartService callControlRecordStartService;
        private readonly CallControlRecordStopService callControlRecordStopService;
        private readonly CallControlRejectService callControlRejectService;
        private readonly CallControlSendDTMFService callControlSendDTMFService;
        private readonly CallControlTransferService callControlTransferService;

        public CallControlService()
        {
            this.callControlAnswerService = new CallControlAnswerService();
            this.callControlDialService = new CallControlDialService();
            this.callControlSpeakService = new CallControlSpeakService();
            this.callControlBridgeService = new CallControlBridgeService();
            this.callControlForkStartService = new CallControlForkStartService();
            this.callControlForkStopService = new CallControlForkStopService();
            this.callControlGatherUsingAudioService = new CallControlGatherUsingAudioService();
            this.callControlGatherUsingSpeakService = new CallControlGatherUsingSpeakService();
            this.callControlHangupService = new CallControlHangupService();
            this.callControlPlaybackStartService = new CallControlPlaybackStartService();
            this.callControlPlaybackStopService = new CallControlPlaybackStopService();
            this.callControlRecordStartService = new CallControlRecordStartService();
            this.callControlRecordStopService = new CallControlRecordStopService();
            this.callControlRejectService = new CallControlRejectService();
            this.callControlSendDTMFService = new CallControlSendDTMFService();
            this.callControlTransferService = new CallControlTransferService();
        }

        public virtual CallAnswerResponse Answer(string id, CallControlAnswerOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlAnswerService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallDialResponse Dial(CallControlDialOptions options, RequestOptions requestOptions = null)
        {
            return this.callControlDialService.Create(options, requestOptions);
        }

        public virtual CallSpeakResponse Speak(string id, CallControlSpeakOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlSpeakService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallBridgeResponse Bridge(string id, CallControlBridgeOptions options, string postFix = "actions/bridge", RequestOptions requestOptions = null)
        {
            return this.callControlBridgeService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallForkStartResponse ForkStart(string id, CallControlForkStartOptions options, string postFix = "actions/forkstart", RequestOptions requestOptions = null)
        {
            return this.callControlForkStartService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallForkStopResponse ForkStop(string id, CallControlForkStopOptions options, string postFix = "actions/forkstop", RequestOptions requestOptions = null)
        {
            return this.callControlForkStopService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallGatherUsingAudioResponse GatherUsingAudio(string id, CallControlGatherUsingAudioOptions options, string postFix = "actions/gatherusingaudio", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingAudioService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallGatherUsingSpeakResponse GatherUsingSpeak(string id, CallControlGatherUsingSpeakOptions options, string postFix = "actions/gatherusingstop", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingSpeakService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallHangUpResponse HangUp(string id, CallControlHangupOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null)
        {
            return this.callControlHangupService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallPlaybackStartResponse PlaybackStart(string id, CallControlPlaybackStartOptions options, string postFix = "actions/playbackstart", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStartService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallPlaybackStopResponse PlaybackStop(string id, CallControlPlaybackStopOptions options, string postFix = "actions/playbackstop", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStopService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallRecordStartResponse RecordStart(string id, CallControlRecordStartOptions options, string postFix = "actions/recordstart", RequestOptions requestOptions = null)
        {
            return this.callControlRecordStartService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallRecordStopResponse RecordStop(string id, CallControlRecordStopOptions options, string postFix = "actions/recordstop", RequestOptions requestOptions = null)
        {
            return this.callControlRecordStopService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallRejectResponse Reject(string id, CallControlRejectOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null)
        {
            return this.callControlRejectService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallSendDTMFResponse SendDTMF(string id, CallControlSendDTMFOptions options, string postFix = "actions/senddtmf", RequestOptions requestOptions = null)
        {
            return this.callControlSendDTMFService.Create(id, options, postFix, requestOptions);
        }

        public virtual CallTransferResponse Transfer(string id, CallControlTransferOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null)
        {
            return this.callControlTransferService.Create(id, options, postFix, requestOptions);
        }
    }
}
