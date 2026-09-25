using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifyProfiles;

[JsonConverter(typeof(JsonModelConverter<VerifyProfileData, VerifyProfileDataFromRaw>))]
public sealed record class VerifyProfileData : JsonModel
{
    public VerifyProfile? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifyProfile>(
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

    public VerifyProfileData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileData (VerifyProfileData verifyProfileData) : base(
        verifyProfileData
    )
    {  }
    #pragma warning restore CS8618

    public VerifyProfileData (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileDataFromRaw.FromRawUnchecked"/>
    public static VerifyProfileData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifyProfileDataFromRaw : IFromRawJson<VerifyProfileData>
{
    /// <inheritdoc/>
    public VerifyProfileData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileData.FromRawUnchecked(rawData);
}