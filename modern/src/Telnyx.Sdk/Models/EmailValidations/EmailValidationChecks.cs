using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.EmailValidations;

[JsonConverter(typeof(JsonModelConverter<EmailValidationChecks, EmailValidationChecksFromRaw>))]
public sealed record class EmailValidationChecks : JsonModel
{
    public required EmailValidationCheck Disposable {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationCheck>(
                "disposable"
            );
        }
        init { this._rawData.Set("disposable", value); }
    }

    public required EmailValidationCheck Mx {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationCheck>(
                "mx"
            );
        }
        init { this._rawData.Set("mx", value); }
    }

    public required EmailValidationCheck RoleBased {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationCheck>(
                "role_based"
            );
        }
        init { this._rawData.Set("role_based", value); }
    }

    public required EmailValidationCheck Syntax {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailValidationCheck>(
                "syntax"
            );
        }
        init { this._rawData.Set("syntax", value); }
    }

    public required Typo Typo {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Typo>(
                "typo"
            );
        }
        init { this._rawData.Set("typo", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Disposable.Validate();
        this.Mx.Validate();
        this.RoleBased.Validate();
        this.Syntax.Validate();
        this.Typo.Validate();
    }

    public EmailValidationChecks ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailValidationChecks (
        EmailValidationChecks emailValidationChecks
    ) : base(emailValidationChecks)
    {  }
    #pragma warning restore CS8618

    public EmailValidationChecks (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailValidationChecks (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="EmailValidationChecksFromRaw.FromRawUnchecked"/>
    public static EmailValidationChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class EmailValidationChecksFromRaw : IFromRawJson<EmailValidationChecks>
{
    /// <inheritdoc/>
    public EmailValidationChecks FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>EmailValidationChecks.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Typo, TypoFromRaw>))]
public sealed record class Typo : JsonModel
{
    public required bool Pass {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>(
                "pass"
            );
        }
        init { this._rawData.Set("pass", value); }
    }

    /// <summary>
    /// Human-readable check detail. Omitted when nil.
    /// </summary>
    public string? Details {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "details"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("details", value);
        }
    }

    /// <summary>
    /// Suggested correction for common typos. Omitted when nil.
    /// </summary>
    public string? Suggestion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "suggestion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("suggestion", value);
        }
    }

    public static implicit operator EmailValidationCheck (Typo typo)=> new() {
        Pass = typo.Pass, Details = typo.Details
    } ;

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Pass;
        _ = this.Details;
        _ = this.Suggestion;
    }

    public Typo ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public Typo (Typo typo) : base(typo)
    {  }
    #pragma warning restore CS8618

    public Typo (IReadOnlyDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    Typo (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="TypoFromRaw.FromRawUnchecked"/>
    public static Typo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }

    [SetsRequiredMembers]
    public Typo (bool pass) : this()
    { this.Pass = pass; }
}class TypoFromRaw : IFromRawJson<Typo>
{
    /// <inheritdoc/>
    public Typo FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>Typo.FromRawUnchecked(rawData);
}[JsonConverter(typeof(JsonModelConverter<IntersectionMember1, IntersectionMember1FromRaw>))]
public sealed record class IntersectionMember1 : JsonModel
{
    /// <summary>
    /// Suggested correction for common typos. Omitted when nil.
    /// </summary>
    public string? Suggestion {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>(
                "suggestion"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawData.Set("suggestion", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    { _ = this.Suggestion; }

    public IntersectionMember1 ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public IntersectionMember1 (IntersectionMember1 intersectionMember1) : base(
        intersectionMember1
    )
    {  }
    #pragma warning restore CS8618

    public IntersectionMember1 (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1 (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IntersectionMember1FromRaw.FromRawUnchecked"/>
    public static IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}class IntersectionMember1FromRaw : IFromRawJson<IntersectionMember1>
{
    /// <inheritdoc/>
    public IntersectionMember1 FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>IntersectionMember1.FromRawUnchecked(rawData);
}