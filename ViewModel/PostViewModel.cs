using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp24012022.ViewModel
{
    public class PostViewModel
    {
        public int Postid { get; set; }
        public string Title { get; set; }
        public DateTime? Createddate { get; set; }
        public string Description { get; set; }
        public int? Categoryid { get; set; }

        public string CategoryName { get; set; }

    }
}
