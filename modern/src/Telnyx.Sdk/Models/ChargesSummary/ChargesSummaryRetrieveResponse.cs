using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ChargesSummary;

[JsonConverter(typeof(JsonModelConverter<ChargesSummaryRetrieveResponse, ChargesSummaryRetrieveResponseFromRaw>))]
public sealed record class ChargesSummaryRetrieveResponse : JsonModel
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

    public ChargesSummaryRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChargesSummaryRetrieveResponse (
        ChargesSummaryRetrieveResponse chargesSummaryRetrieveResponse
    ) : base(chargesSummaryRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ChargesSummaryRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ChargesSummaryRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ChargesSummaryRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ChargesSummaryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ChargesSummaryRetrieveResponse (Data data) : this()
    { this.Data = data; }
}

class ChargesSummaryRetrieveResponseFromRaw : IFromRawJson<ChargesSummaryRetrieveResponse>
{
    /// <inheritdoc/>
    public ChargesSummaryRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ChargesSummaryRetrieveResponse.FromRawUnchecked(rawData);
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
    /// End date of the summary period
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
    /// Start date of the summary period
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

    public required Summary Summary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Summary>(
                "summary"
            );
        }
        init { this._rawData.Set("summary", value); }
    }

    public required Total Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Total>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
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
        _ = this.StartDate;
        this.Summary.Validate();
        this.Total.Validate();
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
}[JsonConverter(typeof(JsonModelConverter<Summary, SummaryFromRaw>))]
public sealed record class Summary : JsonModel
{
    /// <summary>
    /// List of billing adjustments
    /// </summary>
    public required IReadOnlyList<Adjustment> Adjustments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Adjustment>>(
                "adjustments"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Adjustment>>(
                "adjustments",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// List of charge summary lines
    /// </summary>
    public required IReadOnlyList<Line> Lines {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Line>>(
                "lines"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Line>>(
                "lines",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Adjustments)
        {
            item.Validate();
        }
        foreach (var item in this.Lines)
        {
            item.Validate();
        }
    }

    public Summary ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Summary (Summary summary) : base(summary)
    {  }
    #pragma warning restore CS8618

    public Summary (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Summary (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SummaryFromRaw.FromRawUnchecked"/>
    public static Summary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SummaryFromRaw : IFromRawJson<Summary>
{
    /// <inheritdoc/>
    public Summary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Summary.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Adjustment, AdjustmentFromRaw>))]
public sealed record class Adjustment : JsonModel
{
    /// <summary>
    /// Adjustment amount as decimal string
    /// </summary>
    public required string Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "amount"
            );
        }
        init { this._rawData.Set("amount", value); }
    }

    /// <summary>
    /// Description of the adjustment
    /// </summary>
    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Date when the adjustment occurred
    /// </summary>
    public required string EventDate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "event_date"
            );
        }
        init { this._rawData.Set("event_date", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Amount;
        _ = this.Description;
        _ = this.EventDate;
    }

    public Adjustment ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Adjustment (Adjustment adjustment) : base(adjustment)
    {  }
    #pragma warning restore CS8618

    public Adjustment (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Adjustment (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AdjustmentFromRaw.FromRawUnchecked"/>
    public static Adjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AdjustmentFromRaw : IFromRawJson<Adjustment>
{
    /// <inheritdoc/>
    public Adjustment FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Adjustment.FromRawUnchecked(rawData);
}[JsonConverter(typeof(LineConverter))]
public record class Line : ModelBase
{
    public object? Value { get; } = null;

    JsonElement? _element = null;

    public JsonElement Json {
        get {
            return this._element ??= JsonSerializer.SerializeToElement(this.Value, ModelBase.SerializerOptions);
        }
    }

    public string Alias {
        get {
            return Match(comparative: ( x )=>x.Alias, simple: ( x )=>x.Alias);
        }
    }

    public string Name {
        get { return Match(comparative: ( x )=>x.Name, simple: ( x )=>x.Name); }
    }

    public JsonElement Type {
        get { return Match(comparative: ( x )=>x.Type, simple: ( x )=>x.Type); }
    }

    public Line (Comparative value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Line (Simple value, JsonElement? element = null)
    {
        this.Value = value;
        this._element = element;
    }

    public Line (JsonElement element)
    { this._element = element; }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Comparative"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickComparative(out var value)) {
///     // `value` is of type `Comparative`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickComparative([NotNullWhen(true)] out Comparative? value)
    {
        value =this.Value as Comparative ;
        return value != null ;
    }

    /// <summary>
/// Returns true and sets the <c>out</c> parameter if the instance was constructed with a variant of
/// type <see cref="Simple"/>.
/// 
/// <para>Consider using <see cref="Switch"/> or <see cref="Match"/> if you need to handle every variant.</para>
/// 
/// <example>
/// <code>
/// if (instance.TryPickSimple(out var value)) {
///     // `value` is of type `Simple`
///     Console.WriteLine(value);
/// }
/// </code>
/// </example>
/// </summary>
    public bool TryPickSimple([NotNullWhen(true)] out Simple? value)
    {
        value =this.Value as Simple ;
        return value != null ;
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Match"/>
/// if you need your function parameters to return something.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// instance.Switch(
///     (Comparative value) =&gt; {...},
///     (Simple value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public void Switch(
        System::Action<Comparative> comparative, System::Action<Simple> simple
    )
    {
        switch (this.Value)
        {
            case Comparative value:
                comparative(value);
                break;
            case Simple value:
                simple(value);
                break;
            default:
                throw new TelnyxInvalidDataException("Data did not match any variant of Line");

        }
    }

    /// <summary>
/// Calls the function parameter corresponding to the variant the instance was constructed with and
/// returns its result.
/// 
/// <para>Use the <c>TryPick</c> method(s) if you don't need to handle every variant, or <see cref="Switch"/>
/// if you don't need your function parameters to return a value.</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance was constructed with an unknown variant (e.g. deserialized from raw data
/// that doesn't match any variant's expected shape).
/// </exception>
/// 
/// <example>
/// <code>
/// var result = instance.Match(
///     (Comparative value) =&gt; {...},
///     (Simple value) =&gt; {...}
/// );
/// </code>
/// </example>
/// </summary>
    public T Match<T>
    (System::Func<Comparative, T> comparative, System::Func<Simple, T> simple)
    {
        return this.Value switch
        {
            Comparative value=>comparative(value),
            Simple value=>simple(value),
            _ =>throw new TelnyxInvalidDataException("Data did not match any variant of Line")
        } ;
    }

    public static implicit operator Line (Comparative value)=> new(value) ;

    public static implicit operator Line (Simple value)=> new(value) ;

    /// <summary>
/// Validates that the instance was constructed with a known variant and that this variant is valid
/// (based on its own <c>Validate</c> method).
/// 
/// <para>This is useful for instances constructed from raw JSON data (e.g. deserialized from an API response).</para>
/// 
/// <exception cref="TelnyxInvalidDataException">
/// Thrown when the instance does not pass validation.
/// </exception>
/// </summary>
    public override void Validate()
    {
        if (this.Value == null)
        {
            throw new TelnyxInvalidDataException("Data did not match any variant of Line");
        }
        this.Switch((comparative) => comparative.Validate(),
        (simple) => simple.Validate());
    }

    public virtual bool Equals(Line? other)
    =>other != null &&
    this.VariantIndex() == other.VariantIndex() &&
    JsonElementEquality.DeepEquals(this.Json, other.Json);

    public override int GetHashCode()
    { return 0; }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(this.Json), ModelBase.ToStringSerializerOptions);

    int VariantIndex()
    {
        return this.Value switch
        { Comparative _=>0, Simple _=>1, _ =>-1 } ;
    }
}sealed class LineConverter : JsonConverter<Line>
{
    public override Line? Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var element = JsonSerializer.Deserialize<JsonElement>(ref reader, options);
        string? type;
        try {
            type = element.GetProperty("type").GetString();
        } catch {
            type = null;
        }

        switch (type)
        {
            case "comparative":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Comparative>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }case "simple":{
                try
                {
                    var deserialized = JsonSerializer.Deserialize<Simple>(element, options);
                    if (deserialized != null) {

                        return new(deserialized, element);
                    }
                }
                catch (JsonException )
                {
                    // ignore
                }

                return new(element);
            }default:
                { return new Line(element); }

        }
    }

    public override void Write(
        Utf8JsonWriter writer, Line value, JsonSerializerOptions options
    )
    { JsonSerializer.Serialize(writer, value.Json, options); }
}[JsonConverter(typeof(JsonModelConverter<Comparative, ComparativeFromRaw>))]
public sealed record class Comparative : JsonModel
{
    /// <summary>
    /// Service alias
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
    }

    public required MonthDetail ExistingThisMonth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MonthDetail>(
                "existing_this_month"
            );
        }
        init { this._rawData.Set("existing_this_month", value); }
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

    public required MonthDetail NewThisMonth {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<MonthDetail>(
                "new_this_month"
            );
        }
        init { this._rawData.Set("new_this_month", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        this.ExistingThisMonth.Validate();
        _ = this.Name;
        this.NewThisMonth.Validate();
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("comparative")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Comparative ()
    { this.Type = JsonSerializer.SerializeToElement("comparative"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Comparative (Comparative comparative) : base(comparative)
    {  }
    #pragma warning restore CS8618

    public Comparative (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("comparative");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Comparative (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ComparativeFromRaw.FromRawUnchecked"/>
    public static Comparative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ComparativeFromRaw : IFromRawJson<Comparative>
{
    /// <inheritdoc/>
    public Comparative FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Comparative.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Simple, SimpleFromRaw>))]
public sealed record class Simple : JsonModel
{
    /// <summary>
    /// Service alias
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <summary>
    /// Total amount as decimal string
    /// </summary>
    public required string Amount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "amount"
            );
        }
        init { this._rawData.Set("amount", value); }
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

    /// <summary>
    /// Number of items
    /// </summary>
    public required long Quantity {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "quantity"
            );
        }
        init { this._rawData.Set("quantity", value); }
    }

    public JsonElement Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Alias;
        _ = this.Amount;
        _ = this.Name;
        _ = this.Quantity;
        if (!JsonElementEquality.DeepEquals(this.Type, JsonSerializer.SerializeToElement("simple")))
        {
            throw new TelnyxInvalidDataException("Invalid value given for constant");
        }
    }

    public Simple ()
    { this.Type = JsonSerializer.SerializeToElement("simple"); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Simple (Simple simple) : base(simple)
    {  }
    #pragma warning restore CS8618

    public Simple (IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("simple");
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Simple (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimpleFromRaw.FromRawUnchecked"/>
    public static Simple FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimpleFromRaw : IFromRawJson<Simple>
{
    /// <inheritdoc/>
    public Simple FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Simple.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Total, TotalFromRaw>))]
public sealed record class Total : JsonModel
{
    /// <summary>
    /// Total credits as decimal string
    /// </summary>
    public required string Credits {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "credits"
            );
        }
        init { this._rawData.Set("credits", value); }
    }

    /// <summary>
    /// Total existing monthly recurring charges as decimal string
    /// </summary>
    public required string ExistingMrc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "existing_mrc"
            );
        }
        init { this._rawData.Set("existing_mrc", value); }
    }

    /// <summary>
    /// Grand total of all charges as decimal string
    /// </summary>
    public required string GrandTotal {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "grand_total"
            );
        }
        init { this._rawData.Set("grand_total", value); }
    }

    /// <summary>
    /// Ledger adjustments as decimal string
    /// </summary>
    public required string LedgerAdjustments {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "ledger_adjustments"
            );
        }
        init { this._rawData.Set("ledger_adjustments", value); }
    }

    /// <summary>
    /// Total new monthly recurring charges as decimal string
    /// </summary>
    public required string NewMrc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "new_mrc"
            );
        }
        init { this._rawData.Set("new_mrc", value); }
    }

    /// <summary>
    /// Total new one-time charges as decimal string
    /// </summary>
    public required string NewOtc {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "new_otc"
            );
        }
        init { this._rawData.Set("new_otc", value); }
    }

    /// <summary>
    /// Other charges as decimal string
    /// </summary>
    public required string Other {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "other"
            );
        }
        init { this._rawData.Set("other", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Credits;
        _ = this.ExistingMrc;
        _ = this.GrandTotal;
        _ = this.LedgerAdjustments;
        _ = this.NewMrc;
        _ = this.NewOtc;
        _ = this.Other;
    }

    public Total ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Total (Total total) : base(total)
    {  }
    #pragma warning restore CS8618

    public Total (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Total (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TotalFromRaw.FromRawUnchecked"/>
    public static Total FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TotalFromRaw : IFromRawJson<Total>
{
    /// <inheritdoc/>
    public Total FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Total.FromRawUnchecked(rawData);
}