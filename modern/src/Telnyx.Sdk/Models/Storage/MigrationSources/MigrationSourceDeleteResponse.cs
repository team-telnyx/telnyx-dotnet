using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.MigrationSources;

[JsonConverter(typeof(JsonModelConverter<MigrationSourceDeleteResponse, MigrationSourceDeleteResponseFromRaw>))]
public sealed record class MigrationSourceDeleteResponse : JsonModel
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

    public MigrationSourceDeleteResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationSourceDeleteResponse (
        MigrationSourceDeleteResponse migrationSourceDeleteResponse
    ) : base(migrationSourceDeleteResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationSourceDeleteResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationSourceDeleteResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationSourceDeleteResponseFromRaw.FromRawUnchecked"/>
    public static MigrationSourceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationSourceDeleteResponseFromRaw : IFromRawJson<MigrationSourceDeleteResponse>
{
    /// <inheritdoc/>
    public MigrationSourceDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationSourceDeleteResponse.FromRawUnchecked(rawData);
}