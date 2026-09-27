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

[JsonConverter(typeof(JsonModelConverter<AdvancedOrderRequest, AdvancedOrderRequestFromRaw>))]
public sealed record class AdvancedOrderRequest : JsonModel
{
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

    public IReadOnlyList<ApiEnum<string, AdvancedOrderRequestFeature>>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdvancedOrderRequestFeature>>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ApiEnum<string, AdvancedOrderRequestFeature>>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, AdvancedOrderRequestPhoneNumberType>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AdvancedOrderRequestPhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number_type", value);
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
    /// The ID of the requirement group to associate with this advanced order
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AreaCode;
        _ = this.Comments;
        _ = this.CountryCode;
        _ = this.CustomerReference;
        foreach (var item in this.Features ?? [])
        {
            item.Validate();
        }
        this.PhoneNumberType?.Validate();
        _ = this.Quantity;
        _ = this.RequirementGroupID;
    }

    public AdvancedOrderRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdvancedOrderRequest (
        AdvancedOrderRequest advancedOrderRequest
    ) : base(advancedOrderRequest)
    {  }
    #pragma warning restore CS8618

    public AdvancedOrderRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedOrderRequest (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdvancedOrderRequestFromRaw.FromRawUnchecked"/>
    public static AdvancedOrderRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AdvancedOrderRequestFromRaw : IFromRawJson<AdvancedOrderRequest>
{
    /// <inheritdoc/>
    public AdvancedOrderRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AdvancedOrderRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AdvancedOrderRequestFeatureConverter))]
public enum AdvancedOrderRequestFeature
{
    Sms, Mms, Voice, Fax, Emergency
}sealed class AdvancedOrderRequestFeatureConverter : JsonConverter<AdvancedOrderRequestFeature>
{
    public override AdvancedOrderRequestFeature Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>AdvancedOrderRequestFeature.Sms,
            "mms"=>AdvancedOrderRequestFeature.Mms,
            "voice"=>AdvancedOrderRequestFeature.Voice,
            "fax"=>AdvancedOrderRequestFeature.Fax,
            "emergency"=>AdvancedOrderRequestFeature.Emergency,
            _ =>(AdvancedOrderRequestFeature)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderRequestFeature value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderRequestFeature.Sms=>"sms",
            AdvancedOrderRequestFeature.Mms=>"mms",
            AdvancedOrderRequestFeature.Voice=>"voice",
            AdvancedOrderRequestFeature.Fax=>"fax",
            AdvancedOrderRequestFeature.Emergency=>"emergency",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(AdvancedOrderRequestPhoneNumberTypeConverter))]
public enum AdvancedOrderRequestPhoneNumberType
{
    Local, Mobile, TollFree, SharedCost, National, Landline
}sealed class AdvancedOrderRequestPhoneNumberTypeConverter : JsonConverter<AdvancedOrderRequestPhoneNumberType>
{
    public override AdvancedOrderRequestPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>AdvancedOrderRequestPhoneNumberType.Local,
            "mobile"=>AdvancedOrderRequestPhoneNumberType.Mobile,
            "toll_free"=>AdvancedOrderRequestPhoneNumberType.TollFree,
            "shared_cost"=>AdvancedOrderRequestPhoneNumberType.SharedCost,
            "national"=>AdvancedOrderRequestPhoneNumberType.National,
            "landline"=>AdvancedOrderRequestPhoneNumberType.Landline,
            _ =>(AdvancedOrderRequestPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderRequestPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderRequestPhoneNumberType.Local=>"local",
            AdvancedOrderRequestPhoneNumberType.Mobile=>"mobile",
            AdvancedOrderRequestPhoneNumberType.TollFree=>"toll_free",
            AdvancedOrderRequestPhoneNumberType.SharedCost=>"shared_cost",
            AdvancedOrderRequestPhoneNumberType.National=>"national",
            AdvancedOrderRequestPhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}