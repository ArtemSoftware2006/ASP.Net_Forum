using ASP.Net_Forum.DAL.Migrations;
using ASP.Net_Forum.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.Net_Forum.DAL.Interfaces
{
	public interface INoteRepository : IBaseRepository<Domain.Entity.Note>
	{
	}
}
