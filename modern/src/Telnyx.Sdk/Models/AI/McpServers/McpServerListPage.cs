using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services.AI;

namespace Telnyx.Sdk.Models.AI.McpServers;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IMcpServerService.List(McpServerListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class McpServerListPage(IMcpServerServiceWithRawResponse service,
McpServerListParams parameters,
IReadOnlyList<McpServer> response) : IPage<McpServer>
{
    /// <inheritdoc/>
    public IReadOnlyList<McpServer> Items { get { return response; } }

    /// <inheritdoc/>
    public bool HasNext()
    { return this.Items.Count > 0; }

    /// <inheritdoc/>
    async Task<IPage<McpServer>> IPage<McpServer>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<McpServerListPage> Next(
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
    {
        foreach (var item in response)
        {
            item.Validate();
        }
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)), ModelBase.ToStringSerializerOptions);

    public override bool Equals(object? obj)
    {
        if (obj is not McpServerListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}