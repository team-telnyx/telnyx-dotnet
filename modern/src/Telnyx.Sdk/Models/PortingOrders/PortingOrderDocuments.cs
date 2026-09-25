using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders;

/// <summary>
/// Can be specified directly or via the `requirement_group_id` parameter.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<PortingOrderDocuments, PortingOrderDocumentsFromRaw>))]
public sealed record class PortingOrderDocuments : JsonModel
{
    /// <summary>
    /// Returned ID of the submitted Invoice via the Documents endpoint
    /// </summary>
    public string? Invoice {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "invoice"
            );
        }
        init { this._rawData.Set("invoice", value); }
    }

    /// <summary>
    /// Returned ID of the submitted LOA via the Documents endpoint
    /// </summary>
    public string? Loa {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "loa"
            );
        }
        init { this._rawData.Set("loa", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Invoice;
        _ = this.Loa;
    }

    public PortingOrderDocuments ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PortingOrderDocuments (
        PortingOrderDocuments portingOrderDocuments
    ) : base(portingOrderDocuments)
    {  }
    #pragma warning restore CS8618

    public PortingOrderDocuments (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PortingOrderDocuments (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PortingOrderDocumentsFromRaw.FromRawUnchecked"/>
    public static PortingOrderDocuments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class PortingOrderDocumentsFromRaw : IFromRawJson<PortingOrderDocuments>
{
    /// <inheritdoc/>
    public PortingOrderDocuments FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PortingOrderDocuments.FromRawUnchecked(rawData);
}