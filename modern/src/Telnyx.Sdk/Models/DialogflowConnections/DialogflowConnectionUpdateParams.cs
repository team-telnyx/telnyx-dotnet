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

namespace Telnyx.Sdk.Models.DialogflowConnections;

/// <summary>
/// Updates the stored Dialogflow connection for the specified connection and returns
/// the updated configuration.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class DialogflowConnectionUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ConnectionID { get; init; }

    /// <summary>
    /// The JSON map to connect your Dialoglow account.
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> ServiceAccount {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "service_account"
            );
        }
        init {
            this._rawBodyData.Set<FrozenDictionary<string, JsonElement>>(
                "service_account",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The id of a configured conversation profile on your Dialogflow account. (If
    /// you use Dialogflow CX, this param is required)
    /// </summary>
    public string? ConversationProfileID {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "conversation_profile_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("conversation_profile_id", value);
        }
    }

    /// <summary>
    /// Determine which Dialogflow will be used.
    /// </summary>
    public ApiEnum<string, DialogflowConnectionUpdateParamsDialogflowApi>? DialogflowApi {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, DialogflowConnectionUpdateParamsDialogflowApi>>(
                "dialogflow_api"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("dialogflow_api", value);
        }
    }

    /// <summary>
    /// Which Dialogflow environment will be used.
    /// </summary>
    public string? Environment {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "environment"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("environment", value);
        }
    }

    /// <summary>
    /// The region of your agent is. (If you use Dialogflow CX, this param is required)
    /// </summary>
    public string? Location {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "location"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("location", value);
        }
    }

    public DialogflowConnectionUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DialogflowConnectionUpdateParams (
        DialogflowConnectionUpdateParams dialogflowConnectionUpdateParams
    ) : base(dialogflowConnectionUpdateParams)
    {
        this.ConnectionID = dialogflowConnectionUpdateParams.ConnectionID;

        this._rawBodyData = new(dialogflowConnectionUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public DialogflowConnectionUpdateParams (
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
    DialogflowConnectionUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ConnectionID = connectionID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static DialogflowConnectionUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string connectionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            connectionID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ConnectionID"] = JsonSerializer.SerializeToElement(this.ConnectionID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(DialogflowConnectionUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ConnectionID?.Equals(other.ConnectionID) ?? other.ConnectionID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/dialogflow_connections/{0}",
            EncodePathSegment(this.ConnectionID))
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
/// Determine which Dialogflow will be used.
/// </summary>
[JsonConverter(typeof(DialogflowConnectionUpdateParamsDialogflowApiConverter))]
public enum DialogflowConnectionUpdateParamsDialogflowApi
{
    Cx, Es
}

sealed class DialogflowConnectionUpdateParamsDialogflowApiConverter : JsonConverter<DialogflowConnectionUpdateParamsDialogflowApi>
{
    public override DialogflowConnectionUpdateParamsDialogflowApi Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "cx"=>DialogflowConnectionUpdateParamsDialogflowApi.Cx,
            "es"=>DialogflowConnectionUpdateParamsDialogflowApi.Es,
            _ =>(DialogflowConnectionUpdateParamsDialogflowApi)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DialogflowConnectionUpdateParamsDialogflowApi value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            DialogflowConnectionUpdateParamsDialogflowApi.Cx=>"cx",
            DialogflowConnectionUpdateParamsDialogflowApi.Es=>"es",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}