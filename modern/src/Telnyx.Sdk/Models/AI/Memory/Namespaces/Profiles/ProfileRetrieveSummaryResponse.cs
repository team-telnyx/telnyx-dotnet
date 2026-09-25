using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.AI.Memory.Namespaces.Profiles;

[JsonConverter(typeof(JsonModelConverter<ProfileRetrieveSummaryResponse, ProfileRetrieveSummaryResponseFromRaw>))]
public sealed record class ProfileRetrieveSummaryResponse : JsonModel
{
    public required ProfileRetrieveSummaryResponseData Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ProfileRetrieveSummaryResponseData>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public ProfileRetrieveSummaryResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveSummaryResponse (
        ProfileRetrieveSummaryResponse profileRetrieveSummaryResponse
    ) : base(profileRetrieveSummaryResponse)
    {  }
    #pragma warning restore CS8618

    public ProfileRetrieveSummaryResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveSummaryResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveSummaryResponseFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public ProfileRetrieveSummaryResponse (
        ProfileRetrieveSummaryResponseData data
    ) : this()
    { this.Data = data; }
}

class ProfileRetrieveSummaryResponseFromRaw : IFromRawJson<ProfileRetrieveSummaryResponse>
{
    /// <inheritdoc/>
    public ProfileRetrieveSummaryResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRetrieveSummaryResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ProfileRetrieveSummaryResponseData, ProfileRetrieveSummaryResponseDataFromRaw>))]
public sealed record class ProfileRetrieveSummaryResponseData : JsonModel
{
    /// <summary>
    /// Whether newer memories have arrived since the summary was generated. The summary
    /// is regenerated in the background, so a true here is ordinary and the summary
    /// is still usable.
    /// </summary>
    public required bool IsStale {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "is_stale"
            );
        }
        init { this._rawData.Set("is_stale", value); }
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

    /// <summary>
    /// When the summary was last generated. Null while none is ready.
    /// </summary>
    public string? GeneratedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "generated_at"
            );
        }
        init { this._rawData.Set("generated_at", value); }
    }

    /// <summary>
    /// The precomputed summary, ready to place in an assistant's context at the
    /// start of a session.
    /// </summary>
    public string? Text {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "text"
            );
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsStale;
        _ = this.ProfileID;
        _ = this.GeneratedAt;
        _ = this.Text;
    }

    public ProfileRetrieveSummaryResponseData ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ProfileRetrieveSummaryResponseData (
        ProfileRetrieveSummaryResponseData profileRetrieveSummaryResponseData
    ) : base(profileRetrieveSummaryResponseData)
    {  }
    #pragma warning restore CS8618

    public ProfileRetrieveSummaryResponseData (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ProfileRetrieveSummaryResponseData (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ProfileRetrieveSummaryResponseDataFromRaw.FromRawUnchecked"/>
    public static ProfileRetrieveSummaryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class ProfileRetrieveSummaryResponseDataFromRaw : IFromRawJson<ProfileRetrieveSummaryResponseData>
{
    /// <inheritdoc/>
    public ProfileRetrieveSummaryResponseData FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ProfileRetrieveSummaryResponseData.FromRawUnchecked(rawData);
}