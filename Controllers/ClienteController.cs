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
    [Route("api/Clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ApplicationDBContext _context;
        private readonly ClientesService _clientesService;
        

        public ClientesController(
                                ApplicationDBContext context,
                                ClientesService clientesService
                            )
        {
            _context            = context;
            _clientesService    = clientesService;
        }

        [HttpPost]
        [Route("Index")]
        public IActionResult List([FromBody] dynamic argDataSource)
        {
            var objReturn = new JsonReturn();

            try {

                var lstClientes = _clientesService.List(argDataSource);

                objReturn.Result = lstClientes;

            } catch(AppException exception) {
                objReturn.Exception(exception);
            } catch(Exception exception) {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }
         
            return objReturn.build();
        }

    }
}