using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailEvents;

[JsonConverter(typeof(JsonModelConverter<TimeRange, TimeRangeFromRaw>))]
public sealed record class TimeRange : JsonModel
{
    public required DateTimeOffset? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    public required DateTimeOffset? To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.From;
        _ = this.To;
    }

    public TimeRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TimeRange (TimeRange timeRange) : base(timeRange)
    {  }
    #pragma warning restore CS8618

    public TimeRange (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TimeRange (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TimeRangeFromRaw.FromRawUnchecked"/>
    public static TimeRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TimeRangeFromRaw : IFromRawJson<TimeRange>
{
    /// <inheritdoc/>
    public TimeRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TimeRange.FromRawUnchecked(rawData);
}