using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

[JsonConverter(typeof(JsonModelConverter<CallControlCommandResult, CallControlCommandResultFromRaw>))]
public sealed record class CallControlCommandResult : JsonModel
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

    public CallControlCommandResult ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlCommandResult (
        CallControlCommandResult callControlCommandResult
    ) : base(callControlCommandResult)
    {  }
    #pragma warning restore CS8618

    public CallControlCommandResult (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlCommandResult (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlCommandResultFromRaw.FromRawUnchecked"/>
    public static CallControlCommandResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlCommandResultFromRaw : IFromRawJson<CallControlCommandResult>
{
    /// <inheritdoc/>
    public CallControlCommandResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlCommandResult.FromRawUnchecked(rawData);
}