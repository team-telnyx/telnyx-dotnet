using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingCreateResponse, MessagingCreateResponseFromRaw>))]
public sealed record class MessagingCreateResponse : JsonModel
{
    /// <summary>
    /// Legacy V2 MDR usage report response
    /// </summary>
    public MdrUsageReportResponseLegacy? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MdrUsageReportResponseLegacy>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public MessagingCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingCreateResponse (
        MessagingCreateResponse messagingCreateResponse
    ) : base(messagingCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingCreateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingCreateResponseFromRaw : IFromRawJson<MessagingCreateResponse>
{
    /// <inheritdoc/>
    public MessagingCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingCreateResponse.FromRawUnchecked(rawData);
}