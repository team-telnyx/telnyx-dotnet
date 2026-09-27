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

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Switch the supervisor role for a bridged call. This allows switching between
/// different supervisor modes during an active call
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionSwitchSupervisorRoleParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// The supervisor role to switch to. 'barge' allows speaking to both parties,
    /// 'whisper' allows speaking to caller only, 'monitor' allows listening only.
    /// </summary>
    public required ApiEnum<string, ActionSwitchSupervisorRoleParamsRole> Role {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, ActionSwitchSupervisorRoleParamsRole>>(
                "role"
            );
        }
        init { this._rawBodyData.Set("role", value); }
    }

    public ActionSwitchSupervisorRoleParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionSwitchSupervisorRoleParams (
        ActionSwitchSupervisorRoleParams actionSwitchSupervisorRoleParams
    ) : base(actionSwitchSupervisorRoleParams)
    {
        this.CallControlID = actionSwitchSupervisorRoleParams.CallControlID;

        this._rawBodyData = new(actionSwitchSupervisorRoleParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionSwitchSupervisorRoleParams (
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
    ActionSwitchSupervisorRoleParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.CallControlID = callControlID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ActionSwitchSupervisorRoleParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string callControlID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            callControlID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["CallControlID"] = JsonSerializer.SerializeToElement(this.CallControlID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(ActionSwitchSupervisorRoleParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/switch_supervisor_role",
            EncodePathSegment(this.CallControlID))
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
/// The supervisor role to switch to. 'barge' allows speaking to both parties, 'whisper'
/// allows speaking to caller only, 'monitor' allows listening only.
/// </summary>
[JsonConverter(typeof(ActionSwitchSupervisorRoleParamsRoleConverter))]
public enum ActionSwitchSupervisorRoleParamsRole
{
    Barge, Whisper, Monitor
}

sealed class ActionSwitchSupervisorRoleParamsRoleConverter : JsonConverter<ActionSwitchSupervisorRoleParamsRole>
{
    public override ActionSwitchSupervisorRoleParamsRole Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "barge"=>ActionSwitchSupervisorRoleParamsRole.Barge,
            "whisper"=>ActionSwitchSupervisorRoleParamsRole.Whisper,
            "monitor"=>ActionSwitchSupervisorRoleParamsRole.Monitor,
            _ =>(ActionSwitchSupervisorRoleParamsRole)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ActionSwitchSupervisorRoleParamsRole value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            ActionSwitchSupervisorRoleParamsRole.Barge=>"barge",
            ActionSwitchSupervisorRoleParamsRole.Whisper=>"whisper",
            ActionSwitchSupervisorRoleParamsRole.Monitor=>"monitor",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}