using Newtonsoft.Json;
using System.Runtime.Serialization;
using Telnyx.net.Infrastructure.JsonConverters;

namespace Telnyx.net.Entities.Enum.Webhooks
{
    [JsonConverter(typeof(SafeStringEnumConverter), Unknown)]
    public enum EventTypes
    {
        Unknown = -1,
        [EnumMember(Value = "message.received")]
        MessageReceived = 0,

        [EnumMember(Value = "message.finalized")]
        MessageFinalized = 1,

        [EnumMember(Value = "call.initiated")]
        CallInitiated = 2,

        [EnumMember(Value = "call.answered")]
        CallAnswered = 3,

        [EnumMember(Value = "call.hangup")]
        CallHangup = 4,

        [EnumMember(Value = "call.machine.detection.ended")]
        CallMachineDetection = 5,

        [EnumMember(Value = "call.machine.greeting.ended")]
        CallMachineGreetingEnded = 6,

        [EnumMember(Value = "call.bridged")]
        CallBridged = 7,

        [EnumMember(Value = "call.fork.started")]
        CallForkStarted = 8,
        [EnumMember(Value = "call.fork.stopped")]
        CallFordStopped = 9,

        [EnumMember(Value = "call.gather.ended")]
        CallGatherEnded = 10,

        [EnumMember(Value = "call.playback.started")]
        CallPlaybackStarted = 11,

        [EnumMember(Value = "call.dtmf.received")]
        CallDTMFReceived = 12,

        [EnumMember(Value = "call.recording.saved")]
        CallRecordingSaved = 13,

        [EnumMember(Value = "call.speak.ended")]
        CallSpeakEnded = 14,

        [EnumMember(Value = "call.speak.started")]
        CallSpeakStarted = 15,

        [EnumMember(Value = "conference.created")]
        ConferenceCreated = 16,

        [EnumMember(Value = "conference.participant.joined")]
        ConferenceParticipantJoined = 17,

        [EnumMember(Value = "conference.participant.left")]
        ConferenceParticipantLeft = 18,

        [EnumMember(Value = "conference.ended")]
        ConferenceEnded = 19,

        [EnumMember(Value = "conference.recording.saved")]
        ConferenceRecordingSaved = 20,

        [EnumMember(Value = "fax.queued")]
        FaxQueued = 21,

        [EnumMember(Value = "message.sent")]
        MessageSent = 22,
    }
}
