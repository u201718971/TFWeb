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
    public class VentaController : Controller
    {
        private IVentaService vserv;
        public VentaController(IVentaService vs)
        {
            this.vserv = vs;
        }

        [HttpGet("{DetalleId}")]
        public ActionResult GetDetalle([FromRoute] int DetalleId)
        {
            return Ok(
                vserv.Get(DetalleId)
            );
        }

        [HttpGet("{Id}")]
        public ActionResult GetTotal([FromRoute] int Id)
        {
            return Ok(
                vserv.calcularTotal(Id)
            );
        }


        [HttpPost]
        public ActionResult RealizarVenta([FromBody] Venta Venta)
        {
            return Ok(vserv.Add(Venta));
        }

        [HttpPut]
        public ActionResult Put([FromBody] Venta v)
        {
            return Ok(
                vserv.Update(v)
            );
        }
    }
}