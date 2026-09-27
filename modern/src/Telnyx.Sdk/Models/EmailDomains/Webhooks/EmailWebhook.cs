using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailDomains.Webhooks;

[JsonConverter(typeof(JsonModelConverter<EmailWebhook, EmailWebhookFromRaw>))]
public sealed record class EmailWebhook : JsonModel
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

    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
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

    /// <summary>
    /// Allowlist of event types delivered to this webhook. At least one event is
    /// required — there is no default-to-all.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, EmailWebhookEvent>> Events {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, EmailWebhookEvent>>>(
                "events"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ApiEnum<string, EmailWebhookEvent>>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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

    public required System::DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <summary>
    /// HTTPS endpoint to deliver subscribed events to.
    /// </summary>
    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DomainID;
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        this.RecordType.Validate();
        _ = this.UpdatedAt;
        _ = this.Url;
    }

    public EmailWebhook ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailWebhook (EmailWebhook emailWebhook) : base(emailWebhook)
    {  }
    #pragma warning restore CS8618

    public EmailWebhook (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailWebhook (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailWebhookFromRaw.FromRawUnchecked"/>
    public static EmailWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailWebhookFromRaw : IFromRawJson<EmailWebhook>
{
    /// <inheritdoc/>
    public EmailWebhook FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailWebhook.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailWebhook
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_webhook"=>RecordType.EmailWebhook, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailWebhook=>"email_webhook",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}