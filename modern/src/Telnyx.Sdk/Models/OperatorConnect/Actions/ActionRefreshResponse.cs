using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.OperatorConnect.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRefreshResponse, ActionRefreshResponseFromRaw>))]
public sealed record class ActionRefreshResponse : JsonModel
{
    /// <summary>
    /// A message describing the result of the operation
    /// </summary>
    public string? Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <summary>
    /// Describes wether or not the operation was successful
    /// </summary>
    public bool? Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "success"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        _ = this.Success;
    }

    public ActionRefreshResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRefreshResponse (
        ActionRefreshResponse actionRefreshResponse
    ) : base(actionRefreshResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRefreshResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRefreshResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRefreshResponseFromRaw.FromRawUnchecked"/>
    public static ActionRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRefreshResponseFromRaw : IFromRawJson<ActionRefreshResponse>
{
    /// <inheritdoc/>
    public ActionRefreshResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRefreshResponse.FromRawUnchecked(rawData);
}