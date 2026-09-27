using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Calls.Actions;

/// <summary>
/// Gather DTMF signals to build interactive menus.
///
/// <para>You can pass a list of valid digits. The `Answer` command must be issued
/// before the `gather` command.</para>
///
/// <para>**Expected Webhooks:**</para>
///
/// <para>- `call.dtmf.received` (you may receive many of these webhooks) - `call.gather.ended`</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ActionGatherParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? CallControlID { get; init; }

    /// <summary>
    /// Use this field to add state to every subsequent webhook. It must be a valid
    /// Base-64 encoded string.
    /// </summary>
    public string? ClientState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "client_state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("client_state", value);
        }
    }

    /// <summary>
    /// Use this field to avoid duplicate commands. Telnyx will ignore any command
    /// with the same `command_id` for the same `call_control_id`.
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
    /// An id that will be sent back in the corresponding `call.gather.ended` webhook.
    /// Will be randomly generated if not specified.
    /// </summary>
    public string? GatherID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "gather_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("gather_id", value);
        }
    }

    /// <summary>
    /// The number of milliseconds to wait for the first DTMF.
    /// </summary>
    public int? InitialTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "initial_timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("initial_timeout_millis", value);
        }
    }

    /// <summary>
    /// The number of milliseconds to wait for input between digits.
    /// </summary>
    public int? InterDigitTimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "inter_digit_timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("inter_digit_timeout_millis", value);
        }
    }

    /// <summary>
    /// The maximum number of digits to fetch. This parameter has a maximum value
    /// of 128.
    /// </summary>
    public int? MaximumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "maximum_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("maximum_digits", value);
        }
    }

    /// <summary>
    /// The minimum number of digits to fetch. This parameter has a minimum value
    /// of 1.
    /// </summary>
    public int? MinimumDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "minimum_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("minimum_digits", value);
        }
    }

    /// <summary>
    /// The digit used to terminate input if fewer than `maximum_digits` digits have
    /// been gathered. Set to an empty string to disable the terminating digit entirely,
    /// so that a digit such as `#` can be collected as input per `valid_digits`.
    /// </summary>
    public string? TerminatingDigit {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "terminating_digit"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("terminating_digit", value);
        }
    }

    /// <summary>
    /// The number of milliseconds to wait to complete the request.
    /// </summary>
    public int? TimeoutMillis {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<int>(
                "timeout_millis"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("timeout_millis", value);
        }
    }

    /// <summary>
    /// A list of all digits accepted as valid.
    /// </summary>
    public string? ValidDigits {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "valid_digits"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("valid_digits", value);
        }
    }

    public ActionGatherParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionGatherParams (ActionGatherParams actionGatherParams) : base(
        actionGatherParams
    )
    {
        this.CallControlID = actionGatherParams.CallControlID;

        this._rawBodyData = new(actionGatherParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public ActionGatherParams (
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
    ActionGatherParams (
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
    public static ActionGatherParams FromRawUnchecked(
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

    public virtual bool Equals(ActionGatherParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.CallControlID?.Equals(other.CallControlID) ?? other.CallControlID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/calls/{0}/actions/gather",
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