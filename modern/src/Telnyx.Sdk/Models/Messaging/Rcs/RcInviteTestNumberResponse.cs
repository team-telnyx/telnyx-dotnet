using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging.Rcs;

[JsonConverter(typeof(JsonModelConverter<RcInviteTestNumberResponse, RcInviteTestNumberResponseFromRaw>))]
public sealed record class RcInviteTestNumberResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public RcInviteTestNumberResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcInviteTestNumberResponse (
        RcInviteTestNumberResponse rcInviteTestNumberResponse
    ) : base(rcInviteTestNumberResponse)
    {  }
    #pragma warning restore CS8618

    public RcInviteTestNumberResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcInviteTestNumberResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcInviteTestNumberResponseFromRaw.FromRawUnchecked"/>
    public static RcInviteTestNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public RcInviteTestNumberResponse (Data data) : this()
    { this.Data = data; }
}

class RcInviteTestNumberResponseFromRaw : IFromRawJson<RcInviteTestNumberResponse>
{
    /// <inheritdoc/>
    public RcInviteTestNumberResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcInviteTestNumberResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// RCS agent ID
    /// </summary>
    public string? AgentID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_id", value);
        }
    }

    /// <summary>
    /// Phone number that was invited for testing
    /// </summary>
    public string? PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone_number", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource
    /// </summary>
    public ApiEnum<string, DataRecordType>? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DataRecordType>>(
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
    /// Status of the test number invitation
    /// </summary>
    public string? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentID;
        _ = this.PhoneNumber;
        this.RecordType?.Validate();
        _ = this.Status;
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
/// Identifies the type of the resource
/// </summary>
[JsonConverter(typeof(DataRecordTypeConverter))]
public enum DataRecordType
{
    RcsTestNumberInvite
}sealed class DataRecordTypeConverter : JsonConverter<DataRecordType>
{
    public override DataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "rcs.test_number_invite"=>DataRecordType.RcsTestNumberInvite,
            _ =>(DataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DataRecordType.RcsTestNumberInvite=>"rcs.test_number_invite",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}