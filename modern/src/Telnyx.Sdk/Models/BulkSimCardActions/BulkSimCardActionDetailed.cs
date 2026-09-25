using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.BulkSimCardActions;

[JsonConverter(typeof(JsonModelConverter<BulkSimCardActionDetailed, BulkSimCardActionDetailedFromRaw>))]
public sealed record class BulkSimCardActionDetailed : JsonModel
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
    public ApiEnum<string, ActionType>? ActionType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ActionType>>(
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

    public IReadOnlyList<SimCardActionsSummary>? SimCardActionsSummary {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimCardActionsSummary>>(
                "sim_card_actions_summary"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimCardActionsSummary>?>(
                "sim_card_actions_summary",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
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
        foreach (var item in this.SimCardActionsSummary ?? [])
        {
            item.Validate();
        }
        _ = this.UpdatedAt;
    }

    public BulkSimCardActionDetailed ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BulkSimCardActionDetailed (
        BulkSimCardActionDetailed bulkSimCardActionDetailed
    ) : base(bulkSimCardActionDetailed)
    {  }
    #pragma warning restore CS8618

    public BulkSimCardActionDetailed (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BulkSimCardActionDetailed (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BulkSimCardActionDetailedFromRaw.FromRawUnchecked"/>
    public static BulkSimCardActionDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BulkSimCardActionDetailedFromRaw : IFromRawJson<BulkSimCardActionDetailed>
{
    /// <inheritdoc/>
    public BulkSimCardActionDetailed FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BulkSimCardActionDetailed.FromRawUnchecked(rawData);
}

/// <summary>
/// The action type. It can be one of the following: &lt;br/&gt; &lt;ul&gt; &lt;li&gt;&lt;code&gt;bulk_disable_voice&lt;/code&gt;
/// - disable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_enable_voice&lt;/code&gt;
/// - enable voice for every SIM Card in a SIM Card Group.&lt;/li&gt; &lt;li&gt;&lt;code&gt;bulk_set_public_ips&lt;/code&gt;
/// - set a public IP for each specified SIM Card.&lt;/li&gt; &lt;/ul&gt;
/// </summary>
[JsonConverter(typeof(ActionTypeConverter))]
public enum ActionType
{
    BulkDisableVoice, BulkEnableVoice, BulkSetPublicIps
}sealed class ActionTypeConverter : JsonConverter<ActionType>
{
    public override ActionType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "bulk_disable_voice"=>ActionType.BulkDisableVoice,
            "bulk_enable_voice"=>ActionType.BulkEnableVoice,
            "bulk_set_public_ips"=>ActionType.BulkSetPublicIps,
            _ =>(ActionType)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, ActionType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionType.BulkDisableVoice=>"bulk_disable_voice",
            ActionType.BulkEnableVoice=>"bulk_enable_voice",
            ActionType.BulkSetPublicIps=>"bulk_set_public_ips",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}