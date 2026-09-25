using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumbers;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberUpdateResponse, MessagingHostedNumberUpdateResponseFromRaw>))]
public sealed record class MessagingHostedNumberUpdateResponse : JsonModel
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

    public MessagingHostedNumberUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberUpdateResponse (
        MessagingHostedNumberUpdateResponse messagingHostedNumberUpdateResponse
    ) : base(messagingHostedNumberUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberUpdateResponseFromRaw : IFromRawJson<MessagingHostedNumberUpdateResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberUpdateResponse.FromRawUnchecked(rawData);
}