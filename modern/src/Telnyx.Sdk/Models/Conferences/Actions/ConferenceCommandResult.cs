using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Conferences.Actions;

[JsonConverter(typeof(JsonModelConverter<ConferenceCommandResult, ConferenceCommandResultFromRaw>))]
public sealed record class ConferenceCommandResult : JsonModel
{
    public required string Result {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "result"
            );
        }
        init { this._rawData.Set("result", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Result; }

    public ConferenceCommandResult ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceCommandResult (
        ConferenceCommandResult conferenceCommandResult
    ) : base(conferenceCommandResult)
    {  }
    #pragma warning restore CS8618

    public ConferenceCommandResult (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceCommandResult (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceCommandResultFromRaw.FromRawUnchecked"/>
    public static ConferenceCommandResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConferenceCommandResult (string result) : this()
    { this.Result = result; }
}

class ConferenceCommandResultFromRaw : IFromRawJson<ConferenceCommandResult>
{
    /// <inheritdoc/>
    public ConferenceCommandResult FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceCommandResult.FromRawUnchecked(rawData);
}