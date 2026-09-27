using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TexmlApplications;

[JsonConverter(typeof(JsonModelConverter<TexmlApplicationRetrieveResponse, TexmlApplicationRetrieveResponseFromRaw>))]
public sealed record class TexmlApplicationRetrieveResponse : JsonModel
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

    public TexmlApplicationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TexmlApplicationRetrieveResponse (
        TexmlApplicationRetrieveResponse texmlApplicationRetrieveResponse
    ) : base(texmlApplicationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public TexmlApplicationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TexmlApplicationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TexmlApplicationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static TexmlApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class TexmlApplicationRetrieveResponseFromRaw : IFromRawJson<TexmlApplicationRetrieveResponse>
{
    /// <inheritdoc/>
    public TexmlApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TexmlApplicationRetrieveResponse.FromRawUnchecked(rawData);
}