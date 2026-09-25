using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Rooms.Sessions.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionKickResponse, ActionKickResponseFromRaw>))]
public sealed record class ActionKickResponse : JsonModel
{
    public ActionKickResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionKickResponseData>(
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

    public ActionKickResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionKickResponse (ActionKickResponse actionKickResponse) : base(
        actionKickResponse
    )
    {  }
    #pragma warning restore CS8618

    public ActionKickResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionKickResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionKickResponseFromRaw.FromRawUnchecked"/>
    public static ActionKickResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionKickResponseFromRaw : IFromRawJson<ActionKickResponse>
{
    /// <inheritdoc/>
    public ActionKickResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionKickResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionKickResponseData, ActionKickResponseDataFromRaw>))]
public sealed record class ActionKickResponseData : JsonModel
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

    public ActionKickResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionKickResponseData (
        ActionKickResponseData actionKickResponseData
    ) : base(actionKickResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionKickResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionKickResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionKickResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionKickResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionKickResponseDataFromRaw : IFromRawJson<ActionKickResponseData>
{
    /// <inheritdoc/>
    public ActionKickResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionKickResponseData.FromRawUnchecked(rawData);
}