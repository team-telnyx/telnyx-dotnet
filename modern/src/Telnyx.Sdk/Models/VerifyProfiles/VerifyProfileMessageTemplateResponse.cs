using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifyProfiles;

[JsonConverter(typeof(JsonModelConverter<VerifyProfileMessageTemplateResponse, VerifyProfileMessageTemplateResponseFromRaw>))]
public sealed record class VerifyProfileMessageTemplateResponse : JsonModel
{
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Text;
    }

    public VerifyProfileMessageTemplateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileMessageTemplateResponse (
        VerifyProfileMessageTemplateResponse verifyProfileMessageTemplateResponse
    ) : base(verifyProfileMessageTemplateResponse)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileMessageTemplateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileMessageTemplateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileMessageTemplateResponseFromRaw.FromRawUnchecked"/>
    public static VerifyProfileMessageTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifyProfileMessageTemplateResponseFromRaw : IFromRawJson<VerifyProfileMessageTemplateResponse>
{
    /// <inheritdoc/>
    public VerifyProfileMessageTemplateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileMessageTemplateResponse.FromRawUnchecked(rawData);
}