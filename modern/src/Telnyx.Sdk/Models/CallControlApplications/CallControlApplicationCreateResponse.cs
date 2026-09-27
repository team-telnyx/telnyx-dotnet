using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationCreateResponse, CallControlApplicationCreateResponseFromRaw>))]
public sealed record class CallControlApplicationCreateResponse : JsonModel
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

    public CallControlApplicationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationCreateResponse (
        CallControlApplicationCreateResponse callControlApplicationCreateResponse
    ) : base(callControlApplicationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationCreateResponseFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationCreateResponseFromRaw : IFromRawJson<CallControlApplicationCreateResponse>
{
    /// <inheritdoc/>
    public CallControlApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationCreateResponse.FromRawUnchecked(rawData);
}