using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WhatsappReaction, WhatsappReactionFromRaw>))]
public sealed record class WhatsappReaction : JsonModel
{
    public string? Emoji {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "emoji"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("emoji", value);
        }
    }

    public string? MessageID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "message_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("message_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Emoji;
        _ = this.MessageID;
    }

    public WhatsappReaction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappReaction (WhatsappReaction whatsappReaction) : base(
        whatsappReaction
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappReaction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappReaction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappReactionFromRaw.FromRawUnchecked"/>
    public static WhatsappReaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappReactionFromRaw : IFromRawJson<WhatsappReaction>
{
    /// <inheritdoc/>
    public WhatsappReaction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappReaction.FromRawUnchecked(rawData);
}