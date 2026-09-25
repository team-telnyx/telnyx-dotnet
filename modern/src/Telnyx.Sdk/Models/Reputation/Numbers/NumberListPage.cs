using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Numbers = Telnyx.Sdk.Models.Enterprises.Reputation.Numbers;
using Telnyx.Sdk.Services.Reputation;

namespace Telnyx.Sdk.Models.Reputation.Numbers;

/// <summary>
/// A single page from the paginated endpoint that <see cref="INumberService.List(NumberListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class NumberListPage(INumberServiceWithRawResponse service,
NumberListParams parameters,
Numbers::ReputationPhoneNumberList response) : IPage<Numbers::ReputationPhoneNumber>
{
    /// <inheritdoc/>
    public IReadOnlyList<Numbers::ReputationPhoneNumber> Items {
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
    async Task<IPage<Numbers::ReputationPhoneNumber>> IPage<Numbers::ReputationPhoneNumber>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<NumberListPage> Next(
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
        if (obj is not NumberListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}