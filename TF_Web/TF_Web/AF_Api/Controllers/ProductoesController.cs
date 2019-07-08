using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using service;
using service.Implementacion;

namespace AF_Api.Controllers
{

    public class ProductoesController : Controller
    {
        private readonly IProductoService productoS;

        public ProductoesController(ProductoService productoS)
        {
            this.productoS = productoS;
        }

        [HttpGet]
        public ActionResult GetAction()
        {
            return Ok(productoS.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(productoS.Get(id));
        }


    }
}
