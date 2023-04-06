using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
    public class NoteCatigories
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public int CatigoriesId { get; set; }
        public Note Note { get; set; }
        public Categories Categories { get; set; }
    }
}
