using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailMessages.Recipients;

[JsonConverter(typeof(JsonModelConverter<RecipientListPageResponse, RecipientListPageResponseFromRaw>))]
public sealed record class RecipientListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailRecipient> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailRecipient>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailRecipient>>(
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

    public RecipientListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RecipientListPageResponse (
        RecipientListPageResponse recipientListPageResponse
    ) : base(recipientListPageResponse)
    {  }
    #pragma warning restore CS8618

    public RecipientListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RecipientListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RecipientListPageResponseFromRaw.FromRawUnchecked"/>
    public static RecipientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RecipientListPageResponseFromRaw : IFromRawJson<RecipientListPageResponse>
{
    /// <inheritdoc/>
    public RecipientListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RecipientListPageResponse.FromRawUnchecked(rawData);
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
    /// Cursor for the next page. Absent when there are no more results.
    /// </summary>
    public string? PageCursor {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "page_cursor"
            );
        }
        init { this._rawData.Set("page_cursor", value); }
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