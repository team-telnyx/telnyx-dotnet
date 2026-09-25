using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.SimCards.Actions;

[JsonConverter(typeof(JsonModelConverter<ActionValidateRegistrationCodesResponse, ActionValidateRegistrationCodesResponseFromRaw>))]
public sealed record class ActionValidateRegistrationCodesResponse : JsonModel
{
    public IReadOnlyList<Data>? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Data>>(
                "data"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Data>?>(
                "data",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Data ?? [])
        {
            item.Validate();
        }
    }

    public ActionValidateRegistrationCodesResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public ActionValidateRegistrationCodesResponse (
        ActionValidateRegistrationCodesResponse actionValidateRegistrationCodesResponse
    ) : base(actionValidateRegistrationCodesResponse)
    {  }
    #pragma warning restore CS8618

    public ActionValidateRegistrationCodesResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    ActionValidateRegistrationCodesResponse (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="ActionValidateRegistrationCodesResponseFromRaw.FromRawUnchecked"/>
    public static ActionValidateRegistrationCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class ActionValidateRegistrationCodesResponseFromRaw : IFromRawJson<ActionValidateRegistrationCodesResponse>
{
    /// <inheritdoc/>
    public ActionValidateRegistrationCodesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>ActionValidateRegistrationCodesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Data, DataFromRaw>))]
public sealed record class Data : JsonModel
{
    /// <summary>
    /// The validation message
    /// </summary>
    public string? InvalidDetail {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "invalid_detail"
            );
        }
        init { this._rawData.Set("invalid_detail", value); }
    }

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
    /// The 10-digit SIM card registration code
    /// </summary>
    public string? RegistrationCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "registration_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("registration_code", value);
        }
    }

    /// <summary>
    /// The attribute that denotes whether the code is valid or not
    /// </summary>
    public bool? Valid {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "valid"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("valid", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.InvalidDetail;
        _ = this.RecordType;
        _ = this.RegistrationCode;
        _ = this.Valid;
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
}