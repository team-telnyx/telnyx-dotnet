using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SessionAnalysis;

/// <summary>
/// Retrieves a full session analysis tree for a given event, including costs, child
/// events, and product linkages.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SessionAnalysisRetrieveParams : ParamsBase
{
    public required string RecordType { get; init; }

    public string? EventID { get; init; }

    /// <summary>
    /// ISO 8601 timestamp or date to narrow index selection for faster lookups.
    /// Accepts full datetime (e.g., 2026-03-17T10:00:00Z) or date-only format (e.g., 2026-03-17).
    /// </summary>
    public System::DateTimeOffset? DateTime {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "date_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("date_time", value);
        }
    }

    /// <summary>
    /// Controls what data to expand on each event node.
    /// </summary>
    public ApiEnum<string, Expand>? Expand {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Expand>>(
                "expand"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("expand", value);
        }
    }

    /// <summary>
    /// Whether to include child events in the response.
    /// </summary>
    public bool? IncludeChildren {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<bool>(
                "include_children"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("include_children", value);
        }
    }

    /// <summary>
    /// Maximum traversal depth for the event tree.
    /// </summary>
    public long? MaxDepth {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "max_depth"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("max_depth", value);
        }
    }

    public SessionAnalysisRetrieveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SessionAnalysisRetrieveParams (
        SessionAnalysisRetrieveParams sessionAnalysisRetrieveParams
    ) : base(sessionAnalysisRetrieveParams)
    {
        this.RecordType = sessionAnalysisRetrieveParams.RecordType;
        this.EventID = sessionAnalysisRetrieveParams.EventID;
    }
    #pragma warning restore CS8618

    public SessionAnalysisRetrieveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SessionAnalysisRetrieveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string recordType,
        string eventID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RecordType = recordType;
        this.EventID = eventID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SessionAnalysisRetrieveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string recordType,
        string eventID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            recordType,
            eventID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["RecordType"] = JsonSerializer.SerializeToElement(this.RecordType),
        ["EventID"] = JsonSerializer.SerializeToElement(this.EventID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(SessionAnalysisRetrieveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.RecordType.Equals(other.RecordType)&&(this.EventID?.Equals(other.EventID) ?? other.EventID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/session_analysis/{0}/{1}",
            EncodePathSegment(this.RecordType),
            EncodePathSegment(this.EventID))
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
/// Controls what data to expand on each event node.
/// </summary>
[JsonConverter(typeof(ExpandConverter))]
public enum Expand
{
    Record, None
}

sealed class ExpandConverter : JsonConverter<Expand>
{
    public override Expand Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "record"=>Expand.Record, "none"=>Expand.None, _ =>(Expand)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Expand value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Expand.Record=>"record",
            Expand.None=>"none",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}