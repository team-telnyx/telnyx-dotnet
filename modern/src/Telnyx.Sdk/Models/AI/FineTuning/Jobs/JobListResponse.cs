using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.FineTuning.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobListResponse, JobListResponseFromRaw>))]
public sealed record class JobListResponse : JsonModel
{
    public required IReadOnlyList<FineTuningJob> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<FineTuningJob>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<FineTuningJob>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public JobListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobListResponse (JobListResponse jobListResponse) : base(
        jobListResponse
    )
    {  }
    #pragma warning restore CS8618

    public JobListResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobListResponseFromRaw.FromRawUnchecked"/>
    public static JobListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public JobListResponse (IReadOnlyList<FineTuningJob> data) : this()
    { this.Data = data; }
}

class JobListResponseFromRaw : IFromRawJson<JobListResponse>
{
    /// <inheritdoc/>
    public JobListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobListResponse.FromRawUnchecked(rawData);
}