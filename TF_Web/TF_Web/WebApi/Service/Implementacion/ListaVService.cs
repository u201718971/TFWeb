using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Service.Implementacion
{
    public class ListaVService : IListaVentaService
    {

        private AplicacionDbContext context;

        public ListaVService(AplicacionDbContext context)
        {
            this.context = context;
        }

        public bool Add(ListaVenta t)
        {
           try
            {
                context.ListaVenta.Add(t);
                context.SaveChanges();
            }
            catch(System.Exception)
            {
                return false;
            }
            return true;
        }

        public ListaVenta Get(int id)
        {
            var result = new ListaVenta();
            try
            {
                result = context.ListaVenta.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public IEnumerable<ListaVenta> GetAll()
        {
            var result = new List<ListaVenta>();
            try
            {
                result = context.ListaVenta.ToList();
            }
            catch (System.Exception)
            {

            }
            return result;
        }

        public bool Update(ListaVenta entity)
        {
            throw new NotImplementedException();
        }
    }
}
