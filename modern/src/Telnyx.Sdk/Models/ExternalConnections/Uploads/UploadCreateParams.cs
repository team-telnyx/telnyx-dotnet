using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

/// <summary>
/// Creates a new Upload request to Microsoft teams with the included phone numbers.
/// Only one of civic_address_id or location_id must be provided, not both. The maximum
/// allowed phone numbers for the numbers_ids array is 1000.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class UploadCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    public required IReadOnlyList<string> NumberIds {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "number_ids"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "number_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<ApiEnum<string, AdditionalUsage>>? AdditionalUsages {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<ApiEnum<string, AdditionalUsage>>>(
                "additional_usages"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, AdditionalUsage>>?>(
                "additional_usages",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Identifies the civic address to assign all phone numbers to.
    /// </summary>
    public string? CivicAddressID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "civic_address_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("civic_address_id", value);
        }
    }

    /// <summary>
    /// Identifies the location to assign all phone numbers to.
    /// </summary>
    public string? LocationID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "location_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("location_id", value);
        }
    }

    /// <summary>
    /// The use case of the upload request. NOTE: `calling_user_assignment` is not
    /// supported for toll free numbers.
    /// </summary>
    public ApiEnum<string, Usage>? Usage {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, Usage>>(
                "usage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("usage", value);
        }
    }

    public UploadCreateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadCreateParams (UploadCreateParams uploadCreateParams) : base(
        uploadCreateParams
    )
    {
        this.ID = uploadCreateParams.ID;

        this._rawBodyData = new(uploadCreateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public UploadCreateParams (
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
    UploadCreateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static UploadCreateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
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
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(UploadCreateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/external_connections/{0}/uploads",
            EncodePathSegment(this.ID))
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
/// Additional use cases of the upload request. If not provided, all supported usages
/// will be used.
/// </summary>
[JsonConverter(typeof(AdditionalUsageConverter))]
public enum AdditionalUsage
{
    CallingUserAssignment, FirstPartyAppAssignment
}

sealed class AdditionalUsageConverter : JsonConverter<AdditionalUsage>
{
    public override AdditionalUsage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "calling_user_assignment"=>AdditionalUsage.CallingUserAssignment,
            "first_party_app_assignment"=>AdditionalUsage.FirstPartyAppAssignment,
            _ =>(AdditionalUsage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AdditionalUsage value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AdditionalUsage.CallingUserAssignment=>"calling_user_assignment",
            AdditionalUsage.FirstPartyAppAssignment=>"first_party_app_assignment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// The use case of the upload request. NOTE: `calling_user_assignment` is not supported
/// for toll free numbers.
/// </summary>
[JsonConverter(typeof(UsageConverter))]
public enum Usage
{
    CallingUserAssignment, FirstPartyAppAssignment
}

sealed class UsageConverter : JsonConverter<Usage>
{
    public override Usage Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "calling_user_assignment"=>Usage.CallingUserAssignment,
            "first_party_app_assignment"=>Usage.FirstPartyAppAssignment,
            _ =>(Usage)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Usage value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Usage.CallingUserAssignment=>"calling_user_assignment",
            Usage.FirstPartyAppAssignment=>"first_party_app_assignment",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}