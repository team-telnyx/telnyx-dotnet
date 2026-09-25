using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AdvancedOrders;

[JsonConverter(typeof(JsonModelConverter<AdvancedOrder, AdvancedOrderFromRaw>))]
public sealed record class AdvancedOrder : JsonModel
{
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

    public string? AreaCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "area_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("area_code", value);
        }
    }

    public string? Comments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "comments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("comments", value);
        }
    }

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

    public string? CustomerReference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("customer_reference", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, AdvancedOrderFeature>>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdvancedOrderFeature>>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AdvancedOrderFeature>>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<string>? Orders {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "orders"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "orders",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ApiEnum<string, AdvancedOrderPhoneNumberType>>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdvancedOrderPhoneNumberType>>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AdvancedOrderPhoneNumberType>>?>(
                "phone_number_type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

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
    /// The ID of the requirement group associated with this advanced order
    /// </summary>
    public string? RequirementGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_group_id", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, Status>>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, Status>>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, Status>>?>(
                "status",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AreaCode;
        _ = this.Comments;
        _ = this.CountryCode;
        _ = this.CustomerReference;
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        _ = this.Orders;
        foreach (var item in this.PhoneNumberType ?? [])
        {
            item.Validate();
        }
        _ = this.Quantity;
        _ = this.RequirementGroupID;
        foreach (var item in this.Status ?? [])
        {
            item.Validate();
        }
    }

    public AdvancedOrder ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdvancedOrder (AdvancedOrder advancedOrder) : base(advancedOrder)
    {  }
    #pragma warning restore CS8618

    public AdvancedOrder (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedOrder (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdvancedOrderFromRaw.FromRawUnchecked"/>
    public static AdvancedOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdvancedOrderFromRaw : IFromRawJson<AdvancedOrder>
{
    /// <inheritdoc/>
    public AdvancedOrder FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdvancedOrder.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdvancedOrderFeatureConverter))]
public enum AdvancedOrderFeature
{
    Sms, Mms, Voice, Fax, Emergency
}sealed class AdvancedOrderFeatureConverter : JsonConverter<AdvancedOrderFeature>
{
    public override AdvancedOrderFeature Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>AdvancedOrderFeature.Sms,
            "mms"=>AdvancedOrderFeature.Mms,
            "voice"=>AdvancedOrderFeature.Voice,
            "fax"=>AdvancedOrderFeature.Fax,
            "emergency"=>AdvancedOrderFeature.Emergency,
            _ =>(AdvancedOrderFeature)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderFeature value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderFeature.Sms=>"sms",
            AdvancedOrderFeature.Mms=>"mms",
            AdvancedOrderFeature.Voice=>"voice",
            AdvancedOrderFeature.Fax=>"fax",
            AdvancedOrderFeature.Emergency=>"emergency",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(AdvancedOrderPhoneNumberTypeConverter))]
public enum AdvancedOrderPhoneNumberType
{
    Local, Mobile, TollFree, SharedCost, National, Landline
}sealed class AdvancedOrderPhoneNumberTypeConverter : JsonConverter<AdvancedOrderPhoneNumberType>
{
    public override AdvancedOrderPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>AdvancedOrderPhoneNumberType.Local,
            "mobile"=>AdvancedOrderPhoneNumberType.Mobile,
            "toll_free"=>AdvancedOrderPhoneNumberType.TollFree,
            "shared_cost"=>AdvancedOrderPhoneNumberType.SharedCost,
            "national"=>AdvancedOrderPhoneNumberType.National,
            "landline"=>AdvancedOrderPhoneNumberType.Landline,
            _ =>(AdvancedOrderPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderPhoneNumberType.Local=>"local",
            AdvancedOrderPhoneNumberType.Mobile=>"mobile",
            AdvancedOrderPhoneNumberType.TollFree=>"toll_free",
            AdvancedOrderPhoneNumberType.SharedCost=>"shared_cost",
            AdvancedOrderPhoneNumberType.National=>"national",
            AdvancedOrderPhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Pending, Processing, Ordered
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
            "ordered"=>Status.Ordered,
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
            Status.Ordered=>"ordered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}