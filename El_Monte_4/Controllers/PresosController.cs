using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using El_Monte_4.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace El_Monte_4.Controllers
{
    [AutenticationFilter]
    public class PresosController : ApiController
    {
        private CarcelDbContext context;

        public PresosController()
        {
            this.context = new CarcelDbContext();
        }

        List<Preso> preso = new List<Preso>()
        {
            new Preso() { Rut="169244111",Nombre="Jorge", Apellido="suazo",  Id=1 },
			//new Preso() { Nombre="marcelo", Apellido="vergara", Edad=37, ID=2 },
			//new Preso() { Nombre="rodrigo", Apellido="ruiz", Edad=29, ID=3 }
		};

        public IEnumerable<object> get()
        {
            return context.CondenaDelito.Include("Condena").Select(c => new
            {
                Condena = c.Condena,

                Delito = c.Delito.Nombre,
                Preso = new
                {
                    Nombre = c.Condenas.Preso.Nombre,
                    ApellidoPreso = c.Condenas.Preso.Apellido,
                    RutPreso = c.Condenas.Preso.Rut
                }

            });
        }
        public IHttpActionResult get(int id)
        {
            Preso preso = context.Preso.Find(id);

            if (preso == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(preso);//retornamos codigo 200 junto con el Preso buscado
        }
        //api/presos

        public IHttpActionResult post(Preso preso)
        {

            context.Preso.Add(preso);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/presos/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos el preso a eliminar
            Preso preso = context.Preso.Find(id);

            if (preso == null) return NotFound();//404

            context.Preso.Remove(preso);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }


        public IHttpActionResult put(Preso preso)
        {
            context.Entry(preso).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }
    }



}