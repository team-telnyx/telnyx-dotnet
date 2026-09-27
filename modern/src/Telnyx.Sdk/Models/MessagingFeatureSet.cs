using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

/// <summary>
/// The set of features available for a specific messaging use case (SMS or MMS).
/// Features can vary depending on the characteristics the phone number, as well
/// as its current product configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessagingFeatureSet, MessagingFeatureSetFromRaw>))]
public sealed record class MessagingFeatureSet : JsonModel
{
    /// <summary>
    /// Send messages to and receive messages from numbers in the same country.
    /// </summary>
    public required bool DomesticTwoWay {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "domestic_two_way"
            );
        }
        init { this._rawData.Set("domestic_two_way", value); }
    }

    /// <summary>
    /// Receive messages from numbers in other countries.
    /// </summary>
    public required bool InternationalInbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "international_inbound"
            );
        }
        init { this._rawData.Set("international_inbound", value); }
    }

    /// <summary>
    /// Send messages to numbers in other countries.
    /// </summary>
    public required bool InternationalOutbound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "international_outbound"
            );
        }
        init { this._rawData.Set("international_outbound", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DomesticTwoWay;
        _ = this.InternationalInbound;
        _ = this.InternationalOutbound;
    }

    public MessagingFeatureSet ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingFeatureSet (MessagingFeatureSet messagingFeatureSet) : base(
        messagingFeatureSet
    )
    {  }
    #pragma warning restore CS8618

    public MessagingFeatureSet (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingFeatureSet (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingFeatureSetFromRaw.FromRawUnchecked"/>
    public static MessagingFeatureSet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingFeatureSetFromRaw : IFromRawJson<MessagingFeatureSet>
{
    /// <inheritdoc/>
    public MessagingFeatureSet FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingFeatureSet.FromRawUnchecked(rawData);
}