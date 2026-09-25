using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.PortingOrders;

[JsonConverter(typeof(JsonModelConverter<PortingOrdersActivationJob, PortingOrdersActivationJobFromRaw>))]
public sealed record class PortingOrdersActivationJob : JsonModel
{
    /// <summary>
    /// Uniquely identifies this activation job
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the activation job should be executed.
    /// This time should be between some activation window.
    /// </summary>
    public System::DateTimeOffset? ActivateAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "activate_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activate_at", value);
        }
    }

    /// <summary>
    /// Specifies the type of this activation job
    /// </summary>
    public ApiEnum<string, ActivationType>? ActivationType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ActivationType>>(
                "activation_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("activation_type", value);
        }
    }

    /// <summary>
    /// List of allowed activation windows for this activation job
    /// </summary>
    public IReadOnlyList<ActivationWindow>? ActivationWindows {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ActivationWindow>>(
                "activation_windows"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<ActivationWindow>?>(
                "activation_windows",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
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
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// Specifies the status of this activation job
    /// </summary>
    public ApiEnum<string, Status>? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Status>>(
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

    /// <summary>
    /// ISO 8601 formatted date indicating when the resource was created.
    /// </summary>
    public System::DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ActivateAt;
        this.ActivationType?.Validate();
        foreach (var item in this.ActivationWindows ?? [])
        {
            item.Validate();
        }
        _ = this.CreatedAt;
        _ = this.RecordType;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public PortingOrdersActivationJob ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrdersActivationJob (
        PortingOrdersActivationJob portingOrdersActivationJob
    ) : base(portingOrdersActivationJob)
    {  }
    #pragma warning restore CS8618

    public PortingOrdersActivationJob (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrdersActivationJob (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrdersActivationJobFromRaw.FromRawUnchecked"/>
    public static PortingOrdersActivationJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrdersActivationJobFromRaw : IFromRawJson<PortingOrdersActivationJob>
{
    /// <inheritdoc/>
    public PortingOrdersActivationJob FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrdersActivationJob.FromRawUnchecked(rawData);
}

/// <summary>
/// Specifies the type of this activation job
/// </summary>
[JsonConverter(typeof(ActivationTypeConverter))]
public enum ActivationType
{
    Scheduled, OnDemand
}sealed class ActivationTypeConverter : JsonConverter<ActivationType>
{
    public override ActivationType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "scheduled"=>ActivationType.Scheduled,
            "on-demand"=>ActivationType.OnDemand,
            _ =>(ActivationType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActivationType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActivationType.Scheduled=>"scheduled",
            ActivationType.OnDemand=>"on-demand",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<ActivationWindow, ActivationWindowFromRaw>))]
public sealed record class ActivationWindow : JsonModel
{
    /// <summary>
    /// ISO 8601 formatted date indicating when the activation window ends
    /// </summary>
    public System::DateTimeOffset? EndAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "end_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_at", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date indicating when the activation window starts
    /// </summary>
    public System::DateTimeOffset? StartAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "start_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EndAt;
        _ = this.StartAt;
    }

    public ActivationWindow ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActivationWindow (ActivationWindow activationWindow) : base(
        activationWindow
    )
    {  }
    #pragma warning restore CS8618

    public ActivationWindow (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActivationWindow (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActivationWindowFromRaw.FromRawUnchecked"/>
    public static ActivationWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActivationWindowFromRaw : IFromRawJson<ActivationWindow>
{
    /// <inheritdoc/>
    public ActivationWindow FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActivationWindow.FromRawUnchecked(rawData);
}/// <summary>
/// Specifies the status of this activation job
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created, InProcess, Completed, Failed
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
            "created"=>Status.Created,
            "in-process"=>Status.InProcess,
            "completed"=>Status.Completed,
            "failed"=>Status.Failed,
            _ =>(Status)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Status value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Status.Created=>"created",
            Status.InProcess=>"in-process",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}