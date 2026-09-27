using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Tools;

[JsonConverter(typeof(JsonModelConverter<PayToolParams, PayToolParamsFromRaw>))]
public sealed record class PayToolParams : JsonModel
{
    /// <summary>
    /// The name of the pay connector configured in the Telnyx API. Must reference
    /// an existing pay connector for this organization.
    /// </summary>
    public required string ConnectorName {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "connector_name"
            );
        }
        init { this._rawData.Set("connector_name", value); }
    }

    /// <summary>
    /// Default currency for payments processed by this tool.
    /// </summary>
    public string? Currency {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "currency"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("currency", value);
        }
    }

    /// <summary>
    /// Optional description of the pay tool that will be passed to the assistant.
    /// </summary>
    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    /// <summary>
    /// Default payment method for payments processed by this tool.
    /// </summary>
    public string? PaymentMethod {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "payment_method"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("payment_method", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConnectorName;
        _ = this.Currency;
        _ = this.Description;
        _ = this.PaymentMethod;
    }

    public PayToolParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public PayToolParams (PayToolParams payToolParams) : base(payToolParams)
    {  }
    #pragma warning restore CS8618

    public PayToolParams (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    PayToolParams (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PayToolParamsFromRaw.FromRawUnchecked"/>
    public static PayToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public PayToolParams (string connectorName) : this()
    { this.ConnectorName = connectorName; }
}

class PayToolParamsFromRaw : IFromRawJson<PayToolParams>
{
    /// <inheritdoc/>
    public PayToolParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>PayToolParams.FromRawUnchecked(rawData);
}