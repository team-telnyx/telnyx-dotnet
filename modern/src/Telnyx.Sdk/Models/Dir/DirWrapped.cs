using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Dir;

[JsonConverter(typeof(JsonModelConverter<DirWrapped, DirWrappedFromRaw>))]
public sealed record class DirWrapped : JsonModel
{
    public required DirDir Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<DirDir>(
                "data"
            );
        }
        init { this._rawData.Set("data", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    { this.Data.Validate(); }

    public DirWrapped ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public DirWrapped (DirWrapped dirWrapped) : base(dirWrapped)
    {  }
    #pragma warning restore CS8618

    public DirWrapped (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    DirWrapped (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DirWrappedFromRaw.FromRawUnchecked"/>
    public static DirWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public DirWrapped (DirDir data) : this()
    { this.Data = data; }
}

class DirWrappedFromRaw : IFromRawJson<DirWrapped>
{
    /// <inheritdoc/>
    public DirWrapped FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>DirWrapped.FromRawUnchecked(rawData);
}