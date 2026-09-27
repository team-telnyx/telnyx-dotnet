using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Enterprises;

[JsonConverter(typeof(JsonModelConverter<EnterprisePublicWrapped, EnterprisePublicWrappedFromRaw>))]
public sealed record class EnterprisePublicWrapped : JsonModel
{
    public EnterprisePublic? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<EnterprisePublic>(
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

    public EnterprisePublicWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EnterprisePublicWrapped (
        EnterprisePublicWrapped enterprisePublicWrapped
    ) : base(enterprisePublicWrapped)
    {  }
    #pragma warning restore CS8618

    public EnterprisePublicWrapped (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EnterprisePublicWrapped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EnterprisePublicWrappedFromRaw.FromRawUnchecked"/>
    public static EnterprisePublicWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EnterprisePublicWrappedFromRaw : IFromRawJson<EnterprisePublicWrapped>
{
    /// <inheritdoc/>
    public EnterprisePublicWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EnterprisePublicWrapped.FromRawUnchecked(rawData);
}