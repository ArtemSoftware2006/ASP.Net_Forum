using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
    public class UserViews
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public Note Note { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
