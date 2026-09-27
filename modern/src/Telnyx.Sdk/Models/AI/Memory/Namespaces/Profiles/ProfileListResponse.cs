using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileListResponse, ProfileListResponseFromRaw>))]
public sealed record class ProfileListResponse : JsonModel
{
    /// <summary>
    /// Memories stored under this profile, including the consolidated ones that
    /// paraphrase others. Listings are ordered by it.
    /// </summary>
    public required long MemoryCount {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "memory_count"
            );
        }
        init { this._rawData.Set("memory_count", value); }
    }

    public required string ProfileID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "profile_id"
            );
        }
        init { this._rawData.Set("profile_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.MemoryCount;
        _ = this.ProfileID;
    }

    public ProfileListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileListResponse (ProfileListResponse profileListResponse) : base(
        profileListResponse
    )
    {  }
    #pragma warning restore CS8618

    public ProfileListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileListResponseFromRaw.FromRawUnchecked"/>
    public static ProfileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ProfileListResponseFromRaw : IFromRawJson<ProfileListResponse>
{
    /// <inheritdoc/>
    public ProfileListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileListResponse.FromRawUnchecked(rawData);
}