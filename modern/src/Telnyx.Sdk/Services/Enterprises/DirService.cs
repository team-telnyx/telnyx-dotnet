using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Dir = Telnyx.Sdk.Models.Dir;
using Telnyx.Sdk.Models.Enterprises.Dir;

namespace Telnyx.Sdk.Services.Enterprises;

/// <inheritdoc/>
public sealed class DirService : IDirService
{
    readonly Lazy<IDirServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDirServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDirService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new DirService(this._client.WithOptions(modifier)); }

    public DirService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DirServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<Dir::DirWrapped> Create(
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<Dir::DirWrapped> Create(
        string enterpriseID,
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirListPage> List(
        DirListParams parameters, CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirListPage> List(
        string enterpriseID,
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DirServiceWithRawResponse : IDirServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDirServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DirServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DirServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<Dir::DirWrapped>> Create(
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<DirCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dirWrapped = await response.Deserialize<Dir::DirWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dirWrapped.Validate();
            }
            return dirWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<Dir::DirWrapped>> Create(
        string enterpriseID,
        DirCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirListPage>> List(
        DirListParams parameters, CancellationToken cancellationToken = default
    )
    {
        if (parameters.EnterpriseID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.EnterpriseID' cannot be null"
            );
        }

        HttpRequest<DirListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<Dir::DirList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DirListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirListPage>> List(
        string enterpriseID,
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            EnterpriseID = enterpriseID
        }, cancellationToken);
    }
}