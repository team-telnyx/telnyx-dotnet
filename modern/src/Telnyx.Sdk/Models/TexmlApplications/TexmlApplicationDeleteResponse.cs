using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TexmlApplications;

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationDeleteResponse, TexmlApplicationDeleteResponseFromRaw>))]
public sealed record class TexmlApplicationDeleteResponse : JsonModel
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

    public TexmlApplicationDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationDeleteResponse (
        TexmlApplicationDeleteResponse texmlApplicationDeleteResponse
    ) : base(texmlApplicationDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationDeleteResponseFromRaw : IFromRawJson<TexmlApplicationDeleteResponse>
{
    /// <inheritdoc/>
    public TexmlApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationDeleteResponse.FromRawUnchecked(rawData);
}