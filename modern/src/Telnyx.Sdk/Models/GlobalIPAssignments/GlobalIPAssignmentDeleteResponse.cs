using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentDeleteResponse, GlobalIPAssignmentDeleteResponseFromRaw>))]
public sealed record class GlobalIPAssignmentDeleteResponse : JsonModel
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

    public GlobalIPAssignmentDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentDeleteResponse (
        GlobalIPAssignmentDeleteResponse globalIPAssignmentDeleteResponse
    ) : base(globalIPAssignmentDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentDeleteResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentDeleteResponseFromRaw : IFromRawJson<GlobalIPAssignmentDeleteResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentDeleteResponse.FromRawUnchecked(rawData);
}