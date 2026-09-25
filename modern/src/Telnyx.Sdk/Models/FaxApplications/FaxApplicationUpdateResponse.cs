using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FaxApplications;

[JsonConverter(typeof(JsonModelConverter<FaxApplicationUpdateResponse, FaxApplicationUpdateResponseFromRaw>))]
public sealed record class FaxApplicationUpdateResponse : JsonModel
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

    public FaxApplicationUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationUpdateResponse (
        FaxApplicationUpdateResponse faxApplicationUpdateResponse
    ) : base(faxApplicationUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationUpdateResponseFromRaw.FromRawUnchecked"/>
    public static FaxApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationUpdateResponseFromRaw : IFromRawJson<FaxApplicationUpdateResponse>
{
    /// <inheritdoc/>
    public FaxApplicationUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationUpdateResponse.FromRawUnchecked(rawData);
}