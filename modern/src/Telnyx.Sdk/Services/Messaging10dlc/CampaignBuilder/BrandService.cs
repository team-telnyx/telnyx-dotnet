using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder.Brand;

namespace Telnyx.Sdk.Services.Messaging10dlc.CampaignBuilder;

/// <inheritdoc/>
public sealed class BrandService : IBrandService
{
    readonly Lazy<IBrandServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IBrandService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new BrandService(this._client.WithOptions(modifier)); }

    public BrandService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new BrandServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<BrandQualifyByUsecaseResponse> QualifyByUsecase(
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.QualifyByUsecase(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandQualifyByUsecaseResponse> QualifyByUsecase(
        string usecase,
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.QualifyByUsecase(parameters with{
            Usecase = usecase
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BrandServiceWithRawResponse : IBrandServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new BrandServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrandServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandQualifyByUsecaseResponse>> QualifyByUsecase(
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Usecase == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Usecase' cannot be null"
            );
        }

        HttpRequest<BrandQualifyByUsecaseParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<BrandQualifyByUsecaseResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandQualifyByUsecaseResponse>> QualifyByUsecase(
        string usecase,
        BrandQualifyByUsecaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.QualifyByUsecase(parameters with{
            Usecase = usecase
        }, cancellationToken);
    }
}