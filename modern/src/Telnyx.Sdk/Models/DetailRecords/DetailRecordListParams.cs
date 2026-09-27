using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.DetailRecords;

/// <summary>
/// Search for any detail record across the Telnyx Platform
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DetailRecordListParams : ParamsBase
{
    /// <summary>
    /// Filter records on a given record attribute and value. &lt;br/&gt;Example:
    /// filter[status]=delivered. &lt;br/&gt;Required: filter[record_type] must be
    /// specified. &lt;br/&gt;The valid filter fields depend on the record_type:
    /// filtering by a field that does not exist for the selected record_type is rejected
    /// with a 400 error. Call-control and sip-trunking records use started_at, finished_at
    /// and answered_at (they have no created_at); messaging records use created_at.
    /// To list the fields available for a record_type, use the /v2/detail_records/options endpoint.
    /// </summary>
    public Filter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<Filter>(
                "filter"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter", value);
        }
    }

    public long? PageNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[number]", value);
        }
    }

    public long? PageSize {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "page[size]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("page[size]", value);
        }
    }

    /// <summary>
    /// Specifies the sort order for results. &lt;br/&gt;Example: sort=-created_at
    /// &lt;br/&gt;The valid sort fields depend on the record_type: sort by a field
    /// that does not exist for the selected record_type is rejected with a 400 error.
    /// Call-control and sip-trunking records use started_at, finished_at and answered_at
    /// (they have no created_at); messaging records use created_at. To list the
    /// fields available for a record_type, use the /v2/detail_records/options endpoint.
    /// </summary>
    public IReadOnlyList<string>? Sort {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<ImmutableArray<string>>(
                "sort"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set<ImmutableArray<string>?>(
                "sort",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public DetailRecordListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DetailRecordListParams (
        DetailRecordListParams detailRecordListParams
    ) : base(detailRecordListParams)
    {  }
    #pragma warning restore CS8618

    public DetailRecordListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DetailRecordListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DetailRecordListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DetailRecordListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/detail_records"
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
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
/// Filter records on a given record attribute and value. &lt;br/&gt;Example: filter[status]=delivered.
/// &lt;br/&gt;Required: filter[record_type] must be specified. &lt;br/&gt;The valid
/// filter fields depend on the record_type: filtering by a field that does not exist
/// for the selected record_type is rejected with a 400 error. Call-control and sip-trunking
/// records use started_at, finished_at and answered_at (they have no created_at);
/// messaging records use created_at. To list the fields available for a record_type,
/// use the /v2/detail_records/options endpoint.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Filter, FilterFromRaw>))]
public sealed record class Filter : JsonModel
{
    /// <summary>
    /// Filter by the given record type.
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Filter by the given user-friendly date range. You can specify one of the following
    /// enum values, or a dynamic one using this format: last_N_days.
    /// </summary>
    public ApiEnum<string, DateRange>? DateRange {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DateRange>>(
                "date_range"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("date_range", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.RecordType.Validate();
        this.DateRange?.Validate();
    }

    public Filter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Filter (Filter filter) : base(filter)
    {  }
    #pragma warning restore CS8618

    public Filter (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Filter (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FilterFromRaw.FromRawUnchecked"/>
    public static Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Filter (ApiEnum<string, RecordType> recordType) : this()
    { this.RecordType = recordType; }
}

class FilterFromRaw : IFromRawJson<Filter>
{
    /// <inheritdoc/>
    public Filter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Filter.FromRawUnchecked(rawData);
}

/// <summary>
/// Filter by the given record type.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    AIVoiceAssistant,
    Amd,
    CallControl,
    Conference,
    ConferenceParticipant,
    Embedding,
    Fax,
    Inference,
    InferenceSpeechToText,
    MediaStorage,
    MediaStreaming,
    Messaging,
    NoiseSuppression,
    Recording,
    SipTrunking,
    SiprecClient,
    Stt,
    Tts,
    Verify,
    Webrtc,
    Wireless
}

sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "ai-voice-assistant"=>RecordType.AIVoiceAssistant,
            "amd"=>RecordType.Amd,
            "call-control"=>RecordType.CallControl,
            "conference"=>RecordType.Conference,
            "conference-participant"=>RecordType.ConferenceParticipant,
            "embedding"=>RecordType.Embedding,
            "fax"=>RecordType.Fax,
            "inference"=>RecordType.Inference,
            "inference-speech-to-text"=>RecordType.InferenceSpeechToText,
            "media_storage"=>RecordType.MediaStorage,
            "media-streaming"=>RecordType.MediaStreaming,
            "messaging"=>RecordType.Messaging,
            "noise-suppression"=>RecordType.NoiseSuppression,
            "recording"=>RecordType.Recording,
            "sip-trunking"=>RecordType.SipTrunking,
            "siprec-client"=>RecordType.SiprecClient,
            "stt"=>RecordType.Stt,
            "tts"=>RecordType.Tts,
            "verify"=>RecordType.Verify,
            "webrtc"=>RecordType.Webrtc,
            "wireless"=>RecordType.Wireless,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.AIVoiceAssistant=>"ai-voice-assistant",
            RecordType.Amd=>"amd",
            RecordType.CallControl=>"call-control",
            RecordType.Conference=>"conference",
            RecordType.ConferenceParticipant=>"conference-participant",
            RecordType.Embedding=>"embedding",
            RecordType.Fax=>"fax",
            RecordType.Inference=>"inference",
            RecordType.InferenceSpeechToText=>"inference-speech-to-text",
            RecordType.MediaStorage=>"media_storage",
            RecordType.MediaStreaming=>"media-streaming",
            RecordType.Messaging=>"messaging",
            RecordType.NoiseSuppression=>"noise-suppression",
            RecordType.Recording=>"recording",
            RecordType.SipTrunking=>"sip-trunking",
            RecordType.SiprecClient=>"siprec-client",
            RecordType.Stt=>"stt",
            RecordType.Tts=>"tts",
            RecordType.Verify=>"verify",
            RecordType.Webrtc=>"webrtc",
            RecordType.Wireless=>"wireless",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter by the given user-friendly date range. You can specify one of the following
/// enum values, or a dynamic one using this format: last_N_days.
/// </summary>
[JsonConverter(typeof(DateRangeConverter))]
public enum DateRange
{
    Yesterday,
    Today,
    Tomorrow,
    LastWeek,
    ThisWeek,
    NextWeek,
    LastMonth,
    ThisMonth,
    NextMonth
}

sealed class DateRangeConverter : JsonConverter<DateRange>
{
    public override DateRange Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "yesterday"=>DateRange.Yesterday,
            "today"=>DateRange.Today,
            "tomorrow"=>DateRange.Tomorrow,
            "last_week"=>DateRange.LastWeek,
            "this_week"=>DateRange.ThisWeek,
            "next_week"=>DateRange.NextWeek,
            "last_month"=>DateRange.LastMonth,
            "this_month"=>DateRange.ThisMonth,
            "next_month"=>DateRange.NextMonth,
            _ =>(DateRange)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DateRange value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DateRange.Yesterday=>"yesterday",
            DateRange.Today=>"today",
            DateRange.Tomorrow=>"tomorrow",
            DateRange.LastWeek=>"last_week",
            DateRange.ThisWeek=>"this_week",
            DateRange.NextWeek=>"next_week",
            DateRange.LastMonth=>"last_month",
            DateRange.ThisMonth=>"this_month",
            DateRange.NextMonth=>"next_month",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}