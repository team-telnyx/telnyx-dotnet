using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Calls.Actions;

namespace Telnyx.Sdk.Models.Calls;

/// <summary>
/// Settings for handling caller interruptions during Conversation Relay speech.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ConversationRelayInterruptionSettings, ConversationRelayInterruptionSettingsFromRaw>))]
public sealed record class ConversationRelayInterruptionSettings : JsonModel
{
    /// <summary>
    /// Legacy boolean form. `true` is equivalent to `interruptible=any`; `false`
    /// is equivalent to `interruptible=none`.
    /// </summary>
    public bool? Enable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "enable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("enable", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? Interruptible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruptible", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? InterruptibleGreeting {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "interruptible_greeting"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("interruptible_greeting", value);
        }
    }

    /// <summary>
    /// Controls when caller input can interrupt assistant speech. `any` allows speech
    /// or DTMF interruptions; `none` disables interruptions; `speech` allows speech
    /// only; `dtmf` allows DTMF only.
    /// </summary>
    public ApiEnum<string, ConversationRelayInterruptible>? WelcomeGreetingInterruptible {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, ConversationRelayInterruptible>>(
                "welcome_greeting_interruptible"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("welcome_greeting_interruptible", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Enable;
        this.Interruptible?.Validate();
        this.InterruptibleGreeting?.Validate();
        this.WelcomeGreetingInterruptible?.Validate();
    }

    public ConversationRelayInterruptionSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRelayInterruptionSettings (
        ConversationRelayInterruptionSettings conversationRelayInterruptionSettings
    ) : base(conversationRelayInterruptionSettings)
    {  }
    #pragma warning restore CS8618

    public ConversationRelayInterruptionSettings (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRelayInterruptionSettings (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRelayInterruptionSettingsFromRaw.FromRawUnchecked"/>
    public static ConversationRelayInterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ConversationRelayInterruptionSettingsFromRaw : IFromRawJson<ConversationRelayInterruptionSettings>
{
    /// <inheritdoc/>
    public ConversationRelayInterruptionSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConversationRelayInterruptionSettings.FromRawUnchecked(rawData);
}