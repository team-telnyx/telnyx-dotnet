using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IEmailMessageService.RetrieveEvents(EmailMessageRetrieveEventsParams, CancellationToken)"/> queries.
/// </summary>
public sealed class EmailMessageRetrieveEventsPage(IEmailMessageServiceWithRawResponse service,
EmailMessageRetrieveEventsParams parameters,
EmailMessageRetrieveEventsPageResponse response) : IPage<MessageEvent>
{
    /// <inheritdoc/>
    public IReadOnlyList<MessageEvent> Items { get { return response.Data; } }

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
    async Task<IPage<MessageEvent>> IPage<MessageEvent>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<EmailMessageRetrieveEventsPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextCursor = response.Meta.PageCursor ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service.RetrieveEvents(
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
        if (obj is not EmailMessageRetrieveEventsPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}