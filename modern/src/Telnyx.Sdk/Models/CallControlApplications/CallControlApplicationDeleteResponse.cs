using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CallControlApplications;

[JsonConverter(typeof(JsonModelConverter<CallControlApplicationDeleteResponse, CallControlApplicationDeleteResponseFromRaw>))]
public sealed record class CallControlApplicationDeleteResponse : JsonModel
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

    public CallControlApplicationDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CallControlApplicationDeleteResponse (
        CallControlApplicationDeleteResponse callControlApplicationDeleteResponse
    ) : base(callControlApplicationDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public CallControlApplicationDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CallControlApplicationDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CallControlApplicationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static CallControlApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CallControlApplicationDeleteResponseFromRaw : IFromRawJson<CallControlApplicationDeleteResponse>
{
    /// <inheritdoc/>
    public CallControlApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CallControlApplicationDeleteResponse.FromRawUnchecked(rawData);
}