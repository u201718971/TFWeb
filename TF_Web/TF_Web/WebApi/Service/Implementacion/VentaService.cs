using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Models;

namespace WebApi.Service.Implementacion
{
    public class VentaService : IVentaService
    {
        private AplicacionDbContext context;

        public VentaService(AplicacionDbContext context)
        {
            this.context = context;
        }

        public bool Add(Venta t)
        {
            return false;
        }

        public double calcularTotal(int id)
        {
            double total = 0;
            double iva = (double)Get(id).Iva;

            var detalle = context.ListaVenta
                .Include(m => m.Venta)
                .Where(d => d.Venta.Id == id)
                .ToList();

            foreach(ListaVenta v in detalle)
            {

                double valor = (double)v.Cantidad;
                double valor2 = (double)v.Producto.Precio;
                
                total += valor*valor2;
            }
            return total * iva;
        }

        public Venta Get(int id)
        {
            var result = new Venta();
            try  
            {
                result = context.Venta.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public IEnumerable<Venta> GetAll()
        {
            var result = new List<Venta>();
            try
            {
                result = context.Venta.ToList();
            }
            catch(System.Exception)
            {

            }
            return result;
        }

        public bool Update(Venta entity)
        {
            try
            {
                var VentaOriginal = context.Venta.Single(
                    x => x.Id == entity.Id
                );

                VentaOriginal.DiaVenta = entity.DiaVenta;

                context.Update(VentaOriginal);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }
    }
}
