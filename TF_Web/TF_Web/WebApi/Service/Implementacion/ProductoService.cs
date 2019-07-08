using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Models;

namespace WebApi.Service.Implementacion
{
    public class ProductoService : IProductoService
    {
        private AplicacionDbContext context;

        public ProductoService(AplicacionDbContext context)
        {
            this.context = context;
        }

        public bool Add(Producto t)
        {
            return false;
        }

        public Producto Get(int id)
        {
            var result = new Producto();
            try  
            {
                result = context.Producto.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();
            try
            {
                result = context.Producto.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
        }

        public bool Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
