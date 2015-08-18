using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.MODELS.Filters;

namespace Blog.MODELS
{
    public class BlogEntry
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string PostContents { get; set; }
        public DateTime DateOfPost { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int StatusID { get; set; }
        public string UserID { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }

        public string StripContents(string html)
        {
            return HtmlRemoval.StripTagsCharArray(html);
        }
    }
}
