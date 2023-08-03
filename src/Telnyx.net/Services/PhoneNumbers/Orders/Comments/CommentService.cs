namespace Telnyx.net.Services.PhoneNumbers.Orders.Comments
{
    using System.Threading;
    using System.Threading.Tasks;
    using Telnyx.net.Entities;
    using Telnyx.net.Entities.PhoneNumbers.Orders.Comments;

    public class CommentService : Service<Comment>
    {
        public CommentService()
           : base(null)
        {
        }

        public CommentService(string apiKey)
            : base(apiKey)
        {
        }

        public override string BasePath => "/comments";

        public async Task<TelnyxList<Comment>> ListCommentsAsync(CommentListOptions listOptions, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(listOptions, reqOpts, string.Empty, ct);
        }

        public TelnyxList<Comment> ListComments(CommentListOptions listOptions, RequestOptions reqOpts = null)
        {
            return this.ListEntities(listOptions, reqOpts);
        }

        public async Task<Comment> RetrieveCommentsAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.GetEntityAsync(id, reqOpts, parentToken: "data", ct);
        }

        public Comment RetrieveComments(string id, RequestOptions reqOpts = null)
        {
            return this.GetEntity(id, reqOpts, parentToken: "data");
        }

        public virtual Comment Create(CommentCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(options, requestOptions, parentToken: "data");
        }

        public async Task<Comment> CreateAsync(CommentCreateOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(createOptions, requestOptions, parentToken: "data", cancellationToken: cancellationToken);
        }
    }
}
