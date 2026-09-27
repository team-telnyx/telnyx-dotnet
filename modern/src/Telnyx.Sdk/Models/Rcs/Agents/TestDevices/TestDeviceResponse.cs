using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Rcs.Agents.TestDevices;

[JsonConverter(typeof(JsonModelConverter<TestDeviceResponse, TestDeviceResponseFromRaw>))]
public sealed record class TestDeviceResponse : JsonModel
{
    public required ApiEnum<string, InviteStatus> InviteStatus {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, InviteStatus>>(
                "invite_status"
            );
        }
        init { this._rawData.Set("invite_status", value); }
    }

    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    public required string TestDeviceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "test_device_id"
            );
        }
        init { this._rawData.Set("test_device_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.InviteStatus.Validate();
        _ = this.PhoneNumber;
        _ = this.TestDeviceID;
    }

    public TestDeviceResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TestDeviceResponse (TestDeviceResponse testDeviceResponse) : base(
        testDeviceResponse
    )
    {  }
    #pragma warning restore CS8618

    public TestDeviceResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TestDeviceResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TestDeviceResponseFromRaw.FromRawUnchecked"/>
    public static TestDeviceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TestDeviceResponseFromRaw : IFromRawJson<TestDeviceResponse>
{
    /// <inheritdoc/>
    public TestDeviceResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TestDeviceResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(InviteStatusConverter))]
public enum InviteStatus
{
    Pending, Accepted, Declined
}sealed class InviteStatusConverter : JsonConverter<InviteStatus>
{
    public override InviteStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING"=>InviteStatus.Pending,
            "ACCEPTED"=>InviteStatus.Accepted,
            "DECLINED"=>InviteStatus.Declined,
            _ =>(InviteStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, InviteStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            InviteStatus.Pending=>"PENDING",
            InviteStatus.Accepted=>"ACCEPTED",
            InviteStatus.Declined=>"DECLINED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}