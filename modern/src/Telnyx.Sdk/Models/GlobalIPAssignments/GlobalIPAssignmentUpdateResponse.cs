using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentUpdateResponse, GlobalIPAssignmentUpdateResponseFromRaw>))]
public sealed record class GlobalIPAssignmentUpdateResponse : JsonModel
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

    public GlobalIPAssignmentUpdateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentUpdateResponse (
        GlobalIPAssignmentUpdateResponse globalIPAssignmentUpdateResponse
    ) : base(globalIPAssignmentUpdateResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentUpdateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentUpdateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentUpdateResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentUpdateResponseFromRaw : IFromRawJson<GlobalIPAssignmentUpdateResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentUpdateResponse.FromRawUnchecked(rawData);
}