using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SessionAnalysis;

[JsonConverter(typeof(JsonModelConverter<SessionAnalysisRetrieveResponse, SessionAnalysisRetrieveResponseFromRaw>))]
public sealed record class SessionAnalysisRetrieveResponse : JsonModel
{
    public required SessionAnalysisRetrieveResponseCost Cost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<SessionAnalysisRetrieveResponseCost>(
                "cost"
            );
        }
        init { this._rawData.Set("cost", value); }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    public required EventNode Root {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EventNode>(
                "root"
            );
        }
        init { this._rawData.Set("root", value); }
    }

    /// <summary>
    /// Identifier for the analyzed session.
    /// </summary>
    public required string SessionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "session_id"
            );
        }
        init { this._rawData.Set("session_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Cost.Validate();
        this.Meta.Validate();
        this.Root.Validate();
        _ = this.SessionID;
    }

    public SessionAnalysisRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionAnalysisRetrieveResponse (
        SessionAnalysisRetrieveResponse sessionAnalysisRetrieveResponse
    ) : base(sessionAnalysisRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public SessionAnalysisRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionAnalysisRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionAnalysisRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static SessionAnalysisRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SessionAnalysisRetrieveResponseFromRaw : IFromRawJson<SessionAnalysisRetrieveResponse>
{
    /// <inheritdoc/>
    public SessionAnalysisRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionAnalysisRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<SessionAnalysisRetrieveResponseCost, SessionAnalysisRetrieveResponseCostFromRaw>))]
public sealed record class SessionAnalysisRetrieveResponseCost : JsonModel
{
    /// <summary>
    /// ISO 4217 currency code.
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
    /// Total session cost as a decimal string.
    /// </summary>
    public required string Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Currency;
        _ = this.Total;
    }

    public SessionAnalysisRetrieveResponseCost ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionAnalysisRetrieveResponseCost (
        SessionAnalysisRetrieveResponseCost sessionAnalysisRetrieveResponseCost
    ) : base(sessionAnalysisRetrieveResponseCost)
    {  }
    #pragma warning restore CS8618

    public SessionAnalysisRetrieveResponseCost (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionAnalysisRetrieveResponseCost (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SessionAnalysisRetrieveResponseCostFromRaw.FromRawUnchecked"/>
    public static SessionAnalysisRetrieveResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SessionAnalysisRetrieveResponseCostFromRaw : IFromRawJson<SessionAnalysisRetrieveResponseCost>
{
    /// <inheritdoc/>
    public SessionAnalysisRetrieveResponseCost FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SessionAnalysisRetrieveResponseCost.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// Total number of events in the session tree.
    /// </summary>
    public required long EventCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "event_count"
            );
        }
        init { this._rawData.Set("event_count", value); }
    }

    /// <summary>
    /// List of distinct products involved in the session.
    /// </summary>
    public required IReadOnlyList<string> Products {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "products"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "products",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EventCount;
        _ = this.Products;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}