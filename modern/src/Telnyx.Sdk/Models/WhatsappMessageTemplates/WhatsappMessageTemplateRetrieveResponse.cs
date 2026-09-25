using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WhatsappMessageTemplates;

[JsonConverter(typeof(JsonModelConverter<WhatsappMessageTemplateRetrieveResponse, WhatsappMessageTemplateRetrieveResponseFromRaw>))]
public sealed record class WhatsappMessageTemplateRetrieveResponse : JsonModel
{
    public WhatsappTemplateData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WhatsappTemplateData>(
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

    public WhatsappMessageTemplateRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageTemplateRetrieveResponse (
        WhatsappMessageTemplateRetrieveResponse whatsappMessageTemplateRetrieveResponse
    ) : base(whatsappMessageTemplateRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageTemplateRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageTemplateRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageTemplateRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageTemplateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappMessageTemplateRetrieveResponseFromRaw : IFromRawJson<WhatsappMessageTemplateRetrieveResponse>
{
    /// <inheritdoc/>
    public WhatsappMessageTemplateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageTemplateRetrieveResponse.FromRawUnchecked(rawData);
}