using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Models;

namespace WebApi.Service
{
    public interface IVentaService : ICrudService<Venta>
    {
        double calcularTotal(int id);
    }
}
