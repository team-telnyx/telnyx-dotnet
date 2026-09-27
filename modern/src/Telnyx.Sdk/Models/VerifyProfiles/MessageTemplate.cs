using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifyProfiles;

[JsonConverter(typeof(JsonModelConverter<MessageTemplate, MessageTemplateFromRaw>))]
public sealed record class MessageTemplate : JsonModel
{
    public VerifyProfileMessageTemplateResponse? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfileMessageTemplateResponse>(
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

    public MessageTemplate ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageTemplate (MessageTemplate messageTemplate) : base(
        messageTemplate
    )
    {  }
    #pragma warning restore CS8618

    public MessageTemplate (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageTemplate (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessageTemplateFromRaw.FromRawUnchecked"/>
    public static MessageTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessageTemplateFromRaw : IFromRawJson<MessageTemplate>
{
    /// <inheritdoc/>
    public MessageTemplate FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessageTemplate.FromRawUnchecked(rawData);
}