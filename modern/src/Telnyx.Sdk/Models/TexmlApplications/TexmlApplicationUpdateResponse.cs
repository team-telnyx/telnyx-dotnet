using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TexmlApplications;

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationUpdateResponse, TexmlApplicationUpdateResponseFromRaw>))]
public sealed record class TexmlApplicationUpdateResponse : JsonModel
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

    public TexmlApplicationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationUpdateResponse (
        TexmlApplicationUpdateResponse texmlApplicationUpdateResponse
    ) : base(texmlApplicationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationUpdateResponseFromRaw : IFromRawJson<TexmlApplicationUpdateResponse>
{
    /// <inheritdoc/>
    public TexmlApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationUpdateResponse.FromRawUnchecked(rawData);
}