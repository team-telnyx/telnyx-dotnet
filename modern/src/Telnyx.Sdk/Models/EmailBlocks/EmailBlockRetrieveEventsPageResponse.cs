using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailBlocks;

[JsonConverter(typeof(JsonModelConverter<EmailBlockRetrieveEventsPageResponse, EmailBlockRetrieveEventsPageResponseFromRaw>))]
public sealed record class EmailBlockRetrieveEventsPageResponse : JsonModel
{
    public required IReadOnlyList<EmailBlockRetrieveEventsResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailBlockRetrieveEventsResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailBlockRetrieveEventsResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required OffsetMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OffsetMeta>(
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

    public EmailBlockRetrieveEventsPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlockRetrieveEventsPageResponse (
        EmailBlockRetrieveEventsPageResponse emailBlockRetrieveEventsPageResponse
    ) : base(emailBlockRetrieveEventsPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailBlockRetrieveEventsPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlockRetrieveEventsPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockRetrieveEventsPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailBlockRetrieveEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailBlockRetrieveEventsPageResponseFromRaw : IFromRawJson<EmailBlockRetrieveEventsPageResponse>
{
    /// <inheritdoc/>
    public EmailBlockRetrieveEventsPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlockRetrieveEventsPageResponse.FromRawUnchecked(rawData);
}