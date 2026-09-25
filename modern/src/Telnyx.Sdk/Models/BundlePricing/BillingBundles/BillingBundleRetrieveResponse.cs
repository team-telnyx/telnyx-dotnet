using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.BundlePricing.BillingBundles;

[JsonConverter(typeof(JsonModelConverter<BillingBundleRetrieveResponse, BillingBundleRetrieveResponseFromRaw>))]
public sealed record class BillingBundleRetrieveResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public BillingBundleRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BillingBundleRetrieveResponse (
        BillingBundleRetrieveResponse billingBundleRetrieveResponse
    ) : base(billingBundleRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public BillingBundleRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BillingBundleRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BillingBundleRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BillingBundleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public BillingBundleRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class BillingBundleRetrieveResponseFromRaw : IFromRawJson<BillingBundleRetrieveResponse>
{
    /// <inheritdoc/>
    public BillingBundleRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BillingBundleRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Bundle's ID, this is used to identify the bundle in the API.
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// If that bundle is active or not.
    /// </summary>
    public required bool Active {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "active"
            );
        }
        init { this._rawData.Set("active", value); }
    }

    public required IReadOnlyList<BundleLimit> BundleLimits {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<BundleLimit>>(
                "bundle_limits"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<BundleLimit>>(
                "bundle_limits",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Bundle's cost code, this is used to identify the bundle in the billing system.
    /// </summary>
    public required string CostCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cost_code"
            );
        }
        init { this._rawData.Set("cost_code", value); }
    }

    /// <summary>
    /// Date the bundle was created.
    /// </summary>
    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Available to all customers or only to specific customers.
    /// </summary>
    public required bool IsPublic {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "is_public"
            );
        }
        init { this._rawData.Set("is_public", value); }
    }

    /// <summary>
    /// Bundle's name, this is used to identify the bundle in the UI.
    /// </summary>
    public required string Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Slugified version of the bundle's name.
    /// </summary>
    public string? Slug {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "slug"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("slug", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Active;
        foreach (var item in this.BundleLimits)
        {
            item.Validate();
        }
        _ = this.CostCode;
        _ = this.CreatedAt;
        _ = this.IsPublic;
        _ = this.Name;
        _ = this.Slug;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<BundleLimit, BundleLimitFromRaw>))]
public sealed record class BundleLimit : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Metric {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "metric"
            );
        }
        init { this._rawData.Set("metric", value); }
    }

    public required string Service {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "service"
            );
        }
        init { this._rawData.Set("service", value); }
    }

    public required string UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    public string? BillingService {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "billing_service"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("billing_service", value);
        }
    }

    /// <summary>
    /// Use country_iso instead
    /// </summary>
    [System::Obsolete("Use country_iso instead")]
    public string? Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public long? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
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

    public string? CountryIso {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_iso"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_iso", value);
        }
    }

    /// <summary>
    /// An enumeration.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("direction", value);
        }
    }

    public long? Limit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("limit", value);
        }
    }

    public string? Rate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "rate"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("rate", value);
        }
    }

    public IReadOnlyList<string>? Types {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "types"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "types",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Metric;
        _ = this.Service;
        _ = this.UpdatedAt;
        _ = this.BillingService;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.CountryIso;
        this.Direction?.Validate();
        _ = this.Limit;
        _ = this.Rate;
        _ = this.Types;
    }

    public BundleLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BundleLimit (BundleLimit bundleLimit) : base(bundleLimit)
    {  }
    #pragma warning restore CS8618

    public BundleLimit (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BundleLimit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BundleLimitFromRaw.FromRawUnchecked"/>
    public static BundleLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class BundleLimitFromRaw : IFromRawJson<BundleLimit>
{
    /// <inheritdoc/>
    public BundleLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BundleLimit.FromRawUnchecked(rawData);
}/// <summary>
/// An enumeration.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound
}sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound"=>Direction.Inbound,
            "outbound"=>Direction.Outbound,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"inbound",
            Direction.Outbound=>"outbound",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}