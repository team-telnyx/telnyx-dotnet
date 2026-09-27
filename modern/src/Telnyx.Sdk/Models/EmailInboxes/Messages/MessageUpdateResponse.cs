using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Webhooks;

namespace Telnyx.Sdk.Models.EmailInboxes.Messages;

[JsonConverter(typeof(JsonModelConverter<MessageUpdateResponse, MessageUpdateResponseFromRaw>))]
public sealed record class MessageUpdateResponse : JsonModel
{
    public required InboundMessage Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InboundMessage>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public MessageUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageUpdateResponse (
        MessageUpdateResponse messageUpdateResponse
    ) : base(messageUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MessageUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MessageUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public MessageUpdateResponse (InboundMessage data) : this()
    { this.Data = data; }
}

class MessageUpdateResponseFromRaw : IFromRawJson<MessageUpdateResponse>
{
    /// <inheritdoc/>
    public MessageUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageUpdateResponse.FromRawUnchecked(rawData);
}