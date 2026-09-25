using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountUpdateResponse, ManagedAccountUpdateResponseFromRaw>))]
public sealed record class ManagedAccountUpdateResponse : JsonModel
{
    public ManagedAccount? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ManagedAccount>(
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

    public ManagedAccountUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountUpdateResponse (
        ManagedAccountUpdateResponse managedAccountUpdateResponse
    ) : base(managedAccountUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountUpdateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountUpdateResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountUpdateResponseFromRaw : IFromRawJson<ManagedAccountUpdateResponse>
{
    /// <inheritdoc/>
    public ManagedAccountUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountUpdateResponse.FromRawUnchecked(rawData);
}