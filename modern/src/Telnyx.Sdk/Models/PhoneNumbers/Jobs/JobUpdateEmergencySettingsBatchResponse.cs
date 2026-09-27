using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobUpdateEmergencySettingsBatchResponse, JobUpdateEmergencySettingsBatchResponseFromRaw>))]
public sealed record class JobUpdateEmergencySettingsBatchResponse : JsonModel
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

    public JobUpdateEmergencySettingsBatchResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobUpdateEmergencySettingsBatchResponse (
        JobUpdateEmergencySettingsBatchResponse jobUpdateEmergencySettingsBatchResponse
    ) : base(jobUpdateEmergencySettingsBatchResponse)
    {  }
    #pragma warning restore CS8618

    public JobUpdateEmergencySettingsBatchResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobUpdateEmergencySettingsBatchResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobUpdateEmergencySettingsBatchResponseFromRaw.FromRawUnchecked"/>
    public static JobUpdateEmergencySettingsBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobUpdateEmergencySettingsBatchResponseFromRaw : IFromRawJson<JobUpdateEmergencySettingsBatchResponse>
{
    /// <inheritdoc/>
    public JobUpdateEmergencySettingsBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobUpdateEmergencySettingsBatchResponse.FromRawUnchecked(rawData);
}