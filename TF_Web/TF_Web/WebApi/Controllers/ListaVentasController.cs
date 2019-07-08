using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaVentasController : Controller
    {
        private IListaVentaService lvserv;
        public ListaVentasController(IListaVentaService lvs)
        {
            this.lvserv = lvs;
        }

        [HttpGet("{DetalleId}")]
        public ActionResult GetDetalle([FromRoute] int DetalleId)
        {
            return Ok(
                lvserv.Get(DetalleId)
            );
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                lvserv.GetAll()
            );
        }

        [HttpPost]
        public ActionResult GenerarLista([FromBody] ListaVenta model)
        {
            return Ok(
                lvserv.Add(model)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] ListaVenta model)
        {
            return Ok(
                lvserv.Update(model)
            );
        }

    }
}