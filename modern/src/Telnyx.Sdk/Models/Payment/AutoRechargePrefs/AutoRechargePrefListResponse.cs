using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Payment.AutoRechargePrefs;

[JsonConverter(typeof(JsonModelConverter<AutoRechargePrefListResponse, AutoRechargePrefListResponseFromRaw>))]
public sealed record class AutoRechargePrefListResponse : JsonModel
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

    public AutoRechargePrefListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutoRechargePrefListResponse (
        AutoRechargePrefListResponse autoRechargePrefListResponse
    ) : base(autoRechargePrefListResponse)
    {  }
    #pragma warning restore CS8618

    public AutoRechargePrefListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutoRechargePrefListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AutoRechargePrefListResponseFromRaw.FromRawUnchecked"/>
    public static AutoRechargePrefListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AutoRechargePrefListResponseFromRaw : IFromRawJson<AutoRechargePrefListResponse>
{
    /// <inheritdoc/>
    public AutoRechargePrefListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AutoRechargePrefListResponse.FromRawUnchecked(rawData);
}