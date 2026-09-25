using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Fqdns;

[JsonConverter(typeof(JsonModelConverter<FqdnListPageResponse, FqdnListPageResponseFromRaw>))]
public sealed record class FqdnListPageResponse : JsonModel
{
    public IReadOnlyList<Fqdn>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Fqdn>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Fqdn>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ConnectionsPaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConnectionsPaginationMeta>(
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

    public FqdnListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnListPageResponse (
        FqdnListPageResponse fqdnListPageResponse
    ) : base(fqdnListPageResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnListPageResponseFromRaw.FromRawUnchecked"/>
    public static FqdnListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnListPageResponseFromRaw : IFromRawJson<FqdnListPageResponse>
{
    /// <inheritdoc/>
    public FqdnListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnListPageResponse.FromRawUnchecked(rawData);
}