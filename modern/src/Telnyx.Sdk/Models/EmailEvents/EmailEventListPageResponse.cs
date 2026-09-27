using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailEvents;

[JsonConverter(typeof(JsonModelConverter<EmailEventListPageResponse, EmailEventListPageResponseFromRaw>))]
public sealed record class EmailEventListPageResponse : JsonModel
{
    public required IReadOnlyList<EmailEventListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailEventListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailEventListResponse>>(
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

    public EmailEventListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailEventListPageResponse (
        EmailEventListPageResponse emailEventListPageResponse
    ) : base(emailEventListPageResponse)
    {  }
    #pragma warning restore CS8618

    public EmailEventListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailEventListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailEventListPageResponseFromRaw.FromRawUnchecked"/>
    public static EmailEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailEventListPageResponseFromRaw : IFromRawJson<EmailEventListPageResponse>
{
    /// <inheritdoc/>
    public EmailEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailEventListPageResponse.FromRawUnchecked(rawData);
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

    public required TimeRange TimeRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TimeRange>(
                "time_range"
            );
        }
        init { this._rawData.Set("time_range", value); }
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
        this.TimeRange.Validate();
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
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}