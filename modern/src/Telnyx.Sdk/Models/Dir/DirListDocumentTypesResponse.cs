using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using CallReasons = Telnyx.Sdk.Models.CallReasons;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<DirListDocumentTypesResponse, DirListDocumentTypesResponseFromRaw>))]
public sealed record class DirListDocumentTypesResponse : JsonModel
{
    public required IReadOnlyList<Data> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Data>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// JSON:API pagination metadata returned with every paginated list response.
    /// Page numbering is 1-based. `page_size` reports the number of items actually
    /// returned in `data` for this page; the requested size is taken from the `page[size]`
    /// query parameter.
    /// </summary>
    public required CallReasons::BrandedCallingPaginationMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CallReasons::BrandedCallingPaginationMeta>(
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

    public DirListDocumentTypesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirListDocumentTypesResponse (
        DirListDocumentTypesResponse dirListDocumentTypesResponse
    ) : base(dirListDocumentTypesResponse)
    {  }
    #pragma warning restore CS8618

    public DirListDocumentTypesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirListDocumentTypesResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirListDocumentTypesResponseFromRaw.FromRawUnchecked"/>
    public static DirListDocumentTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirListDocumentTypesResponseFromRaw : IFromRawJson<DirListDocumentTypesResponse>
{
    /// <inheritdoc/>
    public DirListDocumentTypesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirListDocumentTypesResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Single supported document type.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <summary>
    /// Stable identifier passed to `Document.document_type`.
    /// </summary>
    public string? ShortName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "short_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("short_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.ShortName;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}