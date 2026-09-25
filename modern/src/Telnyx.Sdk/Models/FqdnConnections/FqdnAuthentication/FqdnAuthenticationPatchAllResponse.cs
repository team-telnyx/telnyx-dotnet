using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FqdnConnections.FqdnAuthentication;

[JsonConverter(typeof(JsonModelConverter<FqdnAuthenticationPatchAllResponse, FqdnAuthenticationPatchAllResponseFromRaw>))]
public sealed record class FqdnAuthenticationPatchAllResponse : JsonModel
{
    public FqdnAuthenticationFqdnAuthentication? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FqdnAuthenticationFqdnAuthentication>(
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

    public FqdnAuthenticationPatchAllResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FqdnAuthenticationPatchAllResponse (
        FqdnAuthenticationPatchAllResponse fqdnAuthenticationPatchAllResponse
    ) : base(fqdnAuthenticationPatchAllResponse)
    {  }
    #pragma warning restore CS8618

    public FqdnAuthenticationPatchAllResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FqdnAuthenticationPatchAllResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FqdnAuthenticationPatchAllResponseFromRaw.FromRawUnchecked"/>
    public static FqdnAuthenticationPatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FqdnAuthenticationPatchAllResponseFromRaw : IFromRawJson<FqdnAuthenticationPatchAllResponse>
{
    /// <inheritdoc/>
    public FqdnAuthenticationPatchAllResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FqdnAuthenticationPatchAllResponse.FromRawUnchecked(rawData);
}