using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationListPageResponse, CallControlApplicationListPageResponseFromRaw>))]
public sealed record class CallControlApplicationListPageResponse : JsonModel
{
    public IReadOnlyList<CallControlApplication>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallControlApplication>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallControlApplication>?>(
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

    public CallControlApplicationListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationListPageResponse (
        CallControlApplicationListPageResponse callControlApplicationListPageResponse
    ) : base(callControlApplicationListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationListPageResponseFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationListPageResponseFromRaw : IFromRawJson<CallControlApplicationListPageResponse>
{
    /// <inheritdoc/>
    public CallControlApplicationListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationListPageResponse.FromRawUnchecked(rawData);
}