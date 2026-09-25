using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes;

[JsonConverter(typeof(JsonModelConverter<EmailInboxResponse, EmailInboxResponseFromRaw>))]
public sealed record class EmailInboxResponse : JsonModel
{
    public required EmailInbox Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailInbox>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailInboxResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailInboxResponse (EmailInboxResponse emailInboxResponse) : base(
        emailInboxResponse
    )
    {  }
    #pragma warning restore CS8618

    public EmailInboxResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailInboxResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailInboxResponseFromRaw.FromRawUnchecked"/>
    public static EmailInboxResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailInboxResponse (EmailInbox data) : this()
    { this.Data = data; }
}

class EmailInboxResponseFromRaw : IFromRawJson<EmailInboxResponse>
{
    /// <inheritdoc/>
    public EmailInboxResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailInboxResponse.FromRawUnchecked(rawData);
}