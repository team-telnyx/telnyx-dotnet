using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Assistants;

[JsonConverter(typeof(JsonModelConverter<HangupToolParams, HangupToolParamsFromRaw>))]
public sealed record class HangupToolParams : JsonModel
{
    /// <summary>
    /// The description of the function that will be passed to the assistant.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Description; }

    public HangupToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public HangupToolParams (HangupToolParams hangupToolParams) : base(
        hangupToolParams
    )
    {  }
    #pragma warning restore CS8618

    public HangupToolParams (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    HangupToolParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="HangupToolParamsFromRaw.FromRawUnchecked"/>
    public static HangupToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class HangupToolParamsFromRaw : IFromRawJson<HangupToolParams>
{
    /// <inheritdoc/>
    public HangupToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>HangupToolParams.FromRawUnchecked(rawData);
}