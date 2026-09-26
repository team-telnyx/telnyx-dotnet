using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests;

/// <summary>
/// Update an existing tollfree verification request. This is particularly useful
/// when there are pending customer actions to be taken.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class RequestUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();public IReadOnlyDictionary<string, JsonElement> RawBodyData {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ID { get; init; }

    /// <summary>
    /// Any additional information
    /// </summary>
    public required string AdditionalInformation {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "additionalInformation"
            );
        }
        init { this._rawBodyData.Set("additionalInformation", value); }
    }

    /// <summary>
    /// Line 1 of the business address
    /// </summary>
    public required string BusinessAddr1 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessAddr1"
            );
        }
        init { this._rawBodyData.Set("businessAddr1", value); }
    }

    /// <summary>
    /// The city of the business address; the first letter should be capitalized
    /// </summary>
    public required string BusinessCity {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessCity"
            );
        }
        init { this._rawBodyData.Set("businessCity", value); }
    }

    /// <summary>
    /// The email address of the business contact
    /// </summary>
    public required string BusinessContactEmail {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessContactEmail"
            );
        }
        init { this._rawBodyData.Set("businessContactEmail", value); }
    }

    /// <summary>
    /// First name of the business contact; there are no specific requirements on formatting
    /// </summary>
    public required string BusinessContactFirstName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessContactFirstName"
            );
        }
        init { this._rawBodyData.Set("businessContactFirstName", value); }
    }

    /// <summary>
    /// Last name of the business contact; there are no specific requirements on formatting
    /// </summary>
    public required string BusinessContactLastName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessContactLastName"
            );
        }
        init { this._rawBodyData.Set("businessContactLastName", value); }
    }

    /// <summary>
    /// The phone number of the business contact in E.164 format
    /// </summary>
    public required string BusinessContactPhone {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessContactPhone"
            );
        }
        init { this._rawBodyData.Set("businessContactPhone", value); }
    }

    /// <summary>
    /// Name of the business; there are no specific formatting requirements
    /// </summary>
    public required string BusinessName {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessName"
            );
        }
        init { this._rawBodyData.Set("businessName", value); }
    }

    /// <summary>
    /// The full name of the state (not the 2 letter code) of the business address;
    /// the first letter should be capitalized
    /// </summary>
    public required string BusinessState {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessState"
            );
        }
        init { this._rawBodyData.Set("businessState", value); }
    }

    /// <summary>
    /// The ZIP code of the business address
    /// </summary>
    public required string BusinessZip {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "businessZip"
            );
        }
        init { this._rawBodyData.Set("businessZip", value); }
    }

    /// <summary>
    /// A URL, including the scheme, pointing to the corporate website
    /// </summary>
    public required string CorporateWebsite {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "corporateWebsite"
            );
        }
        init { this._rawBodyData.Set("corporateWebsite", value); }
    }

    /// <summary>
    /// Message Volume Enums
    /// </summary>
    public required ApiEnum<string, Volume> MessageVolume {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Volume>>(
                "messageVolume"
            );
        }
        init { this._rawBodyData.Set("messageVolume", value); }
    }

    /// <summary>
    /// Human-readable description of how end users will opt into receiving messages
    /// from the given phone numbers
    /// </summary>
    public required string OptInWorkflow {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "optInWorkflow"
            );
        }
        init { this._rawBodyData.Set("optInWorkflow", value); }
    }

    /// <summary>
    /// Images showing the opt-in workflow
    /// </summary>
    public required IReadOnlyList<global::Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests.Url> OptInWorkflowImageUrls {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<global::Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests.Url>>(
                "optInWorkflowImageURLs"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<global::Telnyx.Sdk.Models.MessagingTollfree.Verification.Requests.Url>>(
                "optInWorkflowImageURLs",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The phone numbers to request the verification of
    /// </summary>
    public required IReadOnlyList<TfPhoneNumber> PhoneNumbers {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<TfPhoneNumber>>(
                "phoneNumbers"
            );
        }
        init {
            this._rawBodyData.Set<ImmutableArray<TfPhoneNumber>>(
                "phoneNumbers",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// An example of a message that will be sent from the given phone numbers
    /// </summary>
    public required string ProductionMessageContent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "productionMessageContent"
            );
        }
        init { this._rawBodyData.Set("productionMessageContent", value); }
    }

    /// <summary>
    /// Tollfree usecase categories
    /// </summary>
    public required ApiEnum<string, UseCaseCategories> UseCase {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, UseCaseCategories>>(
                "useCase"
            );
        }
        init { this._rawBodyData.Set("useCase", value); }
    }

    /// <summary>
    /// Human-readable summary of the desired use-case
    /// </summary>
    public required string UseCaseSummary {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>(
                "useCaseSummary"
            );
        }
        init { this._rawBodyData.Set("useCaseSummary", value); }
    }

    /// <summary>
    /// Indicates if messaging content requires age gating (e.g., 18+). Defaults
    /// to false if not provided.
    /// </summary>
    public bool? AgeGatedContent {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>(
                "ageGatedContent"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("ageGatedContent", value);
        }
    }

    /// <summary>
    /// Line 2 of the business address
    /// </summary>
    public string? BusinessAddr2 {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "businessAddr2"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("businessAddr2", value);
        }
    }

    /// <summary>
    /// ISO 3166-1 alpha-2 country code of the issuing business authority. Must be
    /// exactly 2 letters. Automatically converted to uppercase. Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationCountry {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "businessRegistrationCountry"
            );
        }
        init { this._rawBodyData.Set("businessRegistrationCountry", value); }
    }

    /// <summary>
    /// Official business registration number (e.g., Employer Identification Number
    /// (EIN) in the U.S.). Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationNumber {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "businessRegistrationNumber"
            );
        }
        init { this._rawBodyData.Set("businessRegistrationNumber", value); }
    }

    /// <summary>
    /// Type of business registration being provided. Required from January 2026.
    /// </summary>
    public string? BusinessRegistrationType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "businessRegistrationType"
            );
        }
        init { this._rawBodyData.Set("businessRegistrationType", value); }
    }

    /// <summary>
    /// Campaign Verify Authorization Token required for Political use case submissions
    /// starting February 17, 2026. This token is validated by Zipwhip and must be
    /// provided for all Political use case verifications after the deadline.
    /// </summary>
    public string? CampaignVerifyAuthorizationToken {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "campaignVerifyAuthorizationToken"
            );
        }
        init {
            this._rawBodyData.Set("campaignVerifyAuthorizationToken", value);
        }
    }

    /// <summary>
    /// Doing Business As (DBA) name if different from legal name
    /// </summary>
    public string? DoingBusinessAs {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "doingBusinessAs"
            );
        }
        init { this._rawBodyData.Set("doingBusinessAs", value); }
    }

    /// <summary>
    /// Business entity classification
    /// </summary>
    public ApiEnum<string, MessagingTollFreeVerificationEntityType>? EntityType {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessagingTollFreeVerificationEntityType>>(
                "entityType"
            );
        }
        init { this._rawBodyData.Set("entityType", value); }
    }

    /// <summary>
    /// The message returned when users text 'HELP'
    /// </summary>
    public string? HelpMessageResponse {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "helpMessageResponse"
            );
        }
        init { this._rawBodyData.Set("helpMessageResponse", value); }
    }

    /// <summary>
    /// ISV name
    /// </summary>
    public string? IsvReseller {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "isvReseller"
            );
        }
        init { this._rawBodyData.Set("isvReseller", value); }
    }

    /// <summary>
    /// Message sent to users confirming their opt-in to receive messages
    /// </summary>
    public string? OptInConfirmationResponse {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "optInConfirmationResponse"
            );
        }
        init { this._rawBodyData.Set("optInConfirmationResponse", value); }
    }

    /// <summary>
    /// Keywords used to collect and process consumer opt-ins
    /// </summary>
    public string? OptInKeywords {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "optInKeywords"
            );
        }
        init { this._rawBodyData.Set("optInKeywords", value); }
    }

    /// <summary>
    /// URL pointing to the business's privacy policy. Plain string, no URL format validation.
    /// </summary>
    public string? PrivacyPolicyUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "privacyPolicyURL"
            );
        }
        init { this._rawBodyData.Set("privacyPolicyURL", value); }
    }

    /// <summary>
    /// URL pointing to the business's terms and conditions. Plain string, no URL
    /// format validation.
    /// </summary>
    public string? TermsAndConditionUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "termsAndConditionURL"
            );
        }
        init { this._rawBodyData.Set("termsAndConditionURL", value); }
    }

    /// <summary>
    /// URL that should receive webhooks relating to this verification request
    /// </summary>
    public string? WebhookUrl {
        get {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>(
                "webhookUrl"
            );
        }
        init {
            if (value == null) {
                return;
            }

            this._rawBodyData.Set("webhookUrl", value);
        }
    }

    public RequestUpdateParams ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequestUpdateParams (RequestUpdateParams requestUpdateParams) : base(
        requestUpdateParams
    )
    {
        this.ID = requestUpdateParams.ID;

        this._rawBodyData = new(requestUpdateParams._rawBodyData);
    }
    #pragma warning restore CS8618

    public RequestUpdateParams (
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    RequestUpdateParams (
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ID = id;
    }
    #pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static RequestUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string id
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            id
        ) ;
    }

    public override string ToString()
    =>JsonSerializer.Serialize(FriendlyJsonPrinter.PrintValue(new Dictionary<string, JsonElement>(

    )
    {
        ["ID"] = JsonSerializer.SerializeToElement(this.ID),
        ["HeaderData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())),
        ["QueryData"] = FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())),
        ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
    }), ModelBase.ToStringSerializerOptions);

    public virtual bool Equals(RequestUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ID?.Equals(other.ID) ?? other.ID == null)&&this._rawHeaderData.Equals(other._rawHeaderData)&&this._rawQueryData.Equals(other._rawQueryData)&&this._rawBodyData.Equals(
            other._rawBodyData
        ) ;
    }

    public override Uri Url(ClientOptions options)
    {
        return this.ResolvePaginationUrl(new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + string.Format("/messaging_tollfree/verification/requests/{0}",
            EncodePathSegment(this.ID))
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