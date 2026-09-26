using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingProfiles.AutorespConfigs;

/// <summary>
/// Returns the auto-response rules configured for the specified messaging profile.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class AutorespConfigListParams : ParamsBase
{
    public string? ProfileID { get; init; }

    /// <summary>
    /// Filter results by country code.
    /// </summary>
    public string? CountryCode {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("country_code", value);
        }
    }

    /// <summary>
    /// Consolidated created_at parameter (deepObject style). Originally: created_at[gte], created_at[lte]
    /// </summary>
    public CreatedAt? CreatedAt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<CreatedAt>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Consolidated updated_at parameter (deepObject style). Originally: updated_at[gte], updated_at[lte]
    /// </summary>
    public UpdatedAt? UpdatedAt {
        get {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<UpdatedAt>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawQueryData.Set("updated_at", value);
        }
    }

    public AutorespConfigListParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AutorespConfigListParams (
        AutorespConfigListParams autorespConfigListParams
    ) : base(autorespConfigListParams)
    { this.ProfileID = autorespConfigListParams.ProfileID; }
    #pragma warning restore CS8618

    public AutorespConfigListParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AutorespConfigListParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string profileID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.ProfileID = profileID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static AutorespConfigListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string profileID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            profileID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ProfileID"] = JsonSerializer.SerializeToElement(this.ProfileID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(AutorespConfigListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ProfileID?.Equals(other.ProfileID) ?? other.ProfileID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/messaging_profiles/{0}/autoresp_configs",
            EncodePathSegment(this.ProfileID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override void AddHeadersToRequest(
        HttpRequestMessage request, ClientOptions options
    )
    {
        ParamsBase.AddDefaultHeaders(
            request, options, new() { BearerAuth = true }
        );
        foreach (var item in this.RawHeaderData)
        {
            // Explicit per-request headers replace defaults (case-insensitive).
            // Callers own these overrides, including on unauthenticated routes.
            request.Headers.Remove(item.Key);
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    { return 0; }
}

/// <summary>
/// Consolidated created_at parameter (deepObject style). Originally: created_at[gte], created_at[lte]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<CreatedAt, CreatedAtFromRaw>))]
public sealed record class CreatedAt : JsonModel
{
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public CreatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CreatedAt (CreatedAt createdAt) : base(createdAt)
    {  }
    #pragma warning restore CS8618

    public CreatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CreatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CreatedAtFromRaw.FromRawUnchecked"/>
    public static CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CreatedAtFromRaw : IFromRawJson<CreatedAt>
{
    /// <inheritdoc/>
    public CreatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CreatedAt.FromRawUnchecked(rawData);
}

/// <summary>
/// Consolidated updated_at parameter (deepObject style). Originally: updated_at[gte], updated_at[lte]
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UpdatedAt, UpdatedAtFromRaw>))]
public sealed record class UpdatedAt : JsonModel
{
    public string? Gte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "gte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("gte", value);
        }
    }

    public string? Lte {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "lte"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("lte", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Gte;
        _ = this.Lte;
    }

    public UpdatedAt ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UpdatedAt (UpdatedAt updatedAt) : base(updatedAt)
    {  }
    #pragma warning restore CS8618

    public UpdatedAt (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UpdatedAt (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UpdatedAtFromRaw.FromRawUnchecked"/>
    public static UpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UpdatedAtFromRaw : IFromRawJson<UpdatedAt>
{
    /// <inheritdoc/>
    public UpdatedAt FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UpdatedAt.FromRawUnchecked(rawData);
}