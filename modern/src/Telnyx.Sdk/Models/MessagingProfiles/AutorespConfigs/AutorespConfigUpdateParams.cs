using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

/// <summary>
/// Replaces the configuration of the specified auto-response rule.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AutorespConfigUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string ProfileID { get; init; }

    public string? AutorespCfgID { get; init; }

    public required string CountryCode {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "country_code"
            );
        }
        init { this._rawBodyData.Set("country_code", value); }
    }

    public required IReadOnlyList<string> Keywords {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<string>>(
                "keywords"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<string>>(
                "keywords",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required ApiEnum<string, AutorespConfigUpdateParamsOp> Op {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, AutorespConfigUpdateParamsOp>>(
                "op"
            );
        }
        init { this._rawBodyData.Set("op", value); }
    }

    public string? RespText {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "resp_text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("resp_text", value);
        }
    }

    public AutorespConfigUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutorespConfigUpdateParams (
        AutorespConfigUpdateParams autorespConfigUpdateParams
    ) : base(autorespConfigUpdateParams)
    {
        this.ProfileID = autorespConfigUpdateParams.ProfileID;
        this.AutorespCfgID = autorespConfigUpdateParams.AutorespCfgID;

        this._rawBodyData = new(autorespConfigUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public AutorespConfigUpdateParams (
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
    AutorespConfigUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string profileID,
        string autorespCfgID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ProfileID = profileID;
        this.AutorespCfgID = autorespCfgID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AutorespConfigUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string profileID,
        string autorespCfgID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            profileID,
            autorespCfgID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
        ["AutorespCfgID"] = JsonSerializer.SerializeToElement(this.AutorespCfgID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AutorespConfigUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.ProfileID.Equals(other.ProfileID)&&(this.AutorespCfgID?.Equals(other.AutorespCfgID) ?? other.AutorespCfgID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override System::Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new System::UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/messaging_profiles/{0}/autoresp_configs/{1}",
            EncodePathSegment(this.ProfileID),
            EncodePathSegment(this.AutorespCfgID))
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

[JsonConverter(typeof(AutorespConfigUpdateParamsOpConverter))]
public enum AutorespConfigUpdateParamsOp
{
    Start, Stop, Info
}

sealed class AutorespConfigUpdateParamsOpConverter : JsonConverter<AutorespConfigUpdateParamsOp>
{
    public override AutorespConfigUpdateParamsOp Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "start"=>AutorespConfigUpdateParamsOp.Start,
            "stop"=>AutorespConfigUpdateParamsOp.Stop,
            "info"=>AutorespConfigUpdateParamsOp.Info,
            _ =>(AutorespConfigUpdateParamsOp)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        AutorespConfigUpdateParamsOp value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            AutorespConfigUpdateParamsOp.Start=>"start",
            AutorespConfigUpdateParamsOp.Stop=>"stop",
            AutorespConfigUpdateParamsOp.Info=>"info",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}