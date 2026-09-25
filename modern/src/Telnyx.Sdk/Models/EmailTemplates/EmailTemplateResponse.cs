using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailTemplates;

[JsonConverter(typeof(JsonModelConverter<EmailTemplateResponse, EmailTemplateResponseFromRaw>))]
public sealed record class EmailTemplateResponse : JsonModel
{
    public required EmailTemplate Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailTemplate>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailTemplateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateResponse (
        EmailTemplateResponse emailTemplateResponse
    ) : base(emailTemplateResponse)
    {  }
    #pragma warning restore CS8618

    public EmailTemplateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateResponseFromRaw.FromRawUnchecked"/>
    public static EmailTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailTemplateResponse (EmailTemplate data) : this()
    { this.Data = data; }
}

class EmailTemplateResponseFromRaw : IFromRawJson<EmailTemplateResponse>
{
    /// <inheritdoc/>
    public EmailTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplateResponse.FromRawUnchecked(rawData);
}