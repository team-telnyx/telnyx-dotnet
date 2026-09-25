using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<EmailMessageRetrieveEventsPageResponse, EmailMessageRetrieveEventsPageResponseFromRaw>))]
public sealed record class EmailMessageRetrieveEventsPageResponse : JsonModel
{
    public required IReadOnlyList<MessageEvent> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<MessageEvent>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<MessageEvent>>(
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

    public EmailMessageRetrieveEventsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageRetrieveEventsPageResponse (
        EmailMessageRetrieveEventsPageResponse emailMessageRetrieveEventsPageResponse
    ) : base(emailMessageRetrieveEventsPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailMessageRetrieveEventsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageRetrieveEventsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageRetrieveEventsPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailMessageRetrieveEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailMessageRetrieveEventsPageResponseFromRaw : IFromRawJson<EmailMessageRetrieveEventsPageResponse>
{
    /// <inheritdoc/>
    public EmailMessageRetrieveEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessageRetrieveEventsPageResponse.FromRawUnchecked(rawData);
}