using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Rcs.Agents;
using Telnyx.Sdk.Services.Rcs.Agents;

namespace Telnyx.Sdk.Services.Rcs;

/// <inheritdoc/>
public sealed class AgentService : IAgentService
{
    readonly Lazy<IAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAgentService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AgentService(this._client.WithOptions(modifier)); }

    public AgentService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AgentServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _testDevices =new(() => new TestDeviceService(client)) ;
    }

    readonly Lazy<ITestDeviceService> _testDevices;
    public ITestDeviceService TestDevices { get { return _testDevices.Value; } }

    /// <inheritdoc/>
    public async Task<AgentResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AgentResponse> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AgentResponse> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<AgentResponse>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Launch(
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Launch(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AgentResponse> Launch(
        string id,
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Launch(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<List<CarrierApprovalResponse>> RetrieveCarrierApprovals(
        AgentRetrieveCarrierApprovalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveCarrierApprovals(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<List<CarrierApprovalResponse>> RetrieveCarrierApprovals(
        string id,
        AgentRetrieveCarrierApprovalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCarrierApprovals(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Submit(
        AgentSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Submit(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AgentResponse> Submit(
        string id,
        AgentSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AgentServiceWithRawResponse : IAgentServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _testDevices =new(() => new TestDeviceServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ITestDeviceServiceWithRawResponse> _testDevices;
    public ITestDeviceServiceWithRawResponse TestDevices {
        get { return _testDevices.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AgentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponse = await response.Deserialize<AgentResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                agentResponse.Validate();
            }
            return agentResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AgentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponse = await response.Deserialize<AgentResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                agentResponse.Validate();
            }
            return agentResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Retrieve(
        string id,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AgentUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponse = await response.Deserialize<AgentResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                agentResponse.Validate();
            }
            return agentResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Update(
        string id,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<AgentResponse>>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponses = await response.Deserialize<List<AgentResponse>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in agentResponses)
                {
                    item.Validate();
                }
            }
            return agentResponses;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Launch(
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AgentLaunchParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponse = await response.Deserialize<AgentResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                agentResponse.Validate();
            }
            return agentResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Launch(
        string id,
        AgentLaunchParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Launch(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<List<CarrierApprovalResponse>>> RetrieveCarrierApprovals(
        AgentRetrieveCarrierApprovalsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AgentRetrieveCarrierApprovalsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var carrierApprovalResponses = await response.Deserialize<List<CarrierApprovalResponse>>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                foreach (var item in carrierApprovalResponses)
                {
                    item.Validate();
                }
            }
            return carrierApprovalResponses;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<List<CarrierApprovalResponse>>> RetrieveCarrierApprovals(
        string id,
        AgentRetrieveCarrierApprovalsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveCarrierApprovals(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Submit(
        AgentSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<AgentSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var agentResponse = await response.Deserialize<AgentResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                agentResponse.Validate();
            }
            return agentResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Submit(
        string id,
        AgentSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with{
            ID = id
        }, cancellationToken);
    }
}