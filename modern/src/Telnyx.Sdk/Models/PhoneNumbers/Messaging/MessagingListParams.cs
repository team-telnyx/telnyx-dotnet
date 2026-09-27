using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PhoneNumbers.Messaging;

/// <summary>
/// Returns phone numbers with their current messaging product and messaging-profile assignments.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessagingListParams : ParamsBase
{
    /// <summary>
    /// Filter by messaging profile ID.
    /// </summary>
    public string? FilterMessagingProfileID {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[messaging_profile_id]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[messaging_profile_id]", value);
        }
    }

    /// <summary>
    /// Filter by exact phone number (supports comma-separated list).
    /// </summary>
    public string? FilterPhoneNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[phone_number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[phone_number]", value);
        }
    }

    /// <summary>
    /// Filter by phone number substring.
    /// </summary>
    public string? FilterPhoneNumberContains {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "filter[phone_number][contains]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[phone_number][contains]", value);
        }
    }

    /// <summary>
    /// Filter by phone number type.
    /// </summary>
    public ApiEnum<string, FilterType>? FilterType {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, FilterType>>(
                "filter[type]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("filter[type]", value);
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
    /// Sort by phone number.
    /// </summary>
    public ApiEnum<string, SortPhoneNumber>? SortPhoneNumber {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, SortPhoneNumber>>(
                "sort[phone_number]"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("sort[phone_number]", value);
        }
    }

    public MessagingListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessagingListParams (MessagingListParams messagingListParams) : base(
        messagingListParams
    )
    {  }
    #pragma warning restore CS8618

    public MessagingListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MessagingListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MessagingListParams FromRawUnchecked(
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

    public virtual bool Equals(MessagingListParams? other)
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
            options.BaseUrl.ToString().TrimEnd('/') + "/phone_numbers/messaging"
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
/// Filter by phone number type.
/// </summary>
[JsonConverter(typeof(FilterTypeConverter))]
public enum FilterType
{
    Tollfree, Longcode, Shortcode
}

sealed class FilterTypeConverter : JsonConverter<FilterType>
{
    public override FilterType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "tollfree"=>FilterType.Tollfree,
            "longcode"=>FilterType.Longcode,
            "shortcode"=>FilterType.Shortcode,
            _ =>(FilterType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, FilterType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            FilterType.Tollfree=>"tollfree",
            FilterType.Longcode=>"longcode",
            FilterType.Shortcode=>"shortcode",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}

/// <summary>
/// Sort by phone number.
/// </summary>
[JsonConverter(typeof(SortPhoneNumberConverter))]
public enum SortPhoneNumber
{
    Asc, Desc
}

sealed class SortPhoneNumberConverter : JsonConverter<SortPhoneNumber>
{
    public override SortPhoneNumber Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "asc"=>SortPhoneNumber.Asc,
            "desc"=>SortPhoneNumber.Desc,
            _ =>(SortPhoneNumber)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SortPhoneNumber value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SortPhoneNumber.Asc=>"asc",
            SortPhoneNumber.Desc=>"desc",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}