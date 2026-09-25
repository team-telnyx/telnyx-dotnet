using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites;
using TestSuites = Telnyx.Sdk.Services.AI.Assistants.Tests.TestSuites;

namespace Telnyx.Sdk.Services.AI.Assistants.Tests;

/// <inheritdoc/>
public sealed class TestSuiteService : ITestSuiteService
{
    readonly Lazy<ITestSuiteServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITestSuiteServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public ITestSuiteService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new TestSuiteService(this._client.WithOptions(modifier)); }

    public TestSuiteService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new TestSuiteServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _runs =new(() => new TestSuites::RunService(client)) ;
    }

    readonly Lazy<TestSuites::IRunService> _runs;
    public TestSuites::IRunService Runs { get { return _runs.Value; } }

    /// <inheritdoc/>
    public async Task<TestSuiteListResponse> List(
        TestSuiteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TestSuiteServiceWithRawResponse : ITestSuiteServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITestSuiteServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new TestSuiteServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TestSuiteServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _runs =new(() => new TestSuites::RunServiceWithRawResponse(client)) ;
    }

    readonly Lazy<TestSuites::IRunServiceWithRawResponse> _runs;
    public TestSuites::IRunServiceWithRawResponse Runs {
        get { return _runs.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TestSuiteListResponse>> List(
        TestSuiteListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TestSuiteListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var testSuites = await response.Deserialize<TestSuiteListResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                testSuites.Validate();
            }
            return testSuites;
        });
    }
}