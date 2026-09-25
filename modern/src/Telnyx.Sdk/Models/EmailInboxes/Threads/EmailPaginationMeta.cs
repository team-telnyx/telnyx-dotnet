using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads;

[JsonConverter(typeof(JsonModelConverter<EmailPaginationMeta, EmailPaginationMetaFromRaw>))]
public sealed record class EmailPaginationMeta : JsonModel
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
    /// Cursor for the next page, when more results are available.
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

    public EmailPaginationMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailPaginationMeta (EmailPaginationMeta emailPaginationMeta) : base(
        emailPaginationMeta
    )
    {  }
    #pragma warning restore CS8618

    public EmailPaginationMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailPaginationMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailPaginationMetaFromRaw.FromRawUnchecked"/>
    public static EmailPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailPaginationMeta (long pageSize) : this()
    { this.PageSize = pageSize; }
}

class EmailPaginationMetaFromRaw : IFromRawJson<EmailPaginationMeta>
{
    /// <inheritdoc/>
    public EmailPaginationMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailPaginationMeta.FromRawUnchecked(rawData);
}