using System.Net;

namespace Telnyx.Sdk.Exceptions;

public class TelnyxExceptionFactory
{
    public static TelnyxApiException CreateApiException(
        HttpStatusCode statusCode, string responseBody
    )
    {
        return (int) statusCode switch
        {
            400=>new TelnyxBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401=>new TelnyxUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403=>new TelnyxForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404=>new TelnyxNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422=>new TelnyxUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429=>new TelnyxRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499=>new Telnyx4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599=>new Telnyx5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ =>new TelnyxUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            }
        };
    }
}