using System = System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.OAuthGrants;

[JsonConverter(typeof(JsonModelConverter<OAuthGrant, OAuthGrantFromRaw>))]
public sealed record class OAuthGrant : JsonModel
{
    /// <summary>
    /// Unique identifier for the OAuth grant
    /// </summary>
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// OAuth client identifier
    /// </summary>
    public required string ClientID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "client_id"
            );
        }
        init { this._rawData.Set("client_id", value); }
    }

    /// <summary>
    /// Timestamp when the grant was created
    /// </summary>
    public required System::DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<System::DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Record type identifier
    /// </summary>
    public required ApiEnum<string, RecordType> RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RecordType>>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// List of granted OAuth scopes
    /// </summary>
    public required IReadOnlyList<string> Scopes {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "scopes"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "scopes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Timestamp when the grant was last used
    /// </summary>
    public System::DateTimeOffset? LastUsedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<System::DateTimeOffset>(
                "last_used_at"
            );
        }
        init { this._rawData.Set("last_used_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ClientID;
        _ = this.CreatedAt;
        this.RecordType.Validate();
        _ = this.Scopes;
        _ = this.LastUsedAt;
    }

    public OAuthGrant ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public OAuthGrant (OAuthGrant oauthGrant) : base(oauthGrant)
    {  }
    #pragma warning restore CS8618

    public OAuthGrant (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    OAuthGrant (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OAuthGrantFromRaw.FromRawUnchecked"/>
    public static OAuthGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class OAuthGrantFromRaw : IFromRawJson<OAuthGrant>
{
    /// <inheritdoc/>
    public OAuthGrant FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>OAuthGrant.FromRawUnchecked(rawData);
}

/// <summary>
/// Record type identifier
/// </summary>
[JsonConverter(typeof(RecordTypeConverter))]
public enum RecordType
{
    OAuthGrant
}sealed class RecordTypeConverter : JsonConverter<RecordType>
{
    public override RecordType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        { "oauth_grant"=>RecordType.OAuthGrant, _ =>(RecordType)(-1) };
    }

    public override void Write(
        Utf8JsonWriter writer, RecordType value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            RecordType.OAuthGrant=>"oauth_grant",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}