using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileListPageResponse, ProfileListPageResponseFromRaw>))]
public sealed record class ProfileListPageResponse : JsonModel
{
    public required IReadOnlyList<ProfileListResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProfileListResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ProfileListResponse>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Where a listing's page sits in the whole.
    ///
    /// <para>A page is a snapshot: the counts it reports and the order it is drawn
    /// in both move as writes land, so paging through a busy namespace can repeat
    /// or miss an entry at a page boundary.</para>
    /// </summary>
    public required PageMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PageMeta>(
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

    public ProfileListPageResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListPageResponse (
        ProfileListPageResponse profileListPageResponse
    ) : base(profileListPageResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileListPageResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListPageResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListPageResponseFromRaw.FromRawUnchecked"/>
    public static ProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProfileListPageResponseFromRaw : IFromRawJson<ProfileListPageResponse>
{
    /// <inheritdoc/>
    public ProfileListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileListPageResponse.FromRawUnchecked(rawData);
}