using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.CustomStorageCredentials;

[JsonConverter(typeof(JsonModelConverter<CredentialsResponse, CredentialsResponseFromRaw>))]
public sealed record class CredentialsResponse : JsonModel
{
    /// <summary>
    /// Uniquely identifies a Telnyx application (Call Control, TeXML) or Sip connection resource.
    /// </summary>
    public required string ConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "connection_id"
            );
        }
        init { this._rawData.Set("connection_id", value); }
    }

    public required CustomStorageConfiguration Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<CustomStorageConfiguration>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <summary>
    /// Identifies record type.
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectionID;
        this.Data.Validate();
        this.RecordType.Validate();
    }

    public CredentialsResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CredentialsResponse (CredentialsResponse credentialsResponse) : base(
        credentialsResponse
    )
    {  }
    #pragma warning restore CS8618

    public CredentialsResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CredentialsResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CredentialsResponseFromRaw.FromRawUnchecked"/>
    public static CredentialsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CredentialsResponseFromRaw : IFromRawJson<CredentialsResponse>
{
    /// <inheritdoc/>
    public CredentialsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CredentialsResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Identifies record type.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    CustomStorageCredentials
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "custom_storage_credentials"=>RecordType.CustomStorageCredentials,
            _ =>(RecordType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.CustomStorageCredentials=>"custom_storage_credentials",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}