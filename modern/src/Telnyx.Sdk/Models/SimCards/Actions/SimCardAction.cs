using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCards.Actions;

/// <summary>
/// This object represents a SIM card action. It allows tracking the current status
/// of an operation that impacts the SIM card.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardAction, SimCardActionFromRaw>))]
public sealed record class SimCardAction : JsonModel
{
    /// <summary>
    /// Identifies the resource.
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
    /// The operation type. It can be one of the following: &lt;br/&gt; &lt;ul&gt;
    ///  &lt;li&gt;&lt;code&gt;enable&lt;/code&gt; - move the SIM card to the &lt;code&gt;enabled&lt;/code&gt;
    /// status&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enable_standby_sim_card&lt;/code&gt;
    /// - move a SIM card previously on the &lt;code&gt;standby&lt;/code&gt; status
    /// to the &lt;code&gt;enabled&lt;/code&gt; status after it consumes data.&lt;/li&gt;
    ///  &lt;li&gt;&lt;code&gt;disable&lt;/code&gt; - move the SIM card to the &lt;code&gt;disabled&lt;/code&gt;
    /// status&lt;/li&gt;  &lt;li&gt;&lt;code&gt;set_standby&lt;/code&gt; - move
    /// the SIM card to the &lt;code&gt;standby&lt;/code&gt; status&lt;/li&gt;  &lt;/ul&gt;
    /// </summary>
    public ApiEnum<string, SimCardActionActionType>? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, SimCardActionActionType>>(
                "action_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
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
    /// A JSON object representation of the action params.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The related SIM card identifier.
    /// </summary>
    public string? SimCardID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_id", value);
        }
    }

    public SimCardActionStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SimCardActionStatus>(
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
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
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
        this.ActionType?.Validate();
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.Settings;
        _ = this.SimCardID;
        this.Status?.Validate();
        _ = this.UpdatedAt;
    }

    public SimCardAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardAction (SimCardAction simCardAction) : base(simCardAction)
    {  }
    #pragma warning restore CS8618

    public SimCardAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardActionFromRaw.FromRawUnchecked"/>
    public static SimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardActionFromRaw : IFromRawJson<SimCardAction>
{
    /// <inheritdoc/>
    public SimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardAction.FromRawUnchecked(rawData);
}

/// <summary>
/// The operation type. It can be one of the following: &lt;br/&gt; &lt;ul&gt;  &lt;li&gt;&lt;code&gt;enable&lt;/code&gt;
/// - move the SIM card to the &lt;code&gt;enabled&lt;/code&gt; status&lt;/li&gt;
///  &lt;li&gt;&lt;code&gt;enable_standby_sim_card&lt;/code&gt; - move a SIM card
/// previously on the &lt;code&gt;standby&lt;/code&gt; status to the &lt;code&gt;enabled&lt;/code&gt;
/// status after it consumes data.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disable&lt;/code&gt;
/// - move the SIM card to the &lt;code&gt;disabled&lt;/code&gt; status&lt;/li&gt;
///  &lt;li&gt;&lt;code&gt;set_standby&lt;/code&gt; - move the SIM card to the &lt;code&gt;standby&lt;/code&gt;
/// status&lt;/li&gt;  &lt;/ul&gt;
/// </summary>
[JsonConverter(typeof(SimCardActionActionTypeConverter))]
public enum SimCardActionActionType
{
    Enable, EnableStandbySimCard, Disable, SetStandby
}sealed class SimCardActionActionTypeConverter : JsonConverter<SimCardActionActionType>
{
    public override SimCardActionActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enable"=>SimCardActionActionType.Enable,
            "enable_standby_sim_card"=>SimCardActionActionType.EnableStandbySimCard,
            "disable"=>SimCardActionActionType.Disable,
            "set_standby"=>SimCardActionActionType.SetStandby,
            _ =>(SimCardActionActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SimCardActionActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            SimCardActionActionType.Enable=>"enable",
            SimCardActionActionType.EnableStandbySimCard=>"enable_standby_sim_card",
            SimCardActionActionType.Disable=>"disable",
            SimCardActionActionType.SetStandby=>"set_standby",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<SimCardActionStatus, SimCardActionStatusFromRaw>))]
public sealed record class SimCardActionStatus : JsonModel
{
    /// <summary>
    /// It describes why the SIM card action is in the current status. This will
    /// be &lt;code&gt;null&lt;/code&gt; for self-explanatory statuses, such as &lt;code&gt;in-progress&lt;/code&gt;
    /// and &lt;code&gt;completed&lt;/code&gt; but will include further information
    /// on statuses like &lt;code&gt;interrupted&lt;/code&gt; and &lt;code&gt;failed&lt;/code&gt;.
    /// </summary>
    public string? Reason {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "reason"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reason", value);
        }
    }

    /// <summary>
    /// The current status of the SIM card action.
    /// </summary>
    public ApiEnum<string, Value>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Value>>(
                "value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("value", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Reason;
        this.Value?.Validate();
    }

    public SimCardActionStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardActionStatus (SimCardActionStatus simCardActionStatus) : base(
        simCardActionStatus
    )
    {  }
    #pragma warning restore CS8618

    public SimCardActionStatus (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardActionStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardActionStatusFromRaw.FromRawUnchecked"/>
    public static SimCardActionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SimCardActionStatusFromRaw : IFromRawJson<SimCardActionStatus>
{
    /// <inheritdoc/>
    public SimCardActionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardActionStatus.FromRawUnchecked(rawData);
}/// <summary>
/// The current status of the SIM card action.
/// </summary>
[JsonConverter(typeof(ValueConverter))]
public enum Value
{
    InProgress, Completed, Failed, Interrupted
}sealed class ValueConverter : JsonConverter<Value>
{
    public override Value Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>Value.InProgress,
            "completed"=>Value.Completed,
            "failed"=>Value.Failed,
            "interrupted"=>Value.Interrupted,
            _ =>(Value)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Value value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Value.InProgress=>"in-progress",
            Value.Completed=>"completed",
            Value.Failed=>"failed",
            Value.Interrupted=>"interrupted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}