using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telnyx.net.Entities.PhoneNumbers.CommentAsRead;

namespace Telnyx.net.Services.PhoneNumbers.CommentAsRead
{
    public class CommentAsReadService : ServiceNested<CommentsAsRead>
    {
        
        public override string BasePath => "/comments/:id/read";
        public CommentsAsRead Update(string parentId, string id, UpsertCommentAsRead options, RequestOptions requestOptions)
        {
            return this.UpdateNestedEntity(parentId, id, options, requestOptions);
        }

        public async Task<CommentsAsRead> UpdateAsync(string parentId, string id, UpsertCommentAsRead options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.UpdateNestedEntityAsync(parentId, id, options, requestOptions, parentToken: parentToken, cancellationToken: cancellationToken);
        }
    }
}
