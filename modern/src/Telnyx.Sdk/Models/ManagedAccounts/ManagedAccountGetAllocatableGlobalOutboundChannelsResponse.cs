using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse, ManagedAccountGetAllocatableGlobalOutboundChannelsResponseFromRaw>))]
public sealed record class ManagedAccountGetAllocatableGlobalOutboundChannelsResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ManagedAccountGetAllocatableGlobalOutboundChannelsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountGetAllocatableGlobalOutboundChannelsResponse (
        ManagedAccountGetAllocatableGlobalOutboundChannelsResponse managedAccountGetAllocatableGlobalOutboundChannelsResponse
    ) : base(managedAccountGetAllocatableGlobalOutboundChannelsResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountGetAllocatableGlobalOutboundChannelsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountGetAllocatableGlobalOutboundChannelsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountGetAllocatableGlobalOutboundChannelsResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountGetAllocatableGlobalOutboundChannelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountGetAllocatableGlobalOutboundChannelsResponseFromRaw : IFromRawJson<ManagedAccountGetAllocatableGlobalOutboundChannelsResponse>
{
    /// <inheritdoc/>
    public ManagedAccountGetAllocatableGlobalOutboundChannelsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountGetAllocatableGlobalOutboundChannelsResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The total amount of allocatable global outbound channels available to the
    /// authenticated manager. Will be 0 if the feature is not enabled for their account.
    /// </summary>
    public long? AllocatableGlobalOutboundChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "allocatable_global_outbound_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("allocatable_global_outbound_channels", value);
        }
    }

    /// <summary>
    /// Boolean value that indicates if the managed account is able to have custom
    /// pricing set for it or not. If false, uses the pricing of the manager account.
    /// Defaults to false. This value may be changed, but there may be time lag between
    /// when the value is changed and pricing changes take effect.
    /// </summary>
    public bool? ManagedAccountAllowCustomPricing {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "managed_account_allow_custom_pricing"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("managed_account_allow_custom_pricing", value);
        }
    }

    /// <summary>
    /// The type of the data contained in this record.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// The total number of allocatable global outbound channels currently allocated
    /// across all managed accounts for the authenticated user. This includes any
    /// amount of channels allocated by default at managed account creation time.
    /// Will be 0 if the feature is not enabled for their account.
    /// </summary>
    public long? TotalGlobalChannelsAllocated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "total_global_channels_allocated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("total_global_channels_allocated", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllocatableGlobalOutboundChannels;
        _ = this.ManagedAccountAllowCustomPricing;
        _ = this.RecordType;
        _ = this.TotalGlobalChannelsAllocated;
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