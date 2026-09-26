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

namespace Telnyx.Sdk.Models.NotificationChannels;

/// <summary>
/// Updates the specified notification channel and returns the updated channel.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class NotificationChannelUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? NotificationChannelID { get; init; }

    /// <summary>
    /// The destination associated with the channel type.
    /// </summary>
    public string? ChannelDestination {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "channel_destination"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("channel_destination", value);
        }
    }

    /// <summary>
    /// A Channel Type ID
    /// </summary>
    public ApiEnum<string, NotificationChannelUpdateParamsChannelTypeID>? ChannelTypeID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, NotificationChannelUpdateParamsChannelTypeID>>(
                "channel_type_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("channel_type_id", value);
        }
    }

    /// <summary>
    /// A UUID reference to the associated Notification Profile.
    /// </summary>
    public string? NotificationProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "notification_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("notification_profile_id", value);
        }
    }

    public NotificationChannelUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public NotificationChannelUpdateParams (
        NotificationChannelUpdateParams notificationChannelUpdateParams
    ) : base(notificationChannelUpdateParams)
    {
        this.NotificationChannelID = notificationChannelUpdateParams.NotificationChannelID;

        this._rawBodyData = new(notificationChannelUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public NotificationChannelUpdateParams (
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
    NotificationChannelUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string notificationChannelID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.NotificationChannelID = notificationChannelID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static NotificationChannelUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string notificationChannelID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            notificationChannelID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["NotificationChannelID"] = JsonSerializer.SerializeToElement(this.NotificationChannelID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(NotificationChannelUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.NotificationChannelID?.Equals(other.NotificationChannelID) ?? other.NotificationChannelID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/notification_channels/{0}",
            EncodePathSegment(this.NotificationChannelID))
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
/// A Channel Type ID
/// </summary>
[JsonConverter(typeof(NotificationChannelUpdateParamsChannelTypeIDConverter))]
public enum NotificationChannelUpdateParamsChannelTypeID
{
    Sms, Voice, Email, Webhook
}

sealed class NotificationChannelUpdateParamsChannelTypeIDConverter : JsonConverter<NotificationChannelUpdateParamsChannelTypeID>
{
    public override NotificationChannelUpdateParamsChannelTypeID Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms"=>NotificationChannelUpdateParamsChannelTypeID.Sms,
            "voice"=>NotificationChannelUpdateParamsChannelTypeID.Voice,
            "email"=>NotificationChannelUpdateParamsChannelTypeID.Email,
            "webhook"=>NotificationChannelUpdateParamsChannelTypeID.Webhook,
            _ =>(NotificationChannelUpdateParamsChannelTypeID)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        NotificationChannelUpdateParamsChannelTypeID value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            NotificationChannelUpdateParamsChannelTypeID.Sms=>"sms",
            NotificationChannelUpdateParamsChannelTypeID.Voice=>"voice",
            NotificationChannelUpdateParamsChannelTypeID.Email=>"email",
            NotificationChannelUpdateParamsChannelTypeID.Webhook=>"webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}