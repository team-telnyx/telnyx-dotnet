using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadRetryResponse, UploadRetryResponseFromRaw>))]
public sealed record class UploadRetryResponse : JsonModel
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

    public UploadRetryResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadRetryResponse (UploadRetryResponse uploadRetryResponse) : base(
        uploadRetryResponse
    )
    {  }
    #pragma warning restore CS8618

    public UploadRetryResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadRetryResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadRetryResponseFromRaw.FromRawUnchecked"/>
    public static UploadRetryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadRetryResponseFromRaw : IFromRawJson<UploadRetryResponse>
{
    /// <inheritdoc/>
    public UploadRetryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadRetryResponse.FromRawUnchecked(rawData);
}