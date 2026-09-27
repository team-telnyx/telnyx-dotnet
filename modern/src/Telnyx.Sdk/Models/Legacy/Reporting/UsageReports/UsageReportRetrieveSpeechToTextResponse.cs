using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports;

[JsonConverter(typeof(JsonModelConverter<UsageReportRetrieveSpeechToTextResponse, UsageReportRetrieveSpeechToTextResponseFromRaw>))]
public sealed record class UsageReportRetrieveSpeechToTextResponse : JsonModel
{
    public IReadOnlyDictionary<string, JsonElement>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Data; }

    public UsageReportRetrieveSpeechToTextResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsageReportRetrieveSpeechToTextResponse (
        UsageReportRetrieveSpeechToTextResponse usageReportRetrieveSpeechToTextResponse
    ) : base(usageReportRetrieveSpeechToTextResponse)
    {  }
    #pragma warning restore CS8618

    public UsageReportRetrieveSpeechToTextResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsageReportRetrieveSpeechToTextResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsageReportRetrieveSpeechToTextResponseFromRaw.FromRawUnchecked"/>
    public static UsageReportRetrieveSpeechToTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsageReportRetrieveSpeechToTextResponseFromRaw : IFromRawJson<UsageReportRetrieveSpeechToTextResponse>
{
    /// <inheritdoc/>
    public UsageReportRetrieveSpeechToTextResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsageReportRetrieveSpeechToTextResponse.FromRawUnchecked(rawData);
}