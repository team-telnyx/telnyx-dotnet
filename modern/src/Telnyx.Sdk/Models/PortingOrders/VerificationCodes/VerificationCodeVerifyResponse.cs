using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PortingOrders.VerificationCodes;

[JsonConverter(typeof(JsonModelConverter<VerificationCodeVerifyResponse, VerificationCodeVerifyResponseFromRaw>))]
public sealed record class VerificationCodeVerifyResponse : JsonModel
{
    public IReadOnlyList<PortingVerificationCode>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<PortingVerificationCode>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<PortingVerificationCode>?>(
                "data",
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
    }

    public VerificationCodeVerifyResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCodeVerifyResponse (
        VerificationCodeVerifyResponse verificationCodeVerifyResponse
    ) : base(verificationCodeVerifyResponse)
    {  }
    #pragma warning restore CS8618

    public VerificationCodeVerifyResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCodeVerifyResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCodeVerifyResponseFromRaw.FromRawUnchecked"/>
    public static VerificationCodeVerifyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerificationCodeVerifyResponseFromRaw : IFromRawJson<VerificationCodeVerifyResponse>
{
    /// <inheritdoc/>
    public VerificationCodeVerifyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerificationCodeVerifyResponse.FromRawUnchecked(rawData);
}