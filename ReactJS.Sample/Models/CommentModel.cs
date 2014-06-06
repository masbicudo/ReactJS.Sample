
namespace ReactJS.Sample.Models
{
    /// <summary>
    /// Models a comment.
    /// </summary>
    public class CommentModel
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the comment author.
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the text of the comment.
        /// </summary>
        public string Text { get; set; }
    }
}