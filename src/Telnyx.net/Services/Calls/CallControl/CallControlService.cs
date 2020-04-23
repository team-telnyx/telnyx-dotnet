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

        public string CallControlId { get; set; }

        public virtual CallAnswerResponse Answer(CallControlAnswerOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlAnswerService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallDialResponse Dial(CallControlDialOptions options, RequestOptions requestOptions = null)
        {
            return this.callControlDialService.Create(options, requestOptions);
        }

        public virtual CallSpeakResponse Speak(CallControlSpeakOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlSpeakService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallBridgeResponse Bridge(CallControlBridgeOptions options, string postFix = "actions/bridge", RequestOptions requestOptions = null)
        {
            return this.callControlBridgeService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallForkStartResponse ForkStart(CallControlForkStartOptions options, string postFix = "actions/forkstart", RequestOptions requestOptions = null)
        {
            return this.callControlForkStartService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallForkStopResponse ForkStop(CallControlForkStopOptions options, string postFix = "actions/forkstop", RequestOptions requestOptions = null)
        {
            return this.callControlForkStopService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallGatherUsingAudioResponse GatherUsingAudio(CallControlGatherUsingAudioOptions options, string postFix = "actions/gatherusingaudio", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingAudioService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallGatherUsingSpeakResponse GatherUsingSpeak(CallControlGatherUsingSpeakOptions options, string postFix = "actions/gatherusingstop", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingSpeakService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallHangUpResponse HangUp(CallControlHangupOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null)
        {
            return this.callControlHangupService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallPlaybackStartResponse PlaybackStart(CallControlPlaybackStartOptions options, string postFix = "actions/playbackstart", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStartService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallPlaybackStopResponse PlaybackStop(CallControlPlaybackStopOptions options, string postFix = "actions/playbackstop", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStopService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallRecordStartResponse RecordStart(CallControlRecordStartOptions options, string postFix = "actions/recordstart", RequestOptions requestOptions = null)
        {
            return this.callControlRecordStartService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallRecordStopResponse RecordStop(CallControlRecordStopOptions options, string postFix = "actions/recordstop", RequestOptions requestOptions = null)
        {
            return this.callControlRecordStopService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallRejectResponse Reject(CallControlRejectOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null)
        {
            return this.callControlRejectService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallSendDTMFResponse SendDTMF(CallControlSendDTMFOptions options, string postFix = "actions/senddtmf", RequestOptions requestOptions = null)
        {
            return this.callControlSendDTMFService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual CallTransferResponse Transfer(CallControlTransferOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null)
        {
            return this.callControlTransferService.Create(this.CallControlId, options, postFix, requestOptions);
        }
    }
}
