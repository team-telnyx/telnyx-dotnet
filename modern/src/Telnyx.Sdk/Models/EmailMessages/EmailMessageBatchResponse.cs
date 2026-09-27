using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;
using Telnyx.Sdk.Models.EmailInboxes.Drafts;

namespace Telnyx.Sdk.Models.EmailMessages;

[JsonConverter(typeof(JsonModelConverter<EmailMessageBatchResponse, EmailMessageBatchResponseFromRaw>))]
public sealed record class EmailMessageBatchResponse : JsonModel
{
    public required IReadOnlyList<EmailMessage> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<EmailMessage>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<EmailMessage>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required IReadOnlyList<Error> Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Error>>(
                "errors"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Error>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required Meta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Meta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        foreach (var item in this.Errors)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public EmailMessageBatchResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailMessageBatchResponse (
        EmailMessageBatchResponse emailMessageBatchResponse
    ) : base(emailMessageBatchResponse)
    {  }
    #pragma warning restore CS8618

    public EmailMessageBatchResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailMessageBatchResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailMessageBatchResponseFromRaw.FromRawUnchecked"/>
    public static EmailMessageBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailMessageBatchResponseFromRaw : IFromRawJson<EmailMessageBatchResponse>
{
    /// <inheritdoc/>
    public EmailMessageBatchResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailMessageBatchResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Error, ErrorFromRaw>))]
public sealed record class Error : JsonModel
{
    /// <summary>
    /// Batch item errors use `message` (not `detail`) for the human-readable text.
    /// </summary>
    public required ApiEnum<string, Code> Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Code>>(
                "code"
            );
        }
        init { this._rawData.Set("code", value); }
    }

    /// <summary>
    /// Zero-based index of the failed message in the request array.
    /// </summary>
    public required long Index {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "index"
            );
        }
        init { this._rawData.Set("index", value); }
    }

    public required string Message {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "message"
            );
        }
        init { this._rawData.Set("message", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Code.Validate();
        _ = this.Index;
        _ = this.Message;
    }

    public Error ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Error (Error error) : base(error)
    {  }
    #pragma warning restore CS8618

    public Error (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Error (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ErrorFromRaw.FromRawUnchecked"/>
    public static Error FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ErrorFromRaw : IFromRawJson<Error>
{
    /// <inheritdoc/>
    public Error FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Error.FromRawUnchecked(rawData);
}/// <summary>
/// Batch item errors use `message` (not `detail`) for the human-readable text.
/// </summary>
[JsonConverter(typeof(CodeConverter))]
public enum Code
{
    BadRequest,
    NotFound,
    Forbidden,
    ServiceUnavailable,
    UnprocessableEntity,
    ValidationError,
    RecipientSuppressed,
    ReputationSuspended
}sealed class CodeConverter : JsonConverter<Code>
{
    public override Code Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bad_request"=>Code.BadRequest,
            "not_found"=>Code.NotFound,
            "forbidden"=>Code.Forbidden,
            "service_unavailable"=>Code.ServiceUnavailable,
            "unprocessable_entity"=>Code.UnprocessableEntity,
            "validation_error"=>Code.ValidationError,
            "recipient_suppressed"=>Code.RecipientSuppressed,
            "reputation_suspended"=>Code.ReputationSuspended,
            _ =>(Code)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Code value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Code.BadRequest=>"bad_request",
            Code.NotFound=>"not_found",
            Code.Forbidden=>"forbidden",
            Code.ServiceUnavailable=>"service_unavailable",
            Code.UnprocessableEntity=>"unprocessable_entity",
            Code.ValidationError=>"validation_error",
            Code.RecipientSuppressed=>"recipient_suppressed",
            Code.ReputationSuspended=>"reputation_suspended",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<Meta, MetaFromRaw>))]
public sealed record class Meta : JsonModel
{
    public required long Failed {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "failed"
            );
        }
        init { this._rawData.Set("failed", value); }
    }

    public required long Succeeded {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "succeeded"
            );
        }
        init { this._rawData.Set("succeeded", value); }
    }

    public required long Total {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "total"
            );
        }
        init { this._rawData.Set("total", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Failed;
        _ = this.Succeeded;
        _ = this.Total;
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
}