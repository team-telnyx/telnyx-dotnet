using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.ExternalConnections.Releases;

[JsonConverter(typeof(JsonModelConverter<Release, ReleaseFromRaw>))]
public sealed record class Release : JsonModel
{
    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// A message set if there is an error with the upload process.
    /// </summary>
    public string? ErrorMessage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "error_message"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("error_message", value);
        }
    }

    /// <summary>
    /// Represents the status of the release on Microsoft Teams.
    /// </summary>
    public ApiEnum<string, ReleaseStatus>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ReleaseStatus>>(
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

    public IReadOnlyList<TnReleaseEntry>? TelephoneNumbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<TnReleaseEntry>>(
                "telephone_numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<TnReleaseEntry>?>(
                "telephone_numbers",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? TenantID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "tenant_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <summary>
    /// Uniquely identifies the resource.
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
        _ = this.CreatedAt;
        _ = this.ErrorMessage;
        this.Status?.Validate();
        foreach (var item in this.TelephoneNumbers ?? [])
        {
            item.Validate();
        }
        _ = this.TenantID;
        _ = this.TicketID;
    }

    public Release ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Release (Release release) : base(release)
    {  }
    #pragma warning restore CS8618

    public Release (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Release (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReleaseFromRaw.FromRawUnchecked"/>
    public static Release FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ReleaseFromRaw : IFromRawJson<Release>
{
    /// <inheritdoc/>
    public Release FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Release.FromRawUnchecked(rawData);
}

/// <summary>
/// Represents the status of the release on Microsoft Teams.
/// </summary>
[JsonConverter(typeof(ReleaseStatusConverter))]
public enum ReleaseStatus
{
    PendingUpload, Pending, InProgress, Complete, Failed, Expired, Unknown
}sealed class ReleaseStatusConverter : JsonConverter<ReleaseStatus>
{
    public override ReleaseStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending_upload"=>ReleaseStatus.PendingUpload,
            "pending"=>ReleaseStatus.Pending,
            "in_progress"=>ReleaseStatus.InProgress,
            "complete"=>ReleaseStatus.Complete,
            "failed"=>ReleaseStatus.Failed,
            "expired"=>ReleaseStatus.Expired,
            "unknown"=>ReleaseStatus.Unknown,
            _ =>(ReleaseStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ReleaseStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ReleaseStatus.PendingUpload=>"pending_upload",
            ReleaseStatus.Pending=>"pending",
            ReleaseStatus.InProgress=>"in_progress",
            ReleaseStatus.Complete=>"complete",
            ReleaseStatus.Failed=>"failed",
            ReleaseStatus.Expired=>"expired",
            ReleaseStatus.Unknown=>"unknown",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}