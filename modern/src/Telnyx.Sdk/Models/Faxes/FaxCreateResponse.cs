using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Faxes;

[JsonConverter(typeof(JsonModelConverter<FaxCreateResponse, FaxCreateResponseFromRaw>))]
public sealed record class FaxCreateResponse : JsonModel
{
    public Fax? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Fax>(
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

    public FaxCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxCreateResponse (FaxCreateResponse faxCreateResponse) : base(
        faxCreateResponse
    )
    {  }
    #pragma warning restore CS8618

    public FaxCreateResponse (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxCreateResponseFromRaw.FromRawUnchecked"/>
    public static FaxCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxCreateResponseFromRaw : IFromRawJson<FaxCreateResponse>
{
    /// <inheritdoc/>
    public FaxCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxCreateResponse.FromRawUnchecked(rawData);
}