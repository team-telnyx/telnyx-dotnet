using System;
using Telnyx.Sdk.Core;
using BatchDetailRecords = Telnyx.Sdk.Services.Legacy.Reporting.BatchDetailRecords;

namespace Telnyx.Sdk.Services.Legacy.Reporting;

/// <inheritdoc/>
public sealed class BatchDetailRecordService : IBatchDetailRecordService
{
    readonly Lazy<IBatchDetailRecordServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBatchDetailRecordServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBatchDetailRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BatchDetailRecordService(this._client.WithOptions(modifier)); }

    public BatchDetailRecordService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BatchDetailRecordServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _messaging =new(
            () => new BatchDetailRecords::MessagingService(client)
        ) ;
        _speechToText =new(
            () => new BatchDetailRecords::SpeechToTextService(client)
        ) ;
        _voice =new(() => new BatchDetailRecords::VoiceService(client)) ;
    }

    readonly Lazy<BatchDetailRecords::IMessagingService> _messaging;
    public BatchDetailRecords::IMessagingService Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<BatchDetailRecords::ISpeechToTextService> _speechToText;
    public BatchDetailRecords::ISpeechToTextService SpeechToText {
        get { return _speechToText.Value; }
    }

    readonly Lazy<BatchDetailRecords::IVoiceService> _voice;
    public BatchDetailRecords::IVoiceService Voice {
        get { return _voice.Value; }
    }
}

/// <inheritdoc/>
public sealed class BatchDetailRecordServiceWithRawResponse : IBatchDetailRecordServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBatchDetailRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BatchDetailRecordServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BatchDetailRecordServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _messaging =new(
            () => new BatchDetailRecords::MessagingServiceWithRawResponse(
                client
            )
        ) ;
        _speechToText =new(
            () => new BatchDetailRecords::SpeechToTextServiceWithRawResponse(
                client
            )
        ) ;
        _voice =new(
            () => new BatchDetailRecords::VoiceServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<BatchDetailRecords::IMessagingServiceWithRawResponse> _messaging;
    public BatchDetailRecords::IMessagingServiceWithRawResponse Messaging {
        get { return _messaging.Value; }
    }

    readonly Lazy<BatchDetailRecords::ISpeechToTextServiceWithRawResponse> _speechToText;
    public BatchDetailRecords::ISpeechToTextServiceWithRawResponse SpeechToText {
        get { return _speechToText.Value; }
    }

    readonly Lazy<BatchDetailRecords::IVoiceServiceWithRawResponse> _voice;
    public BatchDetailRecords::IVoiceServiceWithRawResponse Voice {
        get { return _voice.Value; }
    }
}