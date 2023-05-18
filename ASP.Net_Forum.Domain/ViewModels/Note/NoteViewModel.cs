using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.ViewModels.Note
{
	public class NoteViewModel
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public string ShortDiscription { get; set; }
		public int UserId { get; set; }
	}
}
