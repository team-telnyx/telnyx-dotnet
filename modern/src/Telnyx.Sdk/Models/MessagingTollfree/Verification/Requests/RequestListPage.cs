using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.MessagingTollfree.Verification;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IRequestService.List(RequestListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class RequestListPage(IRequestServiceWithRawResponse service,
RequestListParams parameters,
RequestListPageResponse response) : IPage<VerificationRequestStatus>
{
    /// <inheritdoc/>
    public IReadOnlyList<VerificationRequestStatus> Items {
        get { return response.Records; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    { return this.Items.Count > 0; }

    /// <inheritdoc/>
    async Task<IPage<VerificationRequestStatus>> IPage<VerificationRequestStatus>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<RequestListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.Page;
        using var nextResponse = await service.List(
            parameters with { Page = currentPageNumber + 1 },
            cancellationToken
        ).ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    { response.Validate(); }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)), ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not RequestListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}