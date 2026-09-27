using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Requirements;

[JsonConverter(typeof(JsonModelConverter<RequirementRetrieveResponse, RequirementRetrieveResponseFromRaw>))]
public sealed record class RequirementRetrieveResponse : JsonModel
{
    public DocReqsRequirement? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocReqsRequirement>(
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

    public RequirementRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementRetrieveResponse (
        RequirementRetrieveResponse requirementRetrieveResponse
    ) : base(requirementRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RequirementRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementRetrieveResponseFromRaw : IFromRawJson<RequirementRetrieveResponse>
{
    /// <inheritdoc/>
    public RequirementRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementRetrieveResponse.FromRawUnchecked(rawData);
}