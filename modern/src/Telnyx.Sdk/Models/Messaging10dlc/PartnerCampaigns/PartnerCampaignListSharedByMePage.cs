using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Services.Messaging10dlc;

namespace Telnyx.Sdk.Models.Messaging10dlc.PartnerCampaigns;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IPartnerCampaignService.ListSharedByMe(PartnerCampaignListSharedByMeParams, CancellationToken)"/> queries.
/// </summary>
public sealed class PartnerCampaignListSharedByMePage(IPartnerCampaignServiceWithRawResponse service,
PartnerCampaignListSharedByMeParams parameters,
PartnerCampaignListSharedByMePageResponse response) : IPage<PartnerCampaignListSharedByMeResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<PartnerCampaignListSharedByMeResponse> Items {
        get { return response.Records ?? []; }
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
            var pageNumber = response.Page ?? 1;
            var pageCount = response.TotalRecords;
            if (pageCount == null)
            {
                return true;
            }
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
    async Task<IPage<PartnerCampaignListSharedByMeResponse>> IPage<PartnerCampaignListSharedByMeResponse>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<PartnerCampaignListSharedByMePage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var currentPageNumber = parameters.Page ?? 1;
        using var nextResponse = await service.ListSharedByMe(
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
        if (obj is not PartnerCampaignListSharedByMePage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}