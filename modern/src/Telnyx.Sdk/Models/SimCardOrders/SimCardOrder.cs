using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCardOrders;

[JsonConverter(typeof(JsonModelConverter<SimCardOrder, SimCardOrderFromRaw>))]
public sealed record class SimCardOrder : JsonModel
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
    /// An object representing the total cost of the order.
    /// </summary>
    public Cost? Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Cost>(
                "cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("cost", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was last created.
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
    /// An object representing the address information from when the order was submitted.
    /// </summary>
    public OrderAddress? OrderAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OrderAddress>(
                "order_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("order_address", value);
        }
    }

    /// <summary>
    /// The amount of SIM cards requested in the SIM card order.
    /// </summary>
    public long? Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "quantity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quantity", value);
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
    /// The current status of the SIM Card order.&lt;ul&gt; &lt;li&gt;&lt;code&gt;pending&lt;/code&gt;
    /// - the order is waiting to be processed.&lt;/li&gt; &lt;li&gt;&lt;code&gt;processing&lt;/code&gt;
    /// - the order is currently being processed.&lt;/li&gt; &lt;li&gt;&lt;code&gt;ready_to_ship&lt;/code&gt;
    /// - the order is ready to be shipped to the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt;
    /// &lt;li&gt;&lt;code&gt;shipped&lt;/code&gt; - the order was shipped and is
    /// on its way to be delivered to the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt;
    /// &lt;li&gt;&lt;code&gt;delivered&lt;/code&gt; - the order was delivered to
    /// the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt; &lt;li&gt;&lt;code&gt;canceled&lt;/code&gt;
    /// - the order was canceled.&lt;/li&gt; &lt;/ul&gt;
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// The URL used to get tracking information about the order.
    /// </summary>
    public string? TrackingUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tracking_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tracking_url", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was last updated.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Cost?.Validate();
        _ = this.CreatedAt;
        this.OrderAddress?.Validate();
        _ = this.Quantity;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.TrackingUrl;
        _ = this.UpdatedAt;
    }

    public SimCardOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardOrder (SimCardOrder simCardOrder) : base(simCardOrder)
    {  }
    #pragma warning restore CS8618

    public SimCardOrder (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardOrderFromRaw.FromRawUnchecked"/>
    public static SimCardOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardOrderFromRaw : IFromRawJson<SimCardOrder>
{
    /// <inheritdoc/>
    public SimCardOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardOrder.FromRawUnchecked(rawData);
}

/// <summary>
/// An object representing the total cost of the order.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Cost, CostFromRaw>))]
public sealed record class Cost : JsonModel
{
    /// <summary>
    /// A string representing the cost amount.
    /// </summary>
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

    /// <summary>
    /// Filter by ISO 4217 currency string.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Currency;
    }

    public Cost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Cost (Cost cost) : base(cost)
    {  }
    #pragma warning restore CS8618

    public Cost (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Cost (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CostFromRaw.FromRawUnchecked"/>
    public static Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CostFromRaw : IFromRawJson<Cost>
{
    /// <inheritdoc/>
    public Cost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Cost.FromRawUnchecked(rawData);
}/// <summary>
/// An object representing the address information from when the order was submitted.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OrderAddress, OrderAddressFromRaw>))]
public sealed record class OrderAddress : JsonModel
{
    /// <summary>
    /// Uniquely identifies the address for the order.
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
    /// State or province where the address is located.
    /// </summary>
    public string? AdministrativeArea {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "administrative_area"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("administrative_area", value);
        }
    }

    /// <summary>
    /// The name of the business where the address is located.
    /// </summary>
    public string? BusinessName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "business_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("business_name", value);
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
    /// Supplemental field for address information.
    /// </summary>
    public string? ExtendedAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "extended_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("extended_address", value);
        }
    }

    /// <summary>
    /// The first name of the shipping recipient.
    /// </summary>
    public string? FirstName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "first_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("first_name", value);
        }
    }

    /// <summary>
    /// The last name of the shipping recipient.
    /// </summary>
    public string? LastName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("last_name", value);
        }
    }

    /// <summary>
    /// The name of the city where the address is located.
    /// </summary>
    public string? Locality {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "locality"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    /// <summary>
    /// Postal code for the address.
    /// </summary>
    public string? PostalCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postal_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postal_code", value);
        }
    }

    /// <summary>
    /// The name of the street where the address is located.
    /// </summary>
    public string? StreetAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street_address"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street_address", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AdministrativeArea;
        _ = this.BusinessName;
        _ = this.CountryCode;
        _ = this.ExtendedAddress;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.Locality;
        _ = this.PostalCode;
        _ = this.StreetAddress;
    }

    public OrderAddress ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OrderAddress (OrderAddress orderAddress) : base(orderAddress)
    {  }
    #pragma warning restore CS8618

    public OrderAddress (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OrderAddress (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrderAddressFromRaw.FromRawUnchecked"/>
    public static OrderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OrderAddressFromRaw : IFromRawJson<OrderAddress>
{
    /// <inheritdoc/>
    public OrderAddress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OrderAddress.FromRawUnchecked(rawData);
}/// <summary>
/// The current status of the SIM Card order.&lt;ul&gt; &lt;li&gt;&lt;code&gt;pending&lt;/code&gt;
/// - the order is waiting to be processed.&lt;/li&gt; &lt;li&gt;&lt;code&gt;processing&lt;/code&gt;
/// - the order is currently being processed.&lt;/li&gt; &lt;li&gt;&lt;code&gt;ready_to_ship&lt;/code&gt;
/// - the order is ready to be shipped to the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt;
/// &lt;li&gt;&lt;code&gt;shipped&lt;/code&gt; - the order was shipped and is on its
/// way to be delivered to the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt; &lt;li&gt;&lt;code&gt;delivered&lt;/code&gt;
/// - the order was delivered to the specified &lt;b&gt;address&lt;/b&gt;.&lt;/li&gt;
/// &lt;li&gt;&lt;code&gt;canceled&lt;/code&gt; - the order was canceled.&lt;/li&gt; &lt;/ul&gt;
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Processing, ReadyToShip, Shipped, Delivered, Canceled
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>Status.Pending,
            "processing"=>Status.Processing,
            "ready_to_ship"=>Status.ReadyToShip,
            "shipped"=>Status.Shipped,
            "delivered"=>Status.Delivered,
            "canceled"=>Status.Canceled,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Pending=>"pending",
            Status.Processing=>"processing",
            Status.ReadyToShip=>"ready_to_ship",
            Status.Shipped=>"shipped",
            Status.Delivered=>"delivered",
            Status.Canceled=>"canceled",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}