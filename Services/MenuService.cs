using net_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace net_test.Services
{
    public class MenuService
    {
        private readonly ApplicationDBContext _context;
        

        public MenuService(ApplicationDBContext context) {
            _context = context;            
        }
        
        public List<dynamic> List()
        {
            List<dynamic> lstRaw = _context.Menus.Where(item => !item.Deleted)
                                            .Select(x => new{
                                                x.Id,
                                                x.Nombre,
                                                x.Icon,
                                                x.Ruta
                                            })
                                            .ToList<dynamic>();
            
            return lstRaw;
        }

    }
}