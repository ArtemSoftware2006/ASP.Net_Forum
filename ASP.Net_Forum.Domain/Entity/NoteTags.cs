using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
	public class NoteTags
	{
		public int Id { get; set; }
		public int TagId { get; set; }
		public Tag Tag { get; set; }
		public int NoteId { get; set; }
		public Note Note { get; set; }
	}
}
