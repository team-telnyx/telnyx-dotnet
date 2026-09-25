using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumbers;

[JsonConverter(typeof(JsonModelConverter<MessagingHostedNumberRetrieveResponse, MessagingHostedNumberRetrieveResponseFromRaw>))]
public sealed record class MessagingHostedNumberRetrieveResponse : JsonModel
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

    public MessagingHostedNumberRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingHostedNumberRetrieveResponse (
        MessagingHostedNumberRetrieveResponse messagingHostedNumberRetrieveResponse
    ) : base(messagingHostedNumberRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingHostedNumberRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingHostedNumberRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingHostedNumberRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessagingHostedNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingHostedNumberRetrieveResponseFromRaw : IFromRawJson<MessagingHostedNumberRetrieveResponse>
{
    /// <inheritdoc/>
    public MessagingHostedNumberRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingHostedNumberRetrieveResponse.FromRawUnchecked(rawData);
}