using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailEvents;

[JsonConverter(typeof(JsonModelConverter<EmailWebhookRecipient, EmailWebhookRecipientFromRaw>))]
public sealed record class EmailWebhookRecipient : JsonModel
{
    public required string Email {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "email"
            );
        }
        init { this._rawData.Set("email", value); }
    }

    public ApiEnum<string, Kind>? Kind {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Kind>>(
                "kind"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("kind", value);
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Email;
        this.Kind?.Validate();
        _ = this.Name;
    }

    public EmailWebhookRecipient ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailWebhookRecipient (
        EmailWebhookRecipient emailWebhookRecipient
    ) : base(emailWebhookRecipient)
    {  }
    #pragma warning restore CS8618

    public EmailWebhookRecipient (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailWebhookRecipient (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailWebhookRecipientFromRaw.FromRawUnchecked"/>
    public static EmailWebhookRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public EmailWebhookRecipient (string email) : this()
    { this.Email = email; }
}

class EmailWebhookRecipientFromRaw : IFromRawJson<EmailWebhookRecipient>
{
    /// <inheritdoc/>
    public EmailWebhookRecipient FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailWebhookRecipient.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(KindConverter))]
public enum Kind
{
    To, Cc, Bcc
}sealed class KindConverter : JsonConverter<Kind>
{
    public override Kind Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "to"=>Kind.To, "cc"=>Kind.Cc, "bcc"=>Kind.Bcc, _ =>(Kind)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Kind value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Kind.To=>"to",
            Kind.Cc=>"cc",
            Kind.Bcc=>"bcc",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}