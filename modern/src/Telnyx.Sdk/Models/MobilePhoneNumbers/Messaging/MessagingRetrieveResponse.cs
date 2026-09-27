using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobilePhoneNumbers.Messaging;

[JsonConverter(typeof(JsonModelConverter<MessagingRetrieveResponse, MessagingRetrieveResponseFromRaw>))]
public sealed record class MessagingRetrieveResponse : JsonModel
{
    public MobilePhoneNumberWithMessagingSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MobilePhoneNumberWithMessagingSettings>(
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

    public MessagingRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingRetrieveResponse (
        MessagingRetrieveResponse messagingRetrieveResponse
    ) : base(messagingRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessagingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingRetrieveResponseFromRaw : IFromRawJson<MessagingRetrieveResponse>
{
    /// <inheritdoc/>
    public MessagingRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingRetrieveResponse.FromRawUnchecked(rawData);
}