using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentCreateResponse, GlobalIPAssignmentCreateResponseFromRaw>))]
public sealed record class GlobalIPAssignmentCreateResponse : JsonModel
{
    public GlobalIPAssignment? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<GlobalIPAssignment>(
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

    public GlobalIPAssignmentCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentCreateResponse (
        GlobalIPAssignmentCreateResponse globalIPAssignmentCreateResponse
    ) : base(globalIPAssignmentCreateResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentCreateResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentCreateResponseFromRaw : IFromRawJson<GlobalIPAssignmentCreateResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentCreateResponse.FromRawUnchecked(rawData);
}