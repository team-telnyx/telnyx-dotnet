using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationRetrieveResponse, CallControlApplicationRetrieveResponseFromRaw>))]
public sealed record class CallControlApplicationRetrieveResponse : JsonModel
{
    public CallControlApplication? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<CallControlApplication>(
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

    public CallControlApplicationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationRetrieveResponse (
        CallControlApplicationRetrieveResponse callControlApplicationRetrieveResponse
    ) : base(callControlApplicationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationRetrieveResponseFromRaw : IFromRawJson<CallControlApplicationRetrieveResponse>
{
    /// <inheritdoc/>
    public CallControlApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationRetrieveResponse.FromRawUnchecked(rawData);
}