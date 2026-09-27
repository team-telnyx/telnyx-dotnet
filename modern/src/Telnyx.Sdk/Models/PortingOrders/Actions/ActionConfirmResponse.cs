using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionConfirmResponse, ActionConfirmResponseFromRaw>))]
public sealed record class ActionConfirmResponse : JsonModel
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

    public ActionConfirmResponseMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ActionConfirmResponseMeta>(
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

    public ActionConfirmResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionConfirmResponse (
        ActionConfirmResponse actionConfirmResponse
    ) : base(actionConfirmResponse)
    {  }
    #pragma warning restore CS8618

    public ActionConfirmResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionConfirmResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionConfirmResponseFromRaw.FromRawUnchecked"/>
    public static ActionConfirmResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionConfirmResponseFromRaw : IFromRawJson<ActionConfirmResponse>
{
    /// <inheritdoc/>
    public ActionConfirmResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionConfirmResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ActionConfirmResponseMeta, ActionConfirmResponseMetaFromRaw>))]
public sealed record class ActionConfirmResponseMeta : JsonModel
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

    public ActionConfirmResponseMeta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionConfirmResponseMeta (
        ActionConfirmResponseMeta actionConfirmResponseMeta
    ) : base(actionConfirmResponseMeta)
    {  }
    #pragma warning restore CS8618

    public ActionConfirmResponseMeta (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionConfirmResponseMeta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionConfirmResponseMetaFromRaw.FromRawUnchecked"/>
    public static ActionConfirmResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionConfirmResponseMetaFromRaw : IFromRawJson<ActionConfirmResponseMeta>
{
    /// <inheritdoc/>
    public ActionConfirmResponseMeta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionConfirmResponseMeta.FromRawUnchecked(rawData);
}