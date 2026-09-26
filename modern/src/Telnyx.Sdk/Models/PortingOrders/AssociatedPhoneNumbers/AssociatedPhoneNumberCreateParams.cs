using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders.AssociatedPhoneNumbers;

/// <summary>
/// Creates a new associated phone number for a porting order. This is used for partial
/// porting in GB to specify which phone numbers should be kept or disconnected.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AssociatedPhoneNumberCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Specifies the action to take with this phone number during partial porting.
    /// </summary>
    public required ApiEnum<string, Action> Action {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Action>>(
                "action"
            );
        }
        init { this._rawBodyData.Set("action", value); }
    }

    public required PhoneNumberRange PhoneNumberRange {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PhoneNumberRange>(
                "phone_number_range"
            );
        }
        init { this._rawBodyData.Set("phone_number_range", value); }
    }

    public AssociatedPhoneNumberCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AssociatedPhoneNumberCreateParams (
        AssociatedPhoneNumberCreateParams associatedPhoneNumberCreateParams
    ) : base(associatedPhoneNumberCreateParams)
    {
        this.PortingOrderID = associatedPhoneNumberCreateParams.PortingOrderID;

        this._rawBodyData = new(associatedPhoneNumberCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AssociatedPhoneNumberCreateParams (
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
    AssociatedPhoneNumberCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string portingOrderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.PortingOrderID = portingOrderID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AssociatedPhoneNumberCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string portingOrderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            portingOrderID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["PortingOrderID"] = JsonSerializer.SerializeToElement(this.PortingOrderID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AssociatedPhoneNumberCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PortingOrderID?.Equals(other.PortingOrderID) ?? other.PortingOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/associated_phone_numbers",
            EncodePathSegment(this.PortingOrderID))
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

/// <summary>
/// Specifies the action to take with this phone number during partial porting.
/// </summary>
[JsonConverter(typeof(ActionConverter))]
public enum Action
{
    Keep, Disconnect
}

sealed class ActionConverter : JsonConverter<Action>
{
    public override Action Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "keep"=>Action.Keep,
            "disconnect"=>Action.Disconnect,
            _ =>(Action)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Action value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Action.Keep=>"keep",
            Action.Disconnect=>"disconnect",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRange, PhoneNumberRangeFromRaw>))]
public sealed record class PhoneNumberRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the phone number range for this associated phone number.
    /// </summary>
    public string? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// Specifies the start of the phone number range for this associated phone number.
    /// </summary>
    public string? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public PhoneNumberRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRange (PhoneNumberRange phoneNumberRange) : base(
        phoneNumberRange
    )
    {  }
    #pragma warning restore CS8618

    public PhoneNumberRange (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRange (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRangeFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PhoneNumberRangeFromRaw : IFromRawJson<PhoneNumberRange>
{
    /// <inheritdoc/>
    public PhoneNumberRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PhoneNumberRange.FromRawUnchecked(rawData);
}