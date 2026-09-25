using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailMessages;

namespace Telnyx.Sdk.Models.EmailInboxes.Drafts;

[JsonConverter(typeof(JsonModelConverter<EmailMessageResponse, EmailMessageResponseFromRaw>))]
public sealed record class EmailMessageResponse : JsonModel
{
    public required EmailMessage Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailMessage>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Recipients removed by suppression checks when at least one recipient remains
    /// and the message is accepted.
    /// </summary>
    public IReadOnlyList<SuppressedRecipient>? Suppressed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SuppressedRecipient>>(
                "suppressed"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SuppressedRecipient>?>(
                "suppressed",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Data.Validate();
        foreach (var item in this.Suppressed ?? [])
        {
            item.Validate();
        }
    }

    public EmailMessageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageResponse (
        EmailMessageResponse emailMessageResponse
    ) : base(emailMessageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailMessageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageResponseFromRaw.FromRawUnchecked"/>
    public static EmailMessageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailMessageResponse (EmailMessage data) : this()
    { this.Data = data; }
}

class EmailMessageResponseFromRaw : IFromRawJson<EmailMessageResponse>
{
    /// <inheritdoc/>
    public EmailMessageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessageResponse.FromRawUnchecked(rawData);
}