using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ChargesBreakdown;

[JsonConverter(typeof(JsonModelConverter<ChargesBreakdownRetrieveResponse, ChargesBreakdownRetrieveResponseFromRaw>))]
public sealed record class ChargesBreakdownRetrieveResponse : JsonModel
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

    public ChargesBreakdownRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargesBreakdownRetrieveResponse (
        ChargesBreakdownRetrieveResponse chargesBreakdownRetrieveResponse
    ) : base(chargesBreakdownRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ChargesBreakdownRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargesBreakdownRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChargesBreakdownRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ChargesBreakdownRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ChargesBreakdownRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class ChargesBreakdownRetrieveResponseFromRaw : IFromRawJson<ChargesBreakdownRetrieveResponse>
{
    /// <inheritdoc/>
    public ChargesBreakdownRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ChargesBreakdownRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Currency code
    /// </summary>
    public required string Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "currency"
            );
        }
        init { this._rawData.Set("currency", value); }
    }

    /// <summary>
    /// End date of the breakdown period
    /// </summary>
    public required string EndDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "end_date"
            );
        }
        init { this._rawData.Set("end_date", value); }
    }

    /// <summary>
    /// List of phone number charge breakdowns
    /// </summary>
    public required IReadOnlyList<Result> Results {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Result>>(
                "results"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Result>>(
                "results",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Start date of the breakdown period
    /// </summary>
    public required string StartDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "start_date"
            );
        }
        init { this._rawData.Set("start_date", value); }
    }

    /// <summary>
    /// User email address
    /// </summary>
    public required string UserEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_email"
            );
        }
        init { this._rawData.Set("user_email", value); }
    }

    /// <summary>
    /// User identifier
    /// </summary>
    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.EndDate;
        foreach (var item in this.Results)
        {
            item.Validate();
        }
        _ = this.StartDate;
        _ = this.UserEmail;
        _ = this.UserID;
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
}[JsonConverter(typeof(JsonModelConverter<Result, ResultFromRaw>))]
public sealed record class Result : JsonModel
{
    /// <summary>
    /// Type of charge for the number
    /// </summary>
    public required string ChargeType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "charge_type"
            );
        }
        init { this._rawData.Set("charge_type", value); }
    }

    /// <summary>
    /// Email address of the service owner
    /// </summary>
    public required string ServiceOwnerEmail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "service_owner_email"
            );
        }
        init { this._rawData.Set("service_owner_email", value); }
    }

    /// <summary>
    /// User ID of the service owner
    /// </summary>
    public required string ServiceOwnerUserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "service_owner_user_id"
            );
        }
        init { this._rawData.Set("service_owner_user_id", value); }
    }

    /// <summary>
    /// List of services associated with this number
    /// </summary>
    public required IReadOnlyList<Service> Services {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Service>>(
                "services"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Service>>(
                "services",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone number
    /// </summary>
    public required string Tn {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "tn"
            );
        }
        init { this._rawData.Set("tn", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChargeType;
        _ = this.ServiceOwnerEmail;
        _ = this.ServiceOwnerUserID;
        foreach (var item in this.Services)
        {
            item.Validate();
        }
        _ = this.Tn;
    }

    public Result ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Result (Result result) : base(result)
    {  }
    #pragma warning restore CS8618

    public Result (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Result (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ResultFromRaw.FromRawUnchecked"/>
    public static Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ResultFromRaw : IFromRawJson<Result>
{
    /// <inheritdoc/>
    public Result FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Result.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Service, ServiceFromRaw>))]
public sealed record class Service : JsonModel
{
    /// <summary>
    /// Cost per unit as decimal string
    /// </summary>
    public required string Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Type of cost (MRC or OTC)
    /// </summary>
    public required string CostType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cost_type"
            );
        }
        init { this._rawData.Set("cost_type", value); }
    }

    /// <summary>
    /// Service name
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Cost;
        _ = this.CostType;
        _ = this.Name;
    }

    public Service ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Service (Service service) : base(service)
    {  }
    #pragma warning restore CS8618

    public Service (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Service (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ServiceFromRaw.FromRawUnchecked"/>
    public static Service FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ServiceFromRaw : IFromRawJson<Service>
{
    /// <inheritdoc/>
    public Service FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Service.FromRawUnchecked(rawData);
}