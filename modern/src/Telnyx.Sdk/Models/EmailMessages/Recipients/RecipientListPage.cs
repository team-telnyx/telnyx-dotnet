using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services.EmailMessages;

namespace Telnyx.Sdk.Models.EmailMessages.Recipients;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IRecipientService.List(RecipientListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class RecipientListPage(IRecipientServiceWithRawResponse service,
RecipientListParams parameters,
RecipientListPageResponse response) : IPage<EmailRecipient>
{
    /// <inheritdoc/>
    public IReadOnlyList<EmailRecipient> Items { get { return response.Data; } }

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
    async Task<IPage<EmailRecipient>> IPage<EmailRecipient>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<RecipientListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta.PageCursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service.List(
            parameters with { PageCursor = nextCursor },
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
        if (obj is not RecipientListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}