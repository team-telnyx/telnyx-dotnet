using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FaxApplications;

[JsonConverter(typeof(JsonModelConverter<FaxApplicationRetrieveResponse, FaxApplicationRetrieveResponseFromRaw>))]
public sealed record class FaxApplicationRetrieveResponse : JsonModel
{
    public FaxApplication? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FaxApplication>(
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

    public FaxApplicationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationRetrieveResponse (
        FaxApplicationRetrieveResponse faxApplicationRetrieveResponse
    ) : base(faxApplicationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static FaxApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationRetrieveResponseFromRaw : IFromRawJson<FaxApplicationRetrieveResponse>
{
    /// <inheritdoc/>
    public FaxApplicationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationRetrieveResponse.FromRawUnchecked(rawData);
}