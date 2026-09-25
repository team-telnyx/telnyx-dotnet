using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailUnsubscribeGroups;

[JsonConverter(typeof(JsonModelConverter<EmailUnsubscribeGroupListPageResponse, EmailUnsubscribeGroupListPageResponseFromRaw>))]
public sealed record class EmailUnsubscribeGroupListPageResponse : JsonModel
{
    public required IReadOnlyList<UnsubscribeGroup> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UnsubscribeGroup>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<UnsubscribeGroup>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Group list `meta` (consistent with `GET /v2/email_blocks`).
    /// </summary>
    public required GroupListMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GroupListMeta>(
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

    public EmailUnsubscribeGroupListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailUnsubscribeGroupListPageResponse (
        EmailUnsubscribeGroupListPageResponse emailUnsubscribeGroupListPageResponse
    ) : base(emailUnsubscribeGroupListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailUnsubscribeGroupListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailUnsubscribeGroupListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailUnsubscribeGroupListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailUnsubscribeGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailUnsubscribeGroupListPageResponseFromRaw : IFromRawJson<EmailUnsubscribeGroupListPageResponse>
{
    /// <inheritdoc/>
    public EmailUnsubscribeGroupListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailUnsubscribeGroupListPageResponse.FromRawUnchecked(rawData);
}