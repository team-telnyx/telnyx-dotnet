using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceRetrieveConferencesResponse, ConferenceRetrieveConferencesResponseFromRaw>))]
public sealed record class ConferenceRetrieveConferencesResponse : JsonModel
{
    public IReadOnlyList<ConferenceResource>? Conferences {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ConferenceResource>>(
                "conferences"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ConferenceResource>?>(
                "conferences",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Conferences.json?Page=0&amp;PageSize=1
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
    /// /v2/texml/Accounts/61bf923e-5e4d-4595-a110-56190ea18a1b/Conferences.json?Page=1&amp;PageSize=1&amp;PageToken=MTY4AjgyNDkwNzIxMQ
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
        foreach (var item in this.Conferences ?? [])
        {
            item.Validate();
        }
        _ = this.End;
        _ = this.FirstPageUri;
        _ = this.NextPageUri;
        _ = this.Page;
        _ = this.PageSize;
        _ = this.Start;
        _ = this.Uri;
    }

    public ConferenceRetrieveConferencesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceRetrieveConferencesResponse (
        ConferenceRetrieveConferencesResponse conferenceRetrieveConferencesResponse
    ) : base(conferenceRetrieveConferencesResponse)
    {  }
    #pragma warning restore CS8618

    public ConferenceRetrieveConferencesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceRetrieveConferencesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceRetrieveConferencesResponseFromRaw.FromRawUnchecked"/>
    public static ConferenceRetrieveConferencesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceRetrieveConferencesResponseFromRaw : IFromRawJson<ConferenceRetrieveConferencesResponse>
{
    /// <inheritdoc/>
    public ConferenceRetrieveConferencesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceRetrieveConferencesResponse.FromRawUnchecked(rawData);
}