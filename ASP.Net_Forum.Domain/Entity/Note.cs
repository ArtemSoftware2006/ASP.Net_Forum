using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.Domain.Entity
{
	[Table("Notes")]
	public class Note
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string ShortDiscription { get; set; }
		public string Body { get; set; }
		public DateTime DateCreated { get; set; }
		[ForeignKey("Users")]
		public int UserId { get; set; }
		public virtual User User { get; set; }
	}
}
