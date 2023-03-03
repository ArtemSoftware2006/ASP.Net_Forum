using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
	public class Note
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime DateCreated { get; set; }
	}
}
