using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageScheduleResponse, MessageScheduleResponseFromRaw>))]
public sealed record class MessageScheduleResponse : JsonModel
{
    public OutboundMessagePayload? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OutboundMessagePayload>(
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

    public MessageScheduleResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageScheduleResponse (
        MessageScheduleResponse messageScheduleResponse
    ) : base(messageScheduleResponse)
    {  }
    #pragma warning restore CS8618

    public MessageScheduleResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageScheduleResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageScheduleResponseFromRaw.FromRawUnchecked"/>
    public static MessageScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageScheduleResponseFromRaw : IFromRawJson<MessageScheduleResponse>
{
    /// <inheritdoc/>
    public MessageScheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageScheduleResponse.FromRawUnchecked(rawData);
}