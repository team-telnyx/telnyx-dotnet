using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.CountryCoverage;

[JsonConverter(typeof(JsonModelConverter<CountryCoverageCountryCoverage, CountryCoverageCountryCoverageFromRaw>))]
public sealed record class CountryCoverageCountryCoverage : JsonModel
{
    /// <summary>
    /// Country ISO code
    /// </summary>
    public string? Code {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("code", value);
        }
    }

    /// <summary>
    /// Set of features supported
    /// </summary>
    public IReadOnlyList<string>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? InternationalSms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "international_sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("international_sms", value);
        }
    }

    /// <summary>
    /// Indicates whether country can be queried with inventory coverage endpoint
    /// </summary>
    public bool? InventoryCoverage {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "inventory_coverage"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("inventory_coverage", value);
        }
    }

    public Local? Local {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Local>(
                "local"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("local", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? Mobile {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "mobile"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "mobile",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? National {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "national"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "national",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public bool? Numbers {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "numbers"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("numbers", value);
        }
    }

    public bool? P2p {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "p2p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("p2p", value);
        }
    }

    /// <summary>
    /// Phone number type
    /// </summary>
    public IReadOnlyList<string>? PhoneNumberType {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "phone_number_type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phone_number_type",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Supports quickship
    /// </summary>
    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
        }
    }

    /// <summary>
    /// Geographic region (e.g., AMER, EMEA, APAC)
    /// </summary>
    public string? Region {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "region"
            );
        }
        init { this._rawData.Set("region", value); }
    }

    /// <summary>
    /// Supports reservable
    /// </summary>
    public bool? Reservable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reservable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reservable", value);
        }
    }

    public IReadOnlyDictionary<string, JsonElement>? SharedCost {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "shared_cost"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "shared_cost",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public TollFree? TollFree {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<TollFree>(
                "toll_free"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("toll_free", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Code;
        _ = this.Features;
        _ = this.InternationalSms;
        _ = this.InventoryCoverage;
        this.Local?.Validate();
        _ = this.Mobile;
        _ = this.National;
        _ = this.Numbers;
        _ = this.P2p;
        _ = this.PhoneNumberType;
        _ = this.Quickship;
        _ = this.Region;
        _ = this.Reservable;
        _ = this.SharedCost;
        this.TollFree?.Validate();
    }

    public CountryCoverageCountryCoverage ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public CountryCoverageCountryCoverage (
        CountryCoverageCountryCoverage countryCoverageCountryCoverage
    ) : base(countryCoverageCountryCoverage)
    {  }
    #pragma warning restore CS8618

    public CountryCoverageCountryCoverage (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    CountryCoverageCountryCoverage (
        FrozenDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="CountryCoverageCountryCoverageFromRaw.FromRawUnchecked"/>
    public static CountryCoverageCountryCoverage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class CountryCoverageCountryCoverageFromRaw : IFromRawJson<CountryCoverageCountryCoverage>
{
    /// <inheritdoc/>
    public CountryCoverageCountryCoverage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>CountryCoverageCountryCoverage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Local, LocalFromRaw>))]
public sealed record class Local : JsonModel
{
    public IReadOnlyList<string>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? FullPstnReplacement {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "full_pstn_replacement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("full_pstn_replacement", value);
        }
    }

    public bool? InternationalSms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "international_sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("international_sms", value);
        }
    }

    public bool? P2p {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "p2p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("p2p", value);
        }
    }

    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
        }
    }

    public bool? Reservable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reservable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reservable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Features;
        _ = this.FullPstnReplacement;
        _ = this.InternationalSms;
        _ = this.P2p;
        _ = this.Quickship;
        _ = this.Reservable;
    }

    public Local ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Local (Local local) : base(local)
    {  }
    #pragma warning restore CS8618

    public Local (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Local (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="LocalFromRaw.FromRawUnchecked"/>
    public static Local FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class LocalFromRaw : IFromRawJson<Local>
{
    /// <inheritdoc/>
    public Local FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Local.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<TollFree, TollFreeFromRaw>))]
public sealed record class TollFree : JsonModel
{
    public IReadOnlyList<string>? Features {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>(
                "features"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "features",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? FullPstnReplacement {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "full_pstn_replacement"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("full_pstn_replacement", value);
        }
    }

    public bool? InternationalSms {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "international_sms"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("international_sms", value);
        }
    }

    public bool? P2p {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "p2p"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("p2p", value);
        }
    }

    public bool? Quickship {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "quickship"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("quickship", value);
        }
    }

    public bool? Reservable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>(
                "reservable"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("reservable", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Features;
        _ = this.FullPstnReplacement;
        _ = this.InternationalSms;
        _ = this.P2p;
        _ = this.Quickship;
        _ = this.Reservable;
    }

    public TollFree ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public TollFree (TollFree tollFree) : base(tollFree)
    {  }
    #pragma warning restore CS8618

    public TollFree (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    TollFree (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TollFreeFromRaw.FromRawUnchecked"/>
    public static TollFree FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class TollFreeFromRaw : IFromRawJson<TollFree>
{
    /// <inheritdoc/>
    public TollFree FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>TollFree.FromRawUnchecked(rawData);
}