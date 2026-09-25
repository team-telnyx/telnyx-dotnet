using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Faxes;

/// <summary>
/// Retrieve a paginated list of faxes sent or received on your account.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FaxListParams : ParamsBase
{
    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[created_at][gte],
    /// filter[created_at][gt], filter[created_at][lte], filter[created_at][lt],
    /// filter[direction][eq], filter[from][eq], filter[to][eq]
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    public FaxListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxListParams (FaxListParams faxListParams) : base(faxListParams)
    {  }
    #pragma warning restore CS8618

    public FaxListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FaxListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(FaxListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/faxes"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Consolidated filter parameter (deepObject style). Originally: filter[created_at][gte],
/// filter[created_at][gt], filter[created_at][lte], filter[created_at][lt], filter[direction][eq],
/// filter[from][eq], filter[to][eq]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Date range filtering operations for fax creation timestamp
    /// </summary>
    public CreatedAt? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreatedAt>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Direction filtering operations
    /// </summary>
    public Direction? Direction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Direction>(
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

    /// <summary>
    /// From number filtering operations
    /// </summary>
    public From? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<From>(
                "from"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    /// <summary>
    /// To number filtering operations
    /// </summary>
    public To? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<To>(
                "to"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("to", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CreatedAt?.Validate();
        this.Direction?.Validate();
        this.From?.Validate();
        this.To?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Date range filtering operations for fax creation timestamp
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    /// <summary>
    /// ISO 8601 date time for filtering faxes created after that date
    /// </summary>
    public DateTimeOffset? Gt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "gt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gt", value);
        }
    }

    /// <summary>
    /// ISO 8601 date time for filtering faxes created after or on that date
    /// </summary>
    public DateTimeOffset? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date time for filtering faxes created before that date
    /// </summary>
    public DateTimeOffset? Lt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "lt"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lt", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date time for filtering faxes created on or before that date
    /// </summary>
    public DateTimeOffset? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gt;
        _ = this.Gte;
        _ = this.Lt;
        _ = this.Lte;
    }

    public CreatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt (CreatedAt createdAt) : base(createdAt)
    {  }
    #pragma warning restore CS8618

    public CreatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Direction filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Direction, DirectionFromRaw>))]
public sealed record class Direction : JsonModel
{
    /// <summary>
    /// The direction, inbound or outbound, for filtering faxes sent from this account
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public Direction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Direction (Direction direction) : base(direction)
    {  }
    #pragma warning restore CS8618

    public Direction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Direction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirectionFromRaw.FromRawUnchecked"/>
    public static Direction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class DirectionFromRaw : IFromRawJson<Direction>
{
    /// <inheritdoc/>
    public Direction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Direction.FromRawUnchecked(rawData);
}

/// <summary>
/// From number filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<From, FromFromRaw>))]
public sealed record class From : JsonModel
{
    /// <summary>
    /// The phone number, in E.164 format for filtering faxes sent from this number
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public From ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public From (From from) : base(from)
    {  }
    #pragma warning restore CS8618

    public From (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    From (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FromFromRaw.FromRawUnchecked"/>
    public static From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FromFromRaw : IFromRawJson<From>
{
    /// <inheritdoc/>
    public From FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>From.FromRawUnchecked(rawData);
}

/// <summary>
/// To number filtering operations
/// </summary>
[JsonConverter(typeof(JsonModelConverter<To, ToFromRaw>))]
public sealed record class To : JsonModel
{
    /// <summary>
    /// The phone number, in E.164 format for filtering faxes sent to this number
    /// </summary>
    public string? Eq {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "eq"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("eq", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Eq; }

    public To ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public To (To to) : base(to)
    {  }
    #pragma warning restore CS8618

    public To (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    To (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ToFromRaw.FromRawUnchecked"/>
    public static To FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ToFromRaw : IFromRawJson<To>
{
    /// <inheritdoc/>
    public To FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    =>To.FromRawUnchecked(rawData);
}