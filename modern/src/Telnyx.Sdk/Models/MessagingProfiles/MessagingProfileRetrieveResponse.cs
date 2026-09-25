using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileRetrieveResponse, MessagingProfileRetrieveResponseFromRaw>))]
public sealed record class MessagingProfileRetrieveResponse : JsonModel
{
    public MessagingMessagingProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingMessagingProfile>(
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

    public MessagingProfileRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileRetrieveResponse (
        MessagingProfileRetrieveResponse messagingProfileRetrieveResponse
    ) : base(messagingProfileRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileRetrieveResponseFromRaw : IFromRawJson<MessagingProfileRetrieveResponse>
{
    /// <inheritdoc/>
    public MessagingProfileRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileRetrieveResponse.FromRawUnchecked(rawData);
}