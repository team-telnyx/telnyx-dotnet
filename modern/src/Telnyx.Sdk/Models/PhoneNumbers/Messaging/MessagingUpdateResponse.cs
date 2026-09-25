using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingUpdateResponse, MessagingUpdateResponseFromRaw>))]
public sealed record class MessagingUpdateResponse : JsonModel
{
    public PhoneNumberWithMessagingSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberWithMessagingSettings>(
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

    public MessagingUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingUpdateResponse (
        MessagingUpdateResponse messagingUpdateResponse
    ) : base(messagingUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingUpdateResponseFromRaw : IFromRawJson<MessagingUpdateResponse>
{
    /// <inheritdoc/>
    public MessagingUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingUpdateResponse.FromRawUnchecked(rawData);
}