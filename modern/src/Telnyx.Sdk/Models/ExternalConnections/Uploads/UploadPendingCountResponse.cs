using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ExternalConnections.Uploads;

[JsonConverter(typeof(JsonModelConverter<UploadPendingCountResponse, UploadPendingCountResponseFromRaw>))]
public sealed record class UploadPendingCountResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public UploadPendingCountResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UploadPendingCountResponse (
        UploadPendingCountResponse uploadPendingCountResponse
    ) : base(uploadPendingCountResponse)
    {  }
    #pragma warning restore CS8618

    public UploadPendingCountResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UploadPendingCountResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UploadPendingCountResponseFromRaw.FromRawUnchecked"/>
    public static UploadPendingCountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UploadPendingCountResponseFromRaw : IFromRawJson<UploadPendingCountResponse>
{
    /// <inheritdoc/>
    public UploadPendingCountResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UploadPendingCountResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The count of phone numbers that are pending assignment to the external connection.
    /// </summary>
    public long? PendingNumbersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "pending_numbers_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pending_numbers_count", value);
        }
    }

    /// <summary>
    /// The count of number uploads that have not yet been uploaded to Microsoft.
    /// </summary>
    public long? PendingOrdersCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "pending_orders_count"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("pending_orders_count", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PendingNumbersCount;
        _ = this.PendingOrdersCount;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}