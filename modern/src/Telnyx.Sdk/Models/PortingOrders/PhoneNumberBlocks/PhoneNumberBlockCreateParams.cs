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

namespace Telnyx.Sdk.Models.PortingOrders.PhoneNumberBlocks;

/// <summary>
/// Creates a phone number block on the porting order, representing a contiguous
/// range of phone numbers to be ported together.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberBlockCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? PortingOrderID { get; init; }

    /// <summary>
    /// Specifies the activation ranges for this porting phone number block. The activation
    /// range must be within the block range and should not overlap with other activation ranges.
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

    public required PhoneNumberRange PhoneNumberRange {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<PhoneNumberRange>(
                "phone_number_range"
            );
        }
        init { this._rawBodyData.Set("phone_number_range", value); }
    }

    public PhoneNumberBlockCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberBlockCreateParams (
        PhoneNumberBlockCreateParams phoneNumberBlockCreateParams
    ) : base(phoneNumberBlockCreateParams)
    {
        this.PortingOrderID = phoneNumberBlockCreateParams.PortingOrderID;

        this._rawBodyData = new(phoneNumberBlockCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public PhoneNumberBlockCreateParams (
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
    PhoneNumberBlockCreateParams (
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
    public static PhoneNumberBlockCreateParams FromRawUnchecked(
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

    public virtual bool Equals(PhoneNumberBlockCreateParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/porting_orders/{0}/phone_number_blocks",
            this.PortingOrderID)
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
    public required string EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "end_at"
            );
        }
        init { this._rawData.Set("end_at", value); }
    }

    /// <summary>
    /// Specifies the start of the activation range. Must be greater or equal the
    /// start of the extension range.
    /// </summary>
    public required string StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
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

[JsonConverter(typeof(JsonModelConverter<PhoneNumberRange, PhoneNumberRangeFromRaw>))]
public sealed record class PhoneNumberRange : JsonModel
{
    /// <summary>
    /// Specifies the end of the phone number range for this porting phone number block.
    /// </summary>
    public required string EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "end_at"
            );
        }
        init { this._rawData.Set("end_at", value); }
    }

    /// <summary>
    /// Specifies the start of the phone number range for this porting phone number block.
    /// </summary>
    public required string StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
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