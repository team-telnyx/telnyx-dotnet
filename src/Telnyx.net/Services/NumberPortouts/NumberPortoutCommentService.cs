namespace Telnyx.net.Services.NumberPortouts
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.NumberPortouts;

    public class NumberPortoutCommentService : Service<PortoutComment>
    {
        public NumberPortoutCommentService()
           : base(null)
        {
        }

        public NumberPortoutCommentService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/portouts";

        public override string PostPath => "/comments";


        public TelnyxList<PortoutComment> ListAllCommentsForAPortoutRequest(string id, RequestOptions reqOpts = null)
        {
            return this.ListEntities(this.PostPath, null, reqOpts, id: id);
        }

        public async Task<TelnyxList<PortoutComment>> ListAllCommentsForAPortoutRequestAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, null, reqOpts, string.Empty, id, ct);
        }

        public virtual PortoutComment CreateCommentsForAPortoutRequest(string id, CreateCommentsForAPortoutRequestOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, options, requestOptions, this.PostPath, parentToken: "data", isJsonResponse: true);
        }

        public async Task<PortoutComment> CreateCommentsForAPortoutRequestAsync(string id, CreateCommentsForAPortoutRequestOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(id, createOptions, requestOptions, this.PostPath, parentToken: "data", cancellationToken);
        }
    }
}
