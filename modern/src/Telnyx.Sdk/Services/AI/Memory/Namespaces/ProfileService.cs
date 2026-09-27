using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;
using Profiles = Telnyx.Sdk.Services.AI.Memory.Namespaces.Profiles;

namespace Telnyx.Sdk.Services.AI.Memory.Namespaces;

/// <inheritdoc/>
public sealed class ProfileService : IProfileService
{
    readonly Lazy<IProfileServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithRawResponse {
        get { return _withRawResponse.Value; }
    }

    readonly ITelnyxClient _client;

    /// <inheritdoc/>
    public IProfileService WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    { return new ProfileService(this._client.WithOptions(modifier)); }

    public ProfileService (ITelnyxClient client)
    {
        _client =client ;

        _withRawResponse =new(
            () => new ProfileServiceWithRawResponse(client.WithRawResponse)
        ) ;
        _memories =new(() => new Profiles::MemoryService(client)) ;
        _sources =new(() => new Profiles::SourceService(client)) ;
    }

    readonly Lazy<Profiles::IMemoryService> _memories;
    public Profiles::IMemoryService Memories { get { return _memories.Value; } }

    readonly Lazy<Profiles::ISourceService> _sources;
    public Profiles::ISourceService Sources { get { return _sources.Value; } }

    /// <inheritdoc/>
    public async Task<ProfileListPage> List(
        ProfileListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.List(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileListPage> List(
        string namespace_,
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileDeleteResponse> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Delete(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileDeleteResponse> Delete(
        string profileID,
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileIngestResponse> Ingest(
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Ingest(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileIngestResponse> Ingest(
        string profileID,
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ingest(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileRecallResponse> Recall(
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Recall(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileRecallResponse> Recall(
        string profileID,
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Recall(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileRememberResponse> Remember(
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.Remember(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileRememberResponse> Remember(
        string profileID,
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remember(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ProfileRetrieveSummaryResponse> RetrieveSummary(
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this.WithRawResponse.RetrieveSummary(parameters, cancellationToken).ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }/// <inheritdoc/>
    public Task<ProfileRetrieveSummaryResponse> RetrieveSummary(
        string profileID,
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveSummary(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ProfileServiceWithRawResponse : IProfileServiceWithRawResponse
{
    readonly ITelnyxClientWithRawResponse _client;

    /// <inheritdoc/>
    public IProfileServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ProfileServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ProfileServiceWithRawResponse (ITelnyxClientWithRawResponse client)
    {
        _client =client ;

        _memories =new(
            () => new Profiles::MemoryServiceWithRawResponse(client)
        ) ;
        _sources =new(
            () => new Profiles::SourceServiceWithRawResponse(client)
        ) ;
    }

    readonly Lazy<Profiles::IMemoryServiceWithRawResponse> _memories;
    public Profiles::IMemoryServiceWithRawResponse Memories {
        get { return _memories.Value; }
    }

    readonly Lazy<Profiles::ISourceServiceWithRawResponse> _sources;
    public Profiles::ISourceServiceWithRawResponse Sources {
        get { return _sources.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileListPage>> List(
        ProfileListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Namespace == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.Namespace' cannot be null"
            );
        }

        HttpRequest<ProfileListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var page = await response.Deserialize<ProfileListPageResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                page.Validate();
            }
            return new ProfileListPage(this, parameters, page);
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileListPage>> List(
        string namespace_,
        ProfileListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with{
            Namespace = namespace_
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileDeleteResponse>> Delete(
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<ProfileDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var profile = await response.Deserialize<ProfileDeleteResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                profile.Validate();
            }
            return profile;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileDeleteResponse>> Delete(
        string profileID,
        ProfileDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileIngestResponse>> Ingest(
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<ProfileIngestParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ProfileIngestResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileIngestResponse>> Ingest(
        string profileID,
        ProfileIngestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Ingest(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileRecallResponse>> Recall(
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<ProfileRecallParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ProfileRecallResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileRecallResponse>> Recall(
        string profileID,
        ProfileRecallParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Recall(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileRememberResponse>> Remember(
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<ProfileRememberParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ProfileRememberResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileRememberResponse>> Remember(
        string profileID,
        ProfileRememberParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remember(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ProfileRetrieveSummaryResponse>> RetrieveSummary(
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ProfileID == null)
        {
            throw new TelnyxInvalidDataException(
                "'parameters.ProfileID' cannot be null"
            );
        }

        HttpRequest<ProfileRetrieveSummaryParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(response, async ( token )=>{
            var deserializedResponse = await response.Deserialize<ProfileRetrieveSummaryResponse>(token).ConfigureAwait(false);
            if (this._client.ResponseValidation) {
                deserializedResponse.Validate();
            }
            return deserializedResponse;
        });
    }/// <inheritdoc/>
    public Task<HttpResponse<ProfileRetrieveSummaryResponse>> RetrieveSummary(
        string profileID,
        ProfileRetrieveSummaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RetrieveSummary(parameters with{
            ProfileID = profileID
        }, cancellationToken);
    }
}