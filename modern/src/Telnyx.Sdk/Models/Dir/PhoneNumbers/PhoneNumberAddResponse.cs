using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir.PhoneNumbers;

/// <summary>
/// Bulk-add success response (HTTP 201). All numbers in the request were accepted
/// into a single new batch. Every entry in `data` shares the same `batch_id` - read
/// it from any element to obtain the batch id for subsequent `GET .../phone_number_batches/{batch_id}`
/// calls. If any number in the request fails (schema-invalid, not in inventory,
/// already attached to another DIR, etc.) the entire request is rejected with HTTP
/// 400 and the canonical Telnyx error envelope; the success body described here is
/// therefore an all-or-nothing payload.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PhoneNumberAddResponse, PhoneNumberAddResponseFromRaw>))]
public sealed record class PhoneNumberAddResponse : JsonModel
{
    /// <summary>
    /// Phone numbers accepted into the new batch. List order mirrors the request
    /// order. Each element shares the same `batch_id`.
    /// </summary>
    public required IReadOnlyList<DirPhoneNumber> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<DirPhoneNumber>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<DirPhoneNumber>>(
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

    public PhoneNumberAddResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAddResponse (
        PhoneNumberAddResponse phoneNumberAddResponse
    ) : base(phoneNumberAddResponse)
    {  }
    #pragma warning restore CS8618

    public PhoneNumberAddResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAddResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAddResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PhoneNumberAddResponse (IReadOnlyList<DirPhoneNumber> data) : this()
    { this.Data = data; }
}

class PhoneNumberAddResponseFromRaw : IFromRawJson<PhoneNumberAddResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAddResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberAddResponse.FromRawUnchecked(rawData);
}