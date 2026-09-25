using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.UacConnections.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionCheckRegistrationStatusResponse, ActionCheckRegistrationStatusResponseFromRaw>))]
public sealed record class ActionCheckRegistrationStatusResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public ActionCheckRegistrationStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionCheckRegistrationStatusResponse (
        ActionCheckRegistrationStatusResponse actionCheckRegistrationStatusResponse
    ) : base(actionCheckRegistrationStatusResponse)
    {  }
    #pragma warning restore CS8618

    public ActionCheckRegistrationStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionCheckRegistrationStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionCheckRegistrationStatusResponseFromRaw.FromRawUnchecked"/>
    public static ActionCheckRegistrationStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionCheckRegistrationStatusResponseFromRaw : IFromRawJson<ActionCheckRegistrationStatusResponse>
{
    /// <inheritdoc/>
    public ActionCheckRegistrationStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionCheckRegistrationStatusResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The ip used during the SIP connection
    /// </summary>
    public string? IPAddress {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ip_address"
            );
        }
        init { this._rawData.Set("ip_address", value); }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was last updated.
    /// </summary>
    public string? LastRegistration {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "last_registration"
            );
        }
        init { this._rawData.Set("last_registration", value); }
    }

    /// <summary>
    /// The port of the SIP connection
    /// </summary>
    public long? Port {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "port"
            );
        }
        init { this._rawData.Set("port", value); }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// The user name of the SIP connection
    /// </summary>
    public string? SipUsername {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sip_username"
            );
        }
        init { this._rawData.Set("sip_username", value); }
    }

    /// <summary>
    /// The current registration status of your SIP connection
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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
    /// The protocol of the SIP connection
    /// </summary>
    public string? Transport {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "transport"
            );
        }
        init { this._rawData.Set("transport", value); }
    }

    /// <summary>
    /// The user agent of the SIP connection
    /// </summary>
    public string? UserAgent {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "user_agent"
            );
        }
        init { this._rawData.Set("user_agent", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IPAddress;
        _ = this.LastRegistration;
        _ = this.Port;
        _ = this.RecordType;
        _ = this.SipUsername;
        this.Status?.Validate();
        _ = this.Transport;
        _ = this.UserAgent;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}/// <summary>
/// The current registration status of your SIP connection
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    NotApplicable, NotRegistered, Failed, Expired, Registered, Unregistered
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "Not Applicable"=>Status.NotApplicable,
            "Not Registered"=>Status.NotRegistered,
            "Failed"=>Status.Failed,
            "Expired"=>Status.Expired,
            "Registered"=>Status.Registered,
            "Unregistered"=>Status.Unregistered,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.NotApplicable=>"Not Applicable",
            Status.NotRegistered=>"Not Registered",
            Status.Failed=>"Failed",
            Status.Expired=>"Expired",
            Status.Registered=>"Registered",
            Status.Unregistered=>"Unregistered",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}