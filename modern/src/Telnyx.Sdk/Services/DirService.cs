using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Dir;
using Dir = Telnyx.Sdk.Services.Dir;

namespace Telnyx.Sdk.Services;

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
        _comments =new(() => new Dir::CommentService(client)) ;
        _phoneNumberBatches =new(
            () => new Dir::PhoneNumberBatchService(client)
        ) ;
        _phoneNumbers =new(() => new Dir::PhoneNumberService(client)) ;
        _references =new(() => new Dir::ReferenceService(client)) ;
        _verifyEmail =new(() => new Dir::VerifyEmailService(client)) ;
    }

    readonly Lazy<Dir::ICommentService> _comments;
    public Dir::ICommentService Comments { get { return _comments.Value; } }

    readonly Lazy<Dir::IPhoneNumberBatchService> _phoneNumberBatches;
    public Dir::IPhoneNumberBatchService PhoneNumberBatches {
        get { return _phoneNumberBatches.Value; }
    }

    readonly Lazy<Dir::IPhoneNumberService> _phoneNumbers;
    public Dir::IPhoneNumberService PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<Dir::IReferenceService> _references;
    public Dir::IReferenceService References {
        get { return _references.Value; }
    }

    readonly Lazy<Dir::IVerifyEmailService> _verifyEmail;
    public Dir::IVerifyEmailService VerifyEmail {
        get { return _verifyEmail.Value; }
    }

    /// <inheritdoc/>
    public async Task<DirWrapped> Retrieve(
        DirRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirWrapped> Retrieve(
        string dirID,
        DirRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirWrapped> Update(
        DirUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirWrapped> Update(
        string dirID,
        DirUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirListPage> List(
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        DirDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string dirID,
        DirDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            DirID = dirID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DirListDocumentTypesResponse> ListDocumentTypes(
        DirListDocumentTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListDocumentTypes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<DirListInfringementClaimsPage> ListInfringementClaims(
        DirListInfringementClaimsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.ListInfringementClaims(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirListInfringementClaimsPage> ListInfringementClaims(
        string dirID,
        DirListInfringementClaimsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInfringementClaims(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> NewLoa(
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.NewLoa(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> NewLoa(
        string dirID,
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.NewLoa(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirWrapped> Submit(
        DirSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Submit(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirWrapped> Submit(
        string dirID,
        DirSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DirWrapped> UpdateInfringement(
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.UpdateInfringement(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<DirWrapped> UpdateInfringement(
        string dirID,
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateInfringement(parameters with{
            DirID = dirID
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
    {
        _client =client ;

        _comments =new(() => new Dir::CommentServiceWithRawResponse(client)) ;
        _phoneNumberBatches =new(
            () => new Dir::PhoneNumberBatchServiceWithRawResponse(client)
        ) ;
        _phoneNumbers =new(
            () => new Dir::PhoneNumberServiceWithRawResponse(client)
        ) ;
        _references =new(
            () => new Dir::ReferenceServiceWithRawResponse(client)
        ) ;
        _verifyEmail =new(
            () => new Dir::VerifyEmailServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Dir::ICommentServiceWithRawResponse> _comments;
    public Dir::ICommentServiceWithRawResponse Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<Dir::IPhoneNumberBatchServiceWithRawResponse> _phoneNumberBatches;
    public Dir::IPhoneNumberBatchServiceWithRawResponse PhoneNumberBatches {
        get { return _phoneNumberBatches.Value; }
    }

    readonly Lazy<Dir::IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public Dir::IPhoneNumberServiceWithRawResponse PhoneNumbers {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<Dir::IReferenceServiceWithRawResponse> _references;
    public Dir::IReferenceServiceWithRawResponse References {
        get { return _references.Value; }
    }

    readonly Lazy<Dir::IVerifyEmailServiceWithRawResponse> _verifyEmail;
    public Dir::IVerifyEmailServiceWithRawResponse VerifyEmail {
        get { return _verifyEmail.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirWrapped>> Retrieve(
        DirRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dirWrapped = await response.Deserialize<DirWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dirWrapped.Validate();
            }
            return dirWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirWrapped>> Retrieve(
        string dirID,
        DirRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirWrapped>> Update(
        DirUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dirWrapped = await response.Deserialize<DirWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dirWrapped.Validate();
            }
            return dirWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirWrapped>> Update(
        string dirID,
        DirUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirListPage>> List(
        DirListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DirListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DirList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DirListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DirDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string dirID,
        DirDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirListDocumentTypesResponse>> ListDocumentTypes(
        DirListDocumentTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<DirListDocumentTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<DirListDocumentTypesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirListInfringementClaimsPage>> ListInfringementClaims(
        DirListInfringementClaimsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirListInfringementClaimsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<DirListInfringementClaimsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new DirListInfringementClaimsPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirListInfringementClaimsPage>> ListInfringementClaims(
        string dirID,
        DirListInfringementClaimsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListInfringementClaims(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> NewLoa(
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirNewLoaParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> NewLoa(
        string dirID,
        DirNewLoaParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.NewLoa(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirWrapped>> Submit(
        DirSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dirWrapped = await response.Deserialize<DirWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dirWrapped.Validate();
            }
            return dirWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirWrapped>> Submit(
        string dirID,
        DirSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with{
            DirID = dirID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DirWrapped>> UpdateInfringement(
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DirID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.DirID' cannot be null"
            );
        }

        HttpRequest<DirUpdateInfringementParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var dirWrapped = await response.Deserialize<DirWrapped>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                dirWrapped.Validate();
            }
            return dirWrapped;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<DirWrapped>> UpdateInfringement(
        string dirID,
        DirUpdateInfringementParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UpdateInfringement(parameters with{
            DirID = dirID
        }, cancellationToken);
    }
}