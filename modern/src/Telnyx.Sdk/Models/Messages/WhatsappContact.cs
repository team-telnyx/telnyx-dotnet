using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<WhatsappContact, WhatsappContactFromRaw>))]
public sealed record class WhatsappContact : JsonModel
{
    public IReadOnlyList<Address>? Addresses {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Address>>(
                "addresses"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Address>?>(
                "addresses",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Birthday {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "birthday"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("birthday", value);
        }
    }

    public IReadOnlyList<Email>? Emails {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Email>>(
                "emails"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Email>?>(
                "emails",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? Name {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "name"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public Org? Org {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Org>(
                "org"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("org", value);
        }
    }

    public IReadOnlyList<Phone>? Phones {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Phone>>(
                "phones"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Phone>?>(
                "phones",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public IReadOnlyList<Url>? Urls {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Url>>(
                "urls"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set<ImmutableArray<Url>?>(
                "urls",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Addresses ?? [])
        {
            item.Validate();
        }
        _ = this.Birthday;
        foreach (var item in this.Emails ?? [])
        {
            item.Validate();
        }
        _ = this.Name;
        this.Org?.Validate();
        foreach (var item in this.Phones ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Urls ?? [])
        {
            item.Validate();
        }
    }

    public WhatsappContact ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public WhatsappContact (WhatsappContact whatsappContact) : base(
        whatsappContact
    )
    {  }
    #pragma warning restore CS8618

    public WhatsappContact (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    WhatsappContact (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappContactFromRaw.FromRawUnchecked"/>
    public static WhatsappContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class WhatsappContactFromRaw : IFromRawJson<WhatsappContact>
{
    /// <inheritdoc/>
    public WhatsappContact FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>WhatsappContact.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
{
    public string? City {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "city"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("city", value);
        }
    }

    public string? Country {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country", value);
        }
    }

    public string? CountryCode {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "country_code"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("country_code", value);
        }
    }

    public string? State {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "state"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("state", value);
        }
    }

    public string? Street {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "street"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("street", value);
        }
    }

    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? Zip {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "zip"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("zip", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.City;
        _ = this.Country;
        _ = this.CountryCode;
        _ = this.State;
        _ = this.Street;
        _ = this.Type;
        _ = this.Zip;
    }

    public Address ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address (Address address) : base(address)
    {  }
    #pragma warning restore CS8618

    public Address (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Address (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Address.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Email, EmailFromRaw>))]
public sealed record class Email : JsonModel
{
    public string? EmailValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "email"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.EmailValue;
        _ = this.Type;
    }

    public Email ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Email (Email email) : base(email)
    {  }
    #pragma warning restore CS8618

    public Email (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Email (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailFromRaw.FromRawUnchecked"/>
    public static Email FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class EmailFromRaw : IFromRawJson<Email>
{
    /// <inheritdoc/>
    public Email FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Email.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Org, OrgFromRaw>))]
public sealed record class Org : JsonModel
{
    public string? Company {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "company"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("company", value);
        }
    }

    public string? Department {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "department"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("department", value);
        }
    }

    public string? Title {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "title"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("title", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Company;
        _ = this.Department;
        _ = this.Title;
    }

    public Org ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Org (Org org) : base(org)
    {  }
    #pragma warning restore CS8618

    public Org (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Org (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="OrgFromRaw.FromRawUnchecked"/>
    public static Org FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class OrgFromRaw : IFromRawJson<Org>
{
    /// <inheritdoc/>
    public Org FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Org.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Phone, PhoneFromRaw>))]
public sealed record class Phone : JsonModel
{
    public string? PhoneValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "phone"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("phone", value);
        }
    }

    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? WaID {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "wa_id"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("wa_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.PhoneValue;
        _ = this.Type;
        _ = this.WaID;
    }

    public Phone ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Phone (Phone phone) : base(phone)
    {  }
    #pragma warning restore CS8618

    public Phone (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Phone (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="PhoneFromRaw.FromRawUnchecked"/>
    public static Phone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class PhoneFromRaw : IFromRawJson<Phone>
{
    /// <inheritdoc/>
    public Phone FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Phone.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<Url, UrlFromRaw>))]
public sealed record class Url : JsonModel
{
    public string? Type {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "type"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("type", value);
        }
    }

    public string? UrlValue {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "url"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("url", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Type;
        _ = this.UrlValue;
    }

    public Url ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Url (Url url) : base(url)
    {  }
    #pragma warning restore CS8618

    public Url (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Url (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UrlFromRaw.FromRawUnchecked"/>
    public static Url FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class UrlFromRaw : IFromRawJson<Url>
{
    /// <inheritdoc/>
    public Url FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Url.FromRawUnchecked(rawData);
}