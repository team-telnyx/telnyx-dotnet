using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Whatsapp.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateCreateResponse, TemplateCreateResponseFromRaw>))]
public sealed record class TemplateCreateResponse : JsonModel
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

    public TemplateCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateCreateResponse (
        TemplateCreateResponse templateCreateResponse
    ) : base(templateCreateResponse)
    {  }
    #pragma warning restore CS8618

    public TemplateCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TemplateCreateResponseFromRaw.FromRawUnchecked"/>
    public static TemplateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TemplateCreateResponseFromRaw : IFromRawJson<TemplateCreateResponse>
{
    /// <inheritdoc/>
    public TemplateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TemplateCreateResponse.FromRawUnchecked(rawData);
}