using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.List;

[JsonConverter(typeof(JsonModelConverter<ListRetrieveByZoneResponse, ListRetrieveByZoneResponseFromRaw>))]
public sealed record class ListRetrieveByZoneResponse : JsonModel
{
    public IReadOnlyList<ListRetrieveByZoneResponseData>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ListRetrieveByZoneResponseData>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ListRetrieveByZoneResponseData>?>(
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

    public ListRetrieveByZoneResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveByZoneResponse (
        ListRetrieveByZoneResponse listRetrieveByZoneResponse
    ) : base(listRetrieveByZoneResponse)
    {  }
    #pragma warning restore CS8618

    public ListRetrieveByZoneResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveByZoneResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ListRetrieveByZoneResponseFromRaw.FromRawUnchecked"/>
    public static ListRetrieveByZoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ListRetrieveByZoneResponseFromRaw : IFromRawJson<ListRetrieveByZoneResponse>
{
    /// <inheritdoc/>
    public ListRetrieveByZoneResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ListRetrieveByZoneResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ListRetrieveByZoneResponseData, ListRetrieveByZoneResponseDataFromRaw>))]
public sealed record class ListRetrieveByZoneResponseData : JsonModel
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

    public IReadOnlyList<ListRetrieveByZoneResponseDataNumber>? Numbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ListRetrieveByZoneResponseDataNumber>>(
                "numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ListRetrieveByZoneResponseDataNumber>?>(
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

    public ListRetrieveByZoneResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveByZoneResponseData (
        ListRetrieveByZoneResponseData listRetrieveByZoneResponseData
    ) : base(listRetrieveByZoneResponseData)
    {  }
    #pragma warning restore CS8618

    public ListRetrieveByZoneResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveByZoneResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ListRetrieveByZoneResponseDataFromRaw.FromRawUnchecked"/>
    public static ListRetrieveByZoneResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ListRetrieveByZoneResponseDataFromRaw : IFromRawJson<ListRetrieveByZoneResponseData>
{
    /// <inheritdoc/>
    public ListRetrieveByZoneResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ListRetrieveByZoneResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<ListRetrieveByZoneResponseDataNumber, ListRetrieveByZoneResponseDataNumberFromRaw>))]
public sealed record class ListRetrieveByZoneResponseDataNumber : JsonModel
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

    public string? Number {
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
        _ = this.Number;
    }

    public ListRetrieveByZoneResponseDataNumber ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ListRetrieveByZoneResponseDataNumber (
        ListRetrieveByZoneResponseDataNumber listRetrieveByZoneResponseDataNumber
    ) : base(listRetrieveByZoneResponseDataNumber)
    {  }
    #pragma warning restore CS8618

    public ListRetrieveByZoneResponseDataNumber (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ListRetrieveByZoneResponseDataNumber (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ListRetrieveByZoneResponseDataNumberFromRaw.FromRawUnchecked"/>
    public static ListRetrieveByZoneResponseDataNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ListRetrieveByZoneResponseDataNumberFromRaw : IFromRawJson<ListRetrieveByZoneResponseDataNumber>
{
    /// <inheritdoc/>
    public ListRetrieveByZoneResponseDataNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ListRetrieveByZoneResponseDataNumber.FromRawUnchecked(rawData);
}