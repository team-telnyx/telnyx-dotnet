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
/// This object represents a bulk SIM card action. It groups SIM card actions created
/// through a bulk endpoint under a single resource for further lookup.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BulkSimCardAction, BulkSimCardActionFromRaw>))]
public sealed record class BulkSimCardAction : JsonModel
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
    /// The action type. It can be one of the following: &lt;br/&gt; &lt;ul&gt; &lt;li&gt;&lt;code&gt;bulk_disable_voice&lt;/code&gt;
    /// - disable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_enable_voice&lt;/code&gt;
    /// - enable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_set_public_ips&lt;/code&gt;
    /// - set a public IP for each specified SIM Card.&lt;/li&gt; &lt;/ul&gt;
    /// </summary>
    public ApiEnum<string, BulkSimCardActionActionType>? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, BulkSimCardActionActionType>>(
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
    /// A JSON object representation of the bulk action payload.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Settings {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "settings"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "settings",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
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
        _ = this.UpdatedAt;
    }

    public BulkSimCardAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkSimCardAction (BulkSimCardAction bulkSimCardAction) : base(
        bulkSimCardAction
    )
    {  }
    #pragma warning restore CS8618

    public BulkSimCardAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkSimCardAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BulkSimCardActionFromRaw.FromRawUnchecked"/>
    public static BulkSimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BulkSimCardActionFromRaw : IFromRawJson<BulkSimCardAction>
{
    /// <inheritdoc/>
    public BulkSimCardAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BulkSimCardAction.FromRawUnchecked(rawData);
}

/// <summary>
/// The action type. It can be one of the following: &lt;br/&gt; &lt;ul&gt; &lt;li&gt;&lt;code&gt;bulk_disable_voice&lt;/code&gt;
/// - disable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_enable_voice&lt;/code&gt;
/// - enable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_set_public_ips&lt;/code&gt;
/// - set a public IP for each specified SIM Card.&lt;/li&gt; &lt;/ul&gt;
/// </summary>
[JsonConverter(typeof(BulkSimCardActionActionTypeConverter))]
public enum BulkSimCardActionActionType
{
    BulkDisableVoice, BulkEnableVoice, BulkSetPublicIps
}sealed class BulkSimCardActionActionTypeConverter : JsonConverter<BulkSimCardActionActionType>
{
    public override BulkSimCardActionActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bulk_disable_voice"=>BulkSimCardActionActionType.BulkDisableVoice,
            "bulk_enable_voice"=>BulkSimCardActionActionType.BulkEnableVoice,
            "bulk_set_public_ips"=>BulkSimCardActionActionType.BulkSetPublicIps,
            _ =>(BulkSimCardActionActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BulkSimCardActionActionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BulkSimCardActionActionType.BulkDisableVoice=>"bulk_disable_voice",
            BulkSimCardActionActionType.BulkEnableVoice=>"bulk_enable_voice",
            BulkSimCardActionActionType.BulkSetPublicIps=>"bulk_set_public_ips",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}