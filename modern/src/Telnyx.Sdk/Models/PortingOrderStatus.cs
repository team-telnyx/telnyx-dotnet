using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models;

/// <summary>
/// Porting order status
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingOrderStatus, PortingOrderStatusFromRaw>))]
public sealed record class PortingOrderStatus : JsonModel
{
    /// <summary>
    /// A list of 0 or more details about this porting order's status
    /// </summary>
    public IReadOnlyList<PortingOrdersExceptionType>? Details {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingOrdersExceptionType>>(
                "details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingOrdersExceptionType>?>(
                "details",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The current status of the porting order
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Details ?? [])
        {
            item.Validate();
        }
        this.Value?.Validate();
    }

    public PortingOrderStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderStatus (PortingOrderStatus portingOrderStatus) : base(
        portingOrderStatus
    )
    {  }
    #pragma warning restore CS8618

    public PortingOrderStatus (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderStatusFromRaw.FromRawUnchecked"/>
    public static PortingOrderStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderStatusFromRaw : IFromRawJson<PortingOrderStatus>
{
    /// <inheritdoc/>
    public PortingOrderStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderStatus.FromRawUnchecked(rawData);
}

/// <summary>
/// The current status of the porting order
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    Draft,
    InProcess,
    Submitted,
    Exception,
    FocDateConfirmed,
    Ported,
    Cancelled,
    CancelPending
}sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft"=>Value.Draft,
            "in-process"=>Value.InProcess,
            "submitted"=>Value.Submitted,
            "exception"=>Value.Exception,
            "foc-date-confirmed"=>Value.FocDateConfirmed,
            "ported"=>Value.Ported,
            "cancelled"=>Value.Cancelled,
            "cancel-pending"=>Value.CancelPending,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.Draft=>"draft",
            Value.InProcess=>"in-process",
            Value.Submitted=>"submitted",
            Value.Exception=>"exception",
            Value.FocDateConfirmed=>"foc-date-confirmed",
            Value.Ported=>"ported",
            Value.Cancelled=>"cancelled",
            Value.CancelPending=>"cancel-pending",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}