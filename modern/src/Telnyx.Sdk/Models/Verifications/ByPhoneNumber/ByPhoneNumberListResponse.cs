using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Verifications.ByPhoneNumber;

[JsonConverter(typeof(JsonModelConverter<ByPhoneNumberListResponse, ByPhoneNumberListResponseFromRaw>))]
public sealed record class ByPhoneNumberListResponse : JsonModel
{
    public required IReadOnlyList<Verification> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Verification>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<Verification>>(
                "data",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required VerifyMeta Meta {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<VerifyMeta>(
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

    public ByPhoneNumberListResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ByPhoneNumberListResponse (
        ByPhoneNumberListResponse byPhoneNumberListResponse
    ) : base(byPhoneNumberListResponse)
    {  }
    #pragma warning restore CS8618

    public ByPhoneNumberListResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ByPhoneNumberListResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ByPhoneNumberListResponseFromRaw.FromRawUnchecked"/>
    public static ByPhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ByPhoneNumberListResponseFromRaw : IFromRawJson<ByPhoneNumberListResponse>
{
    /// <inheritdoc/>
    public ByPhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ByPhoneNumberListResponse.FromRawUnchecked(rawData);
}