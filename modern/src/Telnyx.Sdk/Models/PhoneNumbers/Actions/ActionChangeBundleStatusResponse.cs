using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionChangeBundleStatusResponse, ActionChangeBundleStatusResponseFromRaw>))]
public sealed record class ActionChangeBundleStatusResponse : JsonModel
{
    public PhoneNumberWithVoiceSettings? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PhoneNumberWithVoiceSettings>(
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

    public ActionChangeBundleStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionChangeBundleStatusResponse (
        ActionChangeBundleStatusResponse actionChangeBundleStatusResponse
    ) : base(actionChangeBundleStatusResponse)
    {  }
    #pragma warning restore CS8618

    public ActionChangeBundleStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionChangeBundleStatusResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionChangeBundleStatusResponseFromRaw.FromRawUnchecked"/>
    public static ActionChangeBundleStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionChangeBundleStatusResponseFromRaw : IFromRawJson<ActionChangeBundleStatusResponse>
{
    /// <inheritdoc/>
    public ActionChangeBundleStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionChangeBundleStatusResponse.FromRawUnchecked(rawData);
}