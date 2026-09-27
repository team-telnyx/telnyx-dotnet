using System;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.PhoneNumberBlocks;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PhoneNumberBlockService : IPhoneNumberBlockService
{
    readonly Lazy<IPhoneNumberBlockServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberBlockServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPhoneNumberBlockService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PhoneNumberBlockService(this._client.WithOptions(modifier)); }

    public PhoneNumberBlockService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PhoneNumberBlockServiceWithRawResponse(
                client.WithRawResponse
            )
        ) ;
        _jobs =new(() => new JobService(client)) ;
    }

    readonly Lazy<IJobService> _jobs;
    public IJobService Jobs { get { return _jobs.Value; } }
}

/// <inheritdoc/>
public sealed class PhoneNumberBlockServiceWithRawResponse : IPhoneNumberBlockServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberBlockServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberBlockServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberBlockServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _jobs =new(() => new JobServiceWithRawResponse(client)) ;
    }

    readonly Lazy<IJobServiceWithRawResponse> _jobs;
    public IJobServiceWithRawResponse Jobs { get { return _jobs.Value; } }
}