using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Calls;

[JsonConverter(typeof(JsonModelConverter<SipHeader, SipHeaderFromRaw>))]
public sealed record class SipHeader : JsonModel
{
    /// <summary>
    /// The name of the header to add.
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

    public SipHeader ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SipHeader (SipHeader sipHeader) : base(sipHeader)
    {  }
    #pragma warning restore CS8618

    public SipHeader (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SipHeader (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SipHeaderFromRaw.FromRawUnchecked"/>
    public static SipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SipHeaderFromRaw : IFromRawJson<SipHeader>
{
    /// <inheritdoc/>
    public SipHeader FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SipHeader.FromRawUnchecked(rawData);
}

/// <summary>
/// The name of the header to add.
/// </summary>
[JsonConverter(typeof(NameConverter))]
public enum Name
{
    UserToUser
}sealed class NameConverter : JsonConverter<Name>
{
    public override Name Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "User-to-User"=>Name.UserToUser, _ =>(Name)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, Name value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            Name.UserToUser=>"User-to-User",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}