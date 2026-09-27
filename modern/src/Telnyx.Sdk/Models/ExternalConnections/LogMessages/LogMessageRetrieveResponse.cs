using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.LogMessages;

[JsonConverter(typeof(JsonModelConverter<LogMessageRetrieveResponse, LogMessageRetrieveResponseFromRaw>))]
public sealed record class LogMessageRetrieveResponse : JsonModel
{
    public IReadOnlyList<LogMessage>? LogMessages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<LogMessage>>(
                "log_messages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<LogMessage>?>(
                "log_messages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.LogMessages ?? [])
        {
            item.Validate();
        }
    }

    public LogMessageRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogMessageRetrieveResponse (
        LogMessageRetrieveResponse logMessageRetrieveResponse
    ) : base(logMessageRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public LogMessageRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogMessageRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogMessageRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static LogMessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LogMessageRetrieveResponseFromRaw : IFromRawJson<LogMessageRetrieveResponse>
{
    /// <inheritdoc/>
    public LogMessageRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LogMessageRetrieveResponse.FromRawUnchecked(rawData);
}