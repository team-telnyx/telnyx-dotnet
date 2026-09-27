using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Integrations.Connections;

[JsonConverter(typeof(JsonModelConverter<ConnectionRetrieveResponse, ConnectionRetrieveResponseFromRaw>))]
public sealed record class ConnectionRetrieveResponse : JsonModel
{
    public required IntegrationConnection Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<IntegrationConnection>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ConnectionRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConnectionRetrieveResponse (
        ConnectionRetrieveResponse connectionRetrieveResponse
    ) : base(connectionRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ConnectionRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ConnectionRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ConnectionRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ConnectionRetrieveResponse (IntegrationConnection data) : this()
    { this.Data = data; }
}

class ConnectionRetrieveResponseFromRaw : IFromRawJson<ConnectionRetrieveResponse>
{
    /// <inheritdoc/>
    public ConnectionRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ConnectionRetrieveResponse.FromRawUnchecked(rawData);
}