using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Faxes;

[JsonConverter(typeof(JsonModelConverter<FaxListPageResponse, FaxListPageResponseFromRaw>))]
public sealed record class FaxListPageResponse : JsonModel
{
    public IReadOnlyList<Fax>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Fax>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Fax>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public Metadata? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metadata>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public FaxListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxListPageResponse (FaxListPageResponse faxListPageResponse) : base(
        faxListPageResponse
    )
    {  }
    #pragma warning restore CS8618

    public FaxListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxListPageResponseFromRaw.FromRawUnchecked"/>
    public static FaxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxListPageResponseFromRaw : IFromRawJson<FaxListPageResponse>
{
    /// <inheritdoc/>
    public FaxListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxListPageResponse.FromRawUnchecked(rawData);
}