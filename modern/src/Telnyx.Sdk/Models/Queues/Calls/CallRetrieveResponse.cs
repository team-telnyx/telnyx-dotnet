using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Queues.Calls;

[JsonConverter(typeof(JsonModelConverter<CallRetrieveResponse, CallRetrieveResponseFromRaw>))]
public sealed record class CallRetrieveResponse : JsonModel
{
    public QueueCall? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<QueueCall>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("data", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data?.Validate(); }

    public CallRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallRetrieveResponse (
        CallRetrieveResponse callRetrieveResponse
    ) : base(callRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CallRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CallRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallRetrieveResponseFromRaw : IFromRawJson<CallRetrieveResponse>
{
    /// <inheritdoc/>
    public CallRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallRetrieveResponse.FromRawUnchecked(rawData);
}