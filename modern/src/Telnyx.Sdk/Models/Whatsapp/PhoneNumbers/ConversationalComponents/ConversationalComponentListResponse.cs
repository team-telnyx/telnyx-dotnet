using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.ConversationalComponents;

[JsonConverter(typeof(JsonModelConverter<ConversationalComponentListResponse, ConversationalComponentListResponseFromRaw>))]
public sealed record class ConversationalComponentListResponse : JsonModel
{
    public WhatsappConversationalComponent? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappConversationalComponent>(
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

    public ConversationalComponentListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationalComponentListResponse (
        ConversationalComponentListResponse conversationalComponentListResponse
    ) : base(conversationalComponentListResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationalComponentListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationalComponentListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationalComponentListResponseFromRaw.FromRawUnchecked"/>
    public static ConversationalComponentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationalComponentListResponseFromRaw : IFromRawJson<ConversationalComponentListResponse>
{
    /// <inheritdoc/>
    public ConversationalComponentListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationalComponentListResponse.FromRawUnchecked(rawData);
}