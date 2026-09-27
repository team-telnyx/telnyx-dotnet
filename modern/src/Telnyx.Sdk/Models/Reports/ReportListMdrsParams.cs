using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Reports;

/// <summary>
/// Returns message detail records (MDRs) matching the provided criteria, such as
/// date range, direction, status, and message type.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ReportListMdrsParams : ParamsBase
{
    /// <summary>
    /// Filter results by identifier.
    /// </summary>
    public string? ID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("id", value);
        }
    }

    /// <summary>
    /// Filter results by cld.
    /// </summary>
    public string? Cld {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "cld"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("cld", value);
        }
    }

    /// <summary>
    /// Filter results by cli.
    /// </summary>
    public string? Cli {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "cli"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("cli", value);
        }
    }

    /// <summary>
    /// Filter results by direction.
    /// </summary>
    public ApiEnum<string, Direction>? Direction {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Direction>>(
                "direction"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("direction", value);
        }
    }

    /// <summary>
    /// Pagination end date
    /// </summary>
    public string? EndDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "end_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("end_date", value);
        }
    }

    /// <summary>
    /// Filter results by message type.
    /// </summary>
    public ApiEnum<string, MessageType>? MessageType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, MessageType>>(
                "message_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("message_type", value);
        }
    }

    /// <summary>
    /// Filter results by profile.
    /// </summary>
    public string? Profile {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "profile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("profile", value);
        }
    }

    /// <summary>
    /// Pagination start date
    /// </summary>
    public string? StartDate {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "start_date"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("start_date", value);
        }
    }

    /// <summary>
    /// Filter results by status.
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("status", value);
        }
    }

    public ReportListMdrsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReportListMdrsParams (
        ReportListMdrsParams reportListMdrsParams
    ) : base(reportListMdrsParams)
    {  }
    #pragma warning restore CS8618

    public ReportListMdrsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ReportListMdrsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ReportListMdrsParams FromRawUnchecked(
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

    public virtual bool Equals(ReportListMdrsParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/reports/mdrs"
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
/// Filter results by direction.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound, Outbound
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "INBOUND"=>Direction.Inbound,
            "OUTBOUND"=>Direction.Outbound,
            _ =>(Direction)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Direction value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Direction.Inbound=>"INBOUND",
            Direction.Outbound=>"OUTBOUND",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter results by message type.
/// </summary>
[JsonConverter(typeof(MessageTypeConverter))]
public enum MessageType
{
    Sms, Mms
}

sealed class MessageTypeConverter : JsonConverter<MessageType>
{
    public override MessageType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "SMS"=>MessageType.Sms,
            "MMS"=>MessageType.Mms,
            _ =>(MessageType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, MessageType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            MessageType.Sms=>"SMS",
            MessageType.Mms=>"MMS",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Filter results by status.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    GwTimeout, Delivered, DlrUnconfirmed, DlrTimeout, Received, GwReject, Failed
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "GW_TIMEOUT"=>Status.GwTimeout,
            "DELIVERED"=>Status.Delivered,
            "DLR_UNCONFIRMED"=>Status.DlrUnconfirmed,
            "DLR_TIMEOUT"=>Status.DlrTimeout,
            "RECEIVED"=>Status.Received,
            "GW_REJECT"=>Status.GwReject,
            "FAILED"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.GwTimeout=>"GW_TIMEOUT",
            Status.Delivered=>"DELIVERED",
            Status.DlrUnconfirmed=>"DLR_UNCONFIRMED",
            Status.DlrTimeout=>"DLR_TIMEOUT",
            Status.Received=>"RECEIVED",
            Status.GwReject=>"GW_REJECT",
            Status.Failed=>"FAILED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}