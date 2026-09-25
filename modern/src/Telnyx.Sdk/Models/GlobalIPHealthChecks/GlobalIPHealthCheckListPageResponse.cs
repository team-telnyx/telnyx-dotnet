using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.GlobalIPHealthChecks;

[JsonConverter(typeof(JsonModelConverter<GlobalIPHealthCheckListPageResponse, GlobalIPHealthCheckListPageResponseFromRaw>))]
public sealed record class GlobalIPHealthCheckListPageResponse : JsonModel
{
    public IReadOnlyList<GlobalIPHealthCheck>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GlobalIPHealthCheck>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<GlobalIPHealthCheck>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
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

    public GlobalIPHealthCheckListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPHealthCheckListPageResponse (
        GlobalIPHealthCheckListPageResponse globalIPHealthCheckListPageResponse
    ) : base(globalIPHealthCheckListPageResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPHealthCheckListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPHealthCheckListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPHealthCheckListPageResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPHealthCheckListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPHealthCheckListPageResponseFromRaw : IFromRawJson<GlobalIPHealthCheckListPageResponse>
{
    /// <inheritdoc/>
    public GlobalIPHealthCheckListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPHealthCheckListPageResponse.FromRawUnchecked(rawData);
}