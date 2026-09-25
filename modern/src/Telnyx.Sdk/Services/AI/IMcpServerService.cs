using System;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.Sdk.Core;
using Telnyx.Sdk.Models.AI.McpServers;

namespace Telnyx.Sdk.Services.AI;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IMcpServerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IMcpServerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMcpServerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    ;

    /// <summary>
/// Creates a new MCP server configuration on your account and returns the created
/// server.
/// </summary>
    Task<McpServer> Create(
        McpServerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Retrieve details for a specific MCP server.
/// </summary>
    Task<McpServer> Retrieve(
        McpServerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(McpServerRetrieveParams, CancellationToken)"/>
    Task<McpServer> Retrieve(
        string mcpServerID,
        McpServerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Updates the specified MCP server's configuration and returns the updated server.
/// </summary>
    Task<McpServer> Update(
        McpServerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(McpServerUpdateParams, CancellationToken)"/>
    Task<McpServer> Update(
        string mcpServerID,
        McpServerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a paginated list of the MCP servers configured on your account, with
/// optional filtering by type or URL.
/// </summary>
    Task<McpServerListPage> List(
        McpServerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Permanently deletes the specified MCP server configuration from your account.
/// </summary>
    Task Delete(
        McpServerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(McpServerDeleteParams, CancellationToken)"/>
    Task Delete(
        string mcpServerID,
        McpServerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}

/// <summary>
/// A view of <see cref="IMcpServerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IMcpServerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IMcpServerServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>post /ai/mcp_servers</c>, but is otherwise the
/// same as <see cref="IMcpServerService.Create(McpServerCreateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<McpServer>> Create(
        McpServerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/mcp_servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.Retrieve(McpServerRetrieveParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<McpServer>> Retrieve(
        McpServerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Retrieve(McpServerRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<McpServer>> Retrieve(
        string mcpServerID,
        McpServerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>put /ai/mcp_servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.Update(McpServerUpdateParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<McpServer>> Update(
        McpServerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Update(McpServerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<McpServer>> Update(
        string mcpServerID,
        McpServerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>get /ai/mcp_servers</c>, but is otherwise the
/// same as <see cref="IMcpServerService.List(McpServerListParams?, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse<McpServerListPage>> List(
        McpServerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;

    /// <summary>
/// Returns a raw HTTP response for <c>delete /ai/mcp_servers/{mcp_server_id}</c>, but is otherwise the
/// same as <see cref="IMcpServerService.Delete(McpServerDeleteParams, CancellationToken)"/>.
/// </summary>
    Task<HttpResponse> Delete(
        McpServerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    ;/// <inheritdoc cref="Delete(McpServerDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string mcpServerID,
        McpServerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    ;
}