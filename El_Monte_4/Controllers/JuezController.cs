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
    public class JuezController : ApiController
    {
        private CarcelDbContext context;

        public JuezController()
        {
            context = new CarcelDbContext();
        }
        public IEnumerable<Object> get()
        {
            return context.Juez.ToList();
        }

        public IHttpActionResult get(int id)
        {
            Juez juez = context.Juez.Find(id);

            if (juez == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(juez);//retornamos codigo 200 junto con el Juez buscado
        }

        //api/Juez
        public IHttpActionResult post(Juez juez)
        {

            context.Juez.Add(juez);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/Juez/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos el Juez a eliminar
            Juez juez = context.Juez.Find(id);

            if (juez == null) return NotFound();//404

            context.Juez.Remove(juez);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Juez juez)
        {
            context.Entry(juez).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

    }
}