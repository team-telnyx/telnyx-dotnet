using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.Texml.Accounts;

namespace Telnyx.Sdk.Models.Texml.Accounts.Queues;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IQueueService.List(QueueListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class QueueListPage(IQueueServiceWithRawResponse service,
QueueListParams parameters,
QueueListPageResponse response) : IPage<QueueResource>
{
    /// <inheritdoc/>
    public IReadOnlyList<QueueResource> Items {
        get { return response.Queues ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    { return this.Items.Count > 0; }

    /// <inheritdoc/>
    async Task<IPage<QueueResource>> IPage<QueueResource>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<QueueListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.Page ?? 1;
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
        if (obj is not QueueListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}