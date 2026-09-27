using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants;
using Assistants = Telnyx.Sdk.Services.AI.Assistants;

namespace Telnyx.Sdk.Services.AI;

/// <inheritdoc/>
public sealed class AssistantService : IAssistantService
{
    readonly Lazy<IAssistantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAssistantServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IAssistantService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new AssistantService(this._client.WithOptions(modifier)); }

    public AssistantService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new AssistantServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _tests =new(() => new Assistants::TestService(client)) ;
        _canaryDeploys =new(() => new Assistants::CanaryDeployService(client)) ;
        _scheduledEvents =new(
            () => new Assistants::ScheduledEventService(client)
        ) ;
        _tools =new(() => new Assistants::ToolService(client)) ;
        _versions =new(() => new Assistants::VersionService(client)) ;
        _tags =new(() => new Assistants::TagService(client)) ;
        _instructions =new(() => new Assistants::InstructionService(client)) ;
    }

    readonly Lazy<Assistants::ITestService> _tests;
    public Assistants::ITestService Tests { get { return _tests.Value; } }

    readonly Lazy<Assistants::ICanaryDeployService> _canaryDeploys;
    public Assistants::ICanaryDeployService CanaryDeploys {
        get { return _canaryDeploys.Value; }
    }

    readonly Lazy<Assistants::IScheduledEventService> _scheduledEvents;
    public Assistants::IScheduledEventService ScheduledEvents {
        get { return _scheduledEvents.Value; }
    }

    readonly Lazy<Assistants::IToolService> _tools;
    public Assistants::IToolService Tools { get { return _tools.Value; } }

    readonly Lazy<Assistants::IVersionService> _versions;
    public Assistants::IVersionService Versions {
        get { return _versions.Value; }
    }

    readonly Lazy<Assistants::ITagService> _tags;
    public Assistants::ITagService Tags { get { return _tags.Value; } }

    readonly Lazy<Assistants::IInstructionService> _instructions;
    public Assistants::IInstructionService Instructions {
        get { return _instructions.Value; }
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Create(
        AssistantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Retrieve(
        AssistantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Retrieve(
        string assistantID,
        AssistantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Update(
        AssistantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Update(
        string assistantID,
        AssistantUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssistantsList> List(
        AssistantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AssistantDeleteResponse> Delete(
        AssistantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantDeleteResponse> Delete(
        string assistantID,
        AssistantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssistantChatResponse> Chat(
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Chat(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantChatResponse> Chat(
        string assistantID,
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Chat(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InferenceEmbedding> Clone(
        AssistantCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Clone(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<InferenceEmbedding> Clone(
        string assistantID,
        AssistantCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<string> GetTexml(
        AssistantGetTexmlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.GetTexml(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<string> GetTexml(
        string assistantID,
        AssistantGetTexmlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetTexml(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssistantsList> Imports(
        AssistantImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Imports(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AssistantSendSmsResponse> SendSms(
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.SendSms(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantSendSmsResponse> SendSms(
        string assistantID,
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendSms(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AssistantServiceWithRawResponse : IAssistantServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAssistantServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AssistantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AssistantServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _tests =new(() => new Assistants::TestServiceWithRawResponse(client)) ;
        _canaryDeploys =new(
            () => new Assistants::CanaryDeployServiceWithRawResponse(client)
        ) ;
        _scheduledEvents =new(
            () => new Assistants::ScheduledEventServiceWithRawResponse(client)
        ) ;
        _tools =new(() => new Assistants::ToolServiceWithRawResponse(client)) ;
        _versions =new(
            () => new Assistants::VersionServiceWithRawResponse(client)
        ) ;
        _tags =new(() => new Assistants::TagServiceWithRawResponse(client)) ;
        _instructions =new(
            () => new Assistants::InstructionServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Assistants::ITestServiceWithRawResponse> _tests;
    public Assistants::ITestServiceWithRawResponse Tests {
        get { return _tests.Value; }
    }

    readonly Lazy<Assistants::ICanaryDeployServiceWithRawResponse> _canaryDeploys;
    public Assistants::ICanaryDeployServiceWithRawResponse CanaryDeploys {
        get { return _canaryDeploys.Value; }
    }

    readonly Lazy<Assistants::IScheduledEventServiceWithRawResponse> _scheduledEvents;
    public Assistants::IScheduledEventServiceWithRawResponse ScheduledEvents {
        get { return _scheduledEvents.Value; }
    }

    readonly Lazy<Assistants::IToolServiceWithRawResponse> _tools;
    public Assistants::IToolServiceWithRawResponse Tools {
        get { return _tools.Value; }
    }

    readonly Lazy<Assistants::IVersionServiceWithRawResponse> _versions;
    public Assistants::IVersionServiceWithRawResponse Versions {
        get { return _versions.Value; }
    }

    readonly Lazy<Assistants::ITagServiceWithRawResponse> _tags;
    public Assistants::ITagServiceWithRawResponse Tags {
        get { return _tags.Value; }
    }

    readonly Lazy<Assistants::IInstructionServiceWithRawResponse> _instructions;
    public Assistants::IInstructionServiceWithRawResponse Instructions {
        get { return _instructions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Create(
        AssistantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AssistantCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Retrieve(
        AssistantRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Retrieve(
        string assistantID,
        AssistantRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Update(
        AssistantUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantUpdateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Update(
        string assistantID,
        AssistantUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantsList>> List(
        AssistantListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AssistantListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantsList = await response.Deserialize<AssistantsList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantsList.Validate();
            }
            return assistantsList;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantDeleteResponse>> Delete(
        AssistantDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistant = await response.Deserialize<AssistantDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistant.Validate();
            }
            return assistant;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantDeleteResponse>> Delete(
        string assistantID,
        AssistantDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantChatResponse>> Chat(
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantChatParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<AssistantChatResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantChatResponse>> Chat(
        string assistantID,
        AssistantChatParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Chat(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InferenceEmbedding>> Clone(
        AssistantCloneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantCloneParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var inferenceEmbedding = await response.Deserialize<InferenceEmbedding>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                inferenceEmbedding.Validate();
            }
            return inferenceEmbedding;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<InferenceEmbedding>> Clone(
        string assistantID,
        AssistantCloneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Clone(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<string>> GetTexml(
        AssistantGetTexmlParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantGetTexmlParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            return await response.Deserialize<string>(token).ConfigureAwait(false);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<string>> GetTexml(
        string assistantID,
        AssistantGetTexmlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetTexml(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantsList>> Imports(
        AssistantImportsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AssistantImportsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantsList = await response.Deserialize<AssistantsList>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantsList.Validate();
            }
            return assistantsList;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantSendSmsResponse>> SendSms(
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssistantID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.AssistantID' cannot be null"
            );
        }

        HttpRequest<AssistantSendSmsParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<AssistantSendSmsResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantSendSmsResponse>> SendSms(
        string assistantID,
        AssistantSendSmsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SendSms(parameters with{
            AssistantID = assistantID
        }, cancellationToken);
    }
}