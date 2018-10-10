using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerAPI.apis.Models;

namespace TallerAPI.apis.Controllers
{
    public class PublicacionController : ApiController
    {
        [HttpGet]
        public IEnumerable<Publicacion> Get()
        {
            using(var context = new PublicacionContext())
            {
                return context.Publicaciones.ToList();
            }
        }

        [HttpGet]
        public Publicacion Get(int id)
        {
            using (var context = new PublicacionContext())
            {
                return context.Publicaciones.FirstOrDefault(x=> x.Id == id);
            }
        }

        [HttpPost]
        public Publicacion Post(Publicacion publicacion)
        {
            using (var context = new PublicacionContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges();
                return publicacion;
            }
        }

        [HttpPut]
        public Publicacion Put(Publicacion publicacion)
        {
            using (var context = new PublicacionContext())
            {
                var publicacionAct = context.Publicaciones.FirstOrDefault(x => x.Id == publicacion.Id);
                publicacionAct.Usuario = publicacion.Usuario;
                publicacionAct.FechaPublicacion = publicacion.FechaPublicacion;
                publicacionAct.Descripcion = publicacion.Descripcion;
                publicacionAct.MeGusta = publicacion.MeGusta;
                publicacionAct.MeDisgusta = publicacion.MeDisgusta;
                publicacionAct.VecesCompartido = publicacion.VecesCompartido;
                publicacionAct.EsPrivada = publicacion.EsPrivada;


                context.Publicaciones.Add(publicacion);
                context.SaveChanges();
                return publicacion;
            }
        }
    }
}

