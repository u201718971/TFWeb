using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Service;
using WebApi.Service.Implementacion;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoesController : Controller
    {
        private readonly IProductoService productoservice;

        public ProductoesController(IProductoService productoService)
        {
            this.productoservice = productoService;
        }

        // GET: Producto
        [HttpGet]
        public ActionResult Index()
        {
            return Ok(productoservice.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult Details(int id)
        {
            return Ok(productoservice.Get(id));
        }

    }
}