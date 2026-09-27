using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Core;

namespace Telnyx.Sdk.Models.Organizations.Users;

[JsonConverter(typeof(JsonModelConverter<UserRetrieveResponse, UserRetrieveResponseFromRaw>))]
public sealed record class UserRetrieveResponse : JsonModel
{
    public OrganizationUser? Data {
        get {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<OrganizationUser>(
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

    public UserRetrieveResponse ()
    {  }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserRetrieveResponse (
        UserRetrieveResponse userRetrieveResponse
    ) : base(userRetrieveResponse)
    {  }
    #pragma warning restore CS8618

    public UserRetrieveResponse (
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { this._rawData = new(rawData); }

    #pragma warning disable CS8618
    [SetsRequiredMembers]
    UserRetrieveResponse (FrozenDictionary<string, JsonElement> rawData)
    { this._rawData = new(rawData); }
    #pragma warning restore CS8618

    /// <inheritdoc cref="UserRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static UserRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    { return new(FrozenDictionary.ToFrozenDictionary(rawData)); }
}

class UserRetrieveResponseFromRaw : IFromRawJson<UserRetrieveResponse>
{
    /// <inheritdoc/>
    public UserRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    =>UserRetrieveResponse.FromRawUnchecked(rawData);
}