using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.Instructions;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class InstructionService : IInstructionService
{
    readonly Lazy<IInstructionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInstructionServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IInstructionService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new InstructionService(this._client.WithOptions(modifier)); }

    public InstructionService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new InstructionServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<string> Enhance(
        InstructionEnhanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Enhance(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<string> Enhance(
        string assistantID,
        InstructionEnhanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enhance(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InstructionServiceWithRawResponse : IInstructionServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInstructionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InstructionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InstructionServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> Enhance(
        InstructionEnhanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<InstructionEnhanceParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<string>> Enhance(
        string assistantID,
        InstructionEnhanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Enhance(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }
}