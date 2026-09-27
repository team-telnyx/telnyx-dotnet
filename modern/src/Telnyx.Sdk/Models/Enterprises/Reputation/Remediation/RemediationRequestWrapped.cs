using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises.Reputation.Remediation;

[JsonConverter(typeof(JsonModelConverter<RemediationRequestWrapped, RemediationRequestWrappedFromRaw>))]
public sealed record class RemediationRequestWrapped : JsonModel
{
    /// <summary>
    /// Full detail of a remediation request, returned on submit and GET by id.
    /// </summary>
    public required RemediationRequest Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<RemediationRequest>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public RemediationRequestWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RemediationRequestWrapped (
        RemediationRequestWrapped remediationRequestWrapped
    ) : base(remediationRequestWrapped)
    {  }
    #pragma warning restore CS8618

    public RemediationRequestWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RemediationRequestWrapped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RemediationRequestWrappedFromRaw.FromRawUnchecked"/>
    public static RemediationRequestWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public RemediationRequestWrapped (RemediationRequest data) : this()
    { this.Data = data; }
}

class RemediationRequestWrappedFromRaw : IFromRawJson<RemediationRequestWrapped>
{
    /// <inheritdoc/>
    public RemediationRequestWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RemediationRequestWrapped.FromRawUnchecked(rawData);
}