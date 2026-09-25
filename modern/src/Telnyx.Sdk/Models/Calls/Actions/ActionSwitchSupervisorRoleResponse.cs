using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionSwitchSupervisorRoleResponse, ActionSwitchSupervisorRoleResponseFromRaw>))]
public sealed record class ActionSwitchSupervisorRoleResponse : JsonModel
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

    public ActionSwitchSupervisorRoleResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSwitchSupervisorRoleResponse (
        ActionSwitchSupervisorRoleResponse actionSwitchSupervisorRoleResponse
    ) : base(actionSwitchSupervisorRoleResponse)
    {  }
    #pragma warning restore CS8618

    public ActionSwitchSupervisorRoleResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionSwitchSupervisorRoleResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionSwitchSupervisorRoleResponseFromRaw.FromRawUnchecked"/>
    public static ActionSwitchSupervisorRoleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionSwitchSupervisorRoleResponseFromRaw : IFromRawJson<ActionSwitchSupervisorRoleResponse>
{
    /// <inheritdoc/>
    public ActionSwitchSupervisorRoleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionSwitchSupervisorRoleResponse.FromRawUnchecked(rawData);
}