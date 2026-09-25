using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AuthenticationProviders;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentListPageResponse, GlobalIPAssignmentListPageResponseFromRaw>))]
public sealed record class GlobalIPAssignmentListPageResponse : JsonModel
{
    public IReadOnlyList<GlobalIPAssignment>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<GlobalIPAssignment>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<GlobalIPAssignment>?>(
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

    public GlobalIPAssignmentListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentListPageResponse (
        GlobalIPAssignmentListPageResponse globalIPAssignmentListPageResponse
    ) : base(globalIPAssignmentListPageResponse)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentListPageResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentListPageResponseFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentListPageResponseFromRaw : IFromRawJson<GlobalIPAssignmentListPageResponse>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentListPageResponse.FromRawUnchecked(rawData);
}