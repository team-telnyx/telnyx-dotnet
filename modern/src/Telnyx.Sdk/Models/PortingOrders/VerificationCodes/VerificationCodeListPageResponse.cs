using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.PortingOrders.VerificationCodes;

[JsonConverter(typeof(JsonModelConverter<VerificationCodeListPageResponse, VerificationCodeListPageResponseFromRaw>))]
public sealed record class VerificationCodeListPageResponse : JsonModel
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

    public PaginationMeta? Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<PaginationMeta>(
                "meta"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("meta", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
        this.Meta?.Validate();
    }

    public VerificationCodeListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerificationCodeListPageResponse (
        VerificationCodeListPageResponse verificationCodeListPageResponse
    ) : base(verificationCodeListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VerificationCodeListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerificationCodeListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerificationCodeListPageResponseFromRaw.FromRawUnchecked"/>
    public static VerificationCodeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerificationCodeListPageResponseFromRaw : IFromRawJson<VerificationCodeListPageResponse>
{
    /// <inheritdoc/>
    public VerificationCodeListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerificationCodeListPageResponse.FromRawUnchecked(rawData);
}