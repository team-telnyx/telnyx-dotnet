using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services.Storage;

namespace Telnyx.Sdk.Models.Storage.Cloudfs;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ICloudfService.List(CloudfListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class CloudfListPage(ICloudfServiceWithRawResponse service,
CloudfListParams parameters,
CloudfListPageResponse response) : IPage<CloudfListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<CloudfListResponse> Items {
        get { return response.Data ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Meta?.Cursors?.After != null;
        }
        catch (TelnyxInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<CloudfListResponse>> IPage<CloudfListResponse>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CloudfListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta?.Cursors?.After ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service.List(
            parameters with { PageAfter = nextCursor },
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
        if (obj is not CloudfListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}