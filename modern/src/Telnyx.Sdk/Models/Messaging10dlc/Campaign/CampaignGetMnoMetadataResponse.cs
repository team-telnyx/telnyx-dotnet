using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messaging10dlc.Campaign;

[JsonConverter(typeof(JsonModelConverter<CampaignGetMnoMetadataResponse, CampaignGetMnoMetadataResponseFromRaw>))]
public sealed record class CampaignGetMnoMetadataResponse : JsonModel
{
    public Mno10999? C10999 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Mno10999>(
                "10999"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("10999", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.C10999?.Validate(); }

    public CampaignGetMnoMetadataResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignGetMnoMetadataResponse (
        CampaignGetMnoMetadataResponse campaignGetMnoMetadataResponse
    ) : base(campaignGetMnoMetadataResponse)
    {  }
    #pragma warning restore CS8618

    public CampaignGetMnoMetadataResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignGetMnoMetadataResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CampaignGetMnoMetadataResponseFromRaw.FromRawUnchecked"/>
    public static CampaignGetMnoMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CampaignGetMnoMetadataResponseFromRaw : IFromRawJson<CampaignGetMnoMetadataResponse>
{
    /// <inheritdoc/>
    public CampaignGetMnoMetadataResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CampaignGetMnoMetadataResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Mno10999, Mno10999FromRaw>))]
public sealed record class Mno10999 : JsonModel
{
    public required long MinMsgSamples {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "minMsgSamples"
            );
        }
        init { this._rawData.Set("minMsgSamples", value); }
    }

    public required string Mno {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "mno"
            );
        }
        init { this._rawData.Set("mno", value); }
    }

    public required bool MnoReview {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "mnoReview"
            );
        }
        init { this._rawData.Set("mnoReview", value); }
    }

    public required bool MnoSupport {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "mnoSupport"
            );
        }
        init { this._rawData.Set("mnoSupport", value); }
    }

    public required bool NoEmbeddedLink {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "noEmbeddedLink"
            );
        }
        init { this._rawData.Set("noEmbeddedLink", value); }
    }

    public required bool NoEmbeddedPhone {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "noEmbeddedPhone"
            );
        }
        init { this._rawData.Set("noEmbeddedPhone", value); }
    }

    public required bool Qualify {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "qualify"
            );
        }
        init { this._rawData.Set("qualify", value); }
    }

    public required bool ReqSubscriberHelp {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "reqSubscriberHelp"
            );
        }
        init { this._rawData.Set("reqSubscriberHelp", value); }
    }

    public required bool ReqSubscriberOptin {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "reqSubscriberOptin"
            );
        }
        init { this._rawData.Set("reqSubscriberOptin", value); }
    }

    public required bool ReqSubscriberOptout {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "reqSubscriberOptout"
            );
        }
        init { this._rawData.Set("reqSubscriberOptout", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MinMsgSamples;
        _ = this.Mno;
        _ = this.MnoReview;
        _ = this.MnoSupport;
        _ = this.NoEmbeddedLink;
        _ = this.NoEmbeddedPhone;
        _ = this.Qualify;
        _ = this.ReqSubscriberHelp;
        _ = this.ReqSubscriberOptin;
        _ = this.ReqSubscriberOptout;
    }

    public Mno10999 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Mno10999 (Mno10999 mno10999) : base(mno10999)
    {  }
    #pragma warning restore CS8618

    public Mno10999 (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Mno10999 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="Mno10999FromRaw.FromRawUnchecked"/>
    public static Mno10999 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class Mno10999FromRaw : IFromRawJson<Mno10999>
{
    /// <inheritdoc/>
    public Mno10999 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Mno10999.FromRawUnchecked(rawData);
}