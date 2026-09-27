using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailDomains;

[JsonConverter(typeof(JsonModelConverter<EmailDomainResponse, EmailDomainResponseFromRaw>))]
public sealed record class EmailDomainResponse : JsonModel
{
    public required EmailDomain Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomain>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailDomainResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainResponse (EmailDomainResponse emailDomainResponse) : base(
        emailDomainResponse
    )
    {  }
    #pragma warning restore CS8618

    public EmailDomainResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailDomainResponse (EmailDomain data) : this()
    { this.Data = data; }
}

class EmailDomainResponseFromRaw : IFromRawJson<EmailDomainResponse>
{
    /// <inheritdoc/>
    public EmailDomainResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDomainResponse.FromRawUnchecked(rawData);
}