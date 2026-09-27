using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.Messaging10dlc.Brand;
using Telnyx.Sdk.Services.Messaging10dlc.Brand;

namespace Telnyx.Sdk.Services.Messaging10dlc;

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
        _externalVetting =new(() => new ExternalVettingService(client)) ;
    }

    readonly Lazy<IExternalVettingService> _externalVetting;
    public IExternalVettingService ExternalVetting {
        get { return _externalVetting.Value; }
    }

    /// <inheritdoc/>
    public async Task<TelnyxBrand> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandRetrieveResponse> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandRetrieveResponse> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelnyxBrand> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxBrand> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandListPage> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            BrandID = brandID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandGetFeedbackResponse> GetFeedback(
        BrandGetFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetFeedback(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandGetFeedbackResponse> GetFeedback(
        string brandID,
        BrandGetFeedbackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFeedback(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandSmsOtpStatus> GetSmsOtpByReference(
        BrandGetSmsOtpByReferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetSmsOtpByReference(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandSmsOtpStatus> GetSmsOtpByReference(
        string referenceID,
        BrandGetSmsOtpByReferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSmsOtpByReference(parameters with{
            ReferenceID = referenceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Resend2faEmail(
        BrandResend2faEmailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Resend2faEmail(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Resend2faEmail(
        string brandID,
        BrandResend2faEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Resend2faEmail(parameters with{
            BrandID = brandID
        }, cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandSmsOtpStatus> RetrieveSmsOtpStatus(
        BrandRetrieveSmsOtpStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveSmsOtpStatus(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandSmsOtpStatus> RetrieveSmsOtpStatus(
        string brandID,
        BrandRetrieveSmsOtpStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSmsOtpStatus(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TelnyxBrand> Revet(
        BrandRevetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Revet(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<TelnyxBrand> Revet(
        string brandID,
        BrandRevetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revet(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandTriggerSmsOtpResponse> TriggerSmsOtp(
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.TriggerSmsOtp(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<BrandTriggerSmsOtpResponse> TriggerSmsOtp(
        string brandID,
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TriggerSmsOtp(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task VerifySmsOtp(
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.VerifySmsOtp(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task VerifySmsOtp(
        string brandID,
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.VerifySmsOtp(parameters with{
            BrandID = brandID
        }, cancellationToken).ConfigureAwait(false);
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
    {
        _client =client ;

        _externalVetting =new(
            () => new ExternalVettingServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<IExternalVettingServiceWithRawResponse> _externalVetting;
    public IExternalVettingServiceWithRawResponse ExternalVetting {
        get { return _externalVetting.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxBrand>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxBrand = await response.Deserialize<TelnyxBrand>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxBrand.Validate();
            }
            return telnyxBrand;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var brand = await response.Deserialize<BrandRetrieveResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                brand.Validate();
            }
            return brand;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxBrand>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxBrand = await response.Deserialize<TelnyxBrand>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxBrand.Validate();
            }
            return telnyxBrand;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxBrand>> Update(
        string brandID,
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandListPage>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<BrandListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new BrandListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandGetFeedbackResponse>> GetFeedback(
        BrandGetFeedbackParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandGetFeedbackParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<BrandGetFeedbackResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandGetFeedbackResponse>> GetFeedback(
        string brandID,
        BrandGetFeedbackParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetFeedback(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandSmsOtpStatus>> GetSmsOtpByReference(
        BrandGetSmsOtpByReferenceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReferenceID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ReferenceID' cannot be null"
            );
        }

        HttpRequest<BrandGetSmsOtpByReferenceParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var brandSmsOtpStatus = await response.Deserialize<BrandSmsOtpStatus>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                brandSmsOtpStatus.Validate();
            }
            return brandSmsOtpStatus;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandSmsOtpStatus>> GetSmsOtpByReference(
        string referenceID,
        BrandGetSmsOtpByReferenceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetSmsOtpByReference(parameters with{
            ReferenceID = referenceID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Resend2faEmail(
        BrandResend2faEmailParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandResend2faEmailParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Resend2faEmail(
        string brandID,
        BrandResend2faEmailParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Resend2faEmail(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandSmsOtpStatus>> RetrieveSmsOtpStatus(
        BrandRetrieveSmsOtpStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandRetrieveSmsOtpStatusParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var brandSmsOtpStatus = await response.Deserialize<BrandSmsOtpStatus>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                brandSmsOtpStatus.Validate();
            }
            return brandSmsOtpStatus;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandSmsOtpStatus>> RetrieveSmsOtpStatus(
        string brandID,
        BrandRetrieveSmsOtpStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveSmsOtpStatus(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelnyxBrand>> Revet(
        BrandRevetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandRevetParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var telnyxBrand = await response.Deserialize<TelnyxBrand>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                telnyxBrand.Validate();
            }
            return telnyxBrand;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<TelnyxBrand>> Revet(
        string brandID,
        BrandRevetParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Revet(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandTriggerSmsOtpResponse>> TriggerSmsOtp(
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandTriggerSmsOtpParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<BrandTriggerSmsOtpResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<BrandTriggerSmsOtpResponse>> TriggerSmsOtp(
        string brandID,
        BrandTriggerSmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.TriggerSmsOtp(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> VerifySmsOtp(
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.BrandID' cannot be null"
            );
        }

        HttpRequest<BrandVerifySmsOtpParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> VerifySmsOtp(
        string brandID,
        BrandVerifySmsOtpParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.VerifySmsOtp(parameters with{
            BrandID = brandID
        }, cancellationToken);
    }
}