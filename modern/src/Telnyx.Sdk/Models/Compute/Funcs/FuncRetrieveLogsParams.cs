using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Compute.Funcs;

/// <summary>
/// Returns logs oldest first. `type=runtime` (default) returns function stdout/stderr.
/// `type=invocations` returns one platform-generated record per HTTP request served.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class FuncRetrieveLogsParams : ParamsBase
{
    public string? ID { get; init; }

    /// <summary>
    /// Return records at or before this RFC 3339 timestamp.
    /// </summary>
    public System::DateTimeOffset? EndTime {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("end_time", value);
        }
    }

    /// <summary>
    /// Maximum records to return.
    /// </summary>
    public long? Limit {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>(
                "limit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Return records at or after this RFC 3339 timestamp.
    /// </summary>
    public System::DateTimeOffset? StartTime {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<System::DateTimeOffset>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("start_time", value);
        }
    }

    /// <summary>
    /// Log stream to return.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.Compute.Funcs.Type>? Type {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.Compute.Funcs.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public FuncRetrieveLogsParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FuncRetrieveLogsParams (
        FuncRetrieveLogsParams funcRetrieveLogsParams
    ) : base(funcRetrieveLogsParams)
    { this.ID = funcRetrieveLogsParams.ID; }
    #pragma warning restore CS8618

    public FuncRetrieveLogsParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FuncRetrieveLogsParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static FuncRetrieveLogsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(FuncRetrieveLogsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/compute/funcs/{0}/logs",
            this.ID)
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
/// Log stream to return.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    Runtime, Invocations
}

sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.Compute.Funcs.Type>
{
    public override global::Telnyx.Sdk.Models.Compute.Funcs.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "runtime"=>global::Telnyx.Sdk.Models.Compute.Funcs.Type.Runtime,
            "invocations"=>global::Telnyx.Sdk.Models.Compute.Funcs.Type.Invocations,
            _ =>(global::Telnyx.Sdk.Models.Compute.Funcs.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.Compute.Funcs.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.Compute.Funcs.Type.Runtime=>"runtime",
            global::Telnyx.Sdk.Models.Compute.Funcs.Type.Invocations=>"invocations",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}