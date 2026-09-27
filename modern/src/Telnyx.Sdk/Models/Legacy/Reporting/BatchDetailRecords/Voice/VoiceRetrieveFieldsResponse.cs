using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.BatchDetailRecords.Voice;

/// <summary>
/// Available CDR report fields grouped by category
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VoiceRetrieveFieldsResponse, VoiceRetrieveFieldsResponseFromRaw>))]
public sealed record class VoiceRetrieveFieldsResponse : JsonModel
{
    /// <summary>
    /// Cost and billing related information
    /// </summary>
    public IReadOnlyList<string>? Billing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "Billing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "Billing",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Fields related to call interaction and basic call information
    /// </summary>
    public IReadOnlyList<string>? InteractionData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "Interaction Data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "Interaction Data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Geographic and routing information for phone numbers
    /// </summary>
    public IReadOnlyList<string>? NumberInformation {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "Number Information"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "Number Information",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Technical telephony and call control information
    /// </summary>
    public IReadOnlyList<string>? TelephonyData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "Telephony Data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "Telephony Data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Billing;
        _ = this.InteractionData;
        _ = this.NumberInformation;
        _ = this.TelephonyData;
    }

    public VoiceRetrieveFieldsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VoiceRetrieveFieldsResponse (
        VoiceRetrieveFieldsResponse voiceRetrieveFieldsResponse
    ) : base(voiceRetrieveFieldsResponse)
    {  }
    #pragma warning restore CS8618

    public VoiceRetrieveFieldsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VoiceRetrieveFieldsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VoiceRetrieveFieldsResponseFromRaw.FromRawUnchecked"/>
    public static VoiceRetrieveFieldsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VoiceRetrieveFieldsResponseFromRaw : IFromRawJson<VoiceRetrieveFieldsResponse>
{
    /// <inheritdoc/>
    public VoiceRetrieveFieldsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VoiceRetrieveFieldsResponse.FromRawUnchecked(rawData);
}