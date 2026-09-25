using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services.Storage.Kvs;

namespace Telnyx.Sdk.Models.Storage.Kvs.Keys;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IKeyService.List(KeyListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class KeyListPage(IKeyServiceWithRawResponse service,
KeyListParams parameters,
KeyListPageResponse response) : IPage<KeyListResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<KeyListResponse> Items {
        get { return response.Data ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Meta?.Cursor != null;
        }
        catch (TelnyxInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<KeyListResponse>> IPage<KeyListResponse>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<KeyListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta?.Cursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service.List(
            parameters with { Cursor = nextCursor },
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
        if (obj is not KeyListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}