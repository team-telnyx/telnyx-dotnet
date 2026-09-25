using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.ManagedAccounts;

[JsonConverter(typeof(JsonModelConverter<ManagedAccountRetrieveResponse, ManagedAccountRetrieveResponseFromRaw>))]
public sealed record class ManagedAccountRetrieveResponse : JsonModel
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

    public ManagedAccountRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ManagedAccountRetrieveResponse (
        ManagedAccountRetrieveResponse managedAccountRetrieveResponse
    ) : base(managedAccountRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public ManagedAccountRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ManagedAccountRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ManagedAccountRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ManagedAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ManagedAccountRetrieveResponseFromRaw : IFromRawJson<ManagedAccountRetrieveResponse>
{
    /// <inheritdoc/>
    public ManagedAccountRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ManagedAccountRetrieveResponse.FromRawUnchecked(rawData);
}