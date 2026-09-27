using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Collections.Settings;

[JsonConverter(typeof(JsonModelConverter<SettingsRequest, SettingsRequestFromRaw>))]
public sealed record class SettingsRequest : JsonModel
{
    /// <summary>
    /// How documents are retrieved when searching the collection.
    /// </summary>
    public RetrievalSettings? Retrieval {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RetrievalSettings>(
                "retrieval"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("retrieval", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Retrieval?.Validate(); }

    public SettingsRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SettingsRequest (SettingsRequest settingsRequest) : base(
        settingsRequest
    )
    {  }
    #pragma warning restore CS8618

    public SettingsRequest (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SettingsRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingsRequestFromRaw.FromRawUnchecked"/>
    public static SettingsRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SettingsRequestFromRaw : IFromRawJson<SettingsRequest>
{
    /// <inheritdoc/>
    public SettingsRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SettingsRequest.FromRawUnchecked(rawData);
}