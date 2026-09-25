using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IntegrationSecrets;

[JsonConverter(typeof(JsonModelConverter<IntegrationSecretListPageResponse, IntegrationSecretListPageResponseFromRaw>))]
public sealed record class IntegrationSecretListPageResponse : JsonModel
{
    public required IReadOnlyList<IntegrationSecret> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<IntegrationSecret>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<IntegrationSecret>>(
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

    public IntegrationSecretListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationSecretListPageResponse (
        IntegrationSecretListPageResponse integrationSecretListPageResponse
    ) : base(integrationSecretListPageResponse)
    {  }
    #pragma warning restore CS8618

    public IntegrationSecretListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationSecretListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationSecretListPageResponseFromRaw.FromRawUnchecked"/>
    public static IntegrationSecretListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntegrationSecretListPageResponseFromRaw : IFromRawJson<IntegrationSecretListPageResponse>
{
    /// <inheritdoc/>
    public IntegrationSecretListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntegrationSecretListPageResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required long PageNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_number"
            );
        }
        init { this._rawData.Set("page_number", value); }
    }

    public required long PageSize {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "page_size"
            );
        }
        init { this._rawData.Set("page_size", value); }
    }

    public required long TotalPages {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_pages"
            );
        }
        init { this._rawData.Set("total_pages", value); }
    }

    public required long TotalResults {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total_results"
            );
        }
        init { this._rawData.Set("total_results", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PageNumber;
        _ = this.PageSize;
        _ = this.TotalPages;
        _ = this.TotalResults;
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