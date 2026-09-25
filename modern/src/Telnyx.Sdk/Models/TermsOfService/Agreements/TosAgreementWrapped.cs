using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.TermsOfService.Agreements;

[JsonConverter(typeof(JsonModelConverter<TosAgreementWrapped, TosAgreementWrappedFromRaw>))]
public sealed record class TosAgreementWrapped : JsonModel
{
    /// <summary>
    /// A recorded user agreement to a product's Terms of Service. The `user_id`
    /// is intentionally NOT echoed back on this public surface - the caller already
    /// knows their own identity.
    /// </summary>
    public required TosAgreement Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TosAgreement>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public TosAgreementWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TosAgreementWrapped (TosAgreementWrapped tosAgreementWrapped) : base(
        tosAgreementWrapped
    )
    {  }
    #pragma warning restore CS8618

    public TosAgreementWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TosAgreementWrapped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TosAgreementWrappedFromRaw.FromRawUnchecked"/>
    public static TosAgreementWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public TosAgreementWrapped (TosAgreement data) : this()
    { this.Data = data; }
}

class TosAgreementWrappedFromRaw : IFromRawJson<TosAgreementWrapped>
{
    /// <inheritdoc/>
    public TosAgreementWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TosAgreementWrapped.FromRawUnchecked(rawData);
}