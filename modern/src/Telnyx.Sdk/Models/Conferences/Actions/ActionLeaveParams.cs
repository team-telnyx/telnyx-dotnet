using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Conferences.Actions;

/// <summary>
/// Removes a call leg from a conference and moves it back to parked state.
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `conference.participant.left`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionLeaveParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Unique identifier and token for controlling the call
    /// </summary>
    public required string CallControlID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "call_control_id"
            );
        }
        init { this._rawBodyData.Set("call_control_id", value); }
    }

    /// <summary>
    /// Whether a beep sound should be played when the participant leaves the conference.
    /// Can be used to override the conference-level setting.
    /// </summary>
    public ApiEnum<string, ActionLeaveParamsBeepEnabled>? BeepEnabled {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ActionLeaveParamsBeepEnabled>>(
                "beep_enabled"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("beep_enabled", value);
        }
    }

    /// <summary>
    /// Use this field to avoid execution of duplicate commands. Telnyx will ignore
    /// subsequent commands with the same `command_id` as one that has already been executed.
    /// </summary>
    public string? CommandID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "command_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("command_id", value);
        }
    }

    /// <summary>
    /// Region where the conference data is located. Defaults to the region defined
    /// in user's data locality settings (Europe or US).
    /// </summary>
    public ApiEnum<string, ConferenceRegion>? Region {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConferenceRegion>>(
                "region"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("region", value);
        }
    }

    public ActionLeaveParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionLeaveParams (ActionLeaveParams actionLeaveParams) : base(
        actionLeaveParams
    )
    {
        this.ID = actionLeaveParams.ID;

        this._rawBodyData = new(actionLeaveParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionLeaveParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionLeaveParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionLeaveParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionLeaveParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/conferences/{0}/actions/leave",
            EncodePathSegment(this.ID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Whether a beep sound should be played when the participant leaves the conference.
/// Can be used to override the conference-level setting.
/// </summary>
[JsonConverter(typeof(ActionLeaveParamsBeepEnabledConverter))]
public enum ActionLeaveParamsBeepEnabled
{
    Always, Never, OnEnter, OnExit
}

sealed class ActionLeaveParamsBeepEnabledConverter : JsonConverter<ActionLeaveParamsBeepEnabled>
{
    public override ActionLeaveParamsBeepEnabled Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "always"=>ActionLeaveParamsBeepEnabled.Always,
            "never"=>ActionLeaveParamsBeepEnabled.Never,
            "on_enter"=>ActionLeaveParamsBeepEnabled.OnEnter,
            "on_exit"=>ActionLeaveParamsBeepEnabled.OnExit,
            _ =>(ActionLeaveParamsBeepEnabled)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionLeaveParamsBeepEnabled value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionLeaveParamsBeepEnabled.Always=>"always",
            ActionLeaveParamsBeepEnabled.Never=>"never",
            ActionLeaveParamsBeepEnabled.OnEnter=>"on_enter",
            ActionLeaveParamsBeepEnabled.OnExit=>"on_exit",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}