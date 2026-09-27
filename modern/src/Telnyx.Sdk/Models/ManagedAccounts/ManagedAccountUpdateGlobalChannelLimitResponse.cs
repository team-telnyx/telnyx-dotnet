using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountUpdateGlobalChannelLimitResponse, ManagedAccountUpdateGlobalChannelLimitResponseFromRaw>))]
public sealed record class ManagedAccountUpdateGlobalChannelLimitResponse : JsonModel
{
    public ManagedAccountUpdateGlobalChannelLimitResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ManagedAccountUpdateGlobalChannelLimitResponseData>(
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

    public ManagedAccountUpdateGlobalChannelLimitResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountUpdateGlobalChannelLimitResponse (
        ManagedAccountUpdateGlobalChannelLimitResponse managedAccountUpdateGlobalChannelLimitResponse
    ) : base(managedAccountUpdateGlobalChannelLimitResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountUpdateGlobalChannelLimitResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountUpdateGlobalChannelLimitResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountUpdateGlobalChannelLimitResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountUpdateGlobalChannelLimitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountUpdateGlobalChannelLimitResponseFromRaw : IFromRawJson<ManagedAccountUpdateGlobalChannelLimitResponse>
{
    /// <inheritdoc/>
    public ManagedAccountUpdateGlobalChannelLimitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountUpdateGlobalChannelLimitResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ManagedAccountUpdateGlobalChannelLimitResponseData, ManagedAccountUpdateGlobalChannelLimitResponseDataFromRaw>))]
public sealed record class ManagedAccountUpdateGlobalChannelLimitResponseData : JsonModel
{
    /// <summary>
    /// The user ID of the managed account.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// Integer value that indicates the number of allocatable global outbound channels
    /// that are allocated to the managed account. If the value is 0 then the account
    /// will have no usable channels and will not be able to perform outbound calling.
    /// </summary>
    public long? ChannelLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "channel_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("channel_limit", value);
        }
    }

    /// <summary>
    /// The email of the managed account.
    /// </summary>
    public string? Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The user ID of the manager of the account.
    /// </summary>
    public string? ManagerAccountID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "manager_account_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("manager_account_id", value);
        }
    }

    /// <summary>
    /// The name of the type of data in the response.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ChannelLimit;
        _ = this.Email;
        _ = this.ManagerAccountID;
        _ = this.RecordType;
    }

    public ManagedAccountUpdateGlobalChannelLimitResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountUpdateGlobalChannelLimitResponseData (
        ManagedAccountUpdateGlobalChannelLimitResponseData managedAccountUpdateGlobalChannelLimitResponseData
    ) : base(managedAccountUpdateGlobalChannelLimitResponseData)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountUpdateGlobalChannelLimitResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountUpdateGlobalChannelLimitResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountUpdateGlobalChannelLimitResponseDataFromRaw.FromRawUnchecked"/>
    public static ManagedAccountUpdateGlobalChannelLimitResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ManagedAccountUpdateGlobalChannelLimitResponseDataFromRaw : IFromRawJson<ManagedAccountUpdateGlobalChannelLimitResponseData>
{
    /// <inheritdoc/>
    public ManagedAccountUpdateGlobalChannelLimitResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountUpdateGlobalChannelLimitResponseData.FromRawUnchecked(rawData);
}