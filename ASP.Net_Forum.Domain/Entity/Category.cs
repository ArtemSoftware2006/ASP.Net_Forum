using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}
