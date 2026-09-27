using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.FaxApplications;

[JsonConverter(typeof(JsonModelConverter<FaxApplicationDeleteResponse, FaxApplicationDeleteResponseFromRaw>))]
public sealed record class FaxApplicationDeleteResponse : JsonModel
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

    public FaxApplicationDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public FaxApplicationDeleteResponse (
        FaxApplicationDeleteResponse faxApplicationDeleteResponse
    ) : base(faxApplicationDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public FaxApplicationDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    FaxApplicationDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FaxApplicationDeleteResponseFromRaw.FromRawUnchecked"/>
    public static FaxApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class FaxApplicationDeleteResponseFromRaw : IFromRawJson<FaxApplicationDeleteResponse>
{
    /// <inheritdoc/>
    public FaxApplicationDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>FaxApplicationDeleteResponse.FromRawUnchecked(rawData);
}