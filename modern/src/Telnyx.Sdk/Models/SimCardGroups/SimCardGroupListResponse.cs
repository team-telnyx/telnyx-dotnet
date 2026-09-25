using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCardGroups;

[JsonConverter(typeof(JsonModelConverter<SimCardGroupListResponse, SimCardGroupListResponseFromRaw>))]
public sealed record class SimCardGroupListResponse : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// Represents the amount of data consumed.
    /// </summary>
    public ConsumedData? ConsumedData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConsumedData>(
                "consumed_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("consumed_data", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Upper limit on the amount of data the SIM cards, within the group, can use.
    /// </summary>
    public SimCardGroupListResponseDataLimit? DataLimit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardGroupListResponseDataLimit>(
                "data_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data_limit", value);
        }
    }

    /// <summary>
    /// Indicates whether the SIM card group is the users default group.&lt;br/&gt;The
    /// default group is created for the user and can not be removed.
    /// </summary>
    public bool? Default {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "default"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default", value);
        }
    }

    /// <summary>
    /// A user friendly name for the SIM card group.
    /// </summary>
    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <summary>
    /// The identification of the related Private Wireless Gateway resource.
    /// </summary>
    public string? PrivateWirelessGatewayID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "private_wireless_gateway_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("private_wireless_gateway_id", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
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
    /// The number of SIM cards associated with the group.
    /// </summary>
    public long? SimCardCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "sim_card_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_count", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <summary>
    /// The identification of the related Wireless Blocklist resource.
    /// </summary>
    public string? WirelessBlocklistID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireless_blocklist_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireless_blocklist_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.ConsumedData?.Validate();
        _ = this.CreatedAt;
        this.DataLimit?.Validate();
        _ = this.Default;
        _ = this.Name;
        _ = this.PrivateWirelessGatewayID;
        _ = this.RecordType;
        _ = this.SimCardCount;
        _ = this.UpdatedAt;
        _ = this.WirelessBlocklistID;
    }

    public SimCardGroupListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupListResponse (
        SimCardGroupListResponse simCardGroupListResponse
    ) : base(simCardGroupListResponse)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupListResponseFromRaw.FromRawUnchecked"/>
    public static SimCardGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupListResponseFromRaw : IFromRawJson<SimCardGroupListResponse>
{
    /// <inheritdoc/>
    public SimCardGroupListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Upper limit on the amount of data the SIM cards, within the group, can use.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardGroupListResponseDataLimit, SimCardGroupListResponseDataLimitFromRaw>))]
public sealed record class SimCardGroupListResponseDataLimit : JsonModel
{
    public string? Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "amount"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("amount", value);
        }
    }

    public string? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Unit;
    }

    public SimCardGroupListResponseDataLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupListResponseDataLimit (
        SimCardGroupListResponseDataLimit simCardGroupListResponseDataLimit
    ) : base(simCardGroupListResponseDataLimit)
    {  }
    #pragma warning restore CS8618

    public SimCardGroupListResponseDataLimit (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupListResponseDataLimit (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupListResponseDataLimitFromRaw.FromRawUnchecked"/>
    public static SimCardGroupListResponseDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardGroupListResponseDataLimitFromRaw : IFromRawJson<SimCardGroupListResponseDataLimit>
{
    /// <inheritdoc/>
    public SimCardGroupListResponseDataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupListResponseDataLimit.FromRawUnchecked(rawData);
}