using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Calls.RecordingsJson;

[JsonConverter(typeof(JsonModelConverter<TexmlGetCallRecordingsResponseBody, TexmlGetCallRecordingsResponseBodyFromRaw>))]
public sealed record class TexmlGetCallRecordingsResponseBody : JsonModel
{
    /// <summary>
    /// The number of the last element on the page, zero-indexed.
    /// </summary>
    public long? End {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end", value);
        }
    }

    /// <summary>
    /// Relative uri to the first page of the query results
    /// </summary>
    public string? FirstPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "first_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_page_uri", value);
        }
    }

    /// <summary>
    /// Relative uri to the next page of the query results
    /// </summary>
    public string? NextPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "next_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("next_page_uri", value);
        }
    }

    /// <summary>
    /// Current page number, zero-indexed.
    /// </summary>
    public long? Page {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page", value);
        }
    }

    /// <summary>
    /// The number of items on the page
    /// </summary>
    public long? PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "page_size"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("page_size", value);
        }
    }

    /// <summary>
    /// Relative uri to the previous page of the query results
    /// </summary>
    public string? PreviousPageUri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "previous_page_uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("previous_page_uri", value);
        }
    }

    public IReadOnlyList<TexmlGetCallRecordingResponseBody>? Recordings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TexmlGetCallRecordingResponseBody>>(
                "recordings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TexmlGetCallRecordingResponseBody>?>(
                "recordings",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The number of the first element on the page, zero-indexed.
    /// </summary>
    public long? Start {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "start"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start", value);
        }
    }

    /// <summary>
    /// The URI of the current page.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.End;
        _ = this.FirstPageUri;
        _ = this.NextPageUri;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.PreviousPageUri;
        foreach (var item in this.Recordings ?? [])
        {
            item.Validate();
        }
        _ = this.Start;
        _ = this.Uri;
    }

    public TexmlGetCallRecordingsResponseBody ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlGetCallRecordingsResponseBody (
        TexmlGetCallRecordingsResponseBody texmlGetCallRecordingsResponseBody
    ) : base(texmlGetCallRecordingsResponseBody)
    {  }
    #pragma warning restore CS8618

    public TexmlGetCallRecordingsResponseBody (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlGetCallRecordingsResponseBody (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlGetCallRecordingsResponseBodyFromRaw.FromRawUnchecked"/>
    public static TexmlGetCallRecordingsResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlGetCallRecordingsResponseBodyFromRaw : IFromRawJson<TexmlGetCallRecordingsResponseBody>
{
    /// <inheritdoc/>
    public TexmlGetCallRecordingsResponseBody FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlGetCallRecordingsResponseBody.FromRawUnchecked(rawData);
}