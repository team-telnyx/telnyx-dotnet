using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentRetrieveResponse, GlobalIPAssignmentRetrieveResponseFromRaw>))]
public sealed record class GlobalIPAssignmentRetrieveResponse : JsonModel
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

    public GlobalIPAssignmentRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentRetrieveResponse (
        GlobalIPAssignmentRetrieveResponse globalIPAssignmentRetrieveResponse
    ) : base(globalIPAssignmentRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentRetrieveResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentRetrieveResponseFromRaw : IFromRawJson<GlobalIPAssignmentRetrieveResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentRetrieveResponse.FromRawUnchecked(rawData);
}