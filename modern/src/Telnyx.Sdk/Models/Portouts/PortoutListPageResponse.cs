using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Portouts;

[JsonConverter(typeof(JsonModelConverter<PortoutListPageResponse, PortoutListPageResponseFromRaw>))]
public sealed record class PortoutListPageResponse : JsonModel
{
    public IReadOnlyList<PortoutDetails>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortoutDetails>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortoutDetails>?>(
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

    public PortoutListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortoutListPageResponse (
        PortoutListPageResponse portoutListPageResponse
    ) : base(portoutListPageResponse)
    {  }
    #pragma warning restore CS8618

    public PortoutListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortoutListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortoutListPageResponseFromRaw.FromRawUnchecked"/>
    public static PortoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortoutListPageResponseFromRaw : IFromRawJson<PortoutListPageResponse>
{
    /// <inheritdoc/>
    public PortoutListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortoutListPageResponse.FromRawUnchecked(rawData);
}