using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadRefreshStatusResponse, UploadRefreshStatusResponseFromRaw>))]
public sealed record class UploadRefreshStatusResponse : JsonModel
{
    /// <summary>
    /// Describes wether or not the operation was successful
    /// </summary>
    public bool? Success {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "success"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("success", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Success; }

    public UploadRefreshStatusResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadRefreshStatusResponse (
        UploadRefreshStatusResponse uploadRefreshStatusResponse
    ) : base(uploadRefreshStatusResponse)
    {  }
    #pragma warning restore CS8618

    public UploadRefreshStatusResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadRefreshStatusResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadRefreshStatusResponseFromRaw.FromRawUnchecked"/>
    public static UploadRefreshStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadRefreshStatusResponseFromRaw : IFromRawJson<UploadRefreshStatusResponse>
{
    /// <inheritdoc/>
    public UploadRefreshStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadRefreshStatusResponse.FromRawUnchecked(rawData);
}