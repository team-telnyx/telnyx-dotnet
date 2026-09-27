using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes.Threads.Labels;

[JsonConverter(typeof(JsonModelConverter<LabelDeleteAllResponse, LabelDeleteAllResponseFromRaw>))]
public sealed record class LabelDeleteAllResponse : JsonModel
{
    public required LabelDeleteAllResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LabelDeleteAllResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public LabelDeleteAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelDeleteAllResponse (
        LabelDeleteAllResponse labelDeleteAllResponse
    ) : base(labelDeleteAllResponse)
    {  }
    #pragma warning restore CS8618

    public LabelDeleteAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelDeleteAllResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LabelDeleteAllResponseFromRaw.FromRawUnchecked"/>
    public static LabelDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public LabelDeleteAllResponse (LabelDeleteAllResponseData data) : this()
    { this.Data = data; }
}

class LabelDeleteAllResponseFromRaw : IFromRawJson<LabelDeleteAllResponse>
{
    /// <inheritdoc/>
    public LabelDeleteAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LabelDeleteAllResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<LabelDeleteAllResponseData, LabelDeleteAllResponseDataFromRaw>))]
public sealed record class LabelDeleteAllResponseData : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required IReadOnlyList<string> Labels {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "labels"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "labels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, LabelDeleteAllResponseDataRecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, LabelDeleteAllResponseDataRecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public string? InboxID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "inbox_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inbox_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Labels;
        this.RecordType.Validate();
        _ = this.InboxID;
    }

    public LabelDeleteAllResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LabelDeleteAllResponseData (
        LabelDeleteAllResponseData labelDeleteAllResponseData
    ) : base(labelDeleteAllResponseData)
    {  }
    #pragma warning restore CS8618

    public LabelDeleteAllResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LabelDeleteAllResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LabelDeleteAllResponseDataFromRaw.FromRawUnchecked"/>
    public static LabelDeleteAllResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class LabelDeleteAllResponseDataFromRaw : IFromRawJson<LabelDeleteAllResponseData>
{
    /// <inheritdoc/>
    public LabelDeleteAllResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LabelDeleteAllResponseData.FromRawUnchecked(rawData);
}[JsonConverter(typeof(LabelDeleteAllResponseDataRecordTypeConverter))]
public enum LabelDeleteAllResponseDataRecordType
{
    EmailThread
}sealed class LabelDeleteAllResponseDataRecordTypeConverter : JsonConverter<LabelDeleteAllResponseDataRecordType>
{
    public override LabelDeleteAllResponseDataRecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "email_thread"=>LabelDeleteAllResponseDataRecordType.EmailThread,
            _ =>(LabelDeleteAllResponseDataRecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        LabelDeleteAllResponseDataRecordType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            LabelDeleteAllResponseDataRecordType.EmailThread=>"email_thread",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}