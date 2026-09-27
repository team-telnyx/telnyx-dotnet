using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk.Models.EmailUnsubscribeGroups;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IEmailUnsubscribeGroupService.List(EmailUnsubscribeGroupListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class EmailUnsubscribeGroupListPage(IEmailUnsubscribeGroupServiceWithRawResponse service,
EmailUnsubscribeGroupListParams parameters,
EmailUnsubscribeGroupListPageResponse response) : IPage<UnsubscribeGroup>
{
    /// <inheritdoc/>
    public IReadOnlyList<UnsubscribeGroup> Items {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            if (this.Items.Count == 0)
            {
                return false;
            }
            var pageNumber = response.Meta.PageNumber;
            var pageCount = response.Meta.TotalPages;

            return pageNumber < pageCount;
        }
        catch (TelnyxInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<UnsubscribeGroup>> IPage<UnsubscribeGroup>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<EmailUnsubscribeGroupListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.PageNumber ?? 1;
        using var nextResponse = await service.List(
            parameters with { PageNumber = currentPageNumber + 1 },
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
        if (obj is not EmailUnsubscribeGroupListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}