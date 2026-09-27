using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities;
using Telnyx.net.Entities.PortingOrders.PortingOrderComments;

namespace Telnyx.net.Services.PortingOrders.PortingOrderComments
{
    public class PortingOrderCommentService : ServiceNested<PortingOrderComment>
    {
        public override string BasePath => "/porting_orders/{PARENT_ID}/comments";

        protected override string ClassUrl(string parentId, string baseUrl = null)
        {
            PortingOrderPath.ValidateId(parentId);
            return base.ClassUrl(parentId, baseUrl);
        }

        public TelnyxList<PortingOrderComment> List(string id, PortingOrderCommentOption listOptions = null, RequestOptions requestOptions = null)
        {
            return this.ListNestedEntities(id, listOptions, requestOptions, string.Empty);
        }

        /// <inheritdoc/>
        public async Task<TelnyxList<PortingOrderComment>> ListAsync(string id, PortingOrderCommentOption listOptions = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default)
        {
            return await this.ListNestedEntitiesAsync(id, listOptions, requestOptions, string.Empty, cancellationToken);
        }

        public PortingOrderComment Create(string parentId, UpsertPortingOrderComment options, RequestOptions requestOptions)
        {
            return this.PostRequest<PortingOrderComment>(this.ClassUrl(parentId), options, requestOptions, parentToken: "data");
        }

        public async Task<PortingOrderComment> CreateAsync(string parentId, UpsertPortingOrderComment options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.CreateNestedEntityAsync(parentId, options, requestOptions, string.IsNullOrEmpty(parentToken) ? "data" : parentToken, cancellationToken);
        }
    }
}
