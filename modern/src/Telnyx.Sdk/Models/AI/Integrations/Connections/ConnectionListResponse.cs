using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Integrations.Connections;

[JsonConverter(typeof(JsonModelConverter<ConnectionListResponse, ConnectionListResponseFromRaw>))]
public sealed record class ConnectionListResponse : JsonModel
{
    public required IReadOnlyList<IntegrationConnection> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<IntegrationConnection>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<IntegrationConnection>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ConnectionListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionListResponse (
        ConnectionListResponse connectionListResponse
    ) : base(connectionListResponse)
    {  }
    #pragma warning restore CS8618

    public ConnectionListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionListResponseFromRaw.FromRawUnchecked"/>
    public static ConnectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConnectionListResponse (
        IReadOnlyList<IntegrationConnection> data
    ) : this()
    { this.Data = data; }
}

class ConnectionListResponseFromRaw : IFromRawJson<ConnectionListResponse>
{
    /// <inheritdoc/>
    public ConnectionListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionListResponse.FromRawUnchecked(rawData);
}