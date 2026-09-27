using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Organizations.Users.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRemoveResponse, ActionRemoveResponseFromRaw>))]
public sealed record class ActionRemoveResponse : JsonModel
{
    public OrganizationUser? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OrganizationUser>(
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

    public ActionRemoveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRemoveResponse (
        ActionRemoveResponse actionRemoveResponse
    ) : base(actionRemoveResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRemoveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRemoveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRemoveResponseFromRaw.FromRawUnchecked"/>
    public static ActionRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRemoveResponseFromRaw : IFromRawJson<ActionRemoveResponse>
{
    /// <inheritdoc/>
    public ActionRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRemoveResponse.FromRawUnchecked(rawData);
}