using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Settings;

[JsonConverter(typeof(JsonModelConverter<NamespaceSettingsResponse, NamespaceSettingsResponseFromRaw>))]
public sealed record class NamespaceSettingsResponse : JsonModel
{
    /// <summary>
    /// A namespace's settings, grouped by what they affect.
    /// </summary>
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

    public NamespaceSettingsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NamespaceSettingsResponse (
        NamespaceSettingsResponse namespaceSettingsResponse
    ) : base(namespaceSettingsResponse)
    {  }
    #pragma warning restore CS8618

    public NamespaceSettingsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    NamespaceSettingsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="NamespaceSettingsResponseFromRaw.FromRawUnchecked"/>
    public static NamespaceSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public NamespaceSettingsResponse (Data data) : this()
    { this.Data = data; }
}

class NamespaceSettingsResponseFromRaw : IFromRawJson<NamespaceSettingsResponse>
{
    /// <inheritdoc/>
    public NamespaceSettingsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>NamespaceSettingsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A namespace's settings, grouped by what they affect.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Settings that shape this namespace's summaries.
    /// </summary>
    public DataSummary? Summary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DataSummary>(
                "summary"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("summary", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Summary?.Validate(); }

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
}/// <summary>
/// Settings that shape this namespace's summaries.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DataSummary, DataSummaryFromRaw>))]
public sealed record class DataSummary : JsonModel
{
    /// <summary>
    /// Free-form instructions that influence how this namespace's summaries are written,
    /// shared by every profile in the namespace. How you use them is up to you --
    /// they steer the outcome, so try a phrasing and see how the summary comes out.
    /// Advisory: they steer the summary but never override or deny a profile's own
    /// facts, and they do not affect recall. Null or empty means none are set, and
    /// summaries use the neutral default. A change reaches each summary the next
    /// time it is regenerated.
    /// </summary>
    public string? Instructions {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "instructions"
            );
        }
        init { this._rawData.Set("instructions", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Instructions; }

    public DataSummary ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DataSummary (DataSummary dataSummary) : base(dataSummary)
    {  }
    #pragma warning restore CS8618

    public DataSummary (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DataSummary (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataSummaryFromRaw.FromRawUnchecked"/>
    public static DataSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataSummaryFromRaw : IFromRawJson<DataSummary>
{
    /// <inheritdoc/>
    public DataSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DataSummary.FromRawUnchecked(rawData);
}