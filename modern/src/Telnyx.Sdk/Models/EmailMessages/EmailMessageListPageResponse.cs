using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;
using Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<EmailMessageListPageResponse, EmailMessageListPageResponseFromRaw>))]
public sealed record class EmailMessageListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailMessage> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailMessage>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailMessage>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required EmailPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailPaginationMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public EmailMessageListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageListPageResponse (
        EmailMessageListPageResponse emailMessageListPageResponse
    ) : base(emailMessageListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailMessageListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailMessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailMessageListPageResponseFromRaw : IFromRawJson<EmailMessageListPageResponse>
{
    /// <inheritdoc/>
    public EmailMessageListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessageListPageResponse.FromRawUnchecked(rawData);
}