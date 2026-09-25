using System;
using Telnyx.Sdk.Core;
using BatchDetailRecords = Telnyx.Sdk.Services.Legacy.Reporting.BatchDetailRecords;

namespace Telnyx.Sdk.Services.Legacy.Reporting;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBatchDetailRecordService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBatchDetailRecordServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchDetailRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    BatchDetailRecords::IMessagingService Messaging { get; }

    BatchDetailRecords::ISpeechToTextService SpeechToText { get; }

    BatchDetailRecords::IVoiceService Voice { get; }
}

/// <summary>
/// A view of <see cref="IBatchDetailRecordService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBatchDetailRecordServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBatchDetailRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    BatchDetailRecords::IMessagingServiceWithRawResponse Messaging { get; }

    BatchDetailRecords::ISpeechToTextServiceWithRawResponse SpeechToText {
        get;
    }

    BatchDetailRecords::IVoiceServiceWithRawResponse Voice { get; }
}