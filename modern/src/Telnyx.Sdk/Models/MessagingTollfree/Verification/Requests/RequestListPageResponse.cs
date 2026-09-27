using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// A paginated response
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequestListPageResponse, RequestListPageResponseFromRaw>))]
public sealed record class RequestListPageResponse : JsonModel
{
    /// <summary>
    /// The records yielded by this request
    /// </summary>
    public required IReadOnlyList<VerificationRequestStatus> Records {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VerificationRequestStatus>>(
                "records"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<VerificationRequestStatus>>(
                "records",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The total amount of records for these query parameters
    /// </summary>
    public required long TotalRecords {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_records"
            );
        }
        init { this._rawData.Set("total_records", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Records)
        {
            item.Validate();
        }
        _ = this.TotalRecords;
    }

    public RequestListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestListPageResponse (
        RequestListPageResponse requestListPageResponse
    ) : base(requestListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RequestListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequestListPageResponseFromRaw.FromRawUnchecked"/>
    public static RequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequestListPageResponseFromRaw : IFromRawJson<RequestListPageResponse>
{
    /// <inheritdoc/>
    public RequestListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequestListPageResponse.FromRawUnchecked(rawData);
}