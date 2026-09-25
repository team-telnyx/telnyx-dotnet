using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences;

/// <summary>
/// Returns a paginated list of participants in the specified conference, with support
/// for filtering.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConferenceListParticipantsParams : ParamsBase
{
    public string? ConferenceID { get; init; }

    /// <summary>
    /// Consolidated filter parameter (deepObject style). Originally: filter[muted],
    /// filter[on_hold], filter[whispering]
    /// </summary>
    public ConferenceListParticipantsParamsFilter? Filter {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ConferenceListParticipantsParamsFilter>(
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
    /// Region where the conference data is located
    /// </summary>
    public ApiEnum<string, ConferenceListParticipantsParamsRegion>? Region {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, ConferenceListParticipantsParamsRegion>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("region", value);
        }
    }

    public ConferenceListParticipantsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParticipantsParams (
        ConferenceListParticipantsParams conferenceListParticipantsParams
    ) : base(conferenceListParticipantsParams)
    { this.ConferenceID = conferenceListParticipantsParams.ConferenceID; }
    #pragma warning restore CS8618

    public ConferenceListParticipantsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParticipantsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string conferenceID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ConferenceID = conferenceID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConferenceListParticipantsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string conferenceID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            conferenceID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ConferenceID"] = JsonSerializer.SerializeToElement(this.ConferenceID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ConferenceListParticipantsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConferenceID?.Equals(other.ConferenceID) ?? other.ConferenceID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/participants",
            this.ConferenceID)
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
/// Consolidated filter parameter (deepObject style). Originally: filter[muted], filter[on_hold], filter[whispering]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConferenceListParticipantsParamsFilter, ConferenceListParticipantsParamsFilterFromRaw>))]
public sealed record class ConferenceListParticipantsParamsFilter : JsonModel
{
    /// <summary>
    /// If present, participants will be filtered to those who are/are not muted
    /// </summary>
    public bool? Muted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "muted"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("muted", value);
        }
    }

    /// <summary>
    /// If present, participants will be filtered to those who are/are not put on hold
    /// </summary>
    public bool? OnHold {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "on_hold"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("on_hold", value);
        }
    }

    /// <summary>
    /// If present, participants will be filtered to those who are whispering or
    /// are not
    /// </summary>
    public bool? Whispering {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "whispering"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("whispering", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Muted;
        _ = this.OnHold;
        _ = this.Whispering;
    }

    public ConferenceListParticipantsParamsFilter ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConferenceListParticipantsParamsFilter (
        ConferenceListParticipantsParamsFilter conferenceListParticipantsParamsFilter
    ) : base(conferenceListParticipantsParamsFilter)
    {  }
    #pragma warning restore CS8618

    public ConferenceListParticipantsParamsFilter (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConferenceListParticipantsParamsFilter (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConferenceListParticipantsParamsFilterFromRaw.FromRawUnchecked"/>
    public static ConferenceListParticipantsParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConferenceListParticipantsParamsFilterFromRaw : IFromRawJson<ConferenceListParticipantsParamsFilter>
{
    /// <inheritdoc/>
    public ConferenceListParticipantsParamsFilter FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConferenceListParticipantsParamsFilter.FromRawUnchecked(rawData);
}

/// <summary>
/// Region where the conference data is located
/// </summary>
[JsonConverter(typeof(ConferenceListParticipantsParamsRegionConverter))]
public enum ConferenceListParticipantsParamsRegion
{
    Australia, Europe, MiddleEast, Us
}

sealed class ConferenceListParticipantsParamsRegionConverter : JsonConverter<ConferenceListParticipantsParamsRegion>
{
    public override ConferenceListParticipantsParamsRegion Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Australia"=>ConferenceListParticipantsParamsRegion.Australia,
            "Europe"=>ConferenceListParticipantsParamsRegion.Europe,
            "Middle East"=>ConferenceListParticipantsParamsRegion.MiddleEast,
            "US"=>ConferenceListParticipantsParamsRegion.Us,
            _ =>(ConferenceListParticipantsParamsRegion)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConferenceListParticipantsParamsRegion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ConferenceListParticipantsParamsRegion.Australia=>"Australia",
            ConferenceListParticipantsParamsRegion.Europe=>"Europe",
            ConferenceListParticipantsParamsRegion.MiddleEast=>"Middle East",
            ConferenceListParticipantsParamsRegion.Us=>"US",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}