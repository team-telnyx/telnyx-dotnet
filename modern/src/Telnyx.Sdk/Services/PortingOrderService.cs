using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.PortingOrders;
using PortingOrders = Telnyx.Sdk.Services.PortingOrders;

namespace Telnyx.Sdk.Services;

/// <inheritdoc/>
public sealed class PortingOrderService : IPortingOrderService
{
    readonly Lazy<IPortingOrderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPortingOrderServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IPortingOrderService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new PortingOrderService(this._client.WithOptions(modifier)); }

    public PortingOrderService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new PortingOrderServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _phoneNumberConfigurations =new(
            () => new PortingOrders::PhoneNumberConfigurationService(client)
        ) ;
        _actions =new(() => new PortingOrders::ActionService(client)) ;
        _activationJobs =new(
            () => new PortingOrders::ActivationJobService(client)
        ) ;
        _additionalDocuments =new(
            () => new PortingOrders::AdditionalDocumentService(client)
        ) ;
        _comments =new(() => new PortingOrders::CommentService(client)) ;
        _verificationCodes =new(
            () => new PortingOrders::VerificationCodeService(client)
        ) ;
        _actionRequirements =new(
            () => new PortingOrders::ActionRequirementService(client)
        ) ;
        _associatedPhoneNumbers =new(
            () => new PortingOrders::AssociatedPhoneNumberService(client)
        ) ;
        _phoneNumberBlocks =new(
            () => new PortingOrders::PhoneNumberBlockService(client)
        ) ;
        _phoneNumberExtensions =new(
            () => new PortingOrders::PhoneNumberExtensionService(client)
        ) ;
    }

    readonly Lazy<PortingOrders::IPhoneNumberConfigurationService> _phoneNumberConfigurations;
    public PortingOrders::IPhoneNumberConfigurationService PhoneNumberConfigurations {
        get { return _phoneNumberConfigurations.Value; }
    }

    readonly Lazy<PortingOrders::IActionService> _actions;
    public PortingOrders::IActionService Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<PortingOrders::IActivationJobService> _activationJobs;
    public PortingOrders::IActivationJobService ActivationJobs {
        get { return _activationJobs.Value; }
    }

    readonly Lazy<PortingOrders::IAdditionalDocumentService> _additionalDocuments;
    public PortingOrders::IAdditionalDocumentService AdditionalDocuments {
        get { return _additionalDocuments.Value; }
    }

    readonly Lazy<PortingOrders::ICommentService> _comments;
    public PortingOrders::ICommentService Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<PortingOrders::IVerificationCodeService> _verificationCodes;
    public PortingOrders::IVerificationCodeService VerificationCodes {
        get { return _verificationCodes.Value; }
    }

    readonly Lazy<PortingOrders::IActionRequirementService> _actionRequirements;
    public PortingOrders::IActionRequirementService ActionRequirements {
        get { return _actionRequirements.Value; }
    }

    readonly Lazy<PortingOrders::IAssociatedPhoneNumberService> _associatedPhoneNumbers;
    public PortingOrders::IAssociatedPhoneNumberService AssociatedPhoneNumbers {
        get { return _associatedPhoneNumbers.Value; }
    }

    readonly Lazy<PortingOrders::IPhoneNumberBlockService> _phoneNumberBlocks;
    public PortingOrders::IPhoneNumberBlockService PhoneNumberBlocks {
        get { return _phoneNumberBlocks.Value; }
    }

    readonly Lazy<PortingOrders::IPhoneNumberExtensionService> _phoneNumberExtensions;
    public PortingOrders::IPhoneNumberExtensionService PhoneNumberExtensions {
        get { return _phoneNumberExtensions.Value; }
    }

    /// <inheritdoc/>
    public async Task<PortingOrderCreateResponse> Create(
        PortingOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderRetrieveResponse> Retrieve(
        PortingOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortingOrderRetrieveResponse> Retrieve(
        string id,
        PortingOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderUpdateResponse> Update(
        PortingOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortingOrderUpdateResponse> Update(
        string id,
        PortingOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderListPage> List(
        PortingOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        PortingOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string id,
        PortingOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            ID = id
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderRetrieveAllowedFocWindowsResponse> RetrieveAllowedFocWindows(
        PortingOrderRetrieveAllowedFocWindowsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveAllowedFocWindows(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortingOrderRetrieveAllowedFocWindowsResponse> RetrieveAllowedFocWindows(
        string id,
        PortingOrderRetrieveAllowedFocWindowsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAllowedFocWindows(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderRetrieveExceptionTypesResponse> RetrieveExceptionTypes(
        PortingOrderRetrieveExceptionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveExceptionTypes(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveLoaTemplate(
        PortingOrderRetrieveLoaTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.RetrieveLoaTemplate(parameters, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> RetrieveLoaTemplate(
        string id,
        PortingOrderRetrieveLoaTemplateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLoaTemplate(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderRetrieveRequirementsPage> RetrieveRequirements(
        PortingOrderRetrieveRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveRequirements(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortingOrderRetrieveRequirementsPage> RetrieveRequirements(
        string id,
        PortingOrderRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRequirements(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PortingOrderRetrieveSubRequestResponse> RetrieveSubRequest(
        PortingOrderRetrieveSubRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveSubRequest(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<PortingOrderRetrieveSubRequestResponse> RetrieveSubRequest(
        string id,
        PortingOrderRetrieveSubRequestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSubRequest(parameters with{
            ID = id
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PortingOrderServiceWithRawResponse : IPortingOrderServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPortingOrderServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PortingOrderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PortingOrderServiceWithRawResponse (
        ITelnyxClientWithRawResponse client
    )
    {
        _client =client ;

        _phoneNumberConfigurations =new(
            () => new PortingOrders::PhoneNumberConfigurationServiceWithRawResponse(
                client
            )
        ) ;
        _actions =new(
            () => new PortingOrders::ActionServiceWithRawResponse(client)
        ) ;
        _activationJobs =new(
            () => new PortingOrders::ActivationJobServiceWithRawResponse(client)
        ) ;
        _additionalDocuments =new(
            () => new PortingOrders::AdditionalDocumentServiceWithRawResponse(
                client
            )
        ) ;
        _comments =new(
            () => new PortingOrders::CommentServiceWithRawResponse(client)
        ) ;
        _verificationCodes =new(
            () => new PortingOrders::VerificationCodeServiceWithRawResponse(
                client
            )
        ) ;
        _actionRequirements =new(
            () => new PortingOrders::ActionRequirementServiceWithRawResponse(
                client
            )
        ) ;
        _associatedPhoneNumbers =new(
            () => new PortingOrders::AssociatedPhoneNumberServiceWithRawResponse(
                client
            )
        ) ;
        _phoneNumberBlocks =new(
            () => new PortingOrders::PhoneNumberBlockServiceWithRawResponse(
                client
            )
        ) ;
        _phoneNumberExtensions =new(
            () => new PortingOrders::PhoneNumberExtensionServiceWithRawResponse(
                client
            )
        ) ;
    }

    readonly Lazy<PortingOrders::IPhoneNumberConfigurationServiceWithRawResponse> _phoneNumberConfigurations;
    public PortingOrders::IPhoneNumberConfigurationServiceWithRawResponse PhoneNumberConfigurations {
        get { return _phoneNumberConfigurations.Value; }
    }

    readonly Lazy<PortingOrders::IActionServiceWithRawResponse> _actions;
    public PortingOrders::IActionServiceWithRawResponse Actions {
        get { return _actions.Value; }
    }

    readonly Lazy<PortingOrders::IActivationJobServiceWithRawResponse> _activationJobs;
    public PortingOrders::IActivationJobServiceWithRawResponse ActivationJobs {
        get { return _activationJobs.Value; }
    }

    readonly Lazy<PortingOrders::IAdditionalDocumentServiceWithRawResponse> _additionalDocuments;
    public PortingOrders::IAdditionalDocumentServiceWithRawResponse AdditionalDocuments {
        get { return _additionalDocuments.Value; }
    }

    readonly Lazy<PortingOrders::ICommentServiceWithRawResponse> _comments;
    public PortingOrders::ICommentServiceWithRawResponse Comments {
        get { return _comments.Value; }
    }

    readonly Lazy<PortingOrders::IVerificationCodeServiceWithRawResponse> _verificationCodes;
    public PortingOrders::IVerificationCodeServiceWithRawResponse VerificationCodes {
        get { return _verificationCodes.Value; }
    }

    readonly Lazy<PortingOrders::IActionRequirementServiceWithRawResponse> _actionRequirements;
    public PortingOrders::IActionRequirementServiceWithRawResponse ActionRequirements {
        get { return _actionRequirements.Value; }
    }

    readonly Lazy<PortingOrders::IAssociatedPhoneNumberServiceWithRawResponse> _associatedPhoneNumbers;
    public PortingOrders::IAssociatedPhoneNumberServiceWithRawResponse AssociatedPhoneNumbers {
        get { return _associatedPhoneNumbers.Value; }
    }

    readonly Lazy<PortingOrders::IPhoneNumberBlockServiceWithRawResponse> _phoneNumberBlocks;
    public PortingOrders::IPhoneNumberBlockServiceWithRawResponse PhoneNumberBlocks {
        get { return _phoneNumberBlocks.Value; }
    }

    readonly Lazy<PortingOrders::IPhoneNumberExtensionServiceWithRawResponse> _phoneNumberExtensions;
    public PortingOrders::IPhoneNumberExtensionServiceWithRawResponse PhoneNumberExtensions {
        get { return _phoneNumberExtensions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderCreateResponse>> Create(
        PortingOrderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PortingOrderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var portingOrder = await response.Deserialize<PortingOrderCreateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                portingOrder.Validate();
            }
            return portingOrder;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderRetrieveResponse>> Retrieve(
        PortingOrderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var portingOrder = await response.Deserialize<PortingOrderRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                portingOrder.Validate();
            }
            return portingOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortingOrderRetrieveResponse>> Retrieve(
        string id,
        PortingOrderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderUpdateResponse>> Update(
        PortingOrderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderUpdateParams> request = new()
        {
            Method = TelnyxClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var portingOrder = await response.Deserialize<PortingOrderUpdateResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                portingOrder.Validate();
            }
            return portingOrder;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortingOrderUpdateResponse>> Update(
        string id,
        PortingOrderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderListPage>> List(
        PortingOrderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortingOrderListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PortingOrderListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PortingOrderListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        PortingOrderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string id,
        PortingOrderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderRetrieveAllowedFocWindowsResponse>> RetrieveAllowedFocWindows(
        PortingOrderRetrieveAllowedFocWindowsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderRetrieveAllowedFocWindowsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortingOrderRetrieveAllowedFocWindowsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortingOrderRetrieveAllowedFocWindowsResponse>> RetrieveAllowedFocWindows(
        string id,
        PortingOrderRetrieveAllowedFocWindowsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAllowedFocWindows(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderRetrieveExceptionTypesResponse>> RetrieveExceptionTypes(
        PortingOrderRetrieveExceptionTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PortingOrderRetrieveExceptionTypesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortingOrderRetrieveExceptionTypesResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> RetrieveLoaTemplate(
        PortingOrderRetrieveLoaTemplateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderRetrieveLoaTemplateParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> RetrieveLoaTemplate(
        string id,
        PortingOrderRetrieveLoaTemplateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveLoaTemplate(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderRetrieveRequirementsPage>> RetrieveRequirements(
        PortingOrderRetrieveRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderRetrieveRequirementsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<PortingOrderRetrieveRequirementsPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new PortingOrderRetrieveRequirementsPage(this,
            parameters,
            page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortingOrderRetrieveRequirementsPage>> RetrieveRequirements(
        string id,
        PortingOrderRetrieveRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveRequirements(parameters with{
            ID = id
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PortingOrderRetrieveSubRequestResponse>> RetrieveSubRequest(
        PortingOrderRetrieveSubRequestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ID' cannot be null"
            );
        }

        HttpRequest<PortingOrderRetrieveSubRequestParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<PortingOrderRetrieveSubRequestResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<PortingOrderRetrieveSubRequestResponse>> RetrieveSubRequest(
        string id,
        PortingOrderRetrieveSubRequestParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSubRequest(parameters with{
            ID = id
        }, cancellationToken);
    }
}