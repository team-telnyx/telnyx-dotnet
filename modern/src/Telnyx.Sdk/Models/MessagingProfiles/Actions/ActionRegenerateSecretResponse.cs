using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionRegenerateSecretResponse, ActionRegenerateSecretResponseFromRaw>))]
public sealed record class ActionRegenerateSecretResponse : JsonModel
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

    public ActionRegenerateSecretResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionRegenerateSecretResponse (
        ActionRegenerateSecretResponse actionRegenerateSecretResponse
    ) : base(actionRegenerateSecretResponse)
    {  }
    #pragma warning restore CS8618

    public ActionRegenerateSecretResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionRegenerateSecretResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionRegenerateSecretResponseFromRaw.FromRawUnchecked"/>
    public static ActionRegenerateSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionRegenerateSecretResponseFromRaw : IFromRawJson<ActionRegenerateSecretResponse>
{
    /// <inheritdoc/>
    public ActionRegenerateSecretResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionRegenerateSecretResponse.FromRawUnchecked(rawData);
}