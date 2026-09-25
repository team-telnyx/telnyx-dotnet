using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.DetailRecords;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class DetailRecordService : IDetailRecordService
{
    readonly Lazy<IDetailRecordServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDetailRecordServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IDetailRecordService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new DetailRecordService(this._client.WithOptions(modifier)); }

    public DetailRecordService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new DetailRecordServiceWithRawResponse(client.WithRawResponse)
        ) ;
    }

    /// <inheritdoc/>
    public async Task<DetailRecordListPage> List(
        DetailRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DetailRecordServiceWithRawResponse : IDetailRecordServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDetailRecordServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new DetailRecordServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DetailRecordServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    { _client =client ; }

    /// <inheritdoc/>
    public async Task<HttpResponse<DetailRecordListPage>> List(
        DetailRecordListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DetailRecordListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DetailRecordListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DetailRecordListPage(this, parameters, page);
        });
    }
}