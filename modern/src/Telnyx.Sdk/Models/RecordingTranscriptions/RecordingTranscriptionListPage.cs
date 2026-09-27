using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Services;

namespace Telnyx.Sdk.Models.RecordingTranscriptions;

/// <summary>
/// A single page from the paginated endpoint that <see cref="IRecordingTranscriptionService.List(RecordingTranscriptionListParams, CancellationToken)"/> queries.
/// </summary>
public sealed class RecordingTranscriptionListPage(IRecordingTranscriptionServiceWithRawResponse service,
RecordingTranscriptionListParams parameters,
RecordingTranscriptionListPageResponse response) : IPage<RecordingTranscription>
{
    /// <inheritdoc/>
    public IReadOnlyList<RecordingTranscription> Items {
        get { return response.Data ?? []; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    { return !string.IsNullOrEmpty(response.Meta?.Next); }

    /// <inheritdoc/>
    async Task<IPage<RecordingTranscription>> IPage<RecordingTranscription>.Next(
        CancellationToken cancellationToken
    )
    =>await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<RecordingTranscriptionListPage> Next(
        CancellationToken cancellationToken = default
    )
    {
        var nextUrl = response.Meta?.Next;
        if (nextUrl == null || string.IsNullOrEmpty(nextUrl)) { throw new InvalidOperationException("Cannot request next page"); }
        using var nextResponse = await service.List(
          parameters with { PaginationUrls = [..parameters.PaginationUrls, nextUrl] }, cancellationToken
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
        if (obj is not RecordingTranscriptionListPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode()
    =>0;
}