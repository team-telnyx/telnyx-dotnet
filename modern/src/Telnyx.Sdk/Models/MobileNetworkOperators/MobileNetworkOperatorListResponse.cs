using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobileNetworkOperators;

[JsonConverter(typeof(JsonModelConverter<MobileNetworkOperatorListResponse, MobileNetworkOperatorListResponseFromRaw>))]
public sealed record class MobileNetworkOperatorListResponse : JsonModel
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
    /// The mobile operator two-character (ISO 3166-1 alpha-2) origin country code.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    /// <summary>
    /// MCC stands for Mobile Country Code. It's a three decimal digit that identifies
    /// a country.&lt;br/&gt;&lt;br/&gt; This code is commonly seen joined with a
    /// Mobile Network Code (MNC) in a tuple that allows identifying a carrier known
    /// as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? Mcc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mcc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mcc", value);
        }
    }

    /// <summary>
    /// MNC stands for Mobile Network Code. It's a two to three decimal digits that
    /// identify a network.&lt;br/&gt;&lt;br/&gt;  This code is commonly seen joined
    /// with a Mobile Country Code (MCC) in a tuple that allows identifying a carrier
    /// known as PLMN (Public Land Mobile Network) code.
    /// </summary>
    public string? Mnc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "mnc"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("mnc", value);
        }
    }

    /// <summary>
    /// The network operator name.
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
    /// Indicate whether the mobile network operator can be set as preferred in the
    /// Network Preferences API.
    /// </summary>
    public bool? NetworkPreferencesEnabled {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "network_preferences_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("network_preferences_enabled", value);
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
    /// TADIG stands for Transferred Account Data Interchange Group. The TADIG code
    /// is a unique identifier for network operators in GSM mobile networks.
    /// </summary>
    public string? Tadig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tadig"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tadig", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CountryCode;
        _ = this.Mcc;
        _ = this.Mnc;
        _ = this.Name;
        _ = this.NetworkPreferencesEnabled;
        _ = this.RecordType;
        _ = this.Tadig;
    }

    public MobileNetworkOperatorListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MobileNetworkOperatorListResponse (
        MobileNetworkOperatorListResponse mobileNetworkOperatorListResponse
    ) : base(mobileNetworkOperatorListResponse)
    {  }
    #pragma warning restore CS8618

    public MobileNetworkOperatorListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MobileNetworkOperatorListResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MobileNetworkOperatorListResponseFromRaw.FromRawUnchecked"/>
    public static MobileNetworkOperatorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MobileNetworkOperatorListResponseFromRaw : IFromRawJson<MobileNetworkOperatorListResponse>
{
    /// <inheritdoc/>
    public MobileNetworkOperatorListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MobileNetworkOperatorListResponse.FromRawUnchecked(rawData);
}