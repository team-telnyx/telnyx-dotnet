using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.Verifications.ByPhoneNumber;

namespace Telnyx.Sdk.Models.VerifyProfiles;

/// <summary>
/// A paginated list of Verify profiles
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VerifyProfileListPageResponse, VerifyProfileListPageResponseFromRaw>))]
public sealed record class VerifyProfileListPageResponse : JsonModel
{
    public required IReadOnlyList<VerifyProfile> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VerifyProfile>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<VerifyProfile>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required VerifyMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyMeta>(
                "meta"
            );
        }
        init { this._rawData.Set("meta", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        this.Meta.Validate();
    }

    public VerifyProfileListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileListPageResponse (
        VerifyProfileListPageResponse verifyProfileListPageResponse
    ) : base(verifyProfileListPageResponse)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static VerifyProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifyProfileListPageResponseFromRaw : IFromRawJson<VerifyProfileListPageResponse>
{
    /// <inheritdoc/>
    public VerifyProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileListPageResponse.FromRawUnchecked(rawData);
}