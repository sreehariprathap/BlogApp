using System;
using System.Collections.Generic;

namespace BlogApp24012022.Models
{
    public partial class Post
    {
        public int Postid { get; set; }
        public string Title { get; set; }
        public DateTime? Createddate { get; set; }
        public string Description { get; set; }
        public int? Categoryid { get; set; }

        public virtual Category Category { get; set; }
    }
}
