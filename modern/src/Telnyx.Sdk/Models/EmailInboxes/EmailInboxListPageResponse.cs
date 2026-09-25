using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes;

[JsonConverter(typeof(JsonModelConverter<EmailInboxListPageResponse, EmailInboxListPageResponseFromRaw>))]
public sealed record class EmailInboxListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailInbox> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailInbox>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailInbox>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
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

    public EmailInboxListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailInboxListPageResponse (
        EmailInboxListPageResponse emailInboxListPageResponse
    ) : base(emailInboxListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailInboxListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailInboxListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailInboxListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailInboxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailInboxListPageResponseFromRaw : IFromRawJson<EmailInboxListPageResponse>
{
    /// <inheritdoc/>
    public EmailInboxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailInboxListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    /// <summary>
    /// Cursor for the next inbox page, when more results are available.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "page_cursor"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_cursor", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageSize;
        _ = this.PageCursor;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Meta (long pageSize) : this()
    { this.PageSize = pageSize; }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}