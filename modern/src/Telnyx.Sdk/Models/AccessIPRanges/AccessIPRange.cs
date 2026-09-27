using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AccessIPAddress;

namespace Telnyx.Sdk.Models.AccessIPRanges;

[JsonConverter(typeof(JsonModelConverter<AccessIPRange, AccessIPRangeFromRaw>))]
public sealed record class AccessIPRange : JsonModel
{
    public required string ID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "id"
            );
        }
        init { this._rawData.Set("id", value); }
    }

    public required string CidrBlock {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "cidr_block"
            );
        }
        init { this._rawData.Set("cidr_block", value); }
    }

    /// <summary>
    /// An enumeration.
    /// </summary>
    public required ApiEnum<string, CloudflareSyncStatus> Status {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, CloudflareSyncStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    public required string UserID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>(
                "user_id"
            );
        }
        init { this._rawData.Set("user_id", value); }
    }

    public DateTimeOffset? CreatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    public string? Description {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "description"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public DateTimeOffset? UpdatedAt {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>(
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CidrBlock;
        this.Status.Validate();
        _ = this.UserID;
        _ = this.CreatedAt;
        _ = this.Description;
        _ = this.UpdatedAt;
    }

    public AccessIPRange ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public AccessIPRange (AccessIPRange accessIPRange) : base(accessIPRange)
    {  }
    #pragma warning restore CS8618

    public AccessIPRange (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    AccessIPRange (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AccessIPRangeFromRaw.FromRawUnchecked"/>
    public static AccessIPRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class AccessIPRangeFromRaw : IFromRawJson<AccessIPRange>
{
    /// <inheritdoc/>
    public AccessIPRange FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>AccessIPRange.FromRawUnchecked(rawData);
}