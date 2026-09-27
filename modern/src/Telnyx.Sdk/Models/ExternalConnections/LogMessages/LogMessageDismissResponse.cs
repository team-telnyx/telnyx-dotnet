using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.LogMessages;

[JsonConverter(typeof(JsonModelConverter<LogMessageDismissResponse, LogMessageDismissResponseFromRaw>))]
public sealed record class LogMessageDismissResponse : JsonModel
{
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
    { _ = this.Success; }

    public LogMessageDismissResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogMessageDismissResponse (
        LogMessageDismissResponse logMessageDismissResponse
    ) : base(logMessageDismissResponse)
    {  }
    #pragma warning restore CS8618

    public LogMessageDismissResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogMessageDismissResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogMessageDismissResponseFromRaw.FromRawUnchecked"/>
    public static LogMessageDismissResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LogMessageDismissResponseFromRaw : IFromRawJson<LogMessageDismissResponse>
{
    /// <inheritdoc/>
    public LogMessageDismissResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LogMessageDismissResponse.FromRawUnchecked(rawData);
}