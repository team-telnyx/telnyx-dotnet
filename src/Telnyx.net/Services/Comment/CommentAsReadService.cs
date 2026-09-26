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
        
        public override string BasePath => "/comments/{PARENT_ID}/read";
        public CommentsAsRead Update(string parentId, string id, UpsertCommentAsRead options, RequestOptions requestOptions)
        {
            // This is a single-comment action; legacy parentId/options do not belong on the wire.
            return this.PatchRequest<CommentsAsRead>(this.ClassUrl(Uri.EscapeDataString(id)), null, requestOptions, "data");
        }

        public async Task<CommentsAsRead> UpdateAsync(string parentId, string id, UpsertCommentAsRead options, RequestOptions requestOptions, string parentToken, CancellationToken cancellationToken)
        {
            return await this.PatchRequestAsync<CommentsAsRead>(this.ClassUrl(Uri.EscapeDataString(id)), null, requestOptions, parentToken: string.IsNullOrEmpty(parentToken) ? "data" : parentToken, cancellationToken: cancellationToken);
        }
    }
}
