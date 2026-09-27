using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingHostedNumberOrders.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionUploadFileResponse, ActionUploadFileResponseFromRaw>))]
public sealed record class ActionUploadFileResponse : JsonModel
{
    public MessagingHostedNumberOrder? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessagingHostedNumberOrder>(
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

    public ActionUploadFileResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionUploadFileResponse (
        ActionUploadFileResponse actionUploadFileResponse
    ) : base(actionUploadFileResponse)
    {  }
    #pragma warning restore CS8618

    public ActionUploadFileResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionUploadFileResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionUploadFileResponseFromRaw.FromRawUnchecked"/>
    public static ActionUploadFileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionUploadFileResponseFromRaw : IFromRawJson<ActionUploadFileResponse>
{
    /// <inheritdoc/>
    public ActionUploadFileResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionUploadFileResponse.FromRawUnchecked(rawData);
}