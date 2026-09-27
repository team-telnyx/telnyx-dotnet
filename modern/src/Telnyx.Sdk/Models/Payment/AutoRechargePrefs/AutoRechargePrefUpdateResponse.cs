using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Payment.AutoRechargePrefs;

[JsonConverter(typeof(JsonModelConverter<AutoRechargePrefUpdateResponse, AutoRechargePrefUpdateResponseFromRaw>))]
public sealed record class AutoRechargePrefUpdateResponse : JsonModel
{
    public AutoRechargePref? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<AutoRechargePref>(
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

    public AutoRechargePrefUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRechargePrefUpdateResponse (
        AutoRechargePrefUpdateResponse autoRechargePrefUpdateResponse
    ) : base(autoRechargePrefUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public AutoRechargePrefUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRechargePrefUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRechargePrefUpdateResponseFromRaw.FromRawUnchecked"/>
    public static AutoRechargePrefUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutoRechargePrefUpdateResponseFromRaw : IFromRawJson<AutoRechargePrefUpdateResponse>
{
    /// <inheritdoc/>
    public AutoRechargePrefUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRechargePrefUpdateResponse.FromRawUnchecked(rawData);
}