using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Actions.Purchase;

namespace Telnyx.Sdk.Models.Actions.Register;

[JsonConverter(typeof(JsonModelConverter<RegisterCreateResponse, RegisterCreateResponseFromRaw>))]
public sealed record class RegisterCreateResponse : JsonModel
{
    /// <summary>
    /// Successfully registered SIM cards.
    /// </summary>
    public IReadOnlyList<SimpleSimCard>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<SimpleSimCard>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<SimpleSimCard>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<WirelessErrorC5290d5308>? Errors {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<WirelessErrorC5290d5308>>(
                "errors"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<WirelessErrorC5290d5308>?>(
                "errors",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Errors ?? [])
        {
            item.Validate();
        }
    }

    public RegisterCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RegisterCreateResponse (
        RegisterCreateResponse registerCreateResponse
    ) : base(registerCreateResponse)
    {  }
    #pragma warning restore CS8618

    public RegisterCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RegisterCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RegisterCreateResponseFromRaw.FromRawUnchecked"/>
    public static RegisterCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RegisterCreateResponseFromRaw : IFromRawJson<RegisterCreateResponse>
{
    /// <inheritdoc/>
    public RegisterCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RegisterCreateResponse.FromRawUnchecked(rawData);
}