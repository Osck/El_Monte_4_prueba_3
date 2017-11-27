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
    public class DelitosController : ApiController
    {
        private CarcelDbContext context;

        public DelitosController()
        {
            context = new CarcelDbContext();
        }
        public IEnumerable<Object> get()
        {
            return context.Delito.ToList();
        }


        public IHttpActionResult get(int id)
        {
            Delito delito = context.Delito.Find(id);

            if (delito == null)//404 notfound
            {
                return NotFound();
            }


            return Ok(delito);//retornamos codigo 200 junto con el delito buscado
        }

        //api/delito
        public IHttpActionResult post(Delito delito)
        {

            context.Delito.Add(delito);
            int filasAfectadas = context.SaveChanges();

            if (filasAfectadas == 0)
            {
                return InternalServerError();//500
            }

            return Ok(new { mensaje = "Agregado correctamente" });

        }


        //api/clientes/{id}
        public IHttpActionResult delete(int id)
        {
            //buscamos el delito a eliminar
            Delito delito = context.Delito.Find(id);

            if (delito == null) return NotFound();//404

            context.Delito.Remove(delito);

            if (context.SaveChanges() > 0)
            {
                //retornamos codigo 200
                return Ok(new { Mensaje = "Eliminado correctamente" });
            }

            return InternalServerError();//500

        }

        public IHttpActionResult put(Delito delito)
        {
            context.Entry(delito).State = System.Data.Entity.EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                return Ok(new { Mensaje = "Modificado correctamente" });
            }

            return InternalServerError();



        }

    }
}