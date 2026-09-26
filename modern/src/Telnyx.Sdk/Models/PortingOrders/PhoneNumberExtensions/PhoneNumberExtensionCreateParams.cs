using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberExtensions;

/// <summary>
/// Creates a phone number extension on the porting order, mapping extension ranges
/// to one of the order's phone numbers.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberExtensionCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Specifies the activation ranges for this porting phone number extension.
    /// The activation range must be within the extension range and should not overlap
    /// with other activation ranges.
    /// </summary>
    public required IReadOnlyList<ActivationRange> ActivationRanges {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<ActivationRange>>(
                "activation_ranges"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<ActivationRange>>(
                "activation_ranges",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ExtensionRange ExtensionRange {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ExtensionRange>(
                "extension_range"
            );
        }
        init { this._rawBodyData.Set("extension_range", value); }
    }

    /// <summary>
    /// Identifies the porting phone number associated with this porting phone number extension.
    /// </summary>
    public required string PortingPhoneNumberID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "porting_phone_number_id"
            );
        }
        init { this._rawBodyData.Set("porting_phone_number_id", value); }
    }

    public PhoneNumberExtensionCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberExtensionCreateParams (
        PhoneNumberExtensionCreateParams phoneNumberExtensionCreateParams
    ) : base(phoneNumberExtensionCreateParams)
    {
        this.PortingOrderID = phoneNumberExtensionCreateParams.PortingOrderID;

        this._rawBodyData = new(phoneNumberExtensionCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PhoneNumberExtensionCreateParams (
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
    PhoneNumberExtensionCreateParams (
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
    public static PhoneNumberExtensionCreateParams FromRawUnchecked(
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

    public virtual bool Equals(PhoneNumberExtensionCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.PortingOrderID?.Equals(other.PortingOrderID) ?? other.PortingOrderID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/phone_number_extensions",
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

[JsonConverter(typeof(JsonModelConverter<ActivationRange, ActivationRangeFromRaw>))]
public sealed record class ActivationRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the activation range. It must be no more than the end
    /// of the extension range.
    /// </summary>
    public required long EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "end_at"
            );
        }
        init { this._rawData.Set("end_at", value); }
    }

    /// <summary>
    /// Specifies the start of the activation range. Must be greater or equal the
    /// start of the extension range.
    /// </summary>
    public required long StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "start_at"
            );
        }
        init { this._rawData.Set("start_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public ActivationRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationRange (ActivationRange activationRange) : base(
        activationRange
    )
    {  }
    #pragma warning restore CS8618

    public ActivationRange (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationRange (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationRangeFromRaw.FromRawUnchecked"/>
    public static ActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActivationRangeFromRaw : IFromRawJson<ActivationRange>
{
    /// <inheritdoc/>
    public ActivationRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationRange.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ExtensionRange, ExtensionRangeFromRaw>))]
public sealed record class ExtensionRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the extension range for this porting phone number extension.
    /// </summary>
    public required long EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "end_at"
            );
        }
        init { this._rawData.Set("end_at", value); }
    }

    /// <summary>
    /// Specifies the start of the extension range for this porting phone number extension.
    /// </summary>
    public required long StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "start_at"
            );
        }
        init { this._rawData.Set("start_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public ExtensionRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExtensionRange (ExtensionRange extensionRange) : base(extensionRange)
    {  }
    #pragma warning restore CS8618

    public ExtensionRange (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ExtensionRange (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ExtensionRangeFromRaw.FromRawUnchecked"/>
    public static ExtensionRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ExtensionRangeFromRaw : IFromRawJson<ExtensionRange>
{
    /// <inheritdoc/>
    public ExtensionRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ExtensionRange.FromRawUnchecked(rawData);
}