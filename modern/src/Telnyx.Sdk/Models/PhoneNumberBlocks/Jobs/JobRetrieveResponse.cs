using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumberBlocks.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobRetrieveResponse, JobRetrieveResponseFromRaw>))]
public sealed record class JobRetrieveResponse : JsonModel
{
    public Job? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Job>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public JobRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobRetrieveResponse (JobRetrieveResponse jobRetrieveResponse) : base(
        jobRetrieveResponse
    )
    {  }
    #pragma warning restore CS8618

    public JobRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static JobRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobRetrieveResponseFromRaw : IFromRawJson<JobRetrieveResponse>
{
    /// <inheritdoc/>
    public JobRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobRetrieveResponse.FromRawUnchecked(rawData);
}