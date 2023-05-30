using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.NumberPortouts;

namespace Telnyx.net.Services.NumberPortouts
{
    public class NumberPortoutCommentService : Service<PortoutComment>
    {
        public NumberPortoutCommentService()
           : base(null) { }

        public NumberPortoutCommentService(string apiKey)
            : base(apiKey) { }
        public override string BasePath => "/portouts";

        public override string PostPath => "/comments";


        public TelnyxList<PortoutComment> ListAllCommentsForAPortoutRequest(string id, RequestOptions reqOpts = null)
        {
            return this.ListEntities(this.PostPath, null, reqOpts, id);
        }

        public async Task<TelnyxList<PortoutComment>> ListAllCommentsForAPortoutRequestAsync(string id, RequestOptions reqOpts = null, CancellationToken ct = default)
        {
            return await this.ListEntitiesAsync(this.PostPath, null, reqOpts, ct, id);
        }

        public virtual PortoutComment CreateCommentsForAPortoutRequest(string id, CreateCommentsForAPortoutRequestOptions options, RequestOptions requestOptions = null)
        {
            return this.CreateEntity(id, options, requestOptions, this.PostPath);
        }

        public async Task<PortoutComment> CreateCommentsForAPortoutRequestAsync(string id, CreateCommentsForAPortoutRequestOptions createOptions, RequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.CreateEntityAsync(id, createOptions, requestOptions, cancellationToken, this.PostPath);
        }
    }
}
