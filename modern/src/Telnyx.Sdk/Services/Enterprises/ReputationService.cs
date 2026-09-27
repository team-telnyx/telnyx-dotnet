using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Enterprises.Reputation;
using Telnyx.Sdk.Services.Enterprises.Reputation;

namespace Telnyx.Sdk.Services.Enterprises;

/// <inheritdoc/>
public sealed class ReputationService : IReputationService
{
    readonly Lazy<IReputationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReputationServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IReputationService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ReputationService(this._client.WithOptions(modifier)); }

    public ReputationService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ReputationServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _numbers =new(() => new NumberService(client)) ;
        _loa =new(() => new LoaService(client)) ;
        _remediation =new(() => new RemediationService(client)) ;
    }

    readonly Lazy<INumberService> _numbers;
    public INumberService Numbers { get { return _numbers.Value; } }

    readonly Lazy<ILoaService> _loa;
    public ILoaService Loa { get { return _loa.Value; } }

    readonly Lazy<IRemediationService> _remediation;
    public IRemediationService Remediation {
        get { return _remediation.Value; }
    }

    /// <inheritdoc/>
    public async Task<EnterpriseReputationPublicWrapped> Retrieve(
        ReputationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterpriseReputationPublicWrapped> Retrieve(
        string enterpriseID,
        ReputationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Disable(
        ReputationDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Disable(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Disable(
        string enterpriseID,
        ReputationDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Disable(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EnterpriseReputationPublicWrapped> Enable(
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Enable(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterpriseReputationPublicWrapped> Enable(
        string enterpriseID,
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Enable(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EnterpriseReputationPublicWrapped> UpdateFrequency(
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateFrequency(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<EnterpriseReputationPublicWrapped> UpdateFrequency(
        string enterpriseID,
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFrequency(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReputationServiceWithRawResponse : IReputationServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReputationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReputationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReputationServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _numbers =new(() => new NumberServiceWithRawResponse(client)) ;
        _loa =new(() => new LoaServiceWithRawResponse(client)) ;
        _remediation =new(() => new RemediationServiceWithRawResponse(client)) ;
    }

    readonly Lazy<INumberServiceWithRawResponse> _numbers;
    public INumberServiceWithRawResponse Numbers {
        get { return _numbers.Value; }
    }

    readonly Lazy<ILoaServiceWithRawResponse> _loa;
    public ILoaServiceWithRawResponse Loa { get { return _loa.Value; } }

    readonly Lazy<IRemediationServiceWithRawResponse> _remediation;
    public IRemediationServiceWithRawResponse Remediation {
        get { return _remediation.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterpriseReputationPublicWrapped>> Retrieve(
        ReputationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<ReputationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterpriseReputationPublicWrapped = await response.Deserialize<EnterpriseReputationPublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterpriseReputationPublicWrapped.Validate();
            }
            return enterpriseReputationPublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterpriseReputationPublicWrapped>> Retrieve(
        string enterpriseID,
        ReputationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disable(
        ReputationDisableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<ReputationDisableParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Disable(
        string enterpriseID,
        ReputationDisableParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disable(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterpriseReputationPublicWrapped>> Enable(
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<ReputationEnableParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterpriseReputationPublicWrapped = await response.Deserialize<EnterpriseReputationPublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterpriseReputationPublicWrapped.Validate();
            }
            return enterpriseReputationPublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterpriseReputationPublicWrapped>> Enable(
        string enterpriseID,
        ReputationEnableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Enable(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EnterpriseReputationPublicWrapped>> UpdateFrequency(
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<ReputationUpdateFrequencyParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var enterpriseReputationPublicWrapped = await response.Deserialize<EnterpriseReputationPublicWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                enterpriseReputationPublicWrapped.Validate();
            }
            return enterpriseReputationPublicWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<EnterpriseReputationPublicWrapped>> UpdateFrequency(
        string enterpriseID,
        ReputationUpdateFrequencyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateFrequency(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}