using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingNumbersBulkUpdates;

[JsonConverter(typeof(JsonModelConverter<MessagingNumbersBulkUpdateCreateResponse, MessagingNumbersBulkUpdateCreateResponseFromRaw>))]
public sealed record class MessagingNumbersBulkUpdateCreateResponse : JsonModel
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

    public MessagingNumbersBulkUpdateCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingNumbersBulkUpdateCreateResponse (
        MessagingNumbersBulkUpdateCreateResponse messagingNumbersBulkUpdateCreateResponse
    ) : base(messagingNumbersBulkUpdateCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingNumbersBulkUpdateCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingNumbersBulkUpdateCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingNumbersBulkUpdateCreateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingNumbersBulkUpdateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingNumbersBulkUpdateCreateResponseFromRaw : IFromRawJson<MessagingNumbersBulkUpdateCreateResponse>
{
    /// <inheritdoc/>
    public MessagingNumbersBulkUpdateCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingNumbersBulkUpdateCreateResponse.FromRawUnchecked(rawData);
}