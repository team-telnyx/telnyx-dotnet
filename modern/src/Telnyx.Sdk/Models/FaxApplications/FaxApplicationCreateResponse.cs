using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FaxApplications;

[JsonConverter(typeof(JsonModelConverter<FaxApplicationCreateResponse, FaxApplicationCreateResponseFromRaw>))]
public sealed record class FaxApplicationCreateResponse : JsonModel
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

    public FaxApplicationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationCreateResponse (
        FaxApplicationCreateResponse faxApplicationCreateResponse
    ) : base(faxApplicationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationCreateResponseFromRaw.FromRawUnchecked"/>
    public static FaxApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationCreateResponseFromRaw : IFromRawJson<FaxApplicationCreateResponse>
{
    /// <inheritdoc/>
    public FaxApplicationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationCreateResponse.FromRawUnchecked(rawData);
}