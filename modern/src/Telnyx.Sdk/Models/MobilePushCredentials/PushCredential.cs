using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MobilePushCredentials;

[JsonConverter(typeof(JsonModelConverter<PushCredential, PushCredentialFromRaw>))]
public sealed record class PushCredential : JsonModel
{
    /// <summary>
    /// Unique identifier of a push credential
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
    /// Alias to uniquely identify a credential
    /// </summary>
    public required string Alias {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "alias"
            );
        }
        init { this._rawData.Set("alias", value); }
    }

    /// <summary>
    /// Apple certificate for sending push notifications. For iOS only
    /// </summary>
    public required string Certificate {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "certificate"
            );
        }
        init { this._rawData.Set("certificate", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room was created
    /// </summary>
    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Apple private key for a given certificate for sending push notifications.
    /// For iOS only
    /// </summary>
    public required string PrivateKey {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "private_key"
            );
        }
        init { this._rawData.Set("private_key", value); }
    }

    /// <summary>
    /// Google server key for sending push notifications. For Android only
    /// </summary>
    public required IReadOnlyDictionary<string, JsonElement> ProjectAccountJsonFile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, JsonElement>>(
                "project_account_json_file"
            );
        }
        init {
            this._rawData.Set<FrozenDictionary<string, JsonElement>>(
                "project_account_json_file",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required string RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "record_type"
            );
        }
        init { this._rawData.Set("record_type", value); }
    }

    /// <summary>
    /// Type of mobile push credential. Either &lt;code&gt;ios&lt;/code&gt; or &lt;code&gt;android&lt;/code&gt;
    /// </summary>
    public required string Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "type"
            );
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// ISO 8601 timestamp when the room was updated.
    /// </summary>
    public required DateTimeOffset UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init { this._rawData.Set("updated_at", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Alias;
        _ = this.Certificate;
        _ = this.CreatedAt;
        _ = this.PrivateKey;
        _ = this.ProjectAccountJsonFile;
        _ = this.RecordType;
        _ = this.Type;
        _ = this.UpdatedAt;
    }

    public PushCredential ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PushCredential (PushCredential pushCredential) : base(pushCredential)
    {  }
    #pragma warning restore CS8618

    public PushCredential (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PushCredential (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PushCredentialFromRaw.FromRawUnchecked"/>
    public static PushCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PushCredentialFromRaw : IFromRawJson<PushCredential>
{
    /// <inheritdoc/>
    public PushCredential FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PushCredential.FromRawUnchecked(rawData);
}