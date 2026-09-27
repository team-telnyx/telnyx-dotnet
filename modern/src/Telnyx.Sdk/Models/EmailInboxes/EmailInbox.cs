using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailInboxes;

[JsonConverter(typeof(JsonModelConverter<EmailInbox, EmailInboxFromRaw>))]
public sealed record class EmailInbox : JsonModel
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

    public required string Address {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "address"
            );
        }
        init { this._rawData.Set("address", value); }
    }

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Domain name used by the inbox address.
    /// </summary>
    public required string Domain {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "domain"
            );
        }
        init { this._rawData.Set("domain", value); }
    }

    public required string DomainID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "domain_id"
            );
        }
        init { this._rawData.Set("domain_id", value); }
    }

    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    public required IReadOnlyDictionary<string, JsonElement> Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "settings",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required ApiEnum<string, Status> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Address;
        _ = this.CreatedAt;
        _ = this.Domain;
        _ = this.DomainID;
        this.RecordType.Validate();
        _ = this.Settings;
        this.Status.Validate();
        _ = this.UpdatedAt;
    }

    public EmailInbox ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailInbox (EmailInbox emailInbox) : base(emailInbox)
    {  }
    #pragma warning restore CS8618

    public EmailInbox (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailInbox (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailInboxFromRaw.FromRawUnchecked"/>
    public static EmailInbox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailInboxFromRaw : IFromRawJson<EmailInbox>
{
    /// <inheritdoc/>
    public EmailInbox FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailInbox.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailInbox
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_inbox"=>RecordType.EmailInbox, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailInbox=>"email_inbox",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active, Paused
}sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "active"=>Status.Active, "paused"=>Status.Paused, _ =>(Status)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Active=>"active",
            Status.Paused=>"paused",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}