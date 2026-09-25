using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.WebhookDeliveries;

/// <summary>
/// Webhook delivery attempt details.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Attempt, AttemptFromRaw>))]
public sealed record class Attempt : JsonModel
{
    /// <summary>
    /// Webhook delivery error codes.
    /// </summary>
    public IReadOnlyList<long>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<long>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<long>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 timestamp indicating when the attempt has finished.
    /// </summary>
    public System::DateTimeOffset? FinishedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "finished_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("finished_at", value);
        }
    }

    /// <summary>
    /// HTTP request and response information.
    /// </summary>
    public Http? Http {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Http>(
                "http"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("http", value);
        }
    }

    /// <summary>
    /// ISO 8601 timestamp indicating when the attempt was initiated.
    /// </summary>
    public System::DateTimeOffset? StartedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "started_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("started_at", value);
        }
    }

    public ApiEnum<string, AttemptStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, AttemptStatus>>(
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
        _ = this.Errors;
        _ = this.FinishedAt;
        this.Http?.Validate();
        _ = this.StartedAt;
        this.Status?.Validate();
    }

    public Attempt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attempt (Attempt attempt) : base(attempt)
    {  }
    #pragma warning restore CS8618

    public Attempt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Attempt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AttemptFromRaw.FromRawUnchecked"/>
    public static Attempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AttemptFromRaw : IFromRawJson<Attempt>
{
    /// <inheritdoc/>
    public Attempt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Attempt.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(AttemptStatusConverter))]
public enum AttemptStatus
{
    Delivered, Failed
}sealed class AttemptStatusConverter : JsonConverter<AttemptStatus>
{
    public override AttemptStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "delivered"=>AttemptStatus.Delivered,
            "failed"=>AttemptStatus.Failed,
            _ =>(AttemptStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AttemptStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AttemptStatus.Delivered=>"delivered",
            AttemptStatus.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}