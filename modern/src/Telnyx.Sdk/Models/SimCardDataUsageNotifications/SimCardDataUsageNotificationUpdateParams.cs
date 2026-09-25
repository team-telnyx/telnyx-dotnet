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

namespace Telnyx.Sdk.Models.SimCardDataUsageNotifications;

/// <summary>
/// Updates information for a SIM Card Data Usage Notification.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SimCardDataUsageNotificationUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SimCardDataUsageNotificationID { get; init; }

    /// <summary>
    /// The identification UUID of the related SIM card resource.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sim_card_id", value);
        }
    }

    /// <summary>
    /// Data usage threshold that will trigger the notification.
    /// </summary>
    public SimCardDataUsageNotificationUpdateParamsThreshold? Threshold {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SimCardDataUsageNotificationUpdateParamsThreshold>(
                "threshold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("threshold", value);
        }
    }

    public SimCardDataUsageNotificationUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationUpdateParams (
        SimCardDataUsageNotificationUpdateParams simCardDataUsageNotificationUpdateParams
    ) : base(simCardDataUsageNotificationUpdateParams)
    {
        this.SimCardDataUsageNotificationID = simCardDataUsageNotificationUpdateParams.SimCardDataUsageNotificationID;

        this._rawBodyData = new(simCardDataUsageNotificationUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationUpdateParams (
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
    SimCardDataUsageNotificationUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string simCardDataUsageNotificationID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SimCardDataUsageNotificationID = simCardDataUsageNotificationID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string simCardDataUsageNotificationID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            simCardDataUsageNotificationID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["SimCardDataUsageNotificationID"] = JsonSerializer.SerializeToElement(this.SimCardDataUsageNotificationID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SimCardDataUsageNotificationUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SimCardDataUsageNotificationID?.Equals(other.SimCardDataUsageNotificationID) ?? other.SimCardDataUsageNotificationID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/sim_card_data_usage_notifications/{0}",
            this.SimCardDataUsageNotificationID)
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
/// Data usage threshold that will trigger the notification.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardDataUsageNotificationUpdateParamsThreshold, SimCardDataUsageNotificationUpdateParamsThresholdFromRaw>))]
public sealed record class SimCardDataUsageNotificationUpdateParamsThreshold : JsonModel
{
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

    public ApiEnum<string, SimCardDataUsageNotificationUpdateParamsThresholdUnit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardDataUsageNotificationUpdateParamsThresholdUnit>>(
                "unit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("unit", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        this.Unit?.Validate();
    }

    public SimCardDataUsageNotificationUpdateParamsThreshold ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardDataUsageNotificationUpdateParamsThreshold (
        SimCardDataUsageNotificationUpdateParamsThreshold simCardDataUsageNotificationUpdateParamsThreshold
    ) : base(simCardDataUsageNotificationUpdateParamsThreshold)
    {  }
    #pragma warning restore CS8618

    public SimCardDataUsageNotificationUpdateParamsThreshold (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardDataUsageNotificationUpdateParamsThreshold (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardDataUsageNotificationUpdateParamsThresholdFromRaw.FromRawUnchecked"/>
    public static SimCardDataUsageNotificationUpdateParamsThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardDataUsageNotificationUpdateParamsThresholdFromRaw : IFromRawJson<SimCardDataUsageNotificationUpdateParamsThreshold>
{
    /// <inheritdoc/>
    public SimCardDataUsageNotificationUpdateParamsThreshold FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardDataUsageNotificationUpdateParamsThreshold.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SimCardDataUsageNotificationUpdateParamsThresholdUnitConverter))]
public enum SimCardDataUsageNotificationUpdateParamsThresholdUnit
{
    MB, GB
}

sealed class SimCardDataUsageNotificationUpdateParamsThresholdUnitConverter : JsonConverter<SimCardDataUsageNotificationUpdateParamsThresholdUnit>
{
    public override SimCardDataUsageNotificationUpdateParamsThresholdUnit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "MB"=>SimCardDataUsageNotificationUpdateParamsThresholdUnit.MB,
            "GB"=>SimCardDataUsageNotificationUpdateParamsThresholdUnit.GB,
            _ =>(SimCardDataUsageNotificationUpdateParamsThresholdUnit)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardDataUsageNotificationUpdateParamsThresholdUnit value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardDataUsageNotificationUpdateParamsThresholdUnit.MB=>"MB",
            SimCardDataUsageNotificationUpdateParamsThresholdUnit.GB=>"GB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}