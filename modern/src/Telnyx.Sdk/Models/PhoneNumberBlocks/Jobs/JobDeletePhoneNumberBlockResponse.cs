using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumberBlocks.Jobs;

[JsonConverter(typeof(JsonModelConverter<JobDeletePhoneNumberBlockResponse, JobDeletePhoneNumberBlockResponseFromRaw>))]
public sealed record class JobDeletePhoneNumberBlockResponse : JsonModel
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

    public JobDeletePhoneNumberBlockResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public JobDeletePhoneNumberBlockResponse (
        JobDeletePhoneNumberBlockResponse jobDeletePhoneNumberBlockResponse
    ) : base(jobDeletePhoneNumberBlockResponse)
    {  }
    #pragma warning restore CS8618

    public JobDeletePhoneNumberBlockResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    JobDeletePhoneNumberBlockResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="JobDeletePhoneNumberBlockResponseFromRaw.FromRawUnchecked"/>
    public static JobDeletePhoneNumberBlockResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class JobDeletePhoneNumberBlockResponseFromRaw : IFromRawJson<JobDeletePhoneNumberBlockResponse>
{
    /// <inheritdoc/>
    public JobDeletePhoneNumberBlockResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>JobDeletePhoneNumberBlockResponse.FromRawUnchecked(rawData);
}