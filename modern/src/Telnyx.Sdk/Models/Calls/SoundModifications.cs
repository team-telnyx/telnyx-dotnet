using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Use this field to modify sound effects, for example adjust the pitch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SoundModifications, SoundModificationsFromRaw>))]
public sealed record class SoundModifications : JsonModel
{
    /// <summary>
    /// Adjust the pitch in octaves, values should be between -1 and 1, default 0
    /// </summary>
    public float? Octaves {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "octaves"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("octaves", value);
        }
    }

    /// <summary>
    /// Set the pitch directly, value should be &gt; 0, default 1 (lower = lower tone)
    /// </summary>
    public float? Pitch {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "pitch"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pitch", value);
        }
    }

    /// <summary>
    /// Adjust the pitch in semitones, values should be between -14 and 14, default 0
    /// </summary>
    public float? Semitone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<float>(
                "semitone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("semitone", value);
        }
    }

    /// <summary>
    /// The track to which the sound modifications will be applied. Accepted values
    /// are `inbound` or `outbound`
    /// </summary>
    public string? Track {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "track"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("track", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Octaves;
        _ = this.Pitch;
        _ = this.Semitone;
        _ = this.Track;
    }

    public SoundModifications ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SoundModifications (SoundModifications soundModifications) : base(
        soundModifications
    )
    {  }
    #pragma warning restore CS8618

    public SoundModifications (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SoundModifications (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SoundModificationsFromRaw.FromRawUnchecked"/>
    public static SoundModifications FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SoundModificationsFromRaw : IFromRawJson<SoundModifications>
{
    /// <inheritdoc/>
    public SoundModifications FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SoundModifications.FromRawUnchecked(rawData);
}