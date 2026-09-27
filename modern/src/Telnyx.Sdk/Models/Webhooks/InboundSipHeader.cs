using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Webhooks;

[JsonConverter(typeof(JsonModelConverter<InboundSipHeader, InboundSipHeaderFromRaw>))]
public sealed record class InboundSipHeader : JsonModel
{
    /// <summary>
    /// The name of the header received from the SIP INVITE.
    /// </summary>
    public required ApiEnum<string, Name> Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Name>>(
                "name"
            );
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// The value of the header.
    /// </summary>
    public required string Value {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "value"
            );
        }
        init { this._rawData.Set("value", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Name.Validate();
        _ = this.Value;
    }

    public InboundSipHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InboundSipHeader (InboundSipHeader inboundSipHeader) : base(
        inboundSipHeader
    )
    {  }
    #pragma warning restore CS8618

    public InboundSipHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InboundSipHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InboundSipHeaderFromRaw.FromRawUnchecked"/>
    public static InboundSipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InboundSipHeaderFromRaw : IFromRawJson<InboundSipHeader>
{
    /// <inheritdoc/>
    public InboundSipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InboundSipHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the header received from the SIP INVITE.
/// </summary>
[JsonConverter(typeof(NameConverter))]
public enum Name
{
    UserToUser, Diversion
}sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "User-to-User"=>Name.UserToUser,
            "Diversion"=>Name.Diversion,
            _ =>(Name)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, Name value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Name.UserToUser=>"User-to-User",
            Name.Diversion=>"Diversion",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}