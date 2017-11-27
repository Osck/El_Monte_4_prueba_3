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
    public class CondenaController : ApiController
    {
        private CarcelDbContext context;

        public CondenaController()
        {
            context = new CarcelDbContext();
        }
        List<Condena> Condenas = new List<Condena>()
        {

        };

        public IEnumerable<object> get()
        {
            return context.CondenaDelito.Include("Preso").Select(c => new
            {
                Delitos = c.Delito.Nombre,
                Condena = c.Condena,

                Preso = new
                {
                    Nombre = c.Condenas.Preso.Nombre,
                    Apellido = c.Condenas.Preso.Apellido,
                    Rut = c.Condenas.Preso.Rut
                },


            });


        }

        public IHttpActionResult get(int id)
        {
            Condena condena = context.Condena.Find(id);

            if (condena == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(condena);//retornamos codigo 200 junto con la conena buscado
        }

        //api/condena
        public IHttpActionResult post(Condena condena)
        {

            context.Condena.Add(condena);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/condena/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos la conda a eliminar
            Condena condena = context.Condena.Find(id);

            if (condena == null) return NotFound();//404

            context.Condena.Remove(condena);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Condena condena)
        {
            context.Entry(condena).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

    }
}