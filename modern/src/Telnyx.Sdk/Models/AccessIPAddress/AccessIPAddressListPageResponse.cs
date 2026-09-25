using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AccessIPAddress;

[JsonConverter(typeof(JsonModelConverter<AccessIPAddressListPageResponse, AccessIPAddressListPageResponseFromRaw>))]
public sealed record class AccessIPAddressListPageResponse : JsonModel
{
    public required IReadOnlyList<AccessIPAddressResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AccessIPAddressResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<AccessIPAddressResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required PaginationMetaCloudflareIPListSync Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PaginationMetaCloudflareIPListSync>(
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

    public AccessIPAddressListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPAddressListPageResponse (
        AccessIPAddressListPageResponse accessIPAddressListPageResponse
    ) : base(accessIPAddressListPageResponse)
    {  }
    #pragma warning restore CS8618

    public AccessIPAddressListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPAddressListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AccessIPAddressListPageResponseFromRaw.FromRawUnchecked"/>
    public static AccessIPAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AccessIPAddressListPageResponseFromRaw : IFromRawJson<AccessIPAddressListPageResponse>
{
    /// <inheritdoc/>
    public AccessIPAddressListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AccessIPAddressListPageResponse.FromRawUnchecked(rawData);
}