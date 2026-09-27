using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.EmailBlocks;

/// <summary>
/// Suppression record. Schema fields hidden by the view: `account_id`, `bounce_category`,
/// `dsn_code`, `meta`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<EmailBlock, EmailBlockFromRaw>))]
public sealed record class EmailBlock : JsonModel
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

    public required ApiEnum<string, Reason> Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Reason>>(
                "reason"
            );
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// View-only discriminator.
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

    /// <summary>
    /// Derived server-side from `domain_id`/`from`; never trusted from the caller.
    /// </summary>
    public required ApiEnum<string, Scope> Scope {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Scope>>(
                "scope"
            );
        }
        init { this._rawData.Set("scope", value); }
    }

    public required ApiEnum<string, Source> Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Source>>(
                "source"
            );
        }
        init { this._rawData.Set("source", value); }
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

    /// <summary>
    /// Normalized recipient. (schema: to_address)
    /// </summary>
    public required string To {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "to"
            );
        }
        init { this._rawData.Set("to", value); }
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
    /// `null` ⇒ account scope. Stored on the row; exposed here.
    /// </summary>
    public string? DomainID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "domain_id"
            );
        }
        init { this._rawData.Set("domain_id", value); }
    }

    /// <summary>
    /// Optional expiration time. An active row stops matching send-time suppression
    /// checks as soon as `expires_at &lt;= now()`. A maintenance worker later transitions
    /// the row to `status: expired` and appends an `expired` audit event (normally
    /// within 15 minutes).
    /// </summary>
    public System::DateTimeOffset? ExpiresAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "expires_at"
            );
        }
        init { this._rawData.Set("expires_at", value); }
    }

    /// <summary>
    /// `null` ⇒ not address-scope. (schema: from_address)
    /// </summary>
    public string? From {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "from"
            );
        }
        init { this._rawData.Set("from", value); }
    }

    /// <summary>
    /// `null` ⇒ global; set ⇒ group-scoped opt-out.
    /// </summary>
    public string? GroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "group_id"
            );
        }
        init { this._rawData.Set("group_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        this.Reason.Validate();
        this.RecordType.Validate();
        this.Scope.Validate();
        this.Source.Validate();
        this.Status.Validate();
        _ = this.To;
        _ = this.UpdatedAt;
        _ = this.DomainID;
        _ = this.ExpiresAt;
        _ = this.From;
        _ = this.GroupID;
    }

    public EmailBlock ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailBlock (EmailBlock emailBlock) : base(emailBlock)
    {  }
    #pragma warning restore CS8618

    public EmailBlock (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailBlock (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailBlockFromRaw.FromRawUnchecked"/>
    public static EmailBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailBlockFromRaw : IFromRawJson<EmailBlock>
{
    /// <inheritdoc/>
    public EmailBlock FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailBlock.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ReasonConverter))]
public enum Reason
{
    HardBounce, SpamComplaint, Unsubscribe, Invalid, ManualBlock
}sealed class ReasonConverter : JsonConverter<Reason>
{
    public override Reason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "hard_bounce"=>Reason.HardBounce,
            "spam_complaint"=>Reason.SpamComplaint,
            "unsubscribe"=>Reason.Unsubscribe,
            "invalid"=>Reason.Invalid,
            "manual_block"=>Reason.ManualBlock,
            _ =>(Reason)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Reason value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Reason.HardBounce=>"hard_bounce",
            Reason.SpamComplaint=>"spam_complaint",
            Reason.Unsubscribe=>"unsubscribe",
            Reason.Invalid=>"invalid",
            Reason.ManualBlock=>"manual_block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// View-only discriminator.
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    EmailBlock
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "email_block"=>RecordType.EmailBlock, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.EmailBlock=>"email_block",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Derived server-side from `domain_id`/`from`; never trusted from the caller.
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    Account, Domain, Address
}sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "account"=>Scope.Account,
            "domain"=>Scope.Domain,
            "address"=>Scope.Address,
            _ =>(Scope)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Scope value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Scope.Account=>"account",
            Scope.Domain=>"domain",
            Scope.Address=>"address",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(SourceConverter))]
public enum Source
{
    Feedback, Manual, Import, System
}sealed class SourceConverter : JsonConverter<Source>
{
    public override Source Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "feedback"=>Source.Feedback,
            "manual"=>Source.Manual,
            "import"=>Source.Import,
            "system"=>Source.System,
            _ =>(Source)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Source value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Source.Feedback=>"feedback",
            Source.Manual=>"manual",
            Source.Import=>"import",
            Source.System=>"system",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Active, Expired, Removed
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
            "active"=>Status.Active,
            "expired"=>Status.Expired,
            "removed"=>Status.Removed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Active=>"active",
            Status.Expired=>"expired",
            Status.Removed=>"removed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}