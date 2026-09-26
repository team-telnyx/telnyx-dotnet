using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.GlobalIPAssignments;

/// <summary>
/// Updates the specified Global IP assignment with the provided fields and returns
/// the updated assignment.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GlobalIPAssignmentUpdateParams : ParamsBase
{
    public JsonElement RawBodyData { get; private init; }

    public string? GlobalIPAssignmentID { get; init; }

    public required GlobalIPAssignmentUpdateRequest GlobalIPAssignmentUpdateRequest {
        get {
            return WrappedJsonSerializer.GetNotNullClass<GlobalIPAssignmentUpdateRequest>(this.RawBodyData, "RawBodyData");
        }
        init { this.RawBodyData = JsonSerializer.SerializeToElement(value); }
    }

    public GlobalIPAssignmentUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentUpdateParams (
        GlobalIPAssignmentUpdateParams globalIPAssignmentUpdateParams
    ) : base(globalIPAssignmentUpdateParams)
    {
        this.GlobalIPAssignmentID = globalIPAssignmentUpdateParams.GlobalIPAssignmentID;

        this.RawBodyData = globalIPAssignmentUpdateParams.RawBodyData;
    }
    #pragma warning restore CS8618

    public GlobalIPAssignmentUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string globalIPAssignmentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.RawBodyData = rawBodyData;
        this.GlobalIPAssignmentID = globalIPAssignmentID;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static GlobalIPAssignmentUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        JsonElement rawBodyData,
        string globalIPAssignmentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            rawBodyData,
            globalIPAssignmentID
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["GlobalIPAssignmentID"] = JsonSerializer.SerializeToElement(this.GlobalIPAssignmentID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this.RawBodyData),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(GlobalIPAssignmentUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.GlobalIPAssignmentID?.Equals(other.GlobalIPAssignmentID) ?? other.GlobalIPAssignmentID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this.RawBodyData.Equals(
            other.RawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/global_ip_assignments/{0}",
            EncodePathSegment(this.GlobalIPAssignmentID))
        )
        {
            Query = this.QueryString(options, new() { BearerAuth = true })
        }.Uri) ;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        ) ;
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

[JsonConverter(typeof(JsonModelConverter<GlobalIPAssignmentUpdateRequest, GlobalIPAssignmentUpdateRequestFromRaw>))]
public sealed record class GlobalIPAssignmentUpdateRequest : JsonModel
{
    /// <summary>
    /// Identifies the resource.
    /// </summary>
    public string? ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("id", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was created.
    /// </summary>
    public string? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "created_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("created_at", value);
        }
    }

    /// <summary>
    /// Identifies the type of the resource.
    /// </summary>
    public string? RecordType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "record_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("record_type", value);
        }
    }

    /// <summary>
    /// ISO 8601 formatted date-time indicating when the resource was updated.
    /// </summary>
    public string? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "updated_at"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("updated_at", value);
        }
    }

    public string? GlobalIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "global_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_id", value);
        }
    }

    public string? WireguardPeerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_peer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer_id", value);
        }
    }

    public static implicit operator GlobalIPAssignment (
        GlobalIPAssignmentUpdateRequest globalIPAssignmentUpdateRequest
    )=> new() {
        ID = globalIPAssignmentUpdateRequest.ID,
        CreatedAt = globalIPAssignmentUpdateRequest.CreatedAt,
        RecordType = globalIPAssignmentUpdateRequest.RecordType,
        UpdatedAt = globalIPAssignmentUpdateRequest.UpdatedAt
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.RecordType;
        _ = this.UpdatedAt;
        _ = this.GlobalIPID;
        _ = this.WireguardPeerID;
    }

    public GlobalIPAssignmentUpdateRequest ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIPAssignmentUpdateRequest (
        GlobalIPAssignmentUpdateRequest globalIPAssignmentUpdateRequest
    ) : base(globalIPAssignmentUpdateRequest)
    {  }
    #pragma warning restore CS8618

    public GlobalIPAssignmentUpdateRequest (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIPAssignmentUpdateRequest (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPAssignmentUpdateRequestFromRaw.FromRawUnchecked"/>
    public static GlobalIPAssignmentUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPAssignmentUpdateRequestFromRaw : IFromRawJson<GlobalIPAssignmentUpdateRequest>
{
    /// <inheritdoc/>
    public GlobalIPAssignmentUpdateRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIPAssignmentUpdateRequest.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<GlobalIP, GlobalIPFromRaw>))]
public sealed record class GlobalIP : JsonModel
{
    public string? GlobalIPID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "global_ip_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("global_ip_id", value);
        }
    }

    public string? WireguardPeerID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wireguard_peer_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wireguard_peer_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.GlobalIPID;
        _ = this.WireguardPeerID;
    }

    public GlobalIP ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public GlobalIP (GlobalIP globalIP) : base(globalIP)
    {  }
    #pragma warning restore CS8618

    public GlobalIP (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    GlobalIP (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="GlobalIPFromRaw.FromRawUnchecked"/>
    public static GlobalIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class GlobalIPFromRaw : IFromRawJson<GlobalIP>
{
    /// <inheritdoc/>
    public GlobalIP FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>GlobalIP.FromRawUnchecked(rawData);
}