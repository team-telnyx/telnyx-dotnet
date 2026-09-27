using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<AvailablePhoneNumbersMetadata, AvailablePhoneNumbersMetadataFromRaw>))]
public sealed record class AvailablePhoneNumbersMetadata : JsonModel
{
    public long? BestEffortResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "best_effort_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("best_effort_results", value);
        }
    }

    public long? TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_results"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_results", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BestEffortResults;
        _ = this.TotalResults;
    }

    public AvailablePhoneNumbersMetadata ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailablePhoneNumbersMetadata (
        AvailablePhoneNumbersMetadata availablePhoneNumbersMetadata
    ) : base(availablePhoneNumbersMetadata)
    {  }
    #pragma warning restore CS8618

    public AvailablePhoneNumbersMetadata (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailablePhoneNumbersMetadata (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AvailablePhoneNumbersMetadataFromRaw.FromRawUnchecked"/>
    public static AvailablePhoneNumbersMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AvailablePhoneNumbersMetadataFromRaw : IFromRawJson<AvailablePhoneNumbersMetadata>
{
    /// <inheritdoc/>
    public AvailablePhoneNumbersMetadata FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AvailablePhoneNumbersMetadata.FromRawUnchecked(rawData);
}