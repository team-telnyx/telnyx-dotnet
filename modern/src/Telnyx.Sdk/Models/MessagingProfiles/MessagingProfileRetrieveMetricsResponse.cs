using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileRetrieveMetricsResponse, MessagingProfileRetrieveMetricsResponseFromRaw>))]
public sealed record class MessagingProfileRetrieveMetricsResponse : JsonModel
{
    /// <summary>
    /// Detailed metrics for a messaging profile.
    /// </summary>
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

    public MessagingProfileRetrieveMetricsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileRetrieveMetricsResponse (
        MessagingProfileRetrieveMetricsResponse messagingProfileRetrieveMetricsResponse
    ) : base(messagingProfileRetrieveMetricsResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileRetrieveMetricsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileRetrieveMetricsResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileRetrieveMetricsResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileRetrieveMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileRetrieveMetricsResponseFromRaw : IFromRawJson<MessagingProfileRetrieveMetricsResponse>
{
    /// <inheritdoc/>
    public MessagingProfileRetrieveMetricsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileRetrieveMetricsResponse.FromRawUnchecked(rawData);
}