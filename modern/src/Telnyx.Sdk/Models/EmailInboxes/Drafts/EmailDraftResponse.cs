using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

[JsonConverter(typeof(JsonModelConverter<EmailDraftResponse, EmailDraftResponseFromRaw>))]
public sealed record class EmailDraftResponse : JsonModel
{
    /// <summary>
    /// An unsent, mutable draft message belonging to an inbox.
    /// </summary>
    public required EmailDraft Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDraft>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public EmailDraftResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDraftResponse (EmailDraftResponse emailDraftResponse) : base(
        emailDraftResponse
    )
    {  }
    #pragma warning restore CS8618

    public EmailDraftResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDraftResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailDraftResponseFromRaw.FromRawUnchecked"/>
    public static EmailDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailDraftResponse (EmailDraft data) : this()
    { this.Data = data; }
}

class EmailDraftResponseFromRaw : IFromRawJson<EmailDraftResponse>
{
    /// <inheritdoc/>
    public EmailDraftResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailDraftResponse.FromRawUnchecked(rawData);
}