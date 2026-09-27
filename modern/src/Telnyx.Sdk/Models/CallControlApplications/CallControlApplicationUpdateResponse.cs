using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationUpdateResponse, CallControlApplicationUpdateResponseFromRaw>))]
public sealed record class CallControlApplicationUpdateResponse : JsonModel
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

    public CallControlApplicationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationUpdateResponse (
        CallControlApplicationUpdateResponse callControlApplicationUpdateResponse
    ) : base(callControlApplicationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationUpdateResponseFromRaw : IFromRawJson<CallControlApplicationUpdateResponse>
{
    /// <inheritdoc/>
    public CallControlApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationUpdateResponse.FromRawUnchecked(rawData);
}