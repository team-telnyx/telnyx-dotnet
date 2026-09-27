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
[JsonConverter(typeof(JsonModelConverter<WirelessSimCardAction, WirelessSimCardActionFromRaw>))]
public sealed record class WirelessSimCardAction : JsonModel
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
    /// the SIM card to the &lt;code&gt;standby&lt;/code&gt; status&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enable_voice&lt;/code&gt;
    /// - enable voice calling on the SIM card&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disable_voice&lt;/code&gt;
    /// - disable voice calling on the SIM card&lt;/li&gt;  &lt;/ul&gt;
    /// </summary>
    public ApiEnum<string, WirelessSimCardActionActionType>? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WirelessSimCardActionActionType>>(
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

    public WirelessSimCardActionStatus? Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<WirelessSimCardActionStatus>(
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

    public WirelessSimCardAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessSimCardAction (
        WirelessSimCardAction wirelessSimCardAction
    ) : base(wirelessSimCardAction)
    {  }
    #pragma warning restore CS8618

    public WirelessSimCardAction (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessSimCardAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessSimCardActionFromRaw.FromRawUnchecked"/>
    public static WirelessSimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WirelessSimCardActionFromRaw : IFromRawJson<WirelessSimCardAction>
{
    /// <inheritdoc/>
    public WirelessSimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessSimCardAction.FromRawUnchecked(rawData);
}

/// <summary>
/// The operation type. It can be one of the following: &lt;br/&gt; &lt;ul&gt;  &lt;li&gt;&lt;code&gt;enable&lt;/code&gt;
/// - move the SIM card to the &lt;code&gt;enabled&lt;/code&gt; status&lt;/li&gt;
///  &lt;li&gt;&lt;code&gt;enable_standby_sim_card&lt;/code&gt; - move a SIM card
/// previously on the &lt;code&gt;standby&lt;/code&gt; status to the &lt;code&gt;enabled&lt;/code&gt;
/// status after it consumes data.&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disable&lt;/code&gt;
/// - move the SIM card to the &lt;code&gt;disabled&lt;/code&gt; status&lt;/li&gt;
///  &lt;li&gt;&lt;code&gt;set_standby&lt;/code&gt; - move the SIM card to the &lt;code&gt;standby&lt;/code&gt;
/// status&lt;/li&gt;  &lt;li&gt;&lt;code&gt;enable_voice&lt;/code&gt; - enable voice
/// calling on the SIM card&lt;/li&gt;  &lt;li&gt;&lt;code&gt;disable_voice&lt;/code&gt;
/// - disable voice calling on the SIM card&lt;/li&gt;  &lt;/ul&gt;
/// </summary>
[JsonConverter(typeof(WirelessSimCardActionActionTypeConverter))]
public enum WirelessSimCardActionActionType
{
    Enable, EnableStandbySimCard, Disable, SetStandby, EnableVoice, DisableVoice
}sealed class WirelessSimCardActionActionTypeConverter : JsonConverter<WirelessSimCardActionActionType>
{
    public override WirelessSimCardActionActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "enable"=>WirelessSimCardActionActionType.Enable,
            "enable_standby_sim_card"=>WirelessSimCardActionActionType.EnableStandbySimCard,
            "disable"=>WirelessSimCardActionActionType.Disable,
            "set_standby"=>WirelessSimCardActionActionType.SetStandby,
            "enable_voice"=>WirelessSimCardActionActionType.EnableVoice,
            "disable_voice"=>WirelessSimCardActionActionType.DisableVoice,
            _ =>(WirelessSimCardActionActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WirelessSimCardActionActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WirelessSimCardActionActionType.Enable=>"enable",
            WirelessSimCardActionActionType.EnableStandbySimCard=>"enable_standby_sim_card",
            WirelessSimCardActionActionType.Disable=>"disable",
            WirelessSimCardActionActionType.SetStandby=>"set_standby",
            WirelessSimCardActionActionType.EnableVoice=>"enable_voice",
            WirelessSimCardActionActionType.DisableVoice=>"disable_voice",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(JsonModelConverter<WirelessSimCardActionStatus, WirelessSimCardActionStatusFromRaw>))]
public sealed record class WirelessSimCardActionStatus : JsonModel
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
    public ApiEnum<string, WirelessSimCardActionStatusValue>? Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, WirelessSimCardActionStatusValue>>(
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

    public WirelessSimCardActionStatus ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WirelessSimCardActionStatus (
        WirelessSimCardActionStatus wirelessSimCardActionStatus
    ) : base(wirelessSimCardActionStatus)
    {  }
    #pragma warning restore CS8618

    public WirelessSimCardActionStatus (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WirelessSimCardActionStatus (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WirelessSimCardActionStatusFromRaw.FromRawUnchecked"/>
    public static WirelessSimCardActionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class WirelessSimCardActionStatusFromRaw : IFromRawJson<WirelessSimCardActionStatus>
{
    /// <inheritdoc/>
    public WirelessSimCardActionStatus FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WirelessSimCardActionStatus.FromRawUnchecked(rawData);
}/// <summary>
/// The current status of the SIM card action.
/// </summary>
[JsonConverter(typeof(WirelessSimCardActionStatusValueConverter))]
public enum WirelessSimCardActionStatusValue
{
    InProgress, Completed, Failed, Interrupted
}sealed class WirelessSimCardActionStatusValueConverter : JsonConverter<WirelessSimCardActionStatusValue>
{
    public override WirelessSimCardActionStatusValue Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "in-progress"=>WirelessSimCardActionStatusValue.InProgress,
            "completed"=>WirelessSimCardActionStatusValue.Completed,
            "failed"=>WirelessSimCardActionStatusValue.Failed,
            "interrupted"=>WirelessSimCardActionStatusValue.Interrupted,
            _ =>(WirelessSimCardActionStatusValue)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WirelessSimCardActionStatusValue value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WirelessSimCardActionStatusValue.InProgress=>"in-progress",
            WirelessSimCardActionStatusValue.Completed=>"completed",
            WirelessSimCardActionStatusValue.Failed=>"failed",
            WirelessSimCardActionStatusValue.Interrupted=>"interrupted",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}