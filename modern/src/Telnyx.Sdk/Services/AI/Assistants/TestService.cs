using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Assistants.Tests;
using Telnyx.Sdk.Services.AI.Assistants.Tests;

namespace Telnyx.Sdk.Services.AI.Assistants;

/// <inheritdoc/>
public sealed class TestService : ITestService
{
    readonly Lazy<ITestServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITestServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITestService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    { return new TestService(this._client.WithOptions(modifier)); }

    public TestService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TestServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _testSuites =new(() => new TestSuiteService(client)) ;
        _runs =new(() => new RunService(client)) ;
    }

    readonly Lazy<ITestSuiteService> _testSuites;
    public ITestSuiteService TestSuites { get { return _testSuites.Value; } }

    readonly Lazy<IRunService> _runs;
    public IRunService Runs { get { return _runs.Value; } }

    /// <inheritdoc/>
    public async Task<AssistantTest> Create(
        TestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Create(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AssistantTest> Retrieve(
        TestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Retrieve(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantTest> Retrieve(
        string testID,
        TestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TestID = testID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssistantTest> Update(
        TestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Update(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<AssistantTest> Update(
        string testID,
        TestUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            TestID = testID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TestListPage> List(
        TestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        TestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }/// <inheritdoc/>
    public async Task Delete(
        string testID,
        TestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with{
            TestID = testID
        }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TestServiceWithRawResponse : ITestServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITestServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TestServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TestServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _testSuites =new(() => new TestSuiteServiceWithRawResponse(client)) ;
        _runs =new(() => new RunServiceWithRawResponse(client)) ;
    }

    readonly Lazy<ITestSuiteServiceWithRawResponse> _testSuites;
    public ITestSuiteServiceWithRawResponse TestSuites {
        get { return _testSuites.Value; }
    }

    readonly Lazy<IRunServiceWithRawResponse> _runs;
    public IRunServiceWithRawResponse Runs { get { return _runs.Value; } }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantTest>> Create(
        TestCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TestCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantTest = await response.Deserialize<AssistantTest>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantTest.Validate();
            }
            return assistantTest;
        });
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantTest>> Retrieve(
        TestRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TestID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TestID' cannot be null"
            );
        }

        HttpRequest<TestRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantTest = await response.Deserialize<AssistantTest>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantTest.Validate();
            }
            return assistantTest;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantTest>> Retrieve(
        string testID,
        TestRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with{
            TestID = testID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssistantTest>> Update(
        TestUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TestID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TestID' cannot be null"
            );
        }

        HttpRequest<TestUpdateParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var assistantTest = await response.Deserialize<AssistantTest>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                assistantTest.Validate();
            }
            return assistantTest;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<AssistantTest>> Update(
        string testID,
        TestUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with{
            TestID = testID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TestListPage>> List(
        TestListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TestListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<TestListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new TestListPage(this, parameters, page);
        });
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TestDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TestID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.TestID' cannot be null"
            );
        }

        HttpRequest<TestDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }/// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string testID,
        TestDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with{
            TestID = testID
        }, cancellationToken);
    }
}