using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Invoices;

[JsonConverter(typeof(JsonModelConverter<InvoiceRetrieveResponse, InvoiceRetrieveResponseFromRaw>))]
public sealed record class InvoiceRetrieveResponse : JsonModel
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

    public InvoiceRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceRetrieveResponse (
        InvoiceRetrieveResponse invoiceRetrieveResponse
    ) : base(invoiceRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public InvoiceRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InvoiceRetrieveResponseFromRaw : IFromRawJson<InvoiceRetrieveResponse>
{
    /// <inheritdoc/>
    public InvoiceRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InvoiceRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Present only if the query parameter `action=link` is set.
    /// </summary>
    public string? DownloadUrl {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "download_url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("download_url", value);
        }
    }

    public string? FileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "file_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("file_id", value);
        }
    }

    public string? InvoiceID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "invoice_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("invoice_id", value);
        }
    }

    public bool? Paid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "paid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("paid", value);
        }
    }

    public string? PeriodEnd {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "period_end"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("period_end", value);
        }
    }

    public string? PeriodStart {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "period_start"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("period_start", value);
        }
    }

    public string? Url {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.DownloadUrl;
        _ = this.FileID;
        _ = this.InvoiceID;
        _ = this.Paid;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        _ = this.Url;
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