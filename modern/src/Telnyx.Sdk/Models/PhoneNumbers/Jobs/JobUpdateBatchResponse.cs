using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobUpdateBatchResponse, JobUpdateBatchResponseFromRaw>))]
public sealed record class JobUpdateBatchResponse : JsonModel
{
    public PhoneNumbersJob? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumbersJob>(
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

    public JobUpdateBatchResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobUpdateBatchResponse (
        JobUpdateBatchResponse jobUpdateBatchResponse
    ) : base(jobUpdateBatchResponse)
    {  }
    #pragma warning restore CS8618

    public JobUpdateBatchResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobUpdateBatchResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobUpdateBatchResponseFromRaw.FromRawUnchecked"/>
    public static JobUpdateBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobUpdateBatchResponseFromRaw : IFromRawJson<JobUpdateBatchResponse>
{
    /// <inheritdoc/>
    public JobUpdateBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobUpdateBatchResponse.FromRawUnchecked(rawData);
}