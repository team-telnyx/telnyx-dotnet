using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

/// <summary>
/// Update properties of a conference participant.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceUpdateParticipantParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ID { get; init; }

    public string? ParticipantID { get; init; }

    /// <summary>
    /// Whether entry/exit beeps are enabled for this participant.
    /// </summary>
    public ApiEnum<string, ConferenceUpdateParticipantParamsBeepEnabled>? BeepEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceUpdateParticipantParamsBeepEnabled>>(
                "beep_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("beep_enabled", value);
        }
    }

    /// <summary>
    /// Whether the conference should end when this participant exits.
    /// </summary>
    public bool? EndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("end_conference_on_exit", value);
        }
    }

    /// <summary>
    /// Whether the conference should soft-end when this participant exits. A soft
    /// end will stop new participants from joining but allow existing participants
    /// to remain.
    /// </summary>
    public bool? SoftEndConferenceOnExit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "soft_end_conference_on_exit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("soft_end_conference_on_exit", value);
        }
    }

    public ConferenceUpdateParticipantParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceUpdateParticipantParams (
        ConferenceUpdateParticipantParams conferenceUpdateParticipantParams
    ) : base(conferenceUpdateParticipantParams)
    {
        this.ID = conferenceUpdateParticipantParams.ID;
        this.ParticipantID = conferenceUpdateParticipantParams.ParticipantID;

        this._rawBodyData = new(conferenceUpdateParticipantParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ConferenceUpdateParticipantParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceUpdateParticipantParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id,
        string participantID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
        this.ParticipantID = participantID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConferenceUpdateParticipantParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id,
        string participantID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id,
            participantID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["ParticipantID"] = JsonSerializer.SerializeToElement(this.ParticipantID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ConferenceUpdateParticipantParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ID.Equals(other.ID)&&(this.ParticipantID?.Equals(other.ParticipantID) ?? other.ParticipantID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/participants/{1}",
            EncodePathSegment(this.ID),
            EncodePathSegment(this.ParticipantID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Whether entry/exit beeps are enabled for this participant.
/// </summary>
[JsonConverter(typeof(ConferenceUpdateParticipantParamsBeepEnabledConverter))]
public enum ConferenceUpdateParticipantParamsBeepEnabled
{
    Always, Never, OnEnter, OnExit
}

sealed class ConferenceUpdateParticipantParamsBeepEnabledConverter : JsonConverter<ConferenceUpdateParticipantParamsBeepEnabled>
{
    public override ConferenceUpdateParticipantParamsBeepEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>ConferenceUpdateParticipantParamsBeepEnabled.Always,
            "never"=>ConferenceUpdateParticipantParamsBeepEnabled.Never,
            "on_enter"=>ConferenceUpdateParticipantParamsBeepEnabled.OnEnter,
            "on_exit"=>ConferenceUpdateParticipantParamsBeepEnabled.OnExit,
            _ =>(ConferenceUpdateParticipantParamsBeepEnabled)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceUpdateParticipantParamsBeepEnabled value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceUpdateParticipantParamsBeepEnabled.Always=>"always",
            ConferenceUpdateParticipantParamsBeepEnabled.Never=>"never",
            ConferenceUpdateParticipantParamsBeepEnabled.OnEnter=>"on_enter",
            ConferenceUpdateParticipantParamsBeepEnabled.OnExit=>"on_exit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}