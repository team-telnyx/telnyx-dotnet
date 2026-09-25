using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PrivateWirelessGateways;

/// <summary>
/// The summary of the resource that have been assigned to the Private Wireless Gateway.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PwgAssignedResourcesSummary, PwgAssignedResourcesSummaryFromRaw>))]
public sealed record class PwgAssignedResourcesSummary : JsonModel
{
    /// <summary>
    /// The current count of a resource type assigned to the Private Wireless Gateway.
    /// </summary>
    public long? Count {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    /// <summary>
    /// The type of the resource assigned to the Private Wireless Gateway.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        _ = this.RecordType;
    }

    public PwgAssignedResourcesSummary ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PwgAssignedResourcesSummary (
        PwgAssignedResourcesSummary pwgAssignedResourcesSummary
    ) : base(pwgAssignedResourcesSummary)
    {  }
    #pragma warning restore CS8618

    public PwgAssignedResourcesSummary (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PwgAssignedResourcesSummary (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PwgAssignedResourcesSummaryFromRaw.FromRawUnchecked"/>
    public static PwgAssignedResourcesSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PwgAssignedResourcesSummaryFromRaw : IFromRawJson<PwgAssignedResourcesSummary>
{
    /// <inheritdoc/>
    public PwgAssignedResourcesSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PwgAssignedResourcesSummary.FromRawUnchecked(rawData);
}