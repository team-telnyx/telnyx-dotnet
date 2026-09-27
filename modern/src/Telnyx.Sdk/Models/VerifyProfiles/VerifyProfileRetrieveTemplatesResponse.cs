using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifyProfiles;

/// <summary>
/// A list of Verify profile message templates
/// </summary>
[JsonConverter(typeof(JsonModelConverter<VerifyProfileRetrieveTemplatesResponse, VerifyProfileRetrieveTemplatesResponseFromRaw>))]
public sealed record class VerifyProfileRetrieveTemplatesResponse : JsonModel
{
    public required IReadOnlyList<VerifyProfileMessageTemplateResponse> Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<VerifyProfileMessageTemplateResponse>>(
                "data"
            );
        }
        init {
            this._rawData.Set<ImmutableArray<VerifyProfileMessageTemplateResponse>>(
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

    public VerifyProfileRetrieveTemplatesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifyProfileRetrieveTemplatesResponse (
        VerifyProfileRetrieveTemplatesResponse verifyProfileRetrieveTemplatesResponse
    ) : base(verifyProfileRetrieveTemplatesResponse)
    {  }
    #pragma warning restore CS8618

    public VerifyProfileRetrieveTemplatesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifyProfileRetrieveTemplatesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifyProfileRetrieveTemplatesResponseFromRaw.FromRawUnchecked"/>
    public static VerifyProfileRetrieveTemplatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public VerifyProfileRetrieveTemplatesResponse (
        IReadOnlyList<VerifyProfileMessageTemplateResponse> data
    ) : this()
    { this.Data = data; }
}

class VerifyProfileRetrieveTemplatesResponseFromRaw : IFromRawJson<VerifyProfileRetrieveTemplatesResponse>
{
    /// <inheritdoc/>
    public VerifyProfileRetrieveTemplatesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifyProfileRetrieveTemplatesResponse.FromRawUnchecked(rawData);
}