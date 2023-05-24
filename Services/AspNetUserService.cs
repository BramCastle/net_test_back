using net_test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace net_test.Services
{
    public class AspNetUserService
    {
        private readonly ApplicationDBContext _context;
        

        public AspNetUserService(ApplicationDBContext context) {
            _context = context;            
        }
        
        public AspNetUser FindByEmail(string argEmail) {
            AspNetUser objReturn = null;
            
            if(argEmail != null) {
                objReturn = _context.AspNetUsers
                    .Where(itemUser         => itemUser.Email == argEmail)
                    .FirstOrDefault();
            }

            return objReturn;
        }

        public AspNetUser FindById(string argId)
        {
            AspNetUser objReturn = null;

            if (argId != null)
            {
                objReturn =     _context.AspNetUsers
                                .Where(itemUser => itemUser.Id == argId)
                                .FirstOrDefault();
            }

            return objReturn;
        }

        public List<AspNetUser> ListInId(List<string> ListIds) {
            List<AspNetUser> lstRaw     = _context.AspNetUsers
                                        .Where( itemAspNetUser => ListIds.Contains(itemAspNetUser.Id))
                                        .ToList();
            return lstRaw;
        }

        public List<dynamic> List()
        {
            List<AspNetUser> lstRaw = _context.AspNetUsers.Where(item => !item.Deleted).ToList();

            List<dynamic> lstAspNetUsers = new List<dynamic>();

            lstRaw.ForEach(itemAspNetUser => {
                lstAspNetUsers.Add(new
                {
                    Id              = itemAspNetUser.Id,
                });
            });
            
            return lstAspNetUsers;
        }

    }
}