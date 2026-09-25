using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Settings;

[JsonConverter(typeof(JsonModelConverter<SettingsEnvelope, SettingsEnvelopeFromRaw>))]
public sealed record class SettingsEnvelope : JsonModel
{
    public RetrievalSettingsWrapper? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetrievalSettingsWrapper>(
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

    public SettingsEnvelope ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettingsEnvelope (SettingsEnvelope settingsEnvelope) : base(
        settingsEnvelope
    )
    {  }
    #pragma warning restore CS8618

    public SettingsEnvelope (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SettingsEnvelope (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingsEnvelopeFromRaw.FromRawUnchecked"/>
    public static SettingsEnvelope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SettingsEnvelopeFromRaw : IFromRawJson<SettingsEnvelope>
{
    /// <inheritdoc/>
    public SettingsEnvelope FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SettingsEnvelope.FromRawUnchecked(rawData);
}