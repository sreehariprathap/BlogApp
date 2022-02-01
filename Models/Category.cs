﻿using System;
using System.Collections.Generic;

namespace BlogApp24012022.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
