using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Runs = Telnyx.Sdk.Models.AI.Assistants.Tests.TestSuites.Runs;

namespace Telnyx.Sdk.Models.AI.Assistants.ScheduledEvents;

[JsonConverter(typeof(JsonModelConverter<ScheduledEventListPageResponse, ScheduledEventListPageResponseFromRaw>))]
public sealed record class ScheduledEventListPageResponse : JsonModel
{
    public required IReadOnlyList<ScheduledEventListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ScheduledEventListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ScheduledEventListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Runs::Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Runs::Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public ScheduledEventListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ScheduledEventListPageResponse (
        ScheduledEventListPageResponse scheduledEventListPageResponse
    ) : base(scheduledEventListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ScheduledEventListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ScheduledEventListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ScheduledEventListPageResponseFromRaw.FromRawUnchecked"/>
    public static ScheduledEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ScheduledEventListPageResponseFromRaw : IFromRawJson<ScheduledEventListPageResponse>
{
    /// <inheritdoc/>
    public ScheduledEventListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ScheduledEventListPageResponse.FromRawUnchecked(rawData);
}