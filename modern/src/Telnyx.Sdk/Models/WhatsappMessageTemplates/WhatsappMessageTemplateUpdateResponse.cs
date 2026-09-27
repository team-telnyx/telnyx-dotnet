using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.WhatsappMessageTemplates;

[JsonConverter(typeof(JsonModelConverter<WhatsappMessageTemplateUpdateResponse, WhatsappMessageTemplateUpdateResponseFromRaw>))]
public sealed record class WhatsappMessageTemplateUpdateResponse : JsonModel
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

    public WhatsappMessageTemplateUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappMessageTemplateUpdateResponse (
        WhatsappMessageTemplateUpdateResponse whatsappMessageTemplateUpdateResponse
    ) : base(whatsappMessageTemplateUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public WhatsappMessageTemplateUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappMessageTemplateUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappMessageTemplateUpdateResponseFromRaw.FromRawUnchecked"/>
    public static WhatsappMessageTemplateUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappMessageTemplateUpdateResponseFromRaw : IFromRawJson<WhatsappMessageTemplateUpdateResponse>
{
    /// <inheritdoc/>
    public WhatsappMessageTemplateUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappMessageTemplateUpdateResponse.FromRawUnchecked(rawData);
}