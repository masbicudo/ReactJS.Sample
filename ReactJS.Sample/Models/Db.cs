using System.Collections.Generic;

namespace ReactJS.Sample.Models
{
    public static class Db
    {
        public static readonly Dictionary<int, CommentModel> Comments;

        static Db()
        {
            Comments = new Dictionary<int, CommentModel>();
        }
    }
}