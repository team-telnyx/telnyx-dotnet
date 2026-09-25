using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.PhoneNumbers.ConversationalComponents;

[JsonConverter(typeof(JsonModelConverter<ConversationalComponentPatchAllResponse, ConversationalComponentPatchAllResponseFromRaw>))]
public sealed record class ConversationalComponentPatchAllResponse : JsonModel
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

    public ConversationalComponentPatchAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationalComponentPatchAllResponse (
        ConversationalComponentPatchAllResponse conversationalComponentPatchAllResponse
    ) : base(conversationalComponentPatchAllResponse)
    {  }
    #pragma warning restore CS8618

    public ConversationalComponentPatchAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationalComponentPatchAllResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationalComponentPatchAllResponseFromRaw.FromRawUnchecked"/>
    public static ConversationalComponentPatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationalComponentPatchAllResponseFromRaw : IFromRawJson<ConversationalComponentPatchAllResponse>
{
    /// <inheritdoc/>
    public ConversationalComponentPatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationalComponentPatchAllResponse.FromRawUnchecked(rawData);
}