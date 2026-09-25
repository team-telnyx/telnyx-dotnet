using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileRecallResponse, ProfileRecallResponseFromRaw>))]
public sealed record class ProfileRecallResponse : JsonModel
{
    public required IReadOnlyList<ProfileRecallResponseData> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ProfileRecallResponseData>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<ProfileRecallResponseData>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
    }

    public ProfileRecallResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRecallResponse (
        ProfileRecallResponse profileRecallResponse
    ) : base(profileRecallResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileRecallResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRecallResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRecallResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRecallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ProfileRecallResponse (
        IReadOnlyList<ProfileRecallResponseData> data
    ) : this()
    { this.Data = data; }
}

class ProfileRecallResponseFromRaw : IFromRawJson<ProfileRecallResponse>
{
    /// <inheritdoc/>
    public ProfileRecallResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRecallResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProfileRecallResponseData, ProfileRecallResponseDataFromRaw>))]
public sealed record class ProfileRecallResponseData : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    public string? RecordedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "recorded_at"
            );
        }
        init { this._rawData.Set("recorded_at", value); }
    }

    /// <summary>
    /// Relevance, 0-1. Null where the deployment's reranker is a passthrough; results
    /// are in rank order either way.
    /// </summary>
    public double? Score {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>(
                "score"
            );
        }
        init { this._rawData.Set("score", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Text;
        _ = this.RecordedAt;
        _ = this.Score;
    }

    public ProfileRecallResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRecallResponseData (
        ProfileRecallResponseData profileRecallResponseData
    ) : base(profileRecallResponseData)
    {  }
    #pragma warning restore CS8618

    public ProfileRecallResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRecallResponseData (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRecallResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileRecallResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProfileRecallResponseDataFromRaw : IFromRawJson<ProfileRecallResponseData>
{
    /// <inheritdoc/>
    public ProfileRecallResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRecallResponseData.FromRawUnchecked(rawData);
}