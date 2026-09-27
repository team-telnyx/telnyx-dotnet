using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Storage.Sqldbs;

[JsonConverter(typeof(JsonModelConverter<SqlDatabaseResponseWrapper, SqlDatabaseResponseWrapperFromRaw>))]
public sealed record class SqlDatabaseResponseWrapper : JsonModel
{
    public SqlDatabase? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<SqlDatabase>(
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

    public SqlDatabaseResponseWrapper ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public SqlDatabaseResponseWrapper (
        SqlDatabaseResponseWrapper sqlDatabaseResponseWrapper
    ) : base(sqlDatabaseResponseWrapper)
    {  }
    #pragma warning restore CS8618

    public SqlDatabaseResponseWrapper (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    SqlDatabaseResponseWrapper (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="SqlDatabaseResponseWrapperFromRaw.FromRawUnchecked"/>
    public static SqlDatabaseResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class SqlDatabaseResponseWrapperFromRaw : IFromRawJson<SqlDatabaseResponseWrapper>
{
    /// <inheritdoc/>
    public SqlDatabaseResponseWrapper FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>SqlDatabaseResponseWrapper.FromRawUnchecked(rawData);
}