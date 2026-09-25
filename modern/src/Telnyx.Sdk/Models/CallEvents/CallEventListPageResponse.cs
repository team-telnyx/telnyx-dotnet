using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.CallEvents;

[JsonConverter(typeof(JsonModelConverter<CallEventListPageResponse, CallEventListPageResponseFromRaw>))]
public sealed record class CallEventListPageResponse : JsonModel
{
    public IReadOnlyList<CallEventListResponse>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<CallEventListResponse>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<CallEventListResponse>?>(
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

    public CallEventListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallEventListPageResponse (
        CallEventListPageResponse callEventListPageResponse
    ) : base(callEventListPageResponse)
    {  }
    #pragma warning restore CS8618

    public CallEventListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallEventListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallEventListPageResponseFromRaw.FromRawUnchecked"/>
    public static CallEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallEventListPageResponseFromRaw : IFromRawJson<CallEventListPageResponse>
{
    /// <inheritdoc/>
    public CallEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallEventListPageResponse.FromRawUnchecked(rawData);
}