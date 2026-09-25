using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Sessions.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionMuteResponse, ActionMuteResponseFromRaw>))]
public sealed record class ActionMuteResponse : JsonModel
{
    public ActionMuteResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionMuteResponseData>(
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

    public ActionMuteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionMuteResponse (ActionMuteResponse actionMuteResponse) : base(
        actionMuteResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionMuteResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionMuteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionMuteResponseFromRaw.FromRawUnchecked"/>
    public static ActionMuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionMuteResponseFromRaw : IFromRawJson<ActionMuteResponse>
{
    /// <inheritdoc/>
    public ActionMuteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionMuteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionMuteResponseData, ActionMuteResponseDataFromRaw>))]
public sealed record class ActionMuteResponseData : JsonModel
{
    public string? Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "result"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("result", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Result; }

    public ActionMuteResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionMuteResponseData (
        ActionMuteResponseData actionMuteResponseData
    ) : base(actionMuteResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionMuteResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionMuteResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionMuteResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionMuteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionMuteResponseDataFromRaw : IFromRawJson<ActionMuteResponseData>
{
    /// <inheritdoc/>
    public ActionMuteResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionMuteResponseData.FromRawUnchecked(rawData);
}