using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services.EmailInboxes;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IDraftService.List(DraftListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class DraftListPage(IDraftServiceWithRawResponse service,
DraftListParams parameters,
DraftListPageResponse response) : IPage<EmailDraft>
{
    /// <inheritdoc/>
    public IReadOnlyList<EmailDraft> Items { get { return response.Data; } }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Meta.PageCursor != null;
        }
        catch (TelnyxInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<EmailDraft>> IPage<EmailDraft>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<DraftListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta.PageCursor ?? throw new InvalidOperationException("Cannot request next page");
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
        if (obj is not DraftListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}