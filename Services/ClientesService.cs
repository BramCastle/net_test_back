using net_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace net_test.Services
{
    public class ClientesService
    {
        private readonly ApplicationDBContext _context;
        

        public ClientesService(ApplicationDBContext context) {
            _context = context;            
        }

        public List<dynamic> List(dynamic argCliente){
            
            int length          = (int)argCliente.length;
            int page            = (int)argCliente.page;
            string searchValue  = (string)argCliente.search;

            List<dynamic> lstRaw = _context.Clientes
                            .AsNoTracking()
                            .Where(x => x.Nombre.Contains(searchValue))
                            .OrderBy(x => x.CreatedFecha)
                            .Select(x => new {
                                Id                 = x.Id,
                                Nombre             = x.Nombre,
                                RFC                = x.RFC,
                                CreatedFecha       = x.CreatedFechaNatural,
                                UpdatedFecha       = x.UpdatedFechaNatural,
                                Deleted            = x.Deleted
                            })
                            .Take(length * page)
                            .ToList<dynamic>();

            return lstRaw;

        }

    }
}