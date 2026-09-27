using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles;

[JsonConverter(typeof(JsonModelConverter<MessagingProfileCreateResponse, MessagingProfileCreateResponseFromRaw>))]
public sealed record class MessagingProfileCreateResponse : JsonModel
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

    public MessagingProfileCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingProfileCreateResponse (
        MessagingProfileCreateResponse messagingProfileCreateResponse
    ) : base(messagingProfileCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MessagingProfileCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingProfileCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MessagingProfileCreateResponseFromRaw.FromRawUnchecked"/>
    public static MessagingProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MessagingProfileCreateResponseFromRaw : IFromRawJson<MessagingProfileCreateResponse>
{
    /// <inheritdoc/>
    public MessagingProfileCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MessagingProfileCreateResponse.FromRawUnchecked(rawData);
}