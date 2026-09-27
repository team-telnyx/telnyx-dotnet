using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Invoices;

[JsonConverter(typeof(JsonModelConverter<InvoiceListResponse, InvoiceListResponseFromRaw>))]
public sealed record class InvoiceListResponse : JsonModel
{
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
        _ = this.FileID;
        _ = this.InvoiceID;
        _ = this.Paid;
        _ = this.PeriodEnd;
        _ = this.PeriodStart;
        _ = this.Url;
    }

    public InvoiceListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvoiceListResponse (InvoiceListResponse invoiceListResponse) : base(
        invoiceListResponse
    )
    {  }
    #pragma warning restore CS8618

    public InvoiceListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InvoiceListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InvoiceListResponseFromRaw.FromRawUnchecked"/>
    public static InvoiceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class InvoiceListResponseFromRaw : IFromRawJson<InvoiceListResponse>
{
    /// <inheritdoc/>
    public InvoiceListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InvoiceListResponse.FromRawUnchecked(rawData);
}