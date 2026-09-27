using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Integrations.Connections;

[JsonConverter(typeof(JsonModelConverter<IntegrationConnection, IntegrationConnectionFromRaw>))]
public sealed record class IntegrationConnection : JsonModel
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

    public required IReadOnlyList<string> AllowedTools {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>(
                "allowed_tools"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<string>>(
                "allowed_tools",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string IntegrationID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "integration_id"
            );
        }
        init { this._rawData.Set("integration_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AllowedTools;
        _ = this.IntegrationID;
    }

    public IntegrationConnection ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntegrationConnection (
        IntegrationConnection integrationConnection
    ) : base(integrationConnection)
    {  }
    #pragma warning restore CS8618

    public IntegrationConnection (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntegrationConnection (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntegrationConnectionFromRaw.FromRawUnchecked"/>
    public static IntegrationConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class IntegrationConnectionFromRaw : IFromRawJson<IntegrationConnection>
{
    /// <inheritdoc/>
    public IntegrationConnection FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntegrationConnection.FromRawUnchecked(rawData);
}