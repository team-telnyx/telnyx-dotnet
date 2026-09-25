using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.SimCardGroups.Actions;

/// <summary>
/// This object represents a SIM card group action request. It allows tracking the
/// current status of an operation that impacts the SIM card group and SIM card in it.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SimCardGroupAction, SimCardGroupActionFromRaw>))]
public sealed record class SimCardGroupAction : JsonModel
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
    public Settings? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Settings>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("settings", value);
        }
    }

    /// <summary>
    /// The SIM card group identification.
    /// </summary>
    public string? SimCardGroupID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "sim_card_group_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("sim_card_group_id", value);
        }
    }

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
    /// Represents the type of the operation requested.
    /// </summary>
    public ApiEnum<string, global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type>? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type>>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
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
        _ = this.CreatedAt;
        _ = this.RecordType;
        this.Settings?.Validate();
        _ = this.SimCardGroupID;
        this.Status?.Validate();
        this.Type?.Validate();
        _ = this.UpdatedAt;
    }

    public SimCardGroupAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SimCardGroupAction (SimCardGroupAction simCardGroupAction) : base(
        simCardGroupAction
    )
    {  }
    #pragma warning restore CS8618

    public SimCardGroupAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SimCardGroupAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SimCardGroupActionFromRaw.FromRawUnchecked"/>
    public static SimCardGroupAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SimCardGroupActionFromRaw : IFromRawJson<SimCardGroupAction>
{
    /// <inheritdoc/>
    public SimCardGroupAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SimCardGroupAction.FromRawUnchecked(rawData);
}

/// <summary>
/// A JSON object representation of the action params.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Settings, SettingsFromRaw>))]
public sealed record class Settings : JsonModel
{
    /// <summary>
    /// The identification of the related Private Wireless Gateway resource.
    /// </summary>
    public string? PrivateWirelessGatewayID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "private_wireless_gateway_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("private_wireless_gateway_id", value);
        }
    }

    /// <summary>
    /// The identification of the related Wireless Blocklist resource.
    /// </summary>
    public string? WirelessBlocklistID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireless_blocklist_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireless_blocklist_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PrivateWirelessGatewayID;
        _ = this.WirelessBlocklistID;
    }

    public Settings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Settings (Settings settings) : base(settings)
    {  }
    #pragma warning restore CS8618

    public Settings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Settings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SettingsFromRaw.FromRawUnchecked"/>
    public static Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class SettingsFromRaw : IFromRawJson<Settings>
{
    /// <inheritdoc/>
    public Settings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Settings.FromRawUnchecked(rawData);
}[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    InProgress, Completed, Failed
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
            "in-progress"=>Status.InProgress,
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
            Status.InProgress=>"in-progress",
            Status.Completed=>"completed",
            Status.Failed=>"failed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Represents the type of the operation requested.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    SetPrivateWirelessGateway,
    RemovePrivateWirelessGateway,
    SetWirelessBlocklist,
    RemoveWirelessBlocklist
}sealed class TypeConverter : JsonConverter<global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type>
{
    public override global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "set_private_wireless_gateway"=>global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.SetPrivateWirelessGateway,
            "remove_private_wireless_gateway"=>global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.RemovePrivateWirelessGateway,
            "set_wireless_blocklist"=>global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.SetWirelessBlocklist,
            "remove_wireless_blocklist"=>global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.RemoveWirelessBlocklist,
            _ =>(global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.SetPrivateWirelessGateway=>"set_private_wireless_gateway",
            global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.RemovePrivateWirelessGateway=>"remove_private_wireless_gateway",
            global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.SetWirelessBlocklist=>"set_wireless_blocklist",
            global::Telnyx.Sdk.Models.SimCardGroups.Actions.Type.RemoveWirelessBlocklist=>"remove_wireless_blocklist",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}