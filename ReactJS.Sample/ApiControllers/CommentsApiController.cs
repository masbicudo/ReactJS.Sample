using System.Collections.Generic;
using System.Web.Http;
using ReactJS.Sample.Models;

namespace ReactJS.Sample.ApiControllers
{
    public class CommentsApiController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<CommentModel> Get()
        {
            lock (Db.Comments)
                return Db.Comments.Values;
        }

        // GET api/<controller>/5
        public CommentModel Get(int id)
        {
            lock (Db.Comments)
                return Db.Comments[id];
        }

        // POST api/<controller>
        public int Post([FromBody]CommentModel value)
        {
            lock (Db.Comments)
            {
                value.Id = Db.Comments.Count + 1;
                Db.Comments.Add(value.Id, value);
                return value.Id;
            }
        }

        // PUT api/<controller>/5
        public bool Put(int id, [FromBody]CommentModel value)
        {
            lock (Db.Comments)
            {
                if (!Db.Comments.ContainsKey(id))
                    return false;

                value.Id = id;
                Db.Comments[id] = value;
                return true;
            }
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            lock (Db.Comments)
            {
                if (!Db.Comments.ContainsKey(id))
                    return false;

                Db.Comments.Remove(id);
                return true;
            }
        }
    }
}