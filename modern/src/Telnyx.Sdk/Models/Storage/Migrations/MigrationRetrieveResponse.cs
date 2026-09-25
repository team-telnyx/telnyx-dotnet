using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Migrations;

[JsonConverter(typeof(JsonModelConverter<MigrationRetrieveResponse, MigrationRetrieveResponseFromRaw>))]
public sealed record class MigrationRetrieveResponse : JsonModel
{
    public MigrationParams? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MigrationParams>(
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

    public MigrationRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationRetrieveResponse (
        MigrationRetrieveResponse migrationRetrieveResponse
    ) : base(migrationRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MigrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationRetrieveResponseFromRaw : IFromRawJson<MigrationRetrieveResponse>
{
    /// <inheritdoc/>
    public MigrationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationRetrieveResponse.FromRawUnchecked(rawData);
}