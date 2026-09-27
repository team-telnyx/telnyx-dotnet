using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Faxes.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRefreshResponse, ActionRefreshResponseFromRaw>))]
public sealed record class ActionRefreshResponse : JsonModel
{
    public ActionRefreshResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionRefreshResponseData>(
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

[JsonConverter(typeof(JsonModelConverter<ActionRefreshResponseData, ActionRefreshResponseDataFromRaw>))]
public sealed record class ActionRefreshResponseData : JsonModel
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

    public ActionRefreshResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRefreshResponseData (
        ActionRefreshResponseData actionRefreshResponseData
    ) : base(actionRefreshResponseData)
    {  }
    #pragma warning restore CS8618

    public ActionRefreshResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRefreshResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRefreshResponseDataFromRaw.FromRawUnchecked"/>
    public static ActionRefreshResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionRefreshResponseDataFromRaw : IFromRawJson<ActionRefreshResponseData>
{
    /// <inheritdoc/>
    public ActionRefreshResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRefreshResponseData.FromRawUnchecked(rawData);
}