using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.List;

[JsonConverter(typeof(JsonModelConverter<ListRetrieveAllResponse, ListRetrieveAllResponseFromRaw>))]
public sealed record class ListRetrieveAllResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public ListRetrieveAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveAllResponse (
        ListRetrieveAllResponse listRetrieveAllResponse
    ) : base(listRetrieveAllResponse)
    {  }
    #pragma warning restore CS8618

    public ListRetrieveAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveAllResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ListRetrieveAllResponseFromRaw.FromRawUnchecked"/>
    public static ListRetrieveAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ListRetrieveAllResponseFromRaw : IFromRawJson<ListRetrieveAllResponse>
{
    /// <inheritdoc/>
    public ListRetrieveAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ListRetrieveAllResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    public long? NumberOfChannels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "number_of_channels"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_of_channels", value);
        }
    }

    public IReadOnlyList<Number>? Numbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Number>>(
                "numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Number>?>(
                "numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? ZoneID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zone_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zone_id", value);
        }
    }

    public string? ZoneName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zone_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zone_name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.NumberOfChannels;
        foreach (var item in this.Numbers ?? [])
        {
            item.Validate();
        }
        _ = this.ZoneID;
        _ = this.ZoneName;
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
}[JsonConverter(typeof(JsonModelConverter<Number, NumberFromRaw>))]
public sealed record class Number : JsonModel
{
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

    public string? NumberValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Country;
        _ = this.NumberValue;
    }

    public Number ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Number (Number number) : base(number)
    {  }
    #pragma warning restore CS8618

    public Number (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Number (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NumberFromRaw.FromRawUnchecked"/>
    public static Number FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class NumberFromRaw : IFromRawJson<Number>
{
    /// <inheritdoc/>
    public Number FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Number.FromRawUnchecked(rawData);
}