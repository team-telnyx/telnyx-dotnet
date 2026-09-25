using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.LogMessages;

[JsonConverter(typeof(JsonModelConverter<LogMessage, LogMessageFromRaw>))]
public sealed record class LogMessage : JsonModel
{
    public required string Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    public required string Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "title"
            );
        }
        init { this._rawData.Set("title", value); }
    }

    public string? Detail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "detail"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("detail", value);
        }
    }

    public Meta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Meta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    public Source? Source {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Source>(
                "source"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("source", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Title;
        _ = this.Detail;
        this.Meta?.Validate();
        this.Source?.Validate();
    }

    public LogMessage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LogMessage (LogMessage logMessage) : base(logMessage)
    {  }
    #pragma warning restore CS8618

    public LogMessage (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LogMessage (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LogMessageFromRaw.FromRawUnchecked"/>
    public static LogMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class LogMessageFromRaw : IFromRawJson<LogMessage>
{
    /// <inheritdoc/>
    public LogMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LogMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    /// <summary>
    /// The external connection the log message is associated with, if any.
    /// </summary>
    public string? ExternalConnectionID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "external_connection_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("external_connection_id", value);
        }
    }

    /// <summary>
    /// The telephone number the log message is associated with, if any.
    /// </summary>
    public string? TelephoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "telephone_number"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("telephone_number", value);
        }
    }

    /// <summary>
    /// The ticket ID for an operation that generated the log message, if any.
    /// </summary>
    public string? TicketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ticket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ticket_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ExternalConnectionID;
        _ = this.TelephoneNumber;
        _ = this.TicketID;
    }

    public Meta ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Meta (Meta meta) : base(meta)
    {  }
    #pragma warning restore CS8618

    public Meta (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Meta (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MetaFromRaw.FromRawUnchecked"/>
    public static Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class MetaFromRaw : IFromRawJson<Meta>
{
    /// <inheritdoc/>
    public Meta FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Meta.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Source, SourceFromRaw>))]
public sealed record class Source : JsonModel
{
    /// <summary>
    /// JSON pointer (RFC6901) to the offending entity.
    /// </summary>
    public string? Pointer {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "pointer"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pointer", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Pointer; }

    public Source ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Source (Source source) : base(source)
    {  }
    #pragma warning restore CS8618

    public Source (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Source (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SourceFromRaw.FromRawUnchecked"/>
    public static Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SourceFromRaw : IFromRawJson<Source>
{
    /// <inheritdoc/>
    public Source FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Source.FromRawUnchecked(rawData);
}