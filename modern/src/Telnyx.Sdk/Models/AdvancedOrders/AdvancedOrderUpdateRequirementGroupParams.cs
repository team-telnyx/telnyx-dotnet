using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AdvancedOrders;

/// <summary>
/// Updates the requirement-group configuration for the specified advanced number
/// order. The response contains the updated advanced order.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AdvancedOrderUpdateRequirementGroupParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? AdvancedOrderID { get; init; }

    public string? AreaCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "area_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("area_code", value);
        }
    }

    public string? Comments {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "comments"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("comments", value);
        }
    }

    public string? CountryCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("country_code", value);
        }
    }

    public string? CustomerReference {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "customer_reference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("customer_reference", value);
        }
    }

    public IReadOnlyList<ApiEnum<string, AdvancedOrderUpdateRequirementGroupParamsFeature>>? Features {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdvancedOrderUpdateRequirementGroupParamsFeature>>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, AdvancedOrderUpdateRequirementGroupParamsFeature>>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public ApiEnum<string, AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType>? PhoneNumberType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("phone_number_type", value);
        }
    }

    public long? Quantity {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>(
                "quantity"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("quantity", value);
        }
    }

    /// <summary>
    /// The ID of the requirement group to associate with this advanced order
    /// </summary>
    public string? RequirementGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "requirement_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("requirement_group_id", value);
        }
    }

    public AdvancedOrderUpdateRequirementGroupParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AdvancedOrderUpdateRequirementGroupParams (
        AdvancedOrderUpdateRequirementGroupParams advancedOrderUpdateRequirementGroupParams
    ) : base(advancedOrderUpdateRequirementGroupParams)
    {
        this.AdvancedOrderID = advancedOrderUpdateRequirementGroupParams.AdvancedOrderID;

        this._rawBodyData = new(advancedOrderUpdateRequirementGroupParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AdvancedOrderUpdateRequirementGroupParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AdvancedOrderUpdateRequirementGroupParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string advancedOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.AdvancedOrderID = advancedOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AdvancedOrderUpdateRequirementGroupParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string advancedOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            advancedOrderID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["AdvancedOrderID"] = JsonSerializer.SerializeToElement(this.AdvancedOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AdvancedOrderUpdateRequirementGroupParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.AdvancedOrderID?.Equals(other.AdvancedOrderID) ?? other.AdvancedOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/advanced_orders/{0}/requirement_group",
            EncodePathSegment(this.AdvancedOrderID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

[JsonConverter(typeof(AdvancedOrderUpdateRequirementGroupParamsFeatureConverter))]
public enum AdvancedOrderUpdateRequirementGroupParamsFeature
{
    Sms, Mms, Voice, Fax, Emergency
}

sealed class AdvancedOrderUpdateRequirementGroupParamsFeatureConverter : JsonConverter<AdvancedOrderUpdateRequirementGroupParamsFeature>
{
    public override AdvancedOrderUpdateRequirementGroupParamsFeature Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>AdvancedOrderUpdateRequirementGroupParamsFeature.Sms,
            "mms"=>AdvancedOrderUpdateRequirementGroupParamsFeature.Mms,
            "voice"=>AdvancedOrderUpdateRequirementGroupParamsFeature.Voice,
            "fax"=>AdvancedOrderUpdateRequirementGroupParamsFeature.Fax,
            "emergency"=>AdvancedOrderUpdateRequirementGroupParamsFeature.Emergency,
            _ =>(AdvancedOrderUpdateRequirementGroupParamsFeature)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderUpdateRequirementGroupParamsFeature value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderUpdateRequirementGroupParamsFeature.Sms=>"sms",
            AdvancedOrderUpdateRequirementGroupParamsFeature.Mms=>"mms",
            AdvancedOrderUpdateRequirementGroupParamsFeature.Voice=>"voice",
            AdvancedOrderUpdateRequirementGroupParamsFeature.Fax=>"fax",
            AdvancedOrderUpdateRequirementGroupParamsFeature.Emergency=>"emergency",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(AdvancedOrderUpdateRequirementGroupParamsPhoneNumberTypeConverter))]
public enum AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType
{
    Local, Mobile, TollFree, SharedCost, National, Landline
}

sealed class AdvancedOrderUpdateRequirementGroupParamsPhoneNumberTypeConverter : JsonConverter<AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType>
{
    public override AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "local"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Local,
            "mobile"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Mobile,
            "toll_free"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.TollFree,
            "shared_cost"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.SharedCost,
            "national"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.National,
            "landline"=>AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Landline,
            _ =>(AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Local=>"local",
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Mobile=>"mobile",
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.TollFree=>"toll_free",
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.SharedCost=>"shared_cost",
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.National=>"national",
            AdvancedOrderUpdateRequirementGroupParamsPhoneNumberType.Landline=>"landline",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}