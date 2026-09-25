using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections;

[JsonConverter(typeof(JsonModelConverter<ExternalConnectionUpdateLocationResponse, ExternalConnectionUpdateLocationResponseFromRaw>))]
public sealed record class ExternalConnectionUpdateLocationResponse : JsonModel
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

    public ExternalConnectionUpdateLocationResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalConnectionUpdateLocationResponse (
        ExternalConnectionUpdateLocationResponse externalConnectionUpdateLocationResponse
    ) : base(externalConnectionUpdateLocationResponse)
    {  }
    #pragma warning restore CS8618

    public ExternalConnectionUpdateLocationResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalConnectionUpdateLocationResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExternalConnectionUpdateLocationResponseFromRaw.FromRawUnchecked"/>
    public static ExternalConnectionUpdateLocationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExternalConnectionUpdateLocationResponseFromRaw : IFromRawJson<ExternalConnectionUpdateLocationResponse>
{
    /// <inheritdoc/>
    public ExternalConnectionUpdateLocationResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExternalConnectionUpdateLocationResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public bool? AcceptedAddressSuggestions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "accepted_address_suggestions"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("accepted_address_suggestions", value);
        }
    }

    public string? LocationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("location_id", value);
        }
    }

    public string? StaticEmergencyAddressID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "static_emergency_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("static_emergency_address_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AcceptedAddressSuggestions;
        _ = this.LocationID;
        _ = this.StaticEmergencyAddressID;
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