using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadCreateResponse, UploadCreateResponseFromRaw>))]
public sealed record class UploadCreateResponse : JsonModel
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

    /// <summary>
    /// Ticket id of the upload request
    /// </summary>
    public string? TicketID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "ticket_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("ticket_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Success;
        _ = this.TicketID;
    }

    public UploadCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadCreateResponse (
        UploadCreateResponse uploadCreateResponse
    ) : base(uploadCreateResponse)
    {  }
    #pragma warning restore CS8618

    public UploadCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadCreateResponseFromRaw.FromRawUnchecked"/>
    public static UploadCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadCreateResponseFromRaw : IFromRawJson<UploadCreateResponse>
{
    /// <inheritdoc/>
    public UploadCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadCreateResponse.FromRawUnchecked(rawData);
}