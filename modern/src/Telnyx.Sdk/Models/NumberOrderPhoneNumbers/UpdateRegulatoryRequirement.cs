using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.NumberOrderPhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<UpdateRegulatoryRequirement, UpdateRegulatoryRequirementFromRaw>))]
public sealed record class UpdateRegulatoryRequirement : JsonModel
{
    /// <summary>
    /// The value of the requirement. For address and document requirements, this
    /// should be the ID of the resource. For textual, this should be the value of
    /// the requirement.
    /// </summary>
    public string? FieldValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "field_value"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("field_value", value);
        }
    }

    /// <summary>
    /// Unique id for a requirement.
    /// </summary>
    public string? RequirementID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "requirement_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("requirement_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.FieldValue;
        _ = this.RequirementID;
    }

    public UpdateRegulatoryRequirement ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdateRegulatoryRequirement (
        UpdateRegulatoryRequirement updateRegulatoryRequirement
    ) : base(updateRegulatoryRequirement)
    {  }
    #pragma warning restore CS8618

    public UpdateRegulatoryRequirement (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdateRegulatoryRequirement (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdateRegulatoryRequirementFromRaw.FromRawUnchecked"/>
    public static UpdateRegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdateRegulatoryRequirementFromRaw : IFromRawJson<UpdateRegulatoryRequirement>
{
    /// <inheritdoc/>
    public UpdateRegulatoryRequirement FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdateRegulatoryRequirement.FromRawUnchecked(rawData);
}