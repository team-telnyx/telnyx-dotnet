using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models;

[JsonConverter(typeof(JsonModelConverter<BookAppointmentToolParams, BookAppointmentToolParamsFromRaw>))]
public sealed record class BookAppointmentToolParams : JsonModel
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
    /// Event Type ID for which slots are being fetched. [cal.com](https://cal.com/docs/api-reference/v2/bookings/create-a-booking#body-event-type-id)
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

    /// <summary>
    /// The name of the attendee [cal.com](https://cal.com/docs/api-reference/v2/bookings/create-a-booking#body-attendee-name).
    /// If not provided, the assistant will ask for the attendee's name.
    /// </summary>
    public string? AttendeeName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "attendee_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attendee_name", value);
        }
    }

    /// <summary>
    /// The timezone of the attendee [cal.com](https://cal.com/docs/api-reference/v2/bookings/create-a-booking#body-attendee-timezone).
    /// If not provided, the assistant will ask for the attendee's timezone.
    /// </summary>
    public string? AttendeeTimezone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "attendee_timezone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("attendee_timezone", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ApiKeyRef;
        _ = this.EventTypeID;
        _ = this.AttendeeName;
        _ = this.AttendeeTimezone;
    }

    public BookAppointmentToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BookAppointmentToolParams (
        BookAppointmentToolParams bookAppointmentToolParams
    ) : base(bookAppointmentToolParams)
    {  }
    #pragma warning restore CS8618

    public BookAppointmentToolParams (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BookAppointmentToolParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BookAppointmentToolParamsFromRaw.FromRawUnchecked"/>
    public static BookAppointmentToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BookAppointmentToolParamsFromRaw : IFromRawJson<BookAppointmentToolParams>
{
    /// <inheritdoc/>
    public BookAppointmentToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BookAppointmentToolParams.FromRawUnchecked(rawData);
}