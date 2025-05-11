using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksiegarnia
{
    public class GroupedBookViewModel
    {
        public string Title { get; set; }
        public string CoverPath { get; set; }
        public string AuthorFullName { get; set; }
        public int Count { get; set; }
    }
}
