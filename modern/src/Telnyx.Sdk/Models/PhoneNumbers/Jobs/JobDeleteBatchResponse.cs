using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobDeleteBatchResponse, JobDeleteBatchResponseFromRaw>))]
public sealed record class JobDeleteBatchResponse : JsonModel
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

    public JobDeleteBatchResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobDeleteBatchResponse (
        JobDeleteBatchResponse jobDeleteBatchResponse
    ) : base(jobDeleteBatchResponse)
    {  }
    #pragma warning restore CS8618

    public JobDeleteBatchResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobDeleteBatchResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobDeleteBatchResponseFromRaw.FromRawUnchecked"/>
    public static JobDeleteBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobDeleteBatchResponseFromRaw : IFromRawJson<JobDeleteBatchResponse>
{
    /// <inheritdoc/>
    public JobDeleteBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobDeleteBatchResponse.FromRawUnchecked(rawData);
}