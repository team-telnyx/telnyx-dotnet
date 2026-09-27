using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.PhoneNumberBatches;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberBatchRetrieveResponse, PhoneNumberBatchRetrieveResponseFromRaw>))]
public sealed record class PhoneNumberBatchRetrieveResponse : JsonModel
{
    /// <summary>
    /// A phone-number batch groups all numbers added in a single bulk-add request.
    /// Telnyx vets the batch as a unit. The response embeds the full `phone_numbers`
    /// array so you can read per-number status without a separate call, plus a batch-level
    /// `status` summarising the unit's progress.
    /// </summary>
    public required PhoneNumberBatch Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhoneNumberBatch>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public PhoneNumberBatchRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBatchRetrieveResponse (
        PhoneNumberBatchRetrieveResponse phoneNumberBatchRetrieveResponse
    ) : base(phoneNumberBatchRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberBatchRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberBatchRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberBatchRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberBatchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PhoneNumberBatchRetrieveResponse (PhoneNumberBatch data) : this()
    { this.Data = data; }
}

class PhoneNumberBatchRetrieveResponseFromRaw : IFromRawJson<PhoneNumberBatchRetrieveResponse>
{
    /// <inheritdoc/>
    public PhoneNumberBatchRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberBatchRetrieveResponse.FromRawUnchecked(rawData);
}