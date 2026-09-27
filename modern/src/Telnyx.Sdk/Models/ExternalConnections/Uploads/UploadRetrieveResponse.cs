using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadRetrieveResponse, UploadRetrieveResponseFromRaw>))]
public sealed record class UploadRetrieveResponse : JsonModel
{
    public Upload? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Upload>(
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

    public UploadRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadRetrieveResponse (
        UploadRetrieveResponse uploadRetrieveResponse
    ) : base(uploadRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UploadRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UploadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadRetrieveResponseFromRaw : IFromRawJson<UploadRetrieveResponse>
{
    /// <inheritdoc/>
    public UploadRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadRetrieveResponse.FromRawUnchecked(rawData);
}