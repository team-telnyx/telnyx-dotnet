using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountCreateResponse, ManagedAccountCreateResponseFromRaw>))]
public sealed record class ManagedAccountCreateResponse : JsonModel
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

    public ManagedAccountCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountCreateResponse (
        ManagedAccountCreateResponse managedAccountCreateResponse
    ) : base(managedAccountCreateResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountCreateResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountCreateResponseFromRaw : IFromRawJson<ManagedAccountCreateResponse>
{
    /// <inheritdoc/>
    public ManagedAccountCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountCreateResponse.FromRawUnchecked(rawData);
}