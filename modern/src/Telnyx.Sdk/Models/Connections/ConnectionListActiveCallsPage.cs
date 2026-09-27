using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk.Models.Connections;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IConnectionService.ListActiveCalls(ConnectionListActiveCallsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class ConnectionListActiveCallsPage(IConnectionServiceWithRawResponse service,
ConnectionListActiveCallsParams parameters,
ConnectionListActiveCallsPageResponse response) : IPage<ConnectionListActiveCallsResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<ConnectionListActiveCallsResponse> Items {
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
    async Task<IPage<ConnectionListActiveCallsResponse>> IPage<ConnectionListActiveCallsResponse>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<ConnectionListActiveCallsPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta?.Cursors?.After ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service.ListActiveCalls(
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
        if (obj is not ConnectionListActiveCallsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}