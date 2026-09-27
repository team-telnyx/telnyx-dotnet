using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Migrations;

[JsonConverter(typeof(JsonModelConverter<MigrationCreateResponse, MigrationCreateResponseFromRaw>))]
public sealed record class MigrationCreateResponse : JsonModel
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

    public MigrationCreateResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public MigrationCreateResponse (
        MigrationCreateResponse migrationCreateResponse
    ) : base(migrationCreateResponse)
    {  }
    #pragma warning restore CS8618

    public MigrationCreateResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    MigrationCreateResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="MigrationCreateResponseFromRaw.FromRawUnchecked"/>
    public static MigrationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class MigrationCreateResponseFromRaw : IFromRawJson<MigrationCreateResponse>
{
    /// <inheritdoc/>
    public MigrationCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>MigrationCreateResponse.FromRawUnchecked(rawData);
}