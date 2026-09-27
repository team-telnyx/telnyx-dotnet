using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

/// <summary>
/// Number Pool allows you to send messages from a pool of numbers of different types,
/// assigning weights to each type. The pool consists of all the long code and toll
/// free numbers assigned to the messaging profile.
///
/// <para>To disable this feature, set the object field to `null`. </para>
/// </summary>
[JsonConverter(typeof(JsonModelConverter<NumberPoolSettings, NumberPoolSettingsFromRaw>))]
public sealed record class NumberPoolSettings : JsonModel
{
    /// <summary>
    /// Defines the probability weight for a Long Code number to be selected when
    /// sending a message. The higher the weight the higher the probability. The sum
    /// of the weights for all number types does not necessarily need to add to 100.
    ///  Weight must be a non-negative number, and when equal to zero it will remove
    /// the number type from the pool.
    /// </summary>
    public required double LongCodeWeight {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "long_code_weight"
            );
        }
        init { this._rawData.Set("long_code_weight", value); }
    }

    /// <summary>
    /// If set to true all unhealthy numbers will be automatically excluded from
    /// the pool. Health metrics per number are calculated on a regular basis, taking
    /// into account the deliverability rate and the amount of messages marked as
    /// spam by upstream carriers. Numbers with a deliverability rate below 25% or
    /// spam ratio over 75% will be considered unhealthy.
    /// </summary>
    public required bool SkipUnhealthy {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "skip_unhealthy"
            );
        }
        init { this._rawData.Set("skip_unhealthy", value); }
    }

    /// <summary>
    /// Defines the probability weight for a Toll Free number to be selected when
    /// sending a message. The higher the weight the higher the probability. The sum
    /// of the weights for all number types does not necessarily need to add to 100.
    /// Weight must be a non-negative number, and when equal to zero it will remove
    /// the number type from the pool.
    /// </summary>
    public required double TollFreeWeight {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "toll_free_weight"
            );
        }
        init { this._rawData.Set("toll_free_weight", value); }
    }

    /// <summary>
    /// If set to true, Number Pool will try to choose a sending number with the same
    /// area code as the destination number. If there are no such numbers available,
    /// a nunber with a different area code will be chosen. Currently only NANP numbers
    /// are supported.
    /// </summary>
    public bool? Geomatch {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "geomatch"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("geomatch", value);
        }
    }

    /// <summary>
    /// If set to true, Number Pool will try to choose the same sending number for
    /// all messages to a particular recipient. If the sending number becomes unhealthy
    /// and `skip_unhealthy` is set to true, a new number will be chosen.
    /// </summary>
    public bool? StickySender {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "sticky_sender"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sticky_sender", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.LongCodeWeight;
        _ = this.SkipUnhealthy;
        _ = this.TollFreeWeight;
        _ = this.Geomatch;
        _ = this.StickySender;
    }

    public NumberPoolSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NumberPoolSettings (NumberPoolSettings numberPoolSettings) : base(
        numberPoolSettings
    )
    {  }
    #pragma warning restore CS8618

    public NumberPoolSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NumberPoolSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberPoolSettingsFromRaw.FromRawUnchecked"/>
    public static NumberPoolSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class NumberPoolSettingsFromRaw : IFromRawJson<NumberPoolSettings>
{
    /// <inheritdoc/>
    public NumberPoolSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NumberPoolSettings.FromRawUnchecked(rawData);
}