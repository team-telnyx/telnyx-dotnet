using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk.Models.EmailMessages;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IEmailMessageService.List(EmailMessageListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class EmailMessageListPage(IEmailMessageServiceWithRawResponse service,
EmailMessageListParams parameters,
EmailMessageListPageResponse response) : IPage<EmailMessage>
{
    /// <inheritdoc/>
    public IReadOnlyList<EmailMessage> Items { get { return response.Data; } }

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
    async Task<IPage<EmailMessage>> IPage<EmailMessage>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<EmailMessageListPage> Next(
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
        if (obj is not EmailMessageListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}