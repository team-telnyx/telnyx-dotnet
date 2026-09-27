using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.BulkSimCardActions;

[JsonConverter(typeof(JsonModelConverter<SimCardActionsSummary, SimCardActionsSummaryFromRaw>))]
public sealed record class SimCardActionsSummary : JsonModel
{
    public long? Count {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("count", value);
        }
    }

    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Count;
        this.Status?.Validate();
    }

    public SimCardActionsSummary ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardActionsSummary (
        SimCardActionsSummary simCardActionsSummary
    ) : base(simCardActionsSummary)
    {  }
    #pragma warning restore CS8618

    public SimCardActionsSummary (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardActionsSummary (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardActionsSummaryFromRaw.FromRawUnchecked"/>
    public static SimCardActionsSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardActionsSummaryFromRaw : IFromRawJson<SimCardActionsSummary>
{
    /// <inheritdoc/>
    public SimCardActionsSummary FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardActionsSummary.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress, Completed, Failed, Interrupted
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>Status.InProgress,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            "interrupted"=>Status.Interrupted,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.InProgress=>"in-progress",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            Status.Interrupted=>"interrupted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}