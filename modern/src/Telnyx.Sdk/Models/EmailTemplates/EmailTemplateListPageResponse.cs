using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.EmailInboxes.Threads;

namespace Telnyx.Sdk.Models.EmailTemplates;

[JsonConverter(typeof(JsonModelConverter<EmailTemplateListPageResponse, EmailTemplateListPageResponseFromRaw>))]
public sealed record class EmailTemplateListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailTemplate> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailTemplate>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailTemplate>>(
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

    public EmailTemplateListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailTemplateListPageResponse (
        EmailTemplateListPageResponse emailTemplateListPageResponse
    ) : base(emailTemplateListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailTemplateListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailTemplateListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailTemplateListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailTemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailTemplateListPageResponseFromRaw : IFromRawJson<EmailTemplateListPageResponse>
{
    /// <inheritdoc/>
    public EmailTemplateListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailTemplateListPageResponse.FromRawUnchecked(rawData);
}