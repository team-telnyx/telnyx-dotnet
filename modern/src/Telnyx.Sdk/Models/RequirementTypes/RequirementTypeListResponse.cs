using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.RequirementTypes;

[JsonConverter(typeof(JsonModelConverter<RequirementTypeListResponse, RequirementTypeListResponseFromRaw>))]
public sealed record class RequirementTypeListResponse : JsonModel
{
    public IReadOnlyList<DocReqsRequirementType>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DocReqsRequirementType>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<DocReqsRequirementType>?>(
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

    public RequirementTypeListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementTypeListResponse (
        RequirementTypeListResponse requirementTypeListResponse
    ) : base(requirementTypeListResponse)
    {  }
    #pragma warning restore CS8618

    public RequirementTypeListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementTypeListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementTypeListResponseFromRaw.FromRawUnchecked"/>
    public static RequirementTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementTypeListResponseFromRaw : IFromRawJson<RequirementTypeListResponse>
{
    /// <inheritdoc/>
    public RequirementTypeListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementTypeListResponse.FromRawUnchecked(rawData);
}