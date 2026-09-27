using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.PhoneNumbers.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionVerifyOwnershipResponse, ActionVerifyOwnershipResponseFromRaw>))]
public sealed record class ActionVerifyOwnershipResponse : JsonModel
{
    public Data? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Data>(
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

    public ActionVerifyOwnershipResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionVerifyOwnershipResponse (
        ActionVerifyOwnershipResponse actionVerifyOwnershipResponse
    ) : base(actionVerifyOwnershipResponse)
    {  }
    #pragma warning restore CS8618

    public ActionVerifyOwnershipResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionVerifyOwnershipResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionVerifyOwnershipResponseFromRaw.FromRawUnchecked"/>
    public static ActionVerifyOwnershipResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionVerifyOwnershipResponseFromRaw : IFromRawJson<ActionVerifyOwnershipResponse>
{
    /// <inheritdoc/>
    public ActionVerifyOwnershipResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionVerifyOwnershipResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The list of phone numbers which you own and are in an editable state
    /// </summary>
    public IReadOnlyList<Found>? Found {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Found>>(
                "found"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Found>?>(
                "found",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Phone numbers that are not found in the account
    /// </summary>
    public IReadOnlyList<string>? NotFound {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "not_found"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "not_found",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
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

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Found ?? [])
        {
            item.Validate();
        }
        _ = this.NotFound;
        _ = this.RecordType;
    }

    public Data ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Data (Data data) : base(data)
    {  }
    #pragma warning restore CS8618

    public Data (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Data (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="DataFromRaw.FromRawUnchecked"/>
    public static Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class DataFromRaw : IFromRawJson<Data>
{
    /// <inheritdoc/>
    public Data FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Data.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Found, FoundFromRaw>))]
public sealed record class Found : JsonModel
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
    /// The phone number in E.164 format
    /// </summary>
    public string? NumberValE164 {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "number_val_e164"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("number_val_e164", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.NumberValE164;
    }

    public Found ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Found (Found found) : base(found)
    {  }
    #pragma warning restore CS8618

    public Found (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Found (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="FoundFromRaw.FromRawUnchecked"/>
    public static Found FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class FoundFromRaw : IFromRawJson<Found>
{
    /// <inheritdoc/>
    public Found FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Found.FromRawUnchecked(rawData);
}