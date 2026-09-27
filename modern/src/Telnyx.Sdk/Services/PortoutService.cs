using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Portouts;
using Portouts = Telnyx.Sdk.Services.Portouts;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PortoutService : IPortoutService
{
    readonly Lazy<IPortoutServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPortoutServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPortoutService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PortoutService(this._client.WithOptions(modifier)); }

    public PortoutService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PortoutServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _events =new(() => new Portouts::EventService(client)) ;
        _reports =new(() => new Portouts::ReportService(client)) ;
        _comments =new(() => new Portouts::CommentService(client)) ;
        _supportingDocuments =new(
            () => new Portouts::SupportingDocumentService(client)
        ) ;
    }

    readonly Lazy<Portouts::IEventService> _events;
    public Portouts::IEventService Events { get { return _events.Value; } }

    readonly Lazy<Portouts::IReportService> _reports;
    public Portouts::IReportService Reports { get { return _reports.Value; } }

    readonly Lazy<Portouts::ICommentService> _comments;
    public Portouts::ICommentService Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<Portouts::ISupportingDocumentService> _supportingDocuments;
    public Portouts::ISupportingDocumentService SupportingDocuments {
        get { return _supportingDocuments.Value; }
    }

    /// <inheritdoc/>
    public async Task<PortoutRetrieveResponse> Retrieve(
        PortoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortoutRetrieveResponse> Retrieve(
        string id,
        PortoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortoutListPage> List(
        PortoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PortoutListRejectionCodesResponse> ListRejectionCodes(
        PortoutListRejectionCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListRejectionCodes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortoutListRejectionCodesResponse> ListRejectionCodes(
        string portoutID,
        PortoutListRejectionCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRejectionCodes(parameters with{
            PortoutID = portoutID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortoutUpdateStatusResponse> UpdateStatus(
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortoutUpdateStatusResponse> UpdateStatus(
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status,
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateStatus(parameters with{
            Status = status
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PortoutServiceWithRawResponse : IPortoutServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPortoutServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortoutServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PortoutServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _events =new(() => new Portouts::EventServiceWithRawResponse(client)) ;
        _reports =new(
            () => new Portouts::ReportServiceWithRawResponse(client)
        ) ;
        _comments =new(
            () => new Portouts::CommentServiceWithRawResponse(client)
        ) ;
        _supportingDocuments =new(
            () => new Portouts::SupportingDocumentServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Portouts::IEventServiceWithRawResponse> _events;
    public Portouts::IEventServiceWithRawResponse Events {
        get { return _events.Value; }
    }

    readonly Lazy<Portouts::IReportServiceWithRawResponse> _reports;
    public Portouts::IReportServiceWithRawResponse Reports {
        get { return _reports.Value; }
    }

    readonly Lazy<Portouts::ICommentServiceWithRawResponse> _comments;
    public Portouts::ICommentServiceWithRawResponse Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<Portouts::ISupportingDocumentServiceWithRawResponse> _supportingDocuments;
    public Portouts::ISupportingDocumentServiceWithRawResponse SupportingDocuments {
        get { return _supportingDocuments.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortoutRetrieveResponse>> Retrieve(
        PortoutRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortoutRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var portout = await response.Deserialize<PortoutRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                portout.Validate();
            }
            return portout;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortoutRetrieveResponse>> Retrieve(
        string id,
        PortoutRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortoutListPage>> List(
        PortoutListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortoutListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PortoutListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PortoutListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortoutListRejectionCodesResponse>> ListRejectionCodes(
        PortoutListRejectionCodesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PortoutID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.PortoutID' cannot be null"
            );
        }

        HttpRequest<PortoutListRejectionCodesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortoutListRejectionCodesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortoutListRejectionCodesResponse>> ListRejectionCodes(
        string portoutID,
        PortoutListRejectionCodesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListRejectionCodes(parameters with{
            PortoutID = portoutID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortoutUpdateStatusResponse>> UpdateStatus(
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Status == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Status' cannot be null"
            );
        }

        HttpRequest<PortoutUpdateStatusParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortoutUpdateStatusResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortoutUpdateStatusResponse>> UpdateStatus(
        ApiEnum<string, PortoutUpdateStatusParamsStatus> status,
        PortoutUpdateStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateStatus(parameters with{
            Status = status
        }, cancellationToken);
    }
}