using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.CampaignBuilder.Brand;

[JsonConverter(typeof(JsonModelConverter<BrandQualifyByUsecaseResponse, BrandQualifyByUsecaseResponseFromRaw>))]
public sealed record class BrandQualifyByUsecaseResponse : JsonModel
{
    /// <summary>
    /// Campaign annual subscription fee
    /// </summary>
    public double? AnnualFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "annualFee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("annualFee", value);
        }
    }

    /// <summary>
    /// Maximum number of sub-usecases declaration required.
    /// </summary>
    public long? MaxSubUsecases {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "maxSubUsecases"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("maxSubUsecases", value);
        }
    }

    /// <summary>
    /// Minimum number of sub-usecases declaration required.
    /// </summary>
    public long? MinSubUsecases {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>(
                "minSubUsecases"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("minSubUsecases", value);
        }
    }

    /// <summary>
    /// Map of usecase metadata for each MNO. Key is the network ID of the MNO (e.g.
    /// 10017), Value is the mno metadata for the usecase.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? MnoMetadata {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "mnoMetadata"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "mnoMetadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Campaign monthly subscription fee
    /// </summary>
    public double? MonthlyFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "monthlyFee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("monthlyFee", value);
        }
    }

    /// <summary>
    /// Campaign quarterly subscription fee
    /// </summary>
    public double? QuarterlyFee {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "quarterlyFee"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quarterlyFee", value);
        }
    }

    /// <summary>
    /// Campaign usecase
    /// </summary>
    public string? Usecase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "usecase"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("usecase", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AnnualFee;
        _ = this.MaxSubUsecases;
        _ = this.MinSubUsecases;
        _ = this.MnoMetadata;
        _ = this.MonthlyFee;
        _ = this.QuarterlyFee;
        _ = this.Usecase;
    }

    public BrandQualifyByUsecaseResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandQualifyByUsecaseResponse (
        BrandQualifyByUsecaseResponse brandQualifyByUsecaseResponse
    ) : base(brandQualifyByUsecaseResponse)
    {  }
    #pragma warning restore CS8618

    public BrandQualifyByUsecaseResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandQualifyByUsecaseResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="BrandQualifyByUsecaseResponseFromRaw.FromRawUnchecked"/>
    public static BrandQualifyByUsecaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class BrandQualifyByUsecaseResponseFromRaw : IFromRawJson<BrandQualifyByUsecaseResponse>
{
    /// <inheritdoc/>
    public BrandQualifyByUsecaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>BrandQualifyByUsecaseResponse.FromRawUnchecked(rawData);
}