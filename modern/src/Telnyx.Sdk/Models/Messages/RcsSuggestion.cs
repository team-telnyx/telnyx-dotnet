using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<RcsSuggestion, RcsSuggestionFromRaw>))]
public sealed record class RcsSuggestion : JsonModel
{
    /// <summary>
    /// When tapped, initiates the corresponding native action on the device.
    /// </summary>
    public Action? Action {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Action>(
                "action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("action", value);
        }
    }

    public Reply? Reply {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Reply>(
                "reply"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reply", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Action?.Validate();
        this.Reply?.Validate();
    }

    public RcsSuggestion ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RcsSuggestion (RcsSuggestion rcsSuggestion) : base(rcsSuggestion)
    {  }
    #pragma warning restore CS8618

    public RcsSuggestion (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RcsSuggestion (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RcsSuggestionFromRaw.FromRawUnchecked"/>
    public static RcsSuggestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RcsSuggestionFromRaw : IFromRawJson<RcsSuggestion>
{
    /// <inheritdoc/>
    public RcsSuggestion FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RcsSuggestion.FromRawUnchecked(rawData);
}

/// <summary>
/// When tapped, initiates the corresponding native action on the device.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Action, ActionFromRaw>))]
public sealed record class Action : JsonModel
{
    /// <summary>
    /// Opens the user's default calendar app and starts the new calendar event flow
    /// with the agent-specified event data pre-filled.
    /// </summary>
    public CreateCalendarEventAction? CreateCalendarEventAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CreateCalendarEventAction>(
                "create_calendar_event_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("create_calendar_event_action", value);
        }
    }

    /// <summary>
    /// Opens the user's default dialer app with the agent-specified phone number
    /// filled in.
    /// </summary>
    public DialAction? DialAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DialAction>(
                "dial_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("dial_action", value);
        }
    }

    /// <summary>
    /// Fallback URL to use if a client doesn't support a suggested action. Fallback
    /// URLs open in new browser windows. Maximum 2048 characters.
    /// </summary>
    public string? FallbackUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "fallback_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("fallback_url", value);
        }
    }

    /// <summary>
    /// Opens the user's default web browser app to the specified URL.
    /// </summary>
    public OpenUrlAction? OpenUrlAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OpenUrlAction>(
                "open_url_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("open_url_action", value);
        }
    }

    /// <summary>
    /// Payload (base64 encoded) that will be sent to the agent in the user event
    /// that results when the user taps the suggested action. Maximum 2048 characters.
    /// </summary>
    public string? PostbackData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postback_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postback_data", value);
        }
    }

    /// <summary>
    /// Opens the RCS app's location chooser so the user can pick a location to send
    /// back to the agent.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? ShareLocationAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "share_location_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "share_location_action",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Text that is shown in the suggested action. Maximum 25 characters.
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <summary>
    /// Opens the user's default map app and selects the agent-specified location.
    /// </summary>
    public ViewLocationAction? ViewLocationAction {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ViewLocationAction>(
                "view_location_action"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("view_location_action", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.CreateCalendarEventAction?.Validate();
        this.DialAction?.Validate();
        _ = this.FallbackUrl;
        this.OpenUrlAction?.Validate();
        _ = this.PostbackData;
        _ = this.ShareLocationAction;
        _ = this.Text;
        this.ViewLocationAction?.Validate();
    }

    public Action ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Action (Action action) : base(action)
    {  }
    #pragma warning restore CS8618

    public Action (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Action (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionFromRaw.FromRawUnchecked"/>
    public static Action FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ActionFromRaw : IFromRawJson<Action>
{
    /// <inheritdoc/>
    public Action FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Action.FromRawUnchecked(rawData);
}/// <summary>
/// Opens the user's default calendar app and starts the new calendar event flow with
/// the agent-specified event data pre-filled.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreateCalendarEventAction, CreateCalendarEventActionFromRaw>))]
public sealed record class CreateCalendarEventAction : JsonModel
{
    /// <summary>
    /// Event description. Maximum 500 characters.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public System::DateTimeOffset? EndTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "end_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("end_time", value);
        }
    }

    public System::DateTimeOffset? StartTime {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "start_time"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("start_time", value);
        }
    }

    /// <summary>
    /// Event title. Maximum 100 characters.
    /// </summary>
    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.EndTime;
        _ = this.StartTime;
        _ = this.Title;
    }

    public CreateCalendarEventAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreateCalendarEventAction (
        CreateCalendarEventAction createCalendarEventAction
    ) : base(createCalendarEventAction)
    {  }
    #pragma warning restore CS8618

    public CreateCalendarEventAction (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreateCalendarEventAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreateCalendarEventActionFromRaw.FromRawUnchecked"/>
    public static CreateCalendarEventAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class CreateCalendarEventActionFromRaw : IFromRawJson<CreateCalendarEventAction>
{
    /// <inheritdoc/>
    public CreateCalendarEventAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreateCalendarEventAction.FromRawUnchecked(rawData);
}/// <summary>
/// Opens the user's default dialer app with the agent-specified phone number filled in.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<DialAction, DialActionFromRaw>))]
public sealed record class DialAction : JsonModel
{
    /// <summary>
    /// Phone number in +E.164 format
    /// </summary>
    public required string PhoneNumber {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "phone_number"
            );
        }
        init { this._rawData.Set("phone_number", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.PhoneNumber; }

    public DialAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DialAction (DialAction dialAction) : base(dialAction)
    {  }
    #pragma warning restore CS8618

    public DialAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DialAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DialActionFromRaw.FromRawUnchecked"/>
    public static DialAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public DialAction (string phoneNumber) : this()
    { this.PhoneNumber = phoneNumber; }
}class DialActionFromRaw : IFromRawJson<DialAction>
{
    /// <inheritdoc/>
    public DialAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DialAction.FromRawUnchecked(rawData);
}/// <summary>
/// Opens the user's default web browser app to the specified URL.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<OpenUrlAction, OpenUrlActionFromRaw>))]
public sealed record class OpenUrlAction : JsonModel
{
    /// <summary>
    /// URL open application, browser or webview.
    /// </summary>
    public required ApiEnum<string, Application> Application {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Application>>(
                "application"
            );
        }
        init { this._rawData.Set("application", value); }
    }

    public required string Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "url"
            );
        }
        init { this._rawData.Set("url", value); }
    }

    public required ApiEnum<string, WebviewViewMode> WebviewViewMode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, WebviewViewMode>>(
                "webview_view_mode"
            );
        }
        init { this._rawData.Set("webview_view_mode", value); }
    }

    /// <summary>
    /// Accessbility description for webview.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Application.Validate();
        _ = this.Url;
        this.WebviewViewMode.Validate();
        _ = this.Description;
    }

    public OpenUrlAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OpenUrlAction (OpenUrlAction openUrlAction) : base(openUrlAction)
    {  }
    #pragma warning restore CS8618

    public OpenUrlAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OpenUrlAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OpenUrlActionFromRaw.FromRawUnchecked"/>
    public static OpenUrlAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OpenUrlActionFromRaw : IFromRawJson<OpenUrlAction>
{
    /// <inheritdoc/>
    public OpenUrlAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OpenUrlAction.FromRawUnchecked(rawData);
}/// <summary>
/// URL open application, browser or webview.
/// </summary>
[JsonConverter(typeof(ApplicationConverter))]
public enum Application
{
    OpenUrlApplicationUnspecified, Browser, Webview
}sealed class ApplicationConverter : JsonConverter<Application>
{
    public override Application Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPEN_URL_APPLICATION_UNSPECIFIED"=>Application.OpenUrlApplicationUnspecified,
            "BROWSER"=>Application.Browser,
            "WEBVIEW"=>Application.Webview,
            _ =>(Application)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Application value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Application.OpenUrlApplicationUnspecified=>"OPEN_URL_APPLICATION_UNSPECIFIED",
            Application.Browser=>"BROWSER",
            Application.Webview=>"WEBVIEW",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}[JsonConverter(typeof(WebviewViewModeConverter))]
public enum WebviewViewMode
{
    WebviewViewModeUnspecified, Full, Half, Tall
}sealed class WebviewViewModeConverter : JsonConverter<WebviewViewMode>
{
    public override WebviewViewMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "WEBVIEW_VIEW_MODE_UNSPECIFIED"=>WebviewViewMode.WebviewViewModeUnspecified,
            "FULL"=>WebviewViewMode.Full,
            "HALF"=>WebviewViewMode.Half,
            "TALL"=>WebviewViewMode.Tall,
            _ =>(WebviewViewMode)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebviewViewMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            WebviewViewMode.WebviewViewModeUnspecified=>"WEBVIEW_VIEW_MODE_UNSPECIFIED",
            WebviewViewMode.Full=>"FULL",
            WebviewViewMode.Half=>"HALF",
            WebviewViewMode.Tall=>"TALL",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}/// <summary>
/// Opens the user's default map app and selects the agent-specified location.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ViewLocationAction, ViewLocationActionFromRaw>))]
public sealed record class ViewLocationAction : JsonModel
{
    /// <summary>
    /// The label of the pin dropped
    /// </summary>
    public string? Label {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "label"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    public LatLong? LatLong {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<LatLong>(
                "lat_long"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lat_long", value);
        }
    }

    /// <summary>
    /// query string (Android only)
    /// </summary>
    public string? Query {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "query"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("query", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Label;
        this.LatLong?.Validate();
        _ = this.Query;
    }

    public ViewLocationAction ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ViewLocationAction (ViewLocationAction viewLocationAction) : base(
        viewLocationAction
    )
    {  }
    #pragma warning restore CS8618

    public ViewLocationAction (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ViewLocationAction (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ViewLocationActionFromRaw.FromRawUnchecked"/>
    public static ViewLocationAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ViewLocationActionFromRaw : IFromRawJson<ViewLocationAction>
{
    /// <inheritdoc/>
    public ViewLocationAction FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ViewLocationAction.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<LatLong, LatLongFromRaw>))]
public sealed record class LatLong : JsonModel
{
    /// <summary>
    /// The latitude in degrees. It must be in the range [-90.0, +90.0].
    /// </summary>
    public required double Latitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "latitude"
            );
        }
        init { this._rawData.Set("latitude", value); }
    }

    /// <summary>
    /// The longitude in degrees. It must be in the range [-180.0, +180.0].
    /// </summary>
    public required double Longitude {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>(
                "longitude"
            );
        }
        init { this._rawData.Set("longitude", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Latitude;
        _ = this.Longitude;
    }

    public LatLong ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public LatLong (LatLong latLong) : base(latLong)
    {  }
    #pragma warning restore CS8618

    public LatLong (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    LatLong (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LatLongFromRaw.FromRawUnchecked"/>
    public static LatLong FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class LatLongFromRaw : IFromRawJson<LatLong>
{
    /// <inheritdoc/>
    public LatLong FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>LatLong.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Reply, ReplyFromRaw>))]
public sealed record class Reply : JsonModel
{
    /// <summary>
    /// Payload (base64 encoded) that will be sent to the agent in the user event
    /// that results when the user taps the suggested action. Maximum 2048 characters.
    /// </summary>
    public string? PostbackData {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "postback_data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("postback_data", value);
        }
    }

    /// <summary>
    /// Text that is shown in the suggested reply (maximum 25 characters)
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PostbackData;
        _ = this.Text;
    }

    public Reply ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Reply (Reply reply) : base(reply)
    {  }
    #pragma warning restore CS8618

    public Reply (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Reply (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ReplyFromRaw.FromRawUnchecked"/>
    public static Reply FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ReplyFromRaw : IFromRawJson<Reply>
{
    /// <inheritdoc/>
    public Reply FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Reply.FromRawUnchecked(rawData);
}