using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.ActivationJobs;

[JsonConverter(typeof(JsonModelConverter<ActivationJobListPageResponse, ActivationJobListPageResponseFromRaw>))]
public sealed record class ActivationJobListPageResponse : JsonModel
{
    public IReadOnlyList<PortingOrdersActivationJob>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrdersActivationJob>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrdersActivationJob>?>(
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

    public ActivationJobListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationJobListPageResponse (
        ActivationJobListPageResponse activationJobListPageResponse
    ) : base(activationJobListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ActivationJobListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationJobListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationJobListPageResponseFromRaw.FromRawUnchecked"/>
    public static ActivationJobListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActivationJobListPageResponseFromRaw : IFromRawJson<ActivationJobListPageResponse>
{
    /// <inheritdoc/>
    public ActivationJobListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationJobListPageResponse.FromRawUnchecked(rawData);
}