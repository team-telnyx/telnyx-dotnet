using System = System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Telnyx.Sdk.Exceptions;

namespace Telnyx.Sdk.Models.AI.Assistants.Tests.Runs;

/// <summary>
/// Represents the lifecycle of a test:   - 'pending': Test is waiting to be executed.
///   - 'starting': Test execution is initializing.   - 'running': Test is currently
/// executing.   - 'passed': Test completed successfully.   - 'failed': Test executed
/// but did not pass.   - 'error': An error occurred during test execution.
/// </summary>
[JsonConverter(typeof(TestStatusConverter))]
public enum TestStatus
{
    Pending, Starting, Running, Passed, Failed, Error
}

sealed class TestStatusConverter : JsonConverter<TestStatus>
{
    public override TestStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending"=>TestStatus.Pending,
            "starting"=>TestStatus.Starting,
            "running"=>TestStatus.Running,
            "passed"=>TestStatus.Passed,
            "failed"=>TestStatus.Failed,
            "error"=>TestStatus.Error,
            _ =>(TestStatus)(-1)
        };
    }

    public override void Write(
        Utf8JsonWriter writer, TestStatus value, JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(writer, value switch
        {
            TestStatus.Pending=>"pending",
            TestStatus.Starting=>"starting",
            TestStatus.Running=>"running",
            TestStatus.Passed=>"passed",
            TestStatus.Failed=>"failed",
            TestStatus.Error=>"error",
            _ => throw new TelnyxInvalidDataException(string.Format("Invalid value '{0}' in {1}",
            value,
            nameof(value)))
        }, options);
    }
}