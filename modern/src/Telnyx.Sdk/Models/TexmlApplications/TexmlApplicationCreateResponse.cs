using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TexmlApplications;

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationCreateResponse, TexmlApplicationCreateResponseFromRaw>))]
public sealed record class TexmlApplicationCreateResponse : JsonModel
{
    public TexmlApplication? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TexmlApplication>(
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

    public TexmlApplicationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationCreateResponse (
        TexmlApplicationCreateResponse texmlApplicationCreateResponse
    ) : base(texmlApplicationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationCreateResponseFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationCreateResponseFromRaw : IFromRawJson<TexmlApplicationCreateResponse>
{
    /// <inheritdoc/>
    public TexmlApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationCreateResponse.FromRawUnchecked(rawData);
}