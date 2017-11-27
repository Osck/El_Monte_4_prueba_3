using El_Monte_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace El_Monte_4.Controllers
{
    [AutenticationFilter]
    public class CondenaDelitosController : ApiController
	{
		private CarcelDbContext context;
		public CondenaDelitosController()
		{
			context = new CarcelDbContext();
		}
		public IEnumerable<Object> get()
		{
			return context.CondenaDelito.ToList();
		}
	}
}