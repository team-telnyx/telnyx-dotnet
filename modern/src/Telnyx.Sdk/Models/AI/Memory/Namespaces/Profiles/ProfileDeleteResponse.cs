using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileDeleteResponse, ProfileDeleteResponseFromRaw>))]
public sealed record class ProfileDeleteResponse : JsonModel
{
    public required Data Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Data>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ProfileDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileDeleteResponse (
        ProfileDeleteResponse profileDeleteResponse
    ) : base(profileDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileDeleteResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ProfileDeleteResponse (Data data) : this()
    { this.Data = data; }
}

class ProfileDeleteResponseFromRaw : IFromRawJson<ProfileDeleteResponse>
{
    /// <inheritdoc/>
    public ProfileDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileDeleteResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// Memories the profile held and no longer does, counted before and after. A
    /// report rather than an audit: memory moves in the background between the two
    /// counts. The status carries the outcome.
    /// </summary>
    public required long MemoriesDeleted {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>(
                "memories_deleted"
            );
        }
        init { this._rawData.Set("memories_deleted", value); }
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
        _ = this.MemoriesDeleted;
        _ = this.ProfileID;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}