using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.Messaging10dlc.Brand;

/// <summary>
/// The verification status of an active brand
/// </summary>
[JsonConverter(typeof(BrandIdentityStatusConverter))]
public enum BrandIdentityStatus
{
    Verified, Unverified, SelfDeclared, VettedVerified
}

sealed class BrandIdentityStatusConverter : JsonConverter<BrandIdentityStatus>
{
    public override BrandIdentityStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "VERIFIED"=>BrandIdentityStatus.Verified,
            "UNVERIFIED"=>BrandIdentityStatus.Unverified,
            "SELF_DECLARED"=>BrandIdentityStatus.SelfDeclared,
            "VETTED_VERIFIED"=>BrandIdentityStatus.VettedVerified,
            _ =>(BrandIdentityStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandIdentityStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            BrandIdentityStatus.Verified=>"VERIFIED",
            BrandIdentityStatus.Unverified=>"UNVERIFIED",
            BrandIdentityStatus.SelfDeclared=>"SELF_DECLARED",
            BrandIdentityStatus.VettedVerified=>"VETTED_VERIFIED",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}