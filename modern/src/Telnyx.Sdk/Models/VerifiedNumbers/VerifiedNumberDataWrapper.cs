using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.VerifiedNumbers;

[JsonConverter(typeof(JsonModelConverter<VerifiedNumberDataWrapper, VerifiedNumberDataWrapperFromRaw>))]
public sealed record class VerifiedNumberDataWrapper : JsonModel
{
    public VerifiedNumber? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<VerifiedNumber>(
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

    public VerifiedNumberDataWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public VerifiedNumberDataWrapper (
        VerifiedNumberDataWrapper verifiedNumberDataWrapper
    ) : base(verifiedNumberDataWrapper)
    {  }
    #pragma warning restore CS8618

    public VerifiedNumberDataWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    VerifiedNumberDataWrapper (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="VerifiedNumberDataWrapperFromRaw.FromRawUnchecked"/>
    public static VerifiedNumberDataWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class VerifiedNumberDataWrapperFromRaw : IFromRawJson<VerifiedNumberDataWrapper>
{
    /// <inheritdoc/>
    public VerifiedNumberDataWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>VerifiedNumberDataWrapper.FromRawUnchecked(rawData);
}