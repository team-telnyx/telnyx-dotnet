using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Texml.Accounts.Conferences;

[JsonConverter(typeof(JsonModelConverter<ConferenceResource, ConferenceResourceFromRaw>))]
public sealed record class ConferenceResource : JsonModel
{
    /// <summary>
    /// The id of the account the resource belongs to.
    /// </summary>
    public string? AccountSid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "account_sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("account_sid", value);
        }
    }

    /// <summary>
    /// The version of the API that was used to make the request.
    /// </summary>
    public string? ApiVersion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "api_version"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("api_version", value);
        }
    }

    /// <summary>
    /// Caller ID, if present.
    /// </summary>
    public string? CallSidEndingConference {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "call_sid_ending_conference"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("call_sid_ending_conference", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was created.
    /// </summary>
    public string? DateCreated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_created"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_created", value);
        }
    }

    /// <summary>
    /// The timestamp of when the resource was last updated.
    /// </summary>
    public string? DateUpdated {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "date_updated"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_updated", value);
        }
    }

    /// <summary>
    /// A string that you assigned to describe this conference room.
    /// </summary>
    public string? FriendlyName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "friendly_name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("friendly_name", value);
        }
    }

    /// <summary>
    /// The reason why a conference ended. When a conference is in progress, will
    /// be null.
    /// </summary>
    public ApiEnum<string, ReasonConferenceEnded>? ReasonConferenceEnded {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReasonConferenceEnded>>(
                "reason_conference_ended"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason_conference_ended", value);
        }
    }

    /// <summary>
    /// A string representing the region where the conference is hosted.
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <summary>
    /// The unique identifier of the conference.
    /// </summary>
    public string? Sid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sid", value);
        }
    }

    /// <summary>
    /// The status of this conference.
    /// </summary>
    public ApiEnum<string, ConferenceResourceStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConferenceResourceStatus>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("status", value);
        }
    }

    /// <summary>
    /// A list of related resources identified by their relative URIs.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? SubresourceUris {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "subresource_uris"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "subresource_uris",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The relative URI for this conference.
    /// </summary>
    public string? Uri {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "uri"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("uri", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountSid;
        _ = this.ApiVersion;
        _ = this.CallSidEndingConference;
        _ = this.DateCreated;
        _ = this.DateUpdated;
        _ = this.FriendlyName;
        this.ReasonConferenceEnded?.Validate();
        _ = this.Region;
        _ = this.Sid;
        this.Status?.Validate();
        _ = this.SubresourceUris;
        _ = this.Uri;
    }

    public ConferenceResource ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceResource (ConferenceResource conferenceResource) : base(
        conferenceResource
    )
    {  }
    #pragma warning restore CS8618

    public ConferenceResource (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceResource (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceResourceFromRaw.FromRawUnchecked"/>
    public static ConferenceResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceResourceFromRaw : IFromRawJson<ConferenceResource>
{
    /// <inheritdoc/>
    public ConferenceResource FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceResource.FromRawUnchecked(rawData);
}

/// <summary>
/// The reason why a conference ended. When a conference is in progress, will be null.
/// </summary>
[JsonConverter(typeof(ReasonConferenceEndedConverter))]
public enum ReasonConferenceEnded
{
    ParticipantWithEndConferenceOnExitLeft,
    LastParticipantLeft,
    ConferenceEndedViaApi,
    TimeExceeded
}sealed class ReasonConferenceEndedConverter : JsonConverter<ReasonConferenceEnded>
{
    public override ReasonConferenceEnded Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "participant-with-end-conference-on-exit-left"=>ReasonConferenceEnded.ParticipantWithEndConferenceOnExitLeft,
            "last-participant-left"=>ReasonConferenceEnded.LastParticipantLeft,
            "conference-ended-via-api"=>ReasonConferenceEnded.ConferenceEndedViaApi,
            "time-exceeded"=>ReasonConferenceEnded.TimeExceeded,
            _ =>(ReasonConferenceEnded)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReasonConferenceEnded value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReasonConferenceEnded.ParticipantWithEndConferenceOnExitLeft=>"participant-with-end-conference-on-exit-left",
            ReasonConferenceEnded.LastParticipantLeft=>"last-participant-left",
            ReasonConferenceEnded.ConferenceEndedViaApi=>"conference-ended-via-api",
            ReasonConferenceEnded.TimeExceeded=>"time-exceeded",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The status of this conference.
/// </summary>
[JsonConverter(typeof(ConferenceResourceStatusConverter))]
public enum ConferenceResourceStatus
{
    Init, InProgress, Completed
}sealed class ConferenceResourceStatusConverter : JsonConverter<ConferenceResourceStatus>
{
    public override ConferenceResourceStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "init"=>ConferenceResourceStatus.Init,
            "in-progress"=>ConferenceResourceStatus.InProgress,
            "completed"=>ConferenceResourceStatus.Completed,
            _ =>(ConferenceResourceStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceResourceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceResourceStatus.Init=>"init",
            ConferenceResourceStatus.InProgress=>"in-progress",
            ConferenceResourceStatus.Completed=>"completed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}