using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderUpdateResponse, PortingOrderUpdateResponseFromRaw>))]
public sealed record class PortingOrderUpdateResponse : JsonModel
{
    public PortingOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrder>(
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

    public PortingOrderUpdateResponseMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PortingOrderUpdateResponseMeta>(
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
        this.Data?.Validate();
        this.Meta?.Validate();
    }

    public PortingOrderUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderUpdateResponse (
        PortingOrderUpdateResponse portingOrderUpdateResponse
    ) : base(portingOrderUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public PortingOrderUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderUpdateResponseFromRaw.FromRawUnchecked"/>
    public static PortingOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderUpdateResponseFromRaw : IFromRawJson<PortingOrderUpdateResponse>
{
    /// <inheritdoc/>
    public PortingOrderUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderUpdateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<PortingOrderUpdateResponseMeta, PortingOrderUpdateResponseMetaFromRaw>))]
public sealed record class PortingOrderUpdateResponseMeta : JsonModel
{
    /// <summary>
    /// Link to list all phone numbers
    /// </summary>
    public string? PhoneNumbersUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_numbers_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_numbers_url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.PhoneNumbersUrl; }

    public PortingOrderUpdateResponseMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderUpdateResponseMeta (
        PortingOrderUpdateResponseMeta portingOrderUpdateResponseMeta
    ) : base(portingOrderUpdateResponseMeta)
    {  }
    #pragma warning restore CS8618

    public PortingOrderUpdateResponseMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderUpdateResponseMeta (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderUpdateResponseMetaFromRaw.FromRawUnchecked"/>
    public static PortingOrderUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PortingOrderUpdateResponseMetaFromRaw : IFromRawJson<PortingOrderUpdateResponseMeta>
{
    /// <inheritdoc/>
    public PortingOrderUpdateResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderUpdateResponseMeta.FromRawUnchecked(rawData);
}