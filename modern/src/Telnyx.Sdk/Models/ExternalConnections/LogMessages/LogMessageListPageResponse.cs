using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.LogMessages;

[JsonConverter(typeof(JsonModelConverter<LogMessageListPageResponse, LogMessageListPageResponseFromRaw>))]
public sealed record class LogMessageListPageResponse : JsonModel
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

    public ExternalVoiceIntegrationsPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ExternalVoiceIntegrationsPaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.LogMessages ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public LogMessageListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogMessageListPageResponse (
        LogMessageListPageResponse logMessageListPageResponse
    ) : base(logMessageListPageResponse)
    {  }
    #pragma warning restore CS8618

    public LogMessageListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogMessageListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogMessageListPageResponseFromRaw.FromRawUnchecked"/>
    public static LogMessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LogMessageListPageResponseFromRaw : IFromRawJson<LogMessageListPageResponse>
{
    /// <inheritdoc/>
    public LogMessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LogMessageListPageResponse.FromRawUnchecked(rawData);
}