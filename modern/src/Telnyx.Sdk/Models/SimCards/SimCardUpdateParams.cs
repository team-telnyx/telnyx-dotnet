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

namespace Telnyx.Sdk.Models.SimCards;

/// <summary>
/// Updates the specified SIM card's attributes and returns the updated SIM card.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SimCardUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SimCardID { get; init; }

    /// <summary>
    /// List of IMEIs authorized to use a given SIM card.
    /// </summary>
    public IReadOnlyList<string>? AuthorizedImeis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "authorized_imeis"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>?>(
                "authorized_imeis",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The SIM card individual data limit configuration.
    /// </summary>
    public DataLimit? DataLimit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<DataLimit>(
                "data_limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("data_limit", value);
        }
    }

    /// <summary>
    /// The group SIMCardGroup identification. This attribute can be &lt;code&gt;null&lt;/code&gt;
    /// when it's present in an associated resource.
    /// </summary>
    public string? SimCardGroupID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "sim_card_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("sim_card_group_id", value);
        }
    }

    public SimCardStatus? Status {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<SimCardStatus>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("status", value);
        }
    }

    /// <summary>
    /// Searchable tags associated with the SIM card
    /// </summary>
    public IReadOnlyList<string>? Tags {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "tags"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "tags",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public SimCardUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardUpdateParams (SimCardUpdateParams simCardUpdateParams) : base(
        simCardUpdateParams
    )
    {
        this.SimCardID = simCardUpdateParams.SimCardID;

        this._rawBodyData = new(simCardUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public SimCardUpdateParams (
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
    SimCardUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string simCardID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SimCardID = simCardID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SimCardUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string simCardID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            simCardID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["SimCardID"] = JsonSerializer.SerializeToElement(this.SimCardID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SimCardUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SimCardID?.Equals(other.SimCardID) ?? other.SimCardID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/sim_cards/{0}",
            this.SimCardID)
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
/// The SIM card individual data limit configuration.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataLimit, DataLimitFromRaw>))]
public sealed record class DataLimit : JsonModel
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

    public ApiEnum<string, Unit>? Unit {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Unit>>(
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

    public DataLimit ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataLimit (DataLimit dataLimit) : base(dataLimit)
    {  }
    #pragma warning restore CS8618

    public DataLimit (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DataLimit (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataLimitFromRaw.FromRawUnchecked"/>
    public static DataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DataLimitFromRaw : IFromRawJson<DataLimit>
{
    /// <inheritdoc/>
    public DataLimit FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DataLimit.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(UnitConverter))]
public enum Unit
{
    MB, GB
}

sealed class UnitConverter : JsonConverter<Unit>
{
    public override Unit Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "MB"=>Unit.MB, "GB"=>Unit.GB, _ =>(Unit)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Unit value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Unit.MB=>"MB",
            Unit.GB=>"GB",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}