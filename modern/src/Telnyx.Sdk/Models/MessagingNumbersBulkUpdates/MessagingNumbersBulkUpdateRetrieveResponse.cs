using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingNumbersBulkUpdates;

[JsonConverter(typeof(JsonModelConverter<MessagingNumbersBulkUpdateRetrieveResponse, MessagingNumbersBulkUpdateRetrieveResponseFromRaw>))]
public sealed record class MessagingNumbersBulkUpdateRetrieveResponse : JsonModel
{
    public BulkMessagingSettingsUpdatePhoneNumbers? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BulkMessagingSettingsUpdatePhoneNumbers>(
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

    public MessagingNumbersBulkUpdateRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingNumbersBulkUpdateRetrieveResponse (
        MessagingNumbersBulkUpdateRetrieveResponse messagingNumbersBulkUpdateRetrieveResponse
    ) : base(messagingNumbersBulkUpdateRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingNumbersBulkUpdateRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingNumbersBulkUpdateRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingNumbersBulkUpdateRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessagingNumbersBulkUpdateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingNumbersBulkUpdateRetrieveResponseFromRaw : IFromRawJson<MessagingNumbersBulkUpdateRetrieveResponse>
{
    /// <inheritdoc/>
    public MessagingNumbersBulkUpdateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingNumbersBulkUpdateRetrieveResponse.FromRawUnchecked(rawData);
}