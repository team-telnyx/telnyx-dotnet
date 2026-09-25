using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Faxes;

[JsonConverter(typeof(JsonModelConverter<FaxRetrieveResponse, FaxRetrieveResponseFromRaw>))]
public sealed record class FaxRetrieveResponse : JsonModel
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

    public FaxRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxRetrieveResponse (FaxRetrieveResponse faxRetrieveResponse) : base(
        faxRetrieveResponse
    )
    {  }
    #pragma warning restore CS8618

    public FaxRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FaxRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxRetrieveResponseFromRaw : IFromRawJson<FaxRetrieveResponse>
{
    /// <inheritdoc/>
    public FaxRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxRetrieveResponse.FromRawUnchecked(rawData);
}