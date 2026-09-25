using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileUpdateResponse, MessagingProfileUpdateResponseFromRaw>))]
public sealed record class MessagingProfileUpdateResponse : JsonModel
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

    public MessagingProfileUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileUpdateResponse (
        MessagingProfileUpdateResponse messagingProfileUpdateResponse
    ) : base(messagingProfileUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileUpdateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileUpdateResponseFromRaw : IFromRawJson<MessagingProfileUpdateResponse>
{
    /// <inheritdoc/>
    public MessagingProfileUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileUpdateResponse.FromRawUnchecked(rawData);
}