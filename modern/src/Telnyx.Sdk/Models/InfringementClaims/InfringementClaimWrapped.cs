using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.InfringementClaims;

[JsonConverter(typeof(JsonModelConverter<InfringementClaimWrapped, InfringementClaimWrappedFromRaw>))]
public sealed record class InfringementClaimWrapped : JsonModel
{
    public required InfringementClaim Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<InfringementClaim>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public InfringementClaimWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public InfringementClaimWrapped (
        InfringementClaimWrapped infringementClaimWrapped
    ) : base(infringementClaimWrapped)
    {  }
    #pragma warning restore CS8618

    public InfringementClaimWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    InfringementClaimWrapped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="InfringementClaimWrappedFromRaw.FromRawUnchecked"/>
    public static InfringementClaimWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public InfringementClaimWrapped (InfringementClaim data) : this()
    { this.Data = data; }
}

class InfringementClaimWrappedFromRaw : IFromRawJson<InfringementClaimWrapped>
{
    /// <inheritdoc/>
    public InfringementClaimWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>InfringementClaimWrapped.FromRawUnchecked(rawData);
}