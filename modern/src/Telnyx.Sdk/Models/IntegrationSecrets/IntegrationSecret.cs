using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.IntegrationSecrets;

[JsonConverter(typeof(JsonModelConverter<IntegrationSecret, IntegrationSecretFromRaw>))]
public sealed record class IntegrationSecret : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required DateTimeOffset CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>(
                "created_at"
            );
        }
        init { this._rawData.Set("created_at", value); }
    }

    public required string Identifier {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "identifier"
            );
        }
        init { this._rawData.Set("identifier", value); }
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

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Identifier;
        _ = this.RecordType;
        _ = this.UpdatedAt;
    }

    public IntegrationSecret ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationSecret (IntegrationSecret integrationSecret) : base(
        integrationSecret
    )
    {  }
    #pragma warning restore CS8618

    public IntegrationSecret (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationSecret (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationSecretFromRaw.FromRawUnchecked"/>
    public static IntegrationSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntegrationSecretFromRaw : IFromRawJson<IntegrationSecret>
{
    /// <inheritdoc/>
    public IntegrationSecret FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntegrationSecret.FromRawUnchecked(rawData);
}