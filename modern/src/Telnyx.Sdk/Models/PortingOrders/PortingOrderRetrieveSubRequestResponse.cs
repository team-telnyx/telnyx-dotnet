using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderRetrieveSubRequestResponse, PortingOrderRetrieveSubRequestResponseFromRaw>))]
public sealed record class PortingOrderRetrieveSubRequestResponse : JsonModel
{
    public PortingOrderRetrieveSubRequestResponseData? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderRetrieveSubRequestResponseData>(
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

    public PortingOrderRetrieveSubRequestResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRetrieveSubRequestResponse (
        PortingOrderRetrieveSubRequestResponse portingOrderRetrieveSubRequestResponse
    ) : base(portingOrderRetrieveSubRequestResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRetrieveSubRequestResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRetrieveSubRequestResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRetrieveSubRequestResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderRetrieveSubRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderRetrieveSubRequestResponseFromRaw : IFromRawJson<PortingOrderRetrieveSubRequestResponse>
{
    /// <inheritdoc/>
    public PortingOrderRetrieveSubRequestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRetrieveSubRequestResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PortingOrderRetrieveSubRequestResponseData, PortingOrderRetrieveSubRequestResponseDataFromRaw>))]
public sealed record class PortingOrderRetrieveSubRequestResponseData : JsonModel
{
    /// <summary>
    /// Identifies the Port Request associated with the Porting Order
    /// </summary>
    public string? PortRequestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "port_request_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("port_request_id", value);
        }
    }

    /// <summary>
    /// Identifies the Sub Request associated with the Porting Order
    /// </summary>
    public string? SubRequestID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sub_request_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sub_request_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PortRequestID;
        _ = this.SubRequestID;
    }

    public PortingOrderRetrieveSubRequestResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderRetrieveSubRequestResponseData (
        PortingOrderRetrieveSubRequestResponseData portingOrderRetrieveSubRequestResponseData
    ) : base(portingOrderRetrieveSubRequestResponseData)
    {  }
    #pragma warning restore CS8618

    public PortingOrderRetrieveSubRequestResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderRetrieveSubRequestResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderRetrieveSubRequestResponseDataFromRaw.FromRawUnchecked"/>
    public static PortingOrderRetrieveSubRequestResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingOrderRetrieveSubRequestResponseDataFromRaw : IFromRawJson<PortingOrderRetrieveSubRequestResponseData>
{
    /// <inheritdoc/>
    public PortingOrderRetrieveSubRequestResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderRetrieveSubRequestResponseData.FromRawUnchecked(rawData);
}