using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionHangupResponse, ActionHangupResponseFromRaw>))]
public sealed record class ActionHangupResponse : JsonModel
{
    public CallControlCommandResult? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlCommandResult>(
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

    public ActionHangupResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionHangupResponse (
        ActionHangupResponse actionHangupResponse
    ) : base(actionHangupResponse)
    {  }
    #pragma warning restore CS8618

    public ActionHangupResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionHangupResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionHangupResponseFromRaw.FromRawUnchecked"/>
    public static ActionHangupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionHangupResponseFromRaw : IFromRawJson<ActionHangupResponse>
{
    /// <inheritdoc/>
    public ActionHangupResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionHangupResponse.FromRawUnchecked(rawData);
}