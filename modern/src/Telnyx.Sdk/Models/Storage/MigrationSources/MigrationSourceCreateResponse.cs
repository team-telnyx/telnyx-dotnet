using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.MigrationSources;

[JsonConverter(typeof(JsonModelConverter<MigrationSourceCreateResponse, MigrationSourceCreateResponseFromRaw>))]
public sealed record class MigrationSourceCreateResponse : JsonModel
{
    public MigrationSourceParams? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MigrationSourceParams>(
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

    public MigrationSourceCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceCreateResponse (
        MigrationSourceCreateResponse migrationSourceCreateResponse
    ) : base(migrationSourceCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationSourceCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationSourceCreateResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationSourceCreateResponseFromRaw.FromRawUnchecked"/>
    public static MigrationSourceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationSourceCreateResponseFromRaw : IFromRawJson<MigrationSourceCreateResponse>
{
    /// <inheritdoc/>
    public MigrationSourceCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationSourceCreateResponse.FromRawUnchecked(rawData);
}