using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrderMisc, PortingOrderMiscFromRaw>))]
public sealed record class PortingOrderMisc : JsonModel
{
    /// <summary>
    /// New billing phone number for the remaining numbers. Used in case the current
    /// billing phone number is being ported to Telnyx. This will be set on your account
    /// with your current service provider and should be one of the numbers remaining
    /// on that account.
    /// </summary>
    public string? NewBillingPhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "new_billing_phone_number"
            );
        }
        init { this._rawData.Set("new_billing_phone_number", value); }
    }

    /// <summary>
    /// Remaining numbers can be either kept with their current service provider or
    /// disconnected. 'new_billing_telephone_number' is required when 'remaining_numbers_action'
    /// is 'keep'.
    /// </summary>
    public ApiEnum<string, RemainingNumbersAction>? RemainingNumbersAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, RemainingNumbersAction>>(
                "remaining_numbers_action"
            );
        }
        init { this._rawData.Set("remaining_numbers_action", value); }
    }

    /// <summary>
    /// A port can be either 'full' or 'partial'. When type is 'full' the other attributes
    /// should be omitted.
    /// </summary>
    public ApiEnum<string, PortingOrderType>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, PortingOrderType>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NewBillingPhoneNumber;
        this.RemainingNumbersAction?.Validate();
        this.Type?.Validate();
    }

    public PortingOrderMisc ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderMisc (PortingOrderMisc portingOrderMisc) : base(
        portingOrderMisc
    )
    {  }
    #pragma warning restore CS8618

    public PortingOrderMisc (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderMisc (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderMiscFromRaw.FromRawUnchecked"/>
    public static PortingOrderMisc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderMiscFromRaw : IFromRawJson<PortingOrderMisc>
{
    /// <inheritdoc/>
    public PortingOrderMisc FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderMisc.FromRawUnchecked(rawData);
}

/// <summary>
/// Remaining numbers can be either kept with their current service provider or disconnected.
/// 'new_billing_telephone_number' is required when 'remaining_numbers_action' is 'keep'.
/// </summary>
[JsonConverter(typeof(RemainingNumbersActionConverter))]
public enum RemainingNumbersAction
{
    Keep, Disconnect
}sealed class RemainingNumbersActionConverter : JsonConverter<RemainingNumbersAction>
{
    public override RemainingNumbersAction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "keep"=>RemainingNumbersAction.Keep,
            "disconnect"=>RemainingNumbersAction.Disconnect,
            _ =>(RemainingNumbersAction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        RemainingNumbersAction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RemainingNumbersAction.Keep=>"keep",
            RemainingNumbersAction.Disconnect=>"disconnect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}