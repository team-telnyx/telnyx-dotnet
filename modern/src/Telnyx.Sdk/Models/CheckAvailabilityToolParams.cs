using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<CheckAvailabilityToolParams, CheckAvailabilityToolParamsFromRaw>))]
public sealed record class CheckAvailabilityToolParams : JsonModel
{
    /// <summary>
    /// Reference to an integration secret that contains your Cal.com API key. You
    /// would pass the `identifier` for an integration secret [/v2/integration_secrets](https://developers.telnyx.com/api/secrets-manager/integration-secrets/create-integration-secret)
    /// that refers to your Cal.com API key.
    /// </summary>
    public required string ApiKeyRef {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "api_key_ref"
            );
        }
        init { this._rawData.Set("api_key_ref", value); }
    }

    /// <summary>
    /// Event Type ID for which slots are being fetched. [cal.com](https://cal.com/docs/api-reference/v2/slots/get-available-slots#parameter-event-type-id)
    /// </summary>
    public required long EventTypeID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "event_type_id"
            );
        }
        init { this._rawData.Set("event_type_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyRef;
        _ = this.EventTypeID;
    }

    public CheckAvailabilityToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CheckAvailabilityToolParams (
        CheckAvailabilityToolParams checkAvailabilityToolParams
    ) : base(checkAvailabilityToolParams)
    {  }
    #pragma warning restore CS8618

    public CheckAvailabilityToolParams (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CheckAvailabilityToolParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CheckAvailabilityToolParamsFromRaw.FromRawUnchecked"/>
    public static CheckAvailabilityToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CheckAvailabilityToolParamsFromRaw : IFromRawJson<CheckAvailabilityToolParams>
{
    /// <inheritdoc/>
    public CheckAvailabilityToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CheckAvailabilityToolParams.FromRawUnchecked(rawData);
}