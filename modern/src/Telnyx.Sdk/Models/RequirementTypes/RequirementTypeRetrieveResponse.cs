using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.RequirementTypes;

[JsonConverter(typeof(JsonModelConverter<RequirementTypeRetrieveResponse, RequirementTypeRetrieveResponseFromRaw>))]
public sealed record class RequirementTypeRetrieveResponse : JsonModel
{
    public DocReqsRequirementType? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<DocReqsRequirementType>(
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

    public RequirementTypeRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementTypeRetrieveResponse (
        RequirementTypeRetrieveResponse requirementTypeRetrieveResponse
    ) : base(requirementTypeRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public RequirementTypeRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementTypeRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="RequirementTypeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static RequirementTypeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class RequirementTypeRetrieveResponseFromRaw : IFromRawJson<RequirementTypeRetrieveResponse>
{
    /// <inheritdoc/>
    public RequirementTypeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>RequirementTypeRetrieveResponse.FromRawUnchecked(rawData);
}