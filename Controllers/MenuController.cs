using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_test.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using net_test.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using net_test.Libraries;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace erp.Controllers
{
    [Route("api/Menus")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        private readonly MenuService _menuService;
        

        public MenuController(
                                ApplicationDBContext context,
                                MenuService menuService
                            )
        {
            _context            = context;
            _menuService        = menuService;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult List()
        {
            var objReturn = new JsonReturn();

            try {

                var lstMenus = _menuService.List();

                objReturn.Result = lstMenus;

            } catch(AppException exception) {
                objReturn.Exception(exception);
            } catch(Exception exception) {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }
         
            return objReturn.build();
        }

    }
}