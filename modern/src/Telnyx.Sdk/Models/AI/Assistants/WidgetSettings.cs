using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants;

/// <summary>
/// Configuration settings for the assistant's web widget.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WidgetSettings, WidgetSettingsFromRaw>))]
public sealed record class WidgetSettings : JsonModel
{
    /// <summary>
    /// Text displayed while the agent is processing.
    /// </summary>
    public string? AgentThinkingText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "agent_thinking_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("agent_thinking_text", value);
        }
    }

    public AudioVisualizerConfig? AudioVisualizerConfig {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AudioVisualizerConfig>(
                "audio_visualizer_config"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("audio_visualizer_config", value);
        }
    }

    /// <summary>
    /// The default state of the widget.
    /// </summary>
    public ApiEnum<string, DefaultState>? DefaultState {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, DefaultState>>(
                "default_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("default_state", value);
        }
    }

    /// <summary>
    /// URL for users to give feedback.
    /// </summary>
    public string? GiveFeedbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "give_feedback_url"
            );
        }
        init { this._rawData.Set("give_feedback_url", value); }
    }

    /// <summary>
    /// URL to a custom logo icon for the widget.
    /// </summary>
    public string? LogoIconUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "logo_icon_url"
            );
        }
        init { this._rawData.Set("logo_icon_url", value); }
    }

    /// <summary>
    /// The positioning style for the widget.
    /// </summary>
    public ApiEnum<string, Position>? Position {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Position>>(
                "position"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("position", value);
        }
    }

    /// <summary>
    /// URL for users to report issues.
    /// </summary>
    public string? ReportIssueUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "report_issue_url"
            );
        }
        init { this._rawData.Set("report_issue_url", value); }
    }

    /// <summary>
    /// Text prompting users to speak to interrupt.
    /// </summary>
    public string? SpeakToInterruptText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "speak_to_interrupt_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("speak_to_interrupt_text", value);
        }
    }

    /// <summary>
    /// Custom text displayed on the start call button.
    /// </summary>
    public string? StartCallText {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "start_call_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_call_text", value);
        }
    }

    /// <summary>
    /// The visual theme for the widget.
    /// </summary>
    public ApiEnum<string, Theme>? Theme {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Theme>>(
                "theme"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("theme", value);
        }
    }

    /// <summary>
    /// URL to view conversation history.
    /// </summary>
    public string? ViewHistoryUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "view_history_url"
            );
        }
        init { this._rawData.Set("view_history_url", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AgentThinkingText;
        this.AudioVisualizerConfig?.Validate();
        this.DefaultState?.Validate();
        _ = this.GiveFeedbackUrl;
        _ = this.LogoIconUrl;
        this.Position?.Validate();
        _ = this.ReportIssueUrl;
        _ = this.SpeakToInterruptText;
        _ = this.StartCallText;
        this.Theme?.Validate();
        _ = this.ViewHistoryUrl;
    }

    public WidgetSettings ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WidgetSettings (WidgetSettings widgetSettings) : base(widgetSettings)
    {  }
    #pragma warning restore CS8618

    public WidgetSettings (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WidgetSettings (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WidgetSettingsFromRaw.FromRawUnchecked"/>
    public static WidgetSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WidgetSettingsFromRaw : IFromRawJson<WidgetSettings>
{
    /// <inheritdoc/>
    public WidgetSettings FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WidgetSettings.FromRawUnchecked(rawData);
}

/// <summary>
/// The default state of the widget.
/// </summary>
[JsonConverter(typeof(DefaultStateConverter))]
public enum DefaultState
{
    Expanded, Collapsed
}sealed class DefaultStateConverter : JsonConverter<DefaultState>
{
    public override DefaultState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "expanded"=>DefaultState.Expanded,
            "collapsed"=>DefaultState.Collapsed,
            _ =>(DefaultState)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, DefaultState value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DefaultState.Expanded=>"expanded",
            DefaultState.Collapsed=>"collapsed",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The positioning style for the widget.
/// </summary>
[JsonConverter(typeof(PositionConverter))]
public enum Position
{
    Fixed, Static
}sealed class PositionConverter : JsonConverter<Position>
{
    public override Position Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fixed"=>Position.Fixed,
            "static"=>Position.Static,
            _ =>(Position)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Position value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Position.Fixed=>"fixed",
            Position.Static=>"static",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// The visual theme for the widget.
/// </summary>
[JsonConverter(typeof(ThemeConverter))]
public enum Theme
{
    Light, Dark
}sealed class ThemeConverter : JsonConverter<Theme>
{
    public override Theme Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "light"=>Theme.Light, "dark"=>Theme.Dark, _ =>(Theme)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Theme value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Theme.Light=>"light",
            Theme.Dark=>"dark",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}