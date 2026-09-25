using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign.Usecase;

[JsonConverter(typeof(JsonModelConverter<UsecaseGetCostResponse, UsecaseGetCostResponseFromRaw>))]
public sealed record class UsecaseGetCostResponse : JsonModel
{
    public required string CampaignUsecase {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "campaignUsecase"
            );
        }
        init { this._rawData.Set("campaignUsecase", value); }
    }

    public required string Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "description"
            );
        }
        init { this._rawData.Set("description", value); }
    }

    public required string MonthlyCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "monthlyCost"
            );
        }
        init { this._rawData.Set("monthlyCost", value); }
    }

    public required string UpFrontCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "upFrontCost"
            );
        }
        init { this._rawData.Set("upFrontCost", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CampaignUsecase;
        _ = this.Description;
        _ = this.MonthlyCost;
        _ = this.UpFrontCost;
    }

    public UsecaseGetCostResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UsecaseGetCostResponse (
        UsecaseGetCostResponse usecaseGetCostResponse
    ) : base(usecaseGetCostResponse)
    {  }
    #pragma warning restore CS8618

    public UsecaseGetCostResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UsecaseGetCostResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UsecaseGetCostResponseFromRaw.FromRawUnchecked"/>
    public static UsecaseGetCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UsecaseGetCostResponseFromRaw : IFromRawJson<UsecaseGetCostResponse>
{
    /// <inheritdoc/>
    public UsecaseGetCostResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UsecaseGetCostResponse.FromRawUnchecked(rawData);
}