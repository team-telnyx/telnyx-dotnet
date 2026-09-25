using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Legacy.Reporting.UsageReports.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingDeleteResponse, MessagingDeleteResponseFromRaw>))]
public sealed record class MessagingDeleteResponse : JsonModel
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

    public MessagingDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingDeleteResponse (
        MessagingDeleteResponse messagingDeleteResponse
    ) : base(messagingDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MessagingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingDeleteResponseFromRaw : IFromRawJson<MessagingDeleteResponse>
{
    /// <inheritdoc/>
    public MessagingDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingDeleteResponse.FromRawUnchecked(rawData);
}