namespace Telnyx.net.Services.Calls.CallCommands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.Calls.CallControl.ClientState;
    using Telnyx.net.Services.Calls.CallControl.ClientState;
    using Telnyx.net.Services.Calls.CallControl.GatherStop;
    using Telnyx.net.Services.Calls.CallControl.RecordActions;
    using Telnyx.net.Services.Calls.CallControl.Refer;
    using Telnyx.net.Services.Calls.CallControl.Transcriptions;

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
        private readonly CallControlRejectService callControlRejectService;
        private readonly CallControlSendDTMFService callControlSendDTMFService;
        private readonly CallControlTransferService callControlTransferService;
        private readonly GatherStopService gatherStopService;
        private readonly RecordActionService recordActionService;
        private readonly CallTranscriptionService transcriptionService;
        private readonly CallControlReferService referService;
        private readonly ClientStateService updateClientStateService;

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
            this.callControlRejectService = new CallControlRejectService();
            this.callControlSendDTMFService = new CallControlSendDTMFService();
            this.callControlTransferService = new CallControlTransferService();
            this.gatherStopService = new GatherStopService();
            this.recordActionService = new RecordActionService();
            this.transcriptionService = new CallTranscriptionService();
        }

        public string CallControlId { get; set; }

        public virtual CallAnswerResponse Answer(CallControlAnswerOptions options, string postFix = "actions/answer", RequestOptions requestOptions = null)
        {
            return this.callControlAnswerService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallAnswerResponse> AnswerAsync(CallControlAnswerOptions options, string postFix = "actions/answer", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlAnswerService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual async Task<CallDialResponse> RetrieveCallStatusAsyc(string callControlId = null, RequestOptions opts = null, CancellationToken ct = default)
        {
            string controlId = callControlId ?? this.CallControlId;
            return await this.callControlDialService.RetrieveAsync(controlId, opts, ct);
        }

        public virtual CallDialResponse RetrieveCallStatus(string callControlId = null, RequestOptions opts = null)
        {
            string controlId = callControlId ?? this.CallControlId;
            return this.callControlDialService.Retrieve(controlId, opts);
        }

        public virtual CallDialResponse Dial(CallControlDialOptions options, RequestOptions requestOptions = null)
        {
            return this.callControlDialService.Create(options, requestOptions);
        }

        public virtual async Task<CallDialResponse> DialAsync(CallControlDialOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlDialService.CreateAsync(options, requestOptions, ct);
        }

        public virtual CallSpeakResponse Speak(CallControlSpeakOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlSpeakService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallSpeakResponse> SpeakAsync(CallControlSpeakOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlSpeakService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallBridgeResponse Bridge(CallControlBridgeOptions options, string postFix = "actions/bridge", RequestOptions requestOptions = null)
        {
            return this.callControlBridgeService.Create(this.CallControlId, options, postFix, requestOptions);
        }


        public virtual async Task<CallBridgeResponse> BridgeAsync(CallControlBridgeOptions options, string postFix = "actions/bridge", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlBridgeService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallForkStartResponse ForkStart(CallControlForkStartOptions options, string postFix = "actions/fork_start", RequestOptions requestOptions = null)
        {
            return this.callControlForkStartService.Create(this.CallControlId, options, postFix, requestOptions);
        }


        public virtual async Task<CallForkStartResponse> ForkStartAsync(CallControlForkStartOptions options, string postFix = "actions/fork_start", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlForkStartService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallForkStopResponse ForkStop(CallControlForkStopOptions options, string postFix = "actions/fork_stop", RequestOptions requestOptions = null)
        {
            return this.callControlForkStopService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallForkStopResponse> ForkStopAsync(CallControlForkStopOptions options, string postFix = "actions/fork_stop", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlForkStopService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallGatherUsingAudioResponse GatherUsingAudio(CallControlGatherUsingAudioOptions options, string postFix = "actions/gather_using_audio", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingAudioService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallGatherUsingAudioResponse> GatherUsingAudioAsync(CallControlGatherUsingAudioOptions options, string postFix = "actions/gather_using_audio", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlGatherUsingAudioService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallGatherUsingSpeakResponse GatherUsingSpeak(CallControlGatherUsingSpeakOptions options, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null)
        {
            return this.callControlGatherUsingSpeakService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallGatherUsingSpeakResponse> GatherUsingSpeakAsync(CallControlGatherUsingSpeakOptions options, string postFix = "actions/gather_using_speak", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlGatherUsingSpeakService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual TelnyxApiResponse GatherStop(GatherStopOptions options, RequestOptions requestOptions = null)
        {
            return this.gatherStopService.Stop(this.CallControlId, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> GatherStopAsync(GatherStopOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.gatherStopService.StopAsync(this.CallControlId, options, requestOptions, ct);
        }

        public virtual CallHangUpResponse HangUp(CallControlHangupOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null)
        {
            return this.callControlHangupService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallHangUpResponse> HangUpAsync(CallControlHangupOptions options, string postFix = "actions/hangup", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlHangupService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallPlaybackStartResponse PlaybackStart(CallControlPlaybackStartOptions options, string postFix = "actions/playback_start", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStartService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallPlaybackStartResponse> PlaybackStartAsync(CallControlPlaybackStartOptions options, string postFix = "actions/playback_start", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlPlaybackStartService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallPlaybackStopResponse PlaybackStop(CallControlPlaybackStopOptions options, string postFix = "actions/playback_stop", RequestOptions requestOptions = null)
        {
            return this.callControlPlaybackStopService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallPlaybackStopResponse> PlaybackStopAsync(CallControlPlaybackStopOptions options, string postFix = "actions/playback_stop", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlPlaybackStopService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual TelnyxApiResponse RecordStart(RecordStartOptions options, RequestOptions requestOptions = null)
        {
            return this.recordActionService.Start(this.CallControlId, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> RecordStartAsync(RecordStartOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.recordActionService.StartAsync(this.CallControlId, options, requestOptions, ct);
        }

        public virtual TelnyxApiResponse RecordStop(RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.recordActionService.Stop(this.CallControlId, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> RecordStopAsync(RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.recordActionService.StopAsync(this.CallControlId, options, requestOptions, ct);
        }

        public virtual TelnyxApiResponse RecordPause(RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.recordActionService.Pause(this.CallControlId, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> RecordPauseAsync(RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.recordActionService.PauseAsync(this.CallControlId, options, requestOptions, ct);
        }

        public virtual TelnyxApiResponse RecordResume(RecordActionOptions options, RequestOptions requestOptions = null)
        {
            return this.recordActionService.Resume(this.CallControlId, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> RecordResumeAsync(RecordActionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.recordActionService.ResumeAsync(this.CallControlId, options, requestOptions, ct);
        }

        public virtual CallRejectResponse Reject(CallControlRejectOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null)
        {
            return this.callControlRejectService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallRejectResponse> RejectAsync(CallControlRejectOptions options, string postFix = "actions/reject", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlRejectService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallSendDTMFResponse SendDTMF(CallControlSendDTMFOptions options, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null)
        {
            return this.callControlSendDTMFService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallSendDTMFResponse> SendDTMFAsync(CallControlSendDTMFOptions options, string postFix = "actions/send_dtmf", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlSendDTMFService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual CallTransferResponse Transfer(CallControlTransferOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null)
        {
            return this.callControlTransferService.Create(this.CallControlId, options, postFix, requestOptions);
        }

        public virtual async Task<CallTransferResponse> TransferAsync(CallControlTransferOptions options, string postFix = "actions/transfer", RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.callControlTransferService.CreateAsync(this.CallControlId, options, postFix, requestOptions, ct);
        }

        public virtual TelnyxApiResponse StartTranscription(string id, TranscriptionStartOptions options, RequestOptions requestOptions = null)
        {
            return this.transcriptionService.Start(id, options, requestOptions);
        }

        public virtual TelnyxApiResponse StopTranscription(string id, TranscriptionOptions options, RequestOptions requestOptions = null)
        {
            return this.transcriptionService.Stop(id, options, requestOptions);
        }

        public virtual async Task<TelnyxApiResponse> StartTranscriptionAsync(string id, TranscriptionStartOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.transcriptionService.StartAsync(id, options, requestOptions, ct);
        }

        public virtual async Task<TelnyxApiResponse> StopTranscriptionAsync(string id, TranscriptionOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.transcriptionService.StopAsync(id, options, requestOptions, ct);
        }

        public virtual async Task<TelnyxApiResponse> ReferCallAsync(string id, ReferOptions options, RequestOptions requestOptions = null, CancellationToken ct = default)
        {
            return await this.referService.ReferAsync(id, options, requestOptions, ct);
        }

        public virtual TelnyxApiResponse ReferCall(string id, ReferOptions options, RequestOptions requestOptions = null)
        {
            return this.referService.Refer(id, options, requestOptions);
        }

        public TelnyxApiResponse UpdateClientState(string id, ClientStateOption clientState, RequestOptions requestOptions = null)
        {
            return this.updateClientStateService.Upgrade(id, clientState, requestOptions);
        }

        public async Task<TelnyxApiResponse> UpdateClientStateAsync(string id, ClientStateOption clientState, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.updateClientStateService.UpgradeAsync(id, clientState, requestOptions, cancellationToken);
        }
    }
}
